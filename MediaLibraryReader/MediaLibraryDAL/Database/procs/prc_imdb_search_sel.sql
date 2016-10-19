IF OBJECT_ID('dbo.prc_imdb_search_sel') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_imdb_search_sel
        IF OBJECT_ID('dbo.prc_imdb_search_sel') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_imdb_search_sel >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_imdb_search_sel >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_imdb_search_sel

AS
BEGIN


SELECT
	 imdb_search_id
	,json_result
	,search_string
FROM
	dbo.t_imdb_search WITH (NOLOCK)


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_imdb_search_sel') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_imdb_search_sel >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_imdb_search_sel >>>'
    GO
