IF OBJECT_ID('dbo.prc_track_sel') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_track_sel
        IF OBJECT_ID('dbo.prc_track_sel') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_track_sel >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_track_sel >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_track_sel

AS
BEGIN


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
FROM
	dbo.t_track WITH (NOLOCK)


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_track_sel') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_track_sel >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_track_sel >>>'
    GO
