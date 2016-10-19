IF OBJECT_ID('dbo.prc_genre_type_upd') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_genre_type_upd
        IF OBJECT_ID('dbo.prc_genre_type_upd') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_genre_type_upd >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_genre_type_upd >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_genre_type_upd
(
	 @genre_type_id    int
	,@genre_type_map   varchar(32)
	,@genre_type_text  varchar(64)
	,@updated_by       varchar(30)
)
AS
UPDATE dbo.t_genre_type
SET
	 genre_type_map    = @genre_type_map
	,genre_type_text   = @genre_type_text
	,updated_by        = @updated_by
	,updated_date      = GETDATE()
WHERE
	genre_type_id = @genre_type_id

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_genre_type_upd') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_genre_type_upd >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_genre_type_upd >>>'
    GO
