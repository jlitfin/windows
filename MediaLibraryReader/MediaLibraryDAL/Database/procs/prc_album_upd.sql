IF OBJECT_ID('dbo.prc_album_upd') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_album_upd
        IF OBJECT_ID('dbo.prc_album_upd') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_album_upd >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_album_upd >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_album_upd
(
	 @album_id       int
	,@imdb_id		 varchar(64)
	,@manual_update  bit
	,@name           varchar(128)
	,@year           int
	,@updated_by     varchar(30)
)
AS
UPDATE dbo.t_album
SET
	 imdb_id		 = @imdb_id
	,manual_update   = @manual_update
	,name            = @name
	,year            = @year
	,updated_by      = @updated_by
	,updated_date    = GETDATE()
WHERE
	album_id = @album_id

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_album_upd') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_album_upd >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_album_upd >>>'
    GO
