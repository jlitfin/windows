IF OBJECT_ID('dbo.prc_thread_user_map_sel') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_thread_user_map_sel
        IF OBJECT_ID('dbo.prc_thread_user_map_sel') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_thread_user_map_sel >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_thread_user_map_sel >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_thread_user_map_sel

AS
BEGIN


SELECT
	 id
	,thread_id
	,user_name
FROM
	dbo.t_thread_user_map WITH (NOLOCK)


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_thread_user_map_sel') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_thread_user_map_sel >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_thread_user_map_sel >>>'
    GO
