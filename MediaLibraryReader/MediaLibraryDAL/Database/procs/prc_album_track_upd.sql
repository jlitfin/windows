IF OBJECT_ID('dbo.prc_album_track_upd') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_album_track_upd
        IF OBJECT_ID('dbo.prc_album_track_upd') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_album_track_upd >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_album_track_upd >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_album_track_upd
(
	 @album_id           int
	,@album_track_id     int
	,@artist_id          int
	,@genre_id           int
	,@itunes_track_id    int
	,@kind_type_id       int
	,@manual_update      bit
	,@name               varchar(128)
	,@persistent_id      varchar(64)
	,@total_time_string  varchar(32)
	,@track_number       int
	,@updated_by         varchar(30)
)
AS
UPDATE dbo.t_album_track
SET
	 album_id			 = @album_id
	,artist_id           = @artist_id
	,genre_id            = @genre_id
	,itunes_track_id     = @itunes_track_id
	,kind_type_id        = @kind_type_id
	,manual_update       = @manual_update
	,name                = @name
	,persistent_id       = @persistent_id
	,total_time_string   = @total_time_string
	,track_number        = @track_number
	,updated_by          = @updated_by
	,updated_date        = GETDATE()
WHERE
	album_track_id = @album_track_id

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_album_track_upd') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_album_track_upd >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_album_track_upd >>>'
    GO
