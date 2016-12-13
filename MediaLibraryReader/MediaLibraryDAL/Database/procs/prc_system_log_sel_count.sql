IF OBJECT_ID('dbo.prc_system_log_sel_count') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_system_log_sel_count
        IF OBJECT_ID('dbo.prc_system_log_sel_count') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_system_log_sel_count >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_system_log_sel_count >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_system_log_sel_count
(
	@count int
)
AS
BEGIN


SELECT TOP(@count)
	 activity
	,description
	,id
	,updated_by
	,updated_date
FROM
	dbo.t_system_log WITH (NOLOCK)
ORDER BY
	id DESC


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_system_log_sel_count') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_system_log_sel_count >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_system_log_sel_count >>>'
    GO
