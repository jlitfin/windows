IF OBJECT_ID('dbo.prc_audio_sel') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_audio_sel
        IF OBJECT_ID('dbo.prc_audio_sel') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_audio_sel >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_audio_sel >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_audio_sel

AS
BEGIN


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
FROM
	dbo.t_audio WITH (NOLOCK)


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_audio_sel') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_audio_sel >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_audio_sel >>>'
    GO
