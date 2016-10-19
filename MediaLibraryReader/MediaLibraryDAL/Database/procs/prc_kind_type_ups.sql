IF OBJECT_ID('dbo.prc_kind_type_ups') IS NOT NULL
    BEGIN
        DROP PROCEDURE dbo.prc_kind_type_ups
        IF OBJECT_ID('dbo.prc_kind_type_ups') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE dbo.prc_kind_type_ups >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE dbo.prc_kind_type_ups >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO
CREATE PROCEDURE dbo.prc_kind_type_ups
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
	 kind_type_id    int
	,kind_type_map   varchar(16)
	,kind_type_text  varchar(64)
)
INSERT INTO #tmp
(
	 kind_type_id
	,kind_type_map
	,kind_type_text
)
SELECT
	 kind_type_id
	,kind_type_map
	,kind_type_text
FROM OPENXML (@intDoc, 'ArrayOfKindType/KindType', 1)
WITH (
	 kind_type_id    int                 'KindTypeId'
	,kind_type_map   varchar(16)         'KindTypeMap'
	,kind_type_text  varchar(64)         'KindTypeText'
)


UPDATE t_kind_type
SET
	 kind_type_map   = tmp.kind_type_map
	,kind_type_text  = tmp.kind_type_text
	,updated_by      = @updated_by
	,updated_date    = GETDATE()
FROM
	t_kind_type tbl
	INNER JOIN #tmp tmp
		ON(tbl.kind_type_id = tmp.kind_type_id)


INSERT INTO t_kind_type
(
	 kind_type_map
	,kind_type_text
	,updated_by
)
SELECT
	 tmp.kind_type_map
	,tmp.kind_type_text
	,@updated_by
FROM
	#tmp tmp
	LEFT JOIN t_kind_type tbl
		ON(tmp.kind_type_id = tbl.kind_type_id)
WHERE
	tbl.kind_type_id IS NULL


DROP TABLE #tmp

-- dispose of the document
EXEC sp_xml_removedocument @intDoc

END
GO


SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('dbo.prc_kind_type_ups') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE dbo.prc_kind_type_ups >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE dbo.prc_kind_type_ups >>>'
    GO
