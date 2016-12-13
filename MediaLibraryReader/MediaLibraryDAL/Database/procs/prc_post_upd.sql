IF OBJECT_ID('dbo.prc_post_upd') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_post_upd
        IF OBJECT_ID('dbo.prc_post_upd') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_post_upd >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_post_upd >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_post_upd
(
	 @id           int
	,@author       varchar(256)
	,@content      nvarchar(MAX)
	,@date_string  varchar(32)
	,@thread_id    int
	,@title        varchar(256)
	,@updated_by   varchar(30)
)
AS
UPDATE dbo.t_post
SET
	 author        = @author
	,content       = @content
	,date_string   = @date_string
	,thread_id     = @thread_id
	,title         = @title
	,updated_by    = @updated_by
	,updated_date  = GETDATE()
WHERE
	id = @id

SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_post_upd') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_post_upd >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_post_upd >>>'
    GO
