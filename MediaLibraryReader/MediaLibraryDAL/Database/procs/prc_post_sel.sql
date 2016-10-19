IF OBJECT_ID('dbo.prc_post_sel') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_post_sel
        IF OBJECT_ID('dbo.prc_post_sel') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_post_sel >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_post_sel >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_post_sel

AS
BEGIN


SELECT
	 id
	,author
	,content
	,date_string
	,thread_id
	,title
FROM
	dbo.t_post WITH (NOLOCK)


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_post_sel') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_post_sel >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_post_sel >>>'
    GO
