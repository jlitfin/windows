IF OBJECT_ID('dbo.prc_kind_type_ins') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_kind_type_ins
        IF OBJECT_ID('dbo.prc_kind_type_ins') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_kind_type_ins >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_kind_type_ins >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_kind_type_ins
(
	 @kind_type_id    int
	,@kind_type_map   varchar(16)
	,@kind_type_text  varchar(64)
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_kind_type
(
	 kind_type_map
	,kind_type_text
	,updated_by
)
VALUES
(
	 @kind_type_map   
	,@kind_type_text  
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_kind_type_ins') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_kind_type_ins >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_kind_type_ins >>>'
    GO
