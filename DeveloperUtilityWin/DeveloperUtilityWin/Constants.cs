using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeveloperUtilityWin
{
    public class Constants
    {
        public const string EDS_REQUIRED = @"-- EDS Required Fields -- ";

        public const string PROC_NAME_INDICATOR = "[@@PROC_NAME@@]";

        public const string TABLE_NAME_INDICATOR = "[@@TABLE_NAME@@]";

        public const string EDS_INSERT_OPEN =
@"SET NOCOUNT ON;

	DECLARE @Processed_ID_Code INT
	
	-- Get the PROCESSED status code
	SELECT 
		@Processed_ID_Code = row_status_id
	FROM 
		eds.dbo.t_eds_row_status
	WHERE 
		row_status = 'PROCESSED'
";

        public const string EDS_SELECT_OPEN =
@"DECLARE @first_id  int
DECLARE @start_row int

IF  (@StartRowIndex > 0)
	BEGIN
		SET ROWCOUNT @StartRowIndex
		SELECT 
			@first_id = row_id 
		FROM
			[@@TABLE_NAME@@]
		WHERE
			task_execution_id = @TaskExecutionID 
		ORDER BY
			row_id
	END
ELSE
	BEGIN 
		SET @first_id = 0
	END

IF	(@RowCount IS NOT NULL) 
	BEGIN
		SET ROWCOUNT @RowCount
	END";


        public const string PROC_HEADER =
@"IF OBJECT_ID('[@@PROC_NAME@@]') IS NOT NULL
    BEGIN
        DROP PROCEDURE [@@PROC_NAME@@]
        IF OBJECT_ID('[@@PROC_NAME@@]') IS NOT NULL
            PRINT '<<< FAILED DROPPING PROCEDURE [@@PROC_NAME@@] >>>'
        ELSE
            PRINT '<<< DROPPED PROCEDURE [@@PROC_NAME@@] >>>'
    END
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO";


        public const string PROC_FOOTER =
@"SET ANSI_NULLS OFF
    GO
    SET QUOTED_IDENTIFIER OFF
    GO

    IF OBJECT_ID('[@@PROC_NAME@@]') IS NOT NULL
        PRINT '<<< CREATED PROCEDURE [@@PROC_NAME@@] >>>'
    ELSE
        PRINT '<<< FAILED CREATING PROCEDURE [@@PROC_NAME@@] >>>'
    GO";
    }
}
