IF OBJECT_ID('dbo.prc_artist_upd') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_artist_upd
        IF OBJECT_ID('dbo.prc_artist_upd') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_artist_upd >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_artist_upd >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_artist_upd
(
	 @artist_id  int
	,@base_name  varchar(128)
	,@name       varchar(128)
	,@updated_by varchar(30)
)
AS
UPDATE dbo.t_artist
SET
	 base_name   = @base_name
	,name        = @name
	,updated_by  = @updated_by
	,updated_date = GETDATE()
WHERE
	artist_id = @artist_id

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_artist_upd') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_artist_upd >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_artist_upd >>>'
    GO
