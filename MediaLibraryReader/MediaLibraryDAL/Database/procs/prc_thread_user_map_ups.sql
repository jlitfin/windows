IF OBJECT_ID('dbo.prc_thread_user_map_ups') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_thread_user_map_ups
        IF OBJECT_ID('dbo.prc_thread_user_map_ups') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_thread_user_map_ups >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_thread_user_map_ups >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_thread_user_map_ups
(
	 @xml_list   nvarchar(max)
	,@updated_by varchar(30)
)
AS
BEGIN

DECLARE @intDoc int
DECLARE @doc    nvarchar(max)
SET @doc = @xml_list
--
-- Create an internal representation of the XML document
--
EXEC sp_xml_preparedocument @intDoc OUTPUT, @doc


CREATE TABLE #tmp
(
	 id         int
	,thread_id  int
	,user_name  varchar(256)
)
INSERT INTO #tmp
(
	 id
	,thread_id
	,user_name
)
SELECT
	 id
	,thread_id
	,user_name
FROM OPENXML (@intDoc, 'ArrayOfThreadUserMap/ThreadUserMap', 1)
WITH (
	 id         int                 'Id'
	,thread_id  int                 'ThreadId'
	,user_name  varchar(256)        'UserName'
)


DELETE t_thread_user_map


INSERT INTO t_thread_user_map
(
	 thread_id
	,user_name
	,updated_by
)
SELECT
	 tmp.thread_id
	,tmp.user_name
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_thread_user_map tbl
		ON(tmp.id = tbl.id)
WHERE
	tbl.id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_thread_user_map_ups') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_thread_user_map_ups >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_thread_user_map_ups >>>'
    GO
