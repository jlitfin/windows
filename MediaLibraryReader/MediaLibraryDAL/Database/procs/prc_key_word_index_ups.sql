IF OBJECT_ID('dbo.prc_key_word_index_ups') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_key_word_index_ups
        IF OBJECT_ID('dbo.prc_key_word_index_ups') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_key_word_index_ups >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_key_word_index_ups >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_key_word_index_ups
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
	 id        int
	,key_word  varchar(256)
	,post_id   int
	,count     int
)
INSERT INTO #tmp
(
	 id
	,key_word
	,post_id
	,count
)
SELECT
	 id
	,key_word
	,post_id
	,count
FROM OPENXML (@intDoc, 'ArrayOfKeyWordIndex/KeyWordIndex', 1)
WITH (
	 id        int                 'Id'
	,key_word  varchar(256)        'KeyWord'
	,post_id   int                 'PostId'
	,count     int                 'Count'
)


DELETE t_key_word_index
FROM
	t_key_word_index i
	INNER JOIN #tmp tmp
		ON(i.post_id = tmp.post_id)
	


INSERT INTO t_key_word_index
(
	 key_word
	,post_id
	,count
	,updated_by
)
SELECT
	 tmp.key_word
	,tmp.post_id
	,tmp.count
	,@updated_by
FROM
	#tmp tmp
	INNER JOIN t_key_word kw
		ON(tmp.key_word = kw.word)
	LEFT JOIN t_key_word_index tbl
		ON(tmp.id = tbl.id)
WHERE
	tbl.id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_key_word_index_ups') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_key_word_index_ups >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_key_word_index_ups >>>'
    GO
