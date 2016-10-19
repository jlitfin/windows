IF OBJECT_ID('dbo.prc_artist_ups') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_artist_ups
        IF OBJECT_ID('dbo.prc_artist_ups') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_artist_ups >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_artist_ups >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_artist_ups
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
	 artist_id  int
	,base_name  varchar(128)
	,name       varchar(128)
)
INSERT INTO #tmp
(
	 artist_id
	,base_name
	,name
)
SELECT
	 artist_id
	,base_name
	,name
FROM OPENXML (@intDoc, 'ArrayOfArtist/Artist', 1)
WITH (
	 artist_id  int                 'ArtistId'
	,base_name  varchar(128)        'BaseName'
	,name       varchar(128)        'Name'
)


UPDATE t_artist
SET
	 base_name  = tmp.base_name
	,name       = tmp.name
	,updated_by = @updated_by
	,updated_date= GETDATE()
FROM
	t_artist tbl
	INNER JOIN #tmp tmp
		ON(tbl.artist_id = tmp.artist_id)


INSERT INTO t_artist
(
	 base_name
	,name
	,updated_by
)
SELECT
	 tmp.base_name
	,tmp.name
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_artist tbl
		ON(tmp.artist_id = tbl.artist_id)
WHERE
	tbl.artist_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_artist_ups') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_artist_ups >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_artist_ups >>>'
    GO
