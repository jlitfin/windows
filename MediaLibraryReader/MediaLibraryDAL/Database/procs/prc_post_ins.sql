IF OBJECT_ID('dbo.prc_post_ins') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_post_ins
        IF OBJECT_ID('dbo.prc_post_ins') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_post_ins >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_post_ins >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_post_ins
(
	 @id           int
	,@author       varchar(256)
	,@content      nvarchar(MAX)
	,@date_string  varchar(32)
	,@thread_id    int
	,@title        varchar(256)
	,@updated_by varchar(30)
)
AS
INSERT INTO dbo.t_post
(
	 author
	,content
	,date_string
	,thread_id
	,title
	,updated_by
)
VALUES
(
	 @author       
	,@content      
	,@date_string  
	,@thread_id    
	,@title        
	,@updated_by
)

SELECT SCOPE_IDENTITY()

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_post_ins') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_post_ins >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_post_ins >>>'
    GO
