IF OBJECT_ID('dbo.prc_post_sel_by_thread_count') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_post_sel_by_thread_count
        IF OBJECT_ID('dbo.prc_post_sel_by_thread_count') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_post_sel_by_thread_count >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_post_sel_by_thread_count >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_post_sel_by_thread_count
(
	@thread_id int
	,@count int
	,@post_id int = NULL
)
AS
BEGIN


DECLARE @pd datetime

IF @post_id IS NULL
	BEGIN
		SELECT @pd = MAX(post_date) FROM dbo.t_post WHERE thread_id = @thread_id
	END
ELSE
	BEGIN
		SELECT @pd = post_date FROM t_post WHERE id = @post_id
	END
	
SELECT TOP(@count)
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
	AND post_date <= @pd
ORDER BY
	post_date DESC


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_post_sel_by_thread_count') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_post_sel_by_thread_count >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_post_sel_by_thread_count >>>'
    GO
