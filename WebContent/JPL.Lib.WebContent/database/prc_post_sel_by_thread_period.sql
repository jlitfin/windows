IF OBJECT_ID('dbo.prc_post_sel_by_thread_period') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_post_sel_by_thread_period
        IF OBJECT_ID('dbo.prc_post_sel_by_thread_period') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_post_sel_by_thread_period >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_post_sel_by_thread_period >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_post_sel_by_thread_period
(
	@thread_id int
	,@post_period datetime
)
AS
BEGIN


SELECT
	 id
	,author
	,content
	,post_date
	,thread_id
	,title
FROM
	dbo.t_post WITH (NOLOCK)
WHERE
	thread_id = @thread_id
	AND DATEDIFF(MONTH, post_date, @post_period) = 0
ORDER BY
	post_date DESC

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_post_sel_by_thread_period') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_post_sel_by_thread_period >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_post_sel_by_thread_period >>>'
    GO
