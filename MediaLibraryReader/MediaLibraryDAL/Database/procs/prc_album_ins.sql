IF OBJECT_ID('dbo.prc_album_ins') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_album_ins
        IF OBJECT_ID('dbo.prc_album_ins') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_album_ins >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_album_ins >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_album_ins
(
	 @imdb_id		 varchar(64)
	,@manual_update  bit
	,@name           varchar(128)
	,@year           int
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_album
(
	 imdb_id
	,manual_update
	,name
	,year
	,updated_by
)
VALUES
(
	 @imdb_id
	,@manual_update  
	,@name           
	,@year           
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_album_ins') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_album_ins >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_album_ins >>>'
    GO
