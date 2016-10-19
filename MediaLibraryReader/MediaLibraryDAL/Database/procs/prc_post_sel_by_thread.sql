IF OBJECT_ID('dbo.prc_post_sel_by_thread') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_post_sel_by_thread
        IF OBJECT_ID('dbo.prc_post_sel_by_thread') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_post_sel_by_thread >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_post_sel_by_thread >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_post_sel_by_thread
(
	@thread_id int
)
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
WHERE
	thread_id = @thread_id

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_post_sel_by_thread') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_post_sel_by_thread >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_post_sel_by_thread >>>'
    GO
