IF OBJECT_ID('dbo.prc_artist_ins') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_artist_ins
        IF OBJECT_ID('dbo.prc_artist_ins') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_artist_ins >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_artist_ins >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_artist_ins
(
	 @artist_id  int
	,@base_name  varchar(128)
	,@name       varchar(128)
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_artist
(
	 base_name
	,name
	,updated_by
)
VALUES
(
	 @base_name  
	,@name       
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_artist_ins') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_artist_ins >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_artist_ins >>>'
    GO
