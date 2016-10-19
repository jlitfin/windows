IF OBJECT_ID('dbo.prc_album_track_ins') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_album_track_ins
        IF OBJECT_ID('dbo.prc_album_track_ins') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_album_track_ins >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_album_track_ins >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_album_track_ins
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
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_album_track
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
VALUES
(
	 @album_id             
	,@artist_id          
	,@genre_id           
	,@itunes_track_id    
	,@kind_type_id       
	,@manual_update      
	,@name               
	,@persistent_id      
	,@total_time_string  
	,@track_number       
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_album_track_ins') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_album_track_ins >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_album_track_ins >>>'
    GO
