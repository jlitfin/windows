IF OBJECT_ID('dbo.prc_audio_ins') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_audio_ins
        IF OBJECT_ID('dbo.prc_audio_ins') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_audio_ins >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_audio_ins >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_audio_ins
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
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_audio
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
VALUES
(
	 @album_id           
	,@artist_id          
	,@genre_id           
	,@itunes_track_id    
	,@kind_type_id       
	,@name               
	,@total_time_string  
	,@track_number       
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_audio_ins') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_audio_ins >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_audio_ins >>>'
    GO
