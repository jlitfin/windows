IF OBJECT_ID('dbo.prc_track_upd') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_track_upd
        IF OBJECT_ID('dbo.prc_track_upd') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_track_upd >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_track_upd >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_track_upd
(
	 @track_id              int
	,@name                  varchar(128)
	,@artist                varchar(128)
	,@album_artist          varchar(128)
	,@album                 varchar(128)
	,@genre                 varchar(32)
	,@kind                  varchar(32)
	,@size                  int
	,@total_time            int
	,@total_time_string     varchar(32)
	,@disc_number           int
	,@disc_count            int
	,@track_number          int
	,@track_count           int
	,@year                  int
	,@date_modified         datetime
	,@date_added            datetime
	,@bit_rate              int
	,@sample_rate           int
	,@play_count            int
	,@play_date             int
	,@play_date_utc         datetime
	,@release_date          datetime
	,@artwork_count         int
	,@persistent_id         varchar(32)
	,@track_type            varchar(32)
	,@purchased             bit
	,@location              varchar(512)
	,@file_folder_count     int
	,@library_folder_count  int
	,@updated_by            varchar(30)
)
AS
UPDATE dbo.t_track
SET
	 name                   = @name
	,artist                 = @artist
	,album_artist           = @album_artist
	,album                  = @album
	,genre                  = @genre
	,kind                   = @kind
	,size                   = @size
	,total_time             = @total_time
	,total_time_string      = @total_time_string
	,disc_number            = @disc_number
	,disc_count             = @disc_count
	,track_number           = @track_number
	,track_count            = @track_count
	,year                   = @year
	,date_modified          = @date_modified
	,date_added             = @date_added
	,bit_rate               = @bit_rate
	,sample_rate            = @sample_rate
	,play_count             = @play_count
	,play_date              = @play_date
	,play_date_utc          = @play_date_utc
	,release_date           = @release_date
	,artwork_count          = @artwork_count
	,persistent_id          = @persistent_id
	,track_type             = @track_type
	,purchased              = @purchased
	,location               = @location
	,file_folder_count      = @file_folder_count
	,library_folder_count   = @library_folder_count
	,updated_by             = @updated_by
	,updated_date           = GETDATE()
WHERE
	track_id = @track_id

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_track_upd') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_track_upd >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_track_upd >>>'
    GO
