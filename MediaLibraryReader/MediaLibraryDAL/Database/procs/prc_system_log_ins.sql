IF OBJECT_ID('dbo.prc_system_log_ins') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_system_log_ins
        IF OBJECT_ID('dbo.prc_system_log_ins') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_system_log_ins >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_system_log_ins >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_system_log_ins
(
	 @id           int
	,@activity     varchar(32)
	,@description  varchar(128)
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_system_log
(
	 activity
	,description
	,updated_by
)
VALUES
(
	 @activity     
	,@description  
	,SUSER_SNAME()
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_system_log_ins') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_system_log_ins >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_system_log_ins >>>'
    GO
