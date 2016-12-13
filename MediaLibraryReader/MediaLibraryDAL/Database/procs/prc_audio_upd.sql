IF OBJECT_ID('dbo.prc_audio_upd') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_audio_upd
        IF OBJECT_ID('dbo.prc_audio_upd') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_audio_upd >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_audio_upd >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_audio_upd
(
	 @audio_id           int
	,@album_id           int
	,@artist_id          int
	,@genre_id           int
	,@itunes_track_id    int
	,@kind_type_id       int
	,@name               varchar(128)
	,@total_time_string  varchar(32)
	,@track_number       int
	,@updated_by         varchar(30)
)
AS
UPDATE dbo.t_audio
SET
	 album_id            = @album_id
	,artist_id           = @artist_id
	,genre_id            = @genre_id
	,itunes_track_id     = @itunes_track_id
	,kind_type_id        = @kind_type_id
	,name                = @name
	,total_time_string   = @total_time_string
	,track_number        = @track_number
	,updated_by          = @updated_by
	,updated_date        = GETDATE()
WHERE
	audio_id = @audio_id

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_audio_upd') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_audio_upd >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_audio_upd >>>'
    GO
