IF OBJECT_ID('dbo.prc_album_sel') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_album_sel
        IF OBJECT_ID('dbo.prc_album_sel') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_album_sel >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_album_sel >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_album_sel

AS
BEGIN


SELECT
	 album_id
	,imdb_id
	,manual_update
	,name
	,year
FROM
	dbo.t_album WITH (NOLOCK)


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_album_sel') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_album_sel >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_album_sel >>>'
    GO
