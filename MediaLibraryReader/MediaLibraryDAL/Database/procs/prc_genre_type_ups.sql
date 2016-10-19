IF OBJECT_ID('dbo.prc_genre_type_ups') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_genre_type_ups
        IF OBJECT_ID('dbo.prc_genre_type_ups') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_genre_type_ups >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_genre_type_ups >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_genre_type_ups
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
	 genre_type_id    int
	,genre_type_map   varchar(32)
	,genre_type_text  varchar(64)
)
INSERT INTO #tmp
(
	 genre_type_id
	,genre_type_map
	,genre_type_text
)
SELECT
	 genre_type_id
	,genre_type_map
	,genre_type_text
FROM OPENXML (@intDoc, 'ArrayOfGenreType/GenreType', 1)
WITH (
	 genre_type_id    int                 'GenreTypeId'
	,genre_type_map   varchar(32)         'GenreTypeMap'
	,genre_type_text  varchar(64)         'GenreTypeText'
)


UPDATE t_genre_type
SET
	 genre_type_map   = tmp.genre_type_map
	,genre_type_text  = tmp.genre_type_text
	,updated_by       = @updated_by
	,updated_date     = GETDATE()
FROM
	t_genre_type tbl
	INNER JOIN #tmp tmp
		ON(tbl.genre_type_id = tmp.genre_type_id)


INSERT INTO t_genre_type
(
	 genre_type_map
	,genre_type_text
	,updated_by
)
SELECT
	 tmp.genre_type_map
	,tmp.genre_type_text
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_genre_type tbl
		ON(tmp.genre_type_id = tbl.genre_type_id)
WHERE
	tbl.genre_type_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_genre_type_ups') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_genre_type_ups >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_genre_type_ups >>>'
    GO
