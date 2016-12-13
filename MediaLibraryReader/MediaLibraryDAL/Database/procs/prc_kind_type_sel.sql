IF OBJECT_ID('dbo.prc_kind_type_sel') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_kind_type_sel
        IF OBJECT_ID('dbo.prc_kind_type_sel') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_kind_type_sel >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_kind_type_sel >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

CREATE PROCEDURE dbo.prc_kind_type_sel

AS
BEGIN


SELECT
	 kind_type_id
	,kind_type_map
	,kind_type_text
FROM
	dbo.t_kind_type WITH (NOLOCK)


END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_kind_type_sel') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_kind_type_sel >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_kind_type_sel >>>'
    GO
