IF OBJECT_ID('dbo.prc_artist_sel') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_artist_sel
        IF OBJECT_ID('dbo.prc_artist_sel') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_artist_sel >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_artist_sel >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_artist_sel

AS
BEGIN


SELECT
	 artist_id
	,base_name
	,name
FROM
	dbo.t_artist WITH (NOLOCK)


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_artist_sel') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_artist_sel >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_artist_sel >>>'
    GO
