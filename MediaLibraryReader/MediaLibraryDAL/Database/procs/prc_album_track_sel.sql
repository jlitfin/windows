IF OBJECT_ID('dbo.prc_album_track_sel') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_album_track_sel
        IF OBJECT_ID('dbo.prc_album_track_sel') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_album_track_sel >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_album_track_sel >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_album_track_sel

AS
BEGIN


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
FROM
	dbo.t_album_track WITH (NOLOCK)


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_album_track_sel') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_album_track_sel >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_album_track_sel >>>'
    GO
