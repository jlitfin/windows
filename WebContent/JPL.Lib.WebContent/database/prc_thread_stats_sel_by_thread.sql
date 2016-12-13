
IF OBJECT_ID('dbo.prc_thread_stats_sel_by_thread') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_thread_stats_sel_by_thread
        IF OBJECT_ID('dbo.prc_thread_stats_sel_by_thread') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_thread_stats_sel_by_thread >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_thread_stats_sel_by_thread >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_thread_stats_sel_by_thread
(
	@thread_id int
)
AS
BEGIN


select
	 p.thread_id
	,p.id
	,p.post_date
	,p.title
	,p.author
from
	t_post p
where
	thread_id = @thread_id
order by
	thread_id
	,post_date DESC

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_thread_stats_sel_by_thread') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_thread_stats_sel_by_thread >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_thread_stats_sel_by_thread >>>'
    GO
