IF OBJECT_ID('dbo.prc_key_word_ups') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_key_word_ups
        IF OBJECT_ID('dbo.prc_key_word_ups') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_key_word_ups >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_key_word_ups >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_key_word_ups
(
	 @xml_list   nvarchar(max)
	,@updated_by varchar(30)
)
AS
BEGIN

DECLARE @intDoc int
DECLARE @doc    nvarchar(max)
SET @doc = @xml_list
--
-- Create an internal representation of the XML document
--
EXEC sp_xml_preparedocument @intDoc OUTPUT, @doc


CREATE TABLE #tmp
(
	 word  varchar(256)
)
INSERT INTO #tmp
(
	 word
)
SELECT
	 word
FROM OPENXML (@intDoc, 'ArrayOfKeyWord/KeyWord', 1)
WITH (
	 word  varchar(256)        'Word'
)

INSERT INTO t_key_word
(
	word
	,updated_by
)
SELECT
	tmp.word
	,@updated_by	
FROM
	#tmp tmp
	LEFT JOIN t_key_word tbl
		ON(tmp.word = tbl.word)
WHERE
	tbl.word IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_key_word_ups') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_key_word_ups >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_key_word_ups >>>'
    GO
