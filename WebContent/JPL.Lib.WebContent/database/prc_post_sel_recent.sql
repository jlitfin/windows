IF OBJECT_ID('dbo.prc_post_sel_recent') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_post_sel_recent
        IF OBJECT_ID('dbo.prc_post_sel_recent') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_post_sel_recent >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_post_sel_recent >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_post_sel_recent

AS
BEGIN


SELECT TOP(5)
	 id
	,author
	,content
	,post_date
	,thread_id
	,title
FROM
	dbo.t_post WITH (NOLOCK)
ORDER BY
	post_date DESC


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_post_sel_recent') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_post_sel_recent >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_post_sel_recent >>>'
    GO
