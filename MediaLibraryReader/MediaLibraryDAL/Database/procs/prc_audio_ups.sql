IF OBJECT_ID('dbo.prc_audio_ups') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_audio_ups
        IF OBJECT_ID('dbo.prc_audio_ups') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_audio_ups >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_audio_ups >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_audio_ups
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
	 audio_id           int
	,album_id           int
	,artist_id          int
	,genre_id           int
	,itunes_track_id    int
	,kind_type_id       int
	,name               varchar(128)
	,total_time_string  varchar(32)
	,track_number       int
)
INSERT INTO #tmp
(
	 audio_id
	,album_id
	,artist_id
	,genre_id
	,itunes_track_id
	,kind_type_id
	,name
	,total_time_string
	,track_number
)
SELECT
	 audio_id
	,album_id
	,artist_id
	,genre_id
	,itunes_track_id
	,kind_type_id
	,name
	,total_time_string
	,track_number
FROM OPENXML (@intDoc, 'ArrayOfAudio/Audio', 1)
WITH (
	 audio_id           int                 'AudioId'
	,album_id           int                 'AlbumId'
	,artist_id          int                 'ArtistId'
	,genre_id           int                 'GenreId'
	,itunes_track_id    int                 'ItunesTrackId'
	,kind_type_id       int                 'KindTypeId'
	,name               varchar(128)        'Name'
	,total_time_string  varchar(32)         'TotalTimeString'
	,track_number       int                 'TrackNumber'
)


UPDATE t_audio
SET
	 album_id           = tmp.album_id
	,artist_id          = tmp.artist_id
	,genre_id           = tmp.genre_id
	,itunes_track_id    = tmp.itunes_track_id
	,kind_type_id       = tmp.kind_type_id
	,name               = tmp.name
	,total_time_string  = tmp.total_time_string
	,track_number       = tmp.track_number
	,updated_by         = @updated_by
	,updated_date       = GETDATE()
FROM
	t_audio tbl
	INNER JOIN #tmp tmp
		ON(tbl.audio_id = tmp.audio_id)


INSERT INTO t_audio
(
	 album_id
	,artist_id
	,genre_id
	,itunes_track_id
	,kind_type_id
	,name
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
	,tmp.name
	,tmp.total_time_string
	,tmp.track_number
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_audio tbl
		ON(tmp.audio_id = tbl.audio_id)
WHERE
	tbl.audio_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_audio_ups') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_audio_ups >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_audio_ups >>>'
    GO
