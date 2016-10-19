IF OBJECT_ID('dbo.prc_imdb_search_upd') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_imdb_search_upd
        IF OBJECT_ID('dbo.prc_imdb_search_upd') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_imdb_search_upd >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_imdb_search_upd >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_imdb_search_upd
(
	 @imdb_search_id  int
	,@json_result     varchar(max)
	,@search_string   varchar(128)
	,@updated_by      varchar(30)
)
AS
UPDATE dbo.t_imdb_search
SET
	 json_result      = @json_result
	,search_string    = @search_string
	,updated_by       = @updated_by
	,updated_date     = GETDATE()
WHERE
	imdb_search_id = @imdb_search_id

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_imdb_search_upd') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_imdb_search_upd >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_imdb_search_upd >>>'
    GO
