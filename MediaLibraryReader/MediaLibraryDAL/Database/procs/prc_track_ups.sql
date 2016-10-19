IF OBJECT_ID('dbo.prc_track_ups') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_track_ups
        IF OBJECT_ID('dbo.prc_track_ups') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_track_ups >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_track_ups >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_track_ups
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
	 track_id              int
	,name                  varchar(128)
	,artist                varchar(128)
	,album_artist          varchar(128)
	,album                 varchar(128)
	,genre                 varchar(32)
	,kind                  varchar(32)
	,size                  int
	,total_time            int
	,total_time_string     varchar(32)
	,disc_number           int
	,disc_count            int
	,track_number          int
	,track_count           int
	,year                  int
	,date_modified         datetime
	,date_added            datetime
	,bit_rate              int
	,sample_rate           int
	,play_count            int
	,play_date             int
	,play_date_utc         datetime
	,release_date          datetime
	,artwork_count         int
	,persistent_id         varchar(32)
	,track_type            varchar(32)
	,purchased             bit
	,location              varchar(512)
	,file_folder_count     int
	,library_folder_count  int
)
INSERT INTO #tmp
(
	 track_id
	,name
	,artist
	,album_artist
	,album
	,genre
	,kind
	,size
	,total_time
	,total_time_string
	,disc_number
	,disc_count
	,track_number
	,track_count
	,year
	,date_modified
	,date_added
	,bit_rate
	,sample_rate
	,play_count
	,play_date
	,play_date_utc
	,release_date
	,artwork_count
	,persistent_id
	,track_type
	,purchased
	,location
	,file_folder_count
	,library_folder_count
)
SELECT
	 track_id
	,name
	,artist
	,album_artist
	,album
	,genre
	,kind
	,size
	,total_time
	,total_time_string
	,disc_number
	,disc_count
	,track_number
	,track_count
	,year
	,date_modified
	,date_added
	,bit_rate
	,sample_rate
	,play_count
	,play_date
	,play_date_utc
	,release_date
	,artwork_count
	,persistent_id
	,track_type
	,purchased
	,location
	,file_folder_count
	,library_folder_count
FROM OPENXML (@intDoc, 'ArrayOfTrack/Track', 1)
WITH (
	 track_id              int                 'TrackId'
	,name                  varchar(128)        'Name'
	,artist                varchar(128)        'Artist'
	,album_artist          varchar(128)        'AlbumArtist'
	,album                 varchar(128)        'Album'
	,genre                 varchar(32)         'Genre'
	,kind                  varchar(32)         'Kind'
	,size                  int                 'Size'
	,total_time            int                 'TotalTime'
	,total_time_string     varchar(32)         'TotalTimeString'
	,disc_number           int                 'DiscNumber'
	,disc_count            int                 'DiscCount'
	,track_number          int                 'TrackNumber'
	,track_count           int                 'TrackCount'
	,year                  int                 'Year'
	,date_modified         datetime            'DateModified'
	,date_added            datetime            'DateAdded'
	,bit_rate              int                 'BitRate'
	,sample_rate           int                 'SampleRate'
	,play_count            int                 'PlayCount'
	,play_date             int                 'PlayDate'
	,play_date_utc         datetime            'PlayDateUtc'
	,release_date          datetime            'ReleaseDate'
	,artwork_count         int                 'ArtworkCount'
	,persistent_id         varchar(32)         'PersistentId'
	,track_type            varchar(32)         'TrackType'
	,purchased             bit                 'Purchased'
	,location              varchar(512)        'Location'
	,file_folder_count     int                 'FileFolderCount'
	,library_folder_count  int                 'LibraryFolderCount'
)


UPDATE t_track
SET
	 name                  = tmp.name
	,artist                = tmp.artist
	,album_artist          = tmp.album_artist
	,album                 = tmp.album
	,genre                 = tmp.genre
	,kind                  = tmp.kind
	,size                  = tmp.size
	,total_time            = tmp.total_time
	,total_time_string     = tmp.total_time_string
	,disc_number           = tmp.disc_number
	,disc_count            = tmp.disc_count
	,track_number          = tmp.track_number
	,track_count           = tmp.track_count
	,year                  = tmp.year
	,date_modified         = tmp.date_modified
	,date_added            = tmp.date_added
	,bit_rate              = tmp.bit_rate
	,sample_rate           = tmp.sample_rate
	,play_count            = tmp.play_count
	,play_date             = tmp.play_date
	,play_date_utc         = tmp.play_date_utc
	,release_date          = tmp.release_date
	,artwork_count         = tmp.artwork_count
	,persistent_id         = tmp.persistent_id
	,track_type            = tmp.track_type
	,purchased             = tmp.purchased
	,location              = tmp.location
	,file_folder_count     = tmp.file_folder_count
	,library_folder_count  = tmp.library_folder_count
	,updated_by            = @updated_by
	,updated_date          = GETDATE()
FROM
	t_track tbl
	INNER JOIN #tmp tmp
		ON(tbl.track_id = tmp.track_id)


INSERT INTO t_track
(
	 track_id
	,name
	,artist
	,album_artist
	,album
	,genre
	,kind
	,size
	,total_time
	,total_time_string
	,disc_number
	,disc_count
	,track_number
	,track_count
	,year
	,date_modified
	,date_added
	,bit_rate
	,sample_rate
	,play_count
	,play_date
	,play_date_utc
	,release_date
	,artwork_count
	,persistent_id
	,track_type
	,purchased
	,location
	,file_folder_count
	,library_folder_count
	,updated_by
)
SELECT
	 tmp.track_id
	,tmp.name
	,tmp.artist
	,tmp.album_artist
	,tmp.album
	,tmp.genre
	,tmp.kind
	,tmp.size
	,tmp.total_time
	,tmp.total_time_string
	,tmp.disc_number
	,tmp.disc_count
	,tmp.track_number
	,tmp.track_count
	,tmp.year
	,tmp.date_modified
	,tmp.date_added
	,tmp.bit_rate
	,tmp.sample_rate
	,tmp.play_count
	,tmp.play_date
	,tmp.play_date_utc
	,tmp.release_date
	,tmp.artwork_count
	,tmp.persistent_id
	,tmp.track_type
	,tmp.purchased
	,tmp.location
	,tmp.file_folder_count
	,tmp.library_folder_count
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_track tbl
		ON(tmp.track_id = tbl.track_id)
WHERE
	tbl.track_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_track_ups') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_track_ups >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_track_ups >>>'
    GO
