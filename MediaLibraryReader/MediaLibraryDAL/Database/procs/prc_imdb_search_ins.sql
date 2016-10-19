IF OBJECT_ID('dbo.prc_imdb_search_ins') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_imdb_search_ins
        IF OBJECT_ID('dbo.prc_imdb_search_ins') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_imdb_search_ins >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_imdb_search_ins >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_imdb_search_ins
(
	 @imdb_search_id  int
	,@json_result     varchar(max)
	,@search_string   varchar(128)
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_imdb_search
(
	 json_result
	,search_string
	,updated_by
)
VALUES
(
	 @json_result     
	,@search_string   
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_imdb_search_ins') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_imdb_search_ins >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_imdb_search_ins >>>'
    GO
