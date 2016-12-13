IF OBJECT_ID('dbo.prc_album_track_ups') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_album_track_ups
        IF OBJECT_ID('dbo.prc_album_track_ups') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_album_track_ups >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_album_track_ups >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_album_track_ups
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
	 album_id           int
	,album_track_id     int
	,artist_id          int
	,genre_id           int
	,itunes_track_id    int
	,kind_type_id       int
	,manual_update      bit
	,name               varchar(128)
	,persistent_id      varchar(64)
	,total_time_string  varchar(32)
	,track_number       int
)
INSERT INTO #tmp
(
	 album_id
	,album_track_id
	,artist_id
	,genre_id
	,itunes_track_id
	,kind_type_id
	,manual_update
	,name
	,persistent_id
	,total_time_string
	,track_number
)
SELECT
	 album_id
	,album_track_id
	,artist_id
	,genre_id
	,itunes_track_id
	,kind_type_id
	,manual_update
	,name
	,persistent_id
	,total_time_string
	,track_number
FROM OPENXML (@intDoc, 'ArrayOfAlbumTrack/AlbumTrack', 1)
WITH (
	 album_id           int                 'AlbumId'
	,album_track_id     int                 'AlbumTrackId'
	,artist_id          int                 'ArtistId'
	,genre_id           int                 'GenreId'
	,itunes_track_id    int                 'ItunesTrackId'
	,kind_type_id       int                 'KindTypeId'
	,manual_update      bit                 'ManualUpdate'
	,name               varchar(128)        'Name'
	,persistent_id      varchar(64)         'PersistentId'
	,total_time_string  varchar(32)         'TotalTimeString'
	,track_number       int                 'TrackNumber'
)

UPDATE #tmp
SET
	album_track_id = tbl.album_track_id
FROM
	#tmp tmp
	INNER JOIN t_album_track tbl
		ON(tmp.persistent_id = tbl.persistent_id)

UPDATE t_album_track
SET
	 album_id           = tmp.album_id
	,artist_id          = tmp.artist_id
	,genre_id           = tmp.genre_id
	,itunes_track_id    = tmp.itunes_track_id
	,kind_type_id       = tmp.kind_type_id
	,manual_update      = tmp.manual_update
	,name               = tmp.name
	,persistent_id      = tmp.persistent_id
	,total_time_string  = tmp.total_time_string
	,track_number       = tmp.track_number
	,updated_by         = @updated_by
	,updated_date       = GETDATE()
FROM
	t_album_track tbl
	INNER JOIN #tmp tmp
		ON(tbl.album_track_id = tmp.album_track_id)
WHERE
	tbl.manual_update = 0


INSERT INTO t_album_track
(
	 album_id
	,artist_id
	,genre_id
	,itunes_track_id
	,kind_type_id
	,manual_update
	,name
	,persistent_id
	,total_time_string
	,track_number
	,updated_by
)
SELECT
	 tmp.album_id
	,tmp.artist_id
	,tmp.genre_id
	,tmp.itunes_track_id
	,tmp.kind_type_id
	,tmp.manual_update
	,tmp.name
	,tmp.persistent_id
	,tmp.total_time_string
	,tmp.track_number
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_album_track tbl
		ON(tmp.album_track_id = tbl.album_track_id)
WHERE
	tbl.album_track_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_album_track_ups') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_album_track_ups >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_album_track_ups >>>'
    GO
