IF OBJECT_ID('dbo.prc_album_ups') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_album_ups
        IF OBJECT_ID('dbo.prc_album_ups') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_album_ups >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_album_ups >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_album_ups
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
	 album_id       int
	,imdb_id        varchar(64)
	,manual_update  bit
	,name           varchar(128)
	,year           int
)
INSERT INTO #tmp
(
	 album_id
	,imdb_id
	,manual_update
	,name
	,year
)
SELECT
	 album_id
	,imdb_id
	,manual_update
	,name
	,year
FROM OPENXML (@intDoc, 'ArrayOfAlbum/Album', 1)
WITH (
	 album_id       int                 'AlbumId'
	,imdb_id		varchar(64)         'ImdbId'
	,manual_update  bit                 'ManualUpdate'
	,name           varchar(128)        'Name'
	,year           int                 'Year'
)


UPDATE t_album
SET
	 imdb_id	    = tmp.imdb_id
	,manual_update  = tmp.manual_update
	,name           = tmp.name
	,year           = tmp.year
	,updated_by     = @updated_by
	,updated_date   = GETDATE()
FROM
	t_album tbl
	INNER JOIN #tmp tmp
		ON(tbl.album_id = tmp.album_id)
WHERE
	tbl.manual_update = 0


INSERT INTO t_album
(
	 imdb_id
	,manual_update
	,name
	,year
	,updated_by
)
SELECT
	 tmp.imdb_id
	,tmp.manual_update
	,tmp.name
	,tmp.year
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_album tbl
		ON(tmp.album_id = tbl.album_id)
WHERE
	tbl.album_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_album_ups') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_album_ups >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_album_ups >>>'
    GO
