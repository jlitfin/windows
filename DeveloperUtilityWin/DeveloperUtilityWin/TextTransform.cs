using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

using System.Data;
using System.Data.Common;

namespace DeveloperUtilityWin
{
    public class TextTransform
    {
        public string __primaryKey = "PrimaryKey";
        public string __lookupKey = string.Empty;

        public string CamelCase(string source)
        {
            return CamelCase(source, "_");
        }

        public string CamelCase(string source, string delim)
        {
            StringBuilder sb = new StringBuilder();
            string copy = source;
            if (source != null && source.Length > 0)
            {
                int index = 0;

                //
                // capitalize the first character
                //
                sb.Append(source[0].ToString().ToUpper());
                source = source.Substring(1, source.Length - 1);

                //
                // process remainder
                //
                while (index >= 0)
                {
                    index = source.IndexOf(delim, 0, source.Length);

                    //
                    // add part up to delim
                    //
                    if (index != -1)
                    {
                        sb.Append(source.Substring(0, index));

                        //
                        // capitalize next letter
                        //
                        sb.Append(source[index + 1].ToString().ToUpper());

                        //
                        // truncate to new length
                        //
                        source = source.Substring(index + 2, source.Length - (index + 2));
                    }
                }

                //
                // add final part
                //
                sb.Append(source);
            }

            return sb.ToString();
        }

        public string CamelCasePrivate(string source)
        {
            return CamelCasePrivate(source, "_");
        }

        public string CamelCasePrivate(string source, string delim)
        {
            StringBuilder sb = new StringBuilder();
            string copy = source;
            if (source != null && source.Length > 0)
            {
                int index = 0;

                //
                // capture the first character
                //
                sb.Append("__");
                sb.Append(source[0].ToString().ToLower());
                source = source.Substring(1, source.Length - 1);

                //
                // process remainder
                //
                while (index >= 0)
                {
                    index = source.IndexOf(delim, 0, source.Length);

                    //
                    // add part up to delim
                    //
                    if (index != -1)
                    {
                        sb.Append(source.Substring(0, index));

                        //
                        // capitalize next letter
                        //
                        sb.Append(source[index + 1].ToString().ToUpper());

                        //
                        // truncate to new length
                        //
                        source = source.Substring(index + 2, source.Length - (index + 2));
                    }
                }

                //
                // add final part
                //
                sb.Append(source);
            }

            return sb.ToString();
        }

        public string SQLCase(string source)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < source.Length; ++i)
            {
                string current = source[i].ToString();
                string lower = source[i].ToString().ToLower();
                if (!current.Equals(lower))
                {
                    if (i != 0)
                    {
                        sb.Append("_");
                    }
                }
                sb.Append(lower);
            }


            return sb.ToString();
        }

        public string ConvertClassTypeToDbTypeSpecifier(string classType)
        {
            if (classType.ToLower().StartsWith("string"))
            {
                return "DbType.String";
            }

            if (classType.ToLower().StartsWith("datetime"))
            {
                return "DbType.DateTime";
            }

            if (classType.ToLower().StartsWith("date"))
            {
                return "DbType.Date";
            }

            if (classType.ToLower().StartsWith("decimal"))
            {
                return "DbType.Decimal";
            }

            if (classType.ToLower().StartsWith("int"))
            {
                return "DbType.Int32";
            }

            if (classType.ToLower().StartsWith("bool"))
            {
                return "DbType.Boolean";
            }

            if (classType.ToLower().StartsWith("char"))
            {
                return "DbType.String";
            }

            if (classType.ToLower().StartsWith("float"))
            {
                return "DbType.Double";
            }

            if (classType.ToLower().StartsWith("double"))
            {
                return "DbType.Double";
            }

            return "DbType.UNKNOWN";
        }

        public string ConvertDBTypeToIfNull(string dbType)
        {
            if (dbType.ToLower().StartsWith("varchar"))
            {
                return "string.Empty";
            }

            if (dbType.ToLower().StartsWith("nvarchar"))
            {
                return "string.Empty";
            }

            if (dbType.ToLower().StartsWith("datetime"))
            {
                return "DateTime.MinValue";
            }

            if (dbType.ToLower().StartsWith("date"))
            {
                return "DateTime.MinValue";
            }

            if (dbType.ToLower().StartsWith("decimal"))
            {
                return "0M";
            }

            if (dbType.ToLower().StartsWith("int"))
            {
                return "0";
            }

            if (dbType.ToLower().StartsWith("bit"))
            {
                return "false";
            }


            if (dbType.ToLower().StartsWith("char"))
            {
                return "string.Empty";
            }

            if (dbType.ToLower().StartsWith("float"))
            {
                return "0.0";
            }

            return "unknown null type";
        }

        public string ConvertDbTypeToConvertMethod(string classType)
        {
            if (classType.ToLower().StartsWith("string"))
            {
                return ".ToString";
            }

            if (classType.ToLower().StartsWith("datetime"))
            {
                return ".ToDateTime";
            }

            if (classType.ToLower().StartsWith("date"))
            {
                return ".ToDateTime";
            }

            if (classType.ToLower().StartsWith("decimal"))
            {
                return ".ToDecimal";
            }

            if (classType.ToLower().StartsWith("int"))
            {
                return ".ToInt32";
            }

            if (classType.ToLower().StartsWith("bool"))
            {
                return ".ToBoolean";
            }

            if (classType.ToLower().StartsWith("char"))
            {
                return ".ToString";
            }

            if (classType.ToLower().StartsWith("float"))
            {
                return ".ToDouble";
            }

            if (classType.ToLower().StartsWith("double"))
            {
                return ".ToDouble";
            }

            return ".UNKNOWN";
        }

        public string ConvertDBTypeToClassType(string dbType)
        {
            if (dbType.ToLower().StartsWith("varchar"))
            {
                return "string";
            }

            if (dbType.ToLower().StartsWith("nvarchar"))
            {
                return "string";
            }

            if (dbType.ToLower().StartsWith("datetime"))
            {
                return "DateTime";
            }

            if (dbType.ToLower().StartsWith("date"))
            {
                return "DateTime";
            }

            if (dbType.ToLower().StartsWith("decimal"))
            {
                return "decimal";
            }

            if (dbType.ToLower().StartsWith("int"))
            {
                return "int";
            }

            if (dbType.ToLower().StartsWith("bit"))
            {
                return "bool";
            }

            if (dbType.ToLower().StartsWith("char"))
            {
                return "string";
            }

            if (dbType.ToLower().StartsWith("float"))
            {
                return "double";
            }

            return "unknown data type";
        }

        public string GetEDSSelectAsFromTable(List<string> tableLines, string tableName, string procName)
        {
            string line = string.Empty;
            StringBuilder field = null;
            List<string> objectLines = new List<string>();
            List<string> sourceFields = new List<string>();
            int maxLength = 0;

            foreach (string str in tableLines)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma
                    //
                    int space = str.IndexOf(" ", 0);
                    string temp = str.Substring(1, space).Trim();

                    sourceFields.Add(temp);
                    if (temp.Length > maxLength)
                    {
                        maxLength = temp.Length;
                    }
                }
            }

            string name = procName + "_sel";
            objectLines.Add(Constants.PROC_HEADER.Replace(Constants.PROC_NAME_INDICATOR, name));
            objectLines.Add("");
            objectLines.Add("CREATE PROCEDURE " + name);
            objectLines.Add("(");
            objectLines.Add("\t@TaskExecutionID bigint");
            objectLines.Add("\t,@StartRowIndex int = 0");
            objectLines.Add("\t,@RowCount int = null");
            objectLines.Add(")");
            objectLines.Add("AS");
            objectLines.Add("BEGIN");
            objectLines.Add("");
            objectLines.Add("");
            objectLines.Add(Constants.EDS_SELECT_OPEN.Replace(Constants.TABLE_NAME_INDICATOR, tableName));
            objectLines.Add("");
            objectLines.Add("SELECT");
            objectLines.Add(Constants.EDS_REQUIRED);
            objectLines.Add("\t " + "row_id".PadRight(maxLength + 2, ' ') + " AS RowID");
            objectLines.Add("\t," + "task_execution_id".PadRight(maxLength + 2, ' ') + " AS TaskExecutionID");
            objectLines.Add("\t," + "row_status_id".PadRight(maxLength + 2, ' ') + " AS RowStatus");
            objectLines.Add("\t," + "update_date".PadRight(maxLength + 2, ' ') + " AS UpdateDate");
            objectLines.Add("\t," + "updated_by".PadRight(maxLength + 2, ' ') + " AS UpdatedBy");
            objectLines.Add(Constants.EDS_REQUIRED);

            foreach (string str in sourceFields)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    field = new StringBuilder();
                    field.Append("\t,");
                    field.Append(str.PadRight(maxLength + 2, ' '));
                    field.Append(" AS ");
                    field.Append(CamelCase(str, "_"));

                    objectLines.Add(field.ToString());
                }
            }
            objectLines.Add(Constants.EDS_REQUIRED);
            objectLines.Add("\t," + "recd_seq".PadRight(maxLength + 2, ' ') + " AS RecordSeq");
            objectLines.Add(Constants.EDS_REQUIRED);

            objectLines.Add("FROM");
            objectLines.Add("\t" + tableName);
            objectLines.Add("WHERE");
            objectLines.Add("\t task_execution_id = @TaskExecutionID");
            objectLines.Add("\t\tAND row_id >= @first_id");
            objectLines.Add("ORDER BY");
            objectLines.Add("\trow_id");
            objectLines.Add("");
            objectLines.Add("SET ROWCOUNT 0");
            objectLines.Add("");
            objectLines.Add("");
            objectLines.Add("END");
            objectLines.Add("GO");
            objectLines.Add("");
            objectLines.Add("");
            objectLines.Add(Constants.PROC_FOOTER.Replace(Constants.PROC_NAME_INDICATOR, name));


            StringBuilder outString = new StringBuilder();
            foreach (string str in objectLines)
            {
                outString.AppendLine(str);
            }

            return outString.ToString();

        }

        public string GetInsertProcFromTable(List<string> tableLines, string tableName, string procName)
        {
            int maxLength = 0;
            //
            // get table name without the leading "t_" to compare in check for primary
            // key.
            //
            string tablePrimaryKey = SQLCase(__primaryKey);
            //
            // get the max length for formatting
            //
            foreach (string str in tableLines)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma
                    //
                    int space = str.IndexOf(" ", 0);
                    string temp = str.Substring(1, space).Trim();

                    if (temp.Length > maxLength)
                    {
                        maxLength = temp.Length;
                    }
                }
            }

            StringBuilder proc = new StringBuilder();
            //
            // proc header and declaration
            //
            string name = procName + "_ins";
            string header = Constants.PROC_HEADER.Replace(Constants.PROC_NAME_INDICATOR, name);
            proc.AppendLine(header);
            proc.AppendLine("CREATE PROCEDURE " + name);
            proc.AppendLine("(");

            bool firstCol = true;
            foreach (string str in tableLines)
            {
                StringBuilder line = new StringBuilder();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();
                    string dbType = str.Substring(space, str.Length - space).Trim();

                    //
                    // for the procedure components, we need
                    // 1.  Parms
                    // 2.  Insert into table fields
                    // 3.  Parms as Values
                    //
                    // 1. Parms
                    //
                    if (firstCol)
                    {
                        line.Append("\t @");
                        firstCol = false;
                    }
                    else
                    {
                        line.Append("\t,@");
                    }
                    
                    line.Append(fieldName.PadRight(maxLength + 2, ' '));
                    line.Append(dbType);

                    proc.AppendLine(line.ToString());
                }
            }
            proc.AppendLine("\t,@updated_by varchar(30)");
            proc.AppendLine(")");
            proc.AppendLine("AS");

            proc.AppendLine("INSERT INTO dbo." + tableName);
            proc.AppendLine("(");
            //
            // 2. Insert into table fields
            //
            firstCol = true;
            foreach (string str in tableLines)
            {
                StringBuilder line = new StringBuilder();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();

                    if (!fieldName.Equals(tablePrimaryKey))
                    {

                        if (firstCol)
                        {
                            line.Append("\t ");
                            firstCol = false;
                        }
                        else
                        {
                            line.Append("\t,");
                        }

                        line.Append(fieldName);

                        proc.AppendLine(line.ToString());
                    }

                }
            }
            proc.AppendLine("\t,updated_by");
            proc.AppendLine(")");
            proc.AppendLine("VALUES");
            proc.AppendLine("(");

            //
            // 3. Parms as values
            //
            firstCol = true;
            foreach (string str in tableLines)
            {
                StringBuilder line = new StringBuilder();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();

                    if (!fieldName.Equals(tablePrimaryKey))
                    {
                        if (firstCol)
                        {
                            line.Append("\t @");
                            firstCol = false;
                        }
                        else
                        {
                            line.Append("\t,@");
                        }

                        line.Append(fieldName.PadRight(maxLength + 2, ' '));

                        proc.AppendLine(line.ToString());
                    }

                }
            }
            proc.AppendLine("\t,@updated_by");
            proc.AppendLine(")");
            proc.AppendLine();
            proc.AppendLine("SELECT SCOPE_IDENTITY()");
            proc.AppendLine();
            proc.AppendLine(Constants.PROC_FOOTER.Replace(Constants.PROC_NAME_INDICATOR, name));

            return proc.ToString();
        }

        public string GetSelectFromTable(List<string> tableLines, string tableName, string procName)
        {
            string line = string.Empty;
            StringBuilder field = null;
            List<string> objectLines = new List<string>();
            List<string> sourceFields = new List<string>();
            int maxLength = 0;

            foreach (string str in tableLines)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma
                    //
                    int space = str.IndexOf(" ", 0);
                    string temp = str.Substring(1, space).Trim();

                    sourceFields.Add(temp);
                    if (temp.Length > maxLength)
                    {
                        maxLength = temp.Length;
                    }
                }
            }

            string name = procName + "_sel";
            objectLines.Add(Constants.PROC_HEADER.Replace(Constants.PROC_NAME_INDICATOR, name));
            objectLines.Add("");
            objectLines.Add("CREATE PROCEDURE " + name);
            objectLines.Add("");
            objectLines.Add("AS");
            objectLines.Add("BEGIN");
            objectLines.Add("");
            objectLines.Add("");
            objectLines.Add("SELECT");

            bool firstCol = true;
            foreach (string str in sourceFields)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    field = new StringBuilder();
                    if (firstCol)
                    {
                        field.Append("\t ");
                        firstCol = false;
                    }
                    else
                    {
                        field.Append("\t,");
                    }

                    field.Append(str);

                    objectLines.Add(field.ToString());
                }
            }

            objectLines.Add("FROM");
            objectLines.Add("\t" + "dbo." + tableName + " WITH (NOLOCK)");
            objectLines.Add("");
            objectLines.Add("");
            objectLines.Add("END");
            objectLines.Add("GO");
            objectLines.Add("");
            objectLines.Add("");
            objectLines.Add(Constants.PROC_FOOTER.Replace(Constants.PROC_NAME_INDICATOR, name));


            StringBuilder outString = new StringBuilder();
            foreach (string str in objectLines)
            {
                outString.AppendLine(str);
            }

            return outString.ToString();

        }

        public string GetUpdateFromTable(List<string> tableLines, string tableName, string procName)
        {
            int maxLength = 0;
            //
            // get the max length for formatting
            //
            foreach (string str in tableLines)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma
                    //
                    int space = str.IndexOf(" ", 0);
                    string temp = str.Substring(1, space).Trim();

                    if (temp.Length > maxLength)
                    {
                        maxLength = temp.Length;
                    }
                }
            }

            StringBuilder proc = new StringBuilder();
            StringBuilder line = new StringBuilder();
            //
            // proc header and declaration
            //
            string name = procName + "_upd";
            string header = Constants.PROC_HEADER.Replace(Constants.PROC_NAME_INDICATOR, name);
            proc.AppendLine(header);
            proc.AppendLine("CREATE PROCEDURE " + name);
            proc.AppendLine("(");

            bool firstCol = true;
            foreach (string str in tableLines)
            {
                line.Clear();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();
                    string dbType = str.Substring(space, str.Length - space).Trim();

                    //
                    // for the procedure components, we need
                    // 1.  Parms
                    // 2.  Update table fields
                    // 3.  Parms as Values
                    //
                    // 1. Parms
                    //
                    if (firstCol)
                    {
                        line.Append("\t @");
                        firstCol = false;
                    }
                    else
                    {
                        line.Append("\t,@");
                    }

                    line.Append(fieldName.PadRight(maxLength + 2, ' '));
                    line.Append(dbType);

                    proc.AppendLine(line.ToString());

                }
            }
            line.Clear();
            line.Append("\t,@");
            line.Append("updated_by".PadRight(maxLength + 2, ' '));
            line.Append("varchar(30)");
            proc.AppendLine(line.ToString());
            proc.AppendLine(")");
            proc.AppendLine("AS");

            proc.AppendLine("UPDATE dbo." + tableName);
            proc.AppendLine("SET");
            //
            // 2. update table fields
            //
            string primaryKey = SQLCase(__primaryKey);
            firstCol = true;
            foreach (string str in tableLines)
            {
                line.Clear();

                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();

                    if (!fieldName.Equals(primaryKey))
                    {
                        if (firstCol)
                        {
                            line.Append("\t ");
                            firstCol = false;
                        }
                        else
                        {
                            line.Append("\t,");
                        }

                        line.Append(fieldName.PadRight(maxLength + 2, ' '));
                        line.Append(" = @");
                        line.Append(fieldName);
                        proc.AppendLine(line.ToString());
                    }
                }

            }
            line.Clear();
            line.Append("\t,");
            line.Append("updated_by".PadRight(maxLength + 2, ' '));
            line.Append(" = @updated_by");
            proc.AppendLine(line.ToString());
            line.Clear();
            line.Append("\t,");
            line.Append("updated_date".PadRight(maxLength + 2, ' '));
            line.Append(" = GETDATE()");
            proc.AppendLine(line.ToString());
            proc.AppendLine("WHERE");
            line.Clear();
            line.Append("\t");
            line.Append(primaryKey);
            line.Append(" = @");
            line.Append(primaryKey);
            proc.AppendLine(line.ToString());
            proc.AppendLine();
            proc.AppendLine(Constants.PROC_FOOTER.Replace(Constants.PROC_NAME_INDICATOR, name));

            return proc.ToString();

        }

        public string GetUpsertProcFromTable(List<string> tableLines, string tableName, string className, string procName)
        {
            int maxLength = 0;
            //
            // get the max length for formatting
            //
            foreach (string str in tableLines)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma
                    //
                    int space = str.IndexOf(" ", 0);
                    string temp = str.Substring(1, space).Trim();

                    if (temp.Length > maxLength)
                    {
                        maxLength = temp.Length;
                    }
                }
            }

            StringBuilder proc = new StringBuilder();
            StringBuilder line = new StringBuilder();
            //
            // proc header and declaration
            //
            string name = procName + "_ups";
            string header = Constants.PROC_HEADER.Replace(Constants.PROC_NAME_INDICATOR, name);
            proc.AppendLine(header);
            proc.AppendLine("CREATE PROCEDURE " + name);
            proc.AppendLine("(");

            bool firstCol = true;
            proc.AppendLine("\t @xml_list   nvarchar(max)");
            proc.AppendLine("\t,@updated_by varchar(30)");
            proc.AppendLine(")");
            proc.AppendLine("AS");
            proc.AppendLine("BEGIN");
            proc.AppendLine();
            proc.AppendLine("DECLARE @intDoc int");
            proc.AppendLine("DECLARE @doc    nvarchar(max)");
            proc.AppendLine("SET @doc = @xml_list");
            proc.AppendLine("--");
            proc.AppendLine("-- Create an internal representation of the XML document");
            proc.AppendLine("--");
            proc.AppendLine("EXEC sp_xml_preparedocument @intDoc OUTPUT, @doc");
            proc.AppendLine();
            proc.AppendLine();
            proc.AppendLine("CREATE TABLE #tmp");
            proc.AppendLine("(");
            //
            // 1. Create temp table
            //
            firstCol = true;
            foreach (string str in tableLines)
            {
                line.Clear();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();
                    string dbType = str.Substring(space, str.Length - space).Trim();

                    if (firstCol)
                    {
                        line.Append("\t ");
                        firstCol = false;
                    }
                    else
                    {
                        line.Append("\t,");
                    }

                    line.Append(fieldName.PadRight(maxLength + 2, ' '));
                    line.Append(dbType);
                    proc.AppendLine(line.ToString());

                }
            }
            proc.AppendLine(")");

            proc.AppendLine("INSERT INTO #tmp");
            proc.AppendLine("(");
            //
            // 2. Insert into #tmp
            //
            firstCol = true;
            foreach (string str in tableLines)
            {
                line.Clear();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();

                    if (firstCol)
                    {
                        line.Append("\t ");
                        firstCol = false;
                    }
                    else
                    {
                        line.Append("\t,");
                    }

                    line.Append(fieldName);
                    proc.AppendLine(line.ToString());

                }
            }
            proc.AppendLine(")");
            proc.AppendLine("SELECT");

            firstCol = true;
            foreach (string str in tableLines)
            {
                line.Clear();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();

                    if (firstCol)
                    {
                        line.Append("\t ");
                        firstCol = false;
                    }
                    else
                    {
                        line.Append("\t,");
                    }

                    line.Append(fieldName);
                    proc.AppendLine(line.ToString());

                }
            }
            line.Clear();
            line.Append("FROM OPENXML (@intDoc, 'ArrayOf");
            line.Append(className);
            line.Append("/");
            line.Append(className);
            line.Append("', 1)");
            proc.AppendLine(line.ToString());
            proc.AppendLine("WITH (");

            firstCol = true;
            foreach (string str in tableLines)
            {
                line.Clear();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();
                    string dbType = str.Substring(space, str.Length - space).Trim();

                    if (firstCol)
                    {
                        line.Append("\t ");
                        firstCol = false;
                    }
                    else
                    {
                        line.Append("\t,");
                    }

                    line.Append(fieldName.PadRight(maxLength + 2, ' '));
                    line.Append(dbType.PadRight(20, ' '));
                    line.Append("'");
                    line.Append(CamelCase(fieldName, "_"));
                    line.Append("'");
                    proc.AppendLine(line.ToString());

                }
            }
            proc.AppendLine(")");
            proc.AppendLine();
            proc.AppendLine();

            line.Clear();
            line.Append("UPDATE ");
            line.Append(tableName);
            proc.AppendLine(line.ToString());
            proc.AppendLine("SET");

            firstCol = true;
            foreach (string str in tableLines)
            {
                line.Clear();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();
                    string primaryKey = SQLCase(__primaryKey);
                    if (!fieldName.Equals(primaryKey))
                    {
                        if (firstCol)
                        {
                            line.Append("\t ");
                            firstCol = false;
                        }
                        else
                        {
                            line.Append("\t,");
                        }

                        line.Append(fieldName.PadRight(maxLength + 2, ' '));
                        line.Append("= tmp.");
                        line.Append(fieldName);
                        proc.AppendLine(line.ToString());
                    }

                }
            }
            line.Clear();
            line.Append("\t,");
            line.Append("updated_by".PadRight(maxLength + 2));
            line.Append("= @updated_by");
            proc.AppendLine(line.ToString());
            line.Clear();
            line.Append("\t,");
            line.Append("updated_date".PadRight(maxLength + 2));
            line.Append("= GETDATE()");
            proc.AppendLine(line.ToString());
            proc.AppendLine("FROM");
            line.Clear();
            line.Append("\t");
            line.Append(tableName);
            line.Append(" tbl");
            proc.AppendLine(line.ToString());
            proc.AppendLine("\tINNER JOIN #tmp tmp");

            line.Clear();
            line.Append("\t\tON(tbl.");
            line.Append(SQLCase(__primaryKey));
            line.Append(" = tmp.");
            line.Append(SQLCase(__primaryKey));
            line.Append(")");
            proc.AppendLine(line.ToString());

            proc.AppendLine();
            proc.AppendLine();
            line.Clear();
            line.Append("INSERT INTO ");
            line.Append(tableName);
            proc.AppendLine(line.ToString());
            proc.AppendLine("(");

            firstCol = true;
            foreach (string str in tableLines)
            {
                line.Clear();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();
                    string primaryKey = SQLCase(__primaryKey);
                    if (!fieldName.Equals(primaryKey))
                    {
                        if (firstCol)
                        {
                            line.Append("\t ");
                            firstCol = false;
                        }
                        else
                        {
                            line.Append("\t,");
                        }

                        line.Append(fieldName);
                        proc.AppendLine(line.ToString());
                    }

                }
            }
            proc.AppendLine("\t,updated_by");
            proc.AppendLine(")");
            proc.AppendLine("SELECT");

            firstCol = true;
            foreach (string str in tableLines)
            {
                line.Clear();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();
                    string primaryKey = SQLCase(__primaryKey);
                    if (!fieldName.Equals(primaryKey))
                    {
                        if (firstCol)
                        {
                            line.Append("\t ");
                            firstCol = false;
                        }
                        else
                        {
                            line.Append("\t,");
                        }
                        line.Append("tmp.");
                        line.Append(fieldName);
                        proc.AppendLine(line.ToString());
                    }

                }
            }
            proc.AppendLine("\t,@updated_by");
            proc.AppendLine("FROM");
            proc.AppendLine("\t#tmp tmp");
            line.Clear();
            line.Append("\tLEFT JOIN ");
            line.Append(tableName);
            line.Append(" tbl");
            proc.AppendLine(line.ToString());

            line.Clear();
            line.Append("\t\tON(tmp.");
            line.Append(SQLCase(__primaryKey));
            line.Append(" = tbl.");
            line.Append(SQLCase(__primaryKey));
            line.Append(")");
            proc.AppendLine(line.ToString());

            proc.AppendLine("WHERE");
            line.Clear();
            line.Append("\ttbl.");
            line.Append(SQLCase(__primaryKey));
            line.Append(" IS NULL");
            proc.AppendLine(line.ToString());

            proc.AppendLine();
            proc.AppendLine();

            proc.AppendLine("DROP TABLE #tmp");
            proc.AppendLine();
            proc.AppendLine("-- dispose of the document");
            proc.AppendLine("EXEC sp_xml_removedocument @intDoc");
            proc.AppendLine();
            proc.AppendLine("END");
            proc.AppendLine("GO");
            proc.AppendLine();
            proc.AppendLine();
            proc.AppendLine(Constants.PROC_FOOTER.Replace(Constants.PROC_NAME_INDICATOR, name));

            return proc.ToString();
        }

        public string GetEDSInsertProcFromTable(List<string> tableLines, string tableName, string procName)
        {
            List<string> sourceFields = new List<string>();
            int maxLength = 0;
            //
            // get the max length for formatting
            //
            foreach (string str in tableLines)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma
                    //
                    int space = str.IndexOf(" ", 0);
                    string temp = str.Substring(1, space).Trim();

                    sourceFields.Add(temp);
                    if (temp.Length > maxLength)
                    {
                        maxLength = temp.Length;
                    }
                }
            }

            StringBuilder proc = new StringBuilder();
            //
            // proc header and declaration
            //
            string name = procName + "_ins";
            string header = Constants.PROC_HEADER.Replace(Constants.PROC_NAME_INDICATOR, name);
            proc.AppendLine(header);
            proc.AppendLine("CREATE PROCEDURE " + name);
            proc.AppendLine("(");
            proc.AppendLine(Constants.EDS_REQUIRED);
            proc.AppendLine("\t @" + "Task_Execution_id".PadRight(maxLength + 2, ' ') + "bigint");
            proc.AppendLine("\t,@" + "RecordSeq".PadRight(maxLength + 2, ' ') + "bigint");
            proc.AppendLine(Constants.EDS_REQUIRED);

            foreach (string str in tableLines)
            {
                StringBuilder line = new StringBuilder();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();
                    string dbType = str.Substring(space, str.Length - space).Trim();

                    //
                    // for the procedure components, we need
                    // 1.  Parms
                    // 2.  Insert into table fields
                    // 3.  Parms as Values
                    //
                    // 1. Parms
                    //
                    line.Append("\t,@");
                    line.Append(fieldName.PadRight(maxLength + 2, ' '));
                    line.Append(dbType);

                    proc.AppendLine(line.ToString());

                }
            }
            proc.AppendLine(Constants.EDS_REQUIRED);
            proc.AppendLine("\t,@" + "RowId".PadRight(maxLength + 2, ' ') + "bigint out");
            proc.AppendLine(Constants.EDS_REQUIRED);
            proc.AppendLine(")");
            proc.AppendLine("AS");

            proc.AppendLine(Constants.EDS_INSERT_OPEN);

            proc.AppendLine("INSERT INTO " + tableName);
            proc.AppendLine("(");
            proc.AppendLine(Constants.EDS_REQUIRED);
            proc.AppendLine("\t task_execution_id");
            proc.AppendLine("\t,row_status_id");
            proc.AppendLine(Constants.EDS_REQUIRED);

            //
            // 2. Insert into table fields
            //
            foreach (string str in tableLines)
            {
                StringBuilder line = new StringBuilder();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();

                    line.Append("\t,");
                    line.Append(fieldName);

                    proc.AppendLine(line.ToString());

                }
            }

            proc.AppendLine(Constants.EDS_REQUIRED);
            proc.AppendLine("\t,recd_seq");
            proc.AppendLine(Constants.EDS_REQUIRED);

            proc.AppendLine(")");
            proc.AppendLine("VALUES");
            proc.AppendLine("(");
            proc.AppendLine(Constants.EDS_REQUIRED);
            proc.AppendLine("\t @Task_Execution_Id");
            proc.AppendLine("\t,@Processed_ID_Code");
            proc.AppendLine(Constants.EDS_REQUIRED);

            //
            // 3. Parms as values
            //
            foreach (string str in tableLines)
            {
                StringBuilder line = new StringBuilder();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();

                    line.Append("\t,@");
                    line.Append(fieldName.PadRight(maxLength + 2, ' '));

                    proc.AppendLine(line.ToString());

                }
            }

            proc.AppendLine(Constants.EDS_REQUIRED);
            proc.AppendLine("\t,@RecordSeq");
            proc.AppendLine(Constants.EDS_REQUIRED);
            proc.AppendLine(")");
            proc.AppendLine();
            proc.AppendLine("SET @RowID = @@IDENTITY");
            proc.AppendLine();
            proc.AppendLine();
            proc.AppendLine(Constants.PROC_FOOTER.Replace(Constants.PROC_NAME_INDICATOR, name));

            return proc.ToString();
        }

        public string GetEDSObjectFromTable(List<string> tableLines, string className)
        {
            string line = string.Empty;
            StringBuilder field = null;
            List<string> objectLines = new List<string>();

            //
            // object header
            //
            string header = "public class " + (className.Length > 0 ? className : "ClassName");
            objectLines.Add(header);
            objectLines.Add("{");
            objectLines.Add(" ");

            objectLines.Add("#region public accessors");
            objectLines.Add(" ");

            //
            // public Accessors
            //
            int position = 0;
            foreach (string str in tableLines)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    field = new StringBuilder();
                    //
                    // skip the initial comma
                    //
                    field.Append("[Positiion(");
                    field.Append((++position).ToString());
                    field.Append(")]");
                    field.AppendLine();
                    field.AppendLine("[ExcludeValidation]");
                    field.Append("public ");

                    int space = str.IndexOf(" ", 0);
                    string temp = str.Substring(space, str.Length - space).Trim();
                    field.Append(ConvertDBTypeToClassType(temp));

                    field.Append(" ");
                    temp = str.Substring(1, space).Trim();
                    field.Append(temp);

                    field.AppendLine(" { get; set; } ");
                    objectLines.Add(field.ToString());
                }
            }

            objectLines.Add(" ");
            objectLines.Add("#endregion");
            objectLines.Add("}");

            StringBuilder outString = new StringBuilder();
            foreach (string str in objectLines)
            {
                outString.AppendLine(str);
            }


            return outString.ToString();
        }

        private string GetAddMethod(List<string> tableLines, string className)
        {
            StringBuilder add = new StringBuilder();
            if (tableLines != null && tableLines.Count > 0 && className.Length > 1)
            {
                string instanceName = className[0].ToString().ToLower() + className.Substring(1, className.Length - 1);
                StringBuilder line = new StringBuilder();
                line.Append("internal int Add(");
                line.Append(className);
                line.Append(" ");
                line.Append(instanceName);
                line.Append(", string updatedBy)");

                add.AppendLine(line.ToString());
                add.AppendLine("{");
                add.AppendLine("");

                line.Clear();
                line.Append("DbCommand command = Database.GetStoredProcCommand(\"prc_");
                line.Append(SQLCase(instanceName));
                line.Append("_ins\");");
                add.AppendLine(line.ToString());

                foreach (string str in tableLines)
                {
                    if (str != null && !string.IsNullOrWhiteSpace(str))
                    {
                        int space = str.IndexOf(" ", 0);
                        string fieldName = str.Substring(1, space).Trim(); // skip comma
                        string dbType = str.Substring(space, str.Length - space).Trim();
                        string classType = ConvertDBTypeToClassType(dbType);

                        line.Clear();
                        line.Append("Database.AddInParameter(command, \"");
                        line.Append("@");
                        line.Append(fieldName);
                        line.Append("\", ");
                        line.Append(ConvertClassTypeToDbTypeSpecifier(classType));
                        line.Append(", ");
                        line.Append(instanceName);
                        line.Append(".");
                        line.Append(CamelCase(fieldName, "_"));
                        line.Append(");");
                        add.AppendLine(line.ToString());
                    }
                }
                
                add.AppendLine("Database.AddInParameter(command, \"@updated_by\", DbType.String, updatedBy);");
                add.AppendLine();

                add.AppendLine();
                add.AppendLine();
                add.AppendLine("return Convert.ToInt32(Database.ExecuteScalar(command));");
                add.AppendLine("}");
            }

            return add.ToString();
        }

        private string GetConstructor(string className)
        {
            StringBuilder con = new StringBuilder();
            StringBuilder line = new StringBuilder();

            if (className != null && className.Length > 0)
            {
                con.AppendLine("#region private members");
                con.AppendLine();
                if (__lookupKey != null && __lookupKey.Length > 0)
                {
                    line.Append("private Dictionary<int, ");
                    line.Append(className);
                    line.Append("> __cache;");
                    con.AppendLine(line.ToString());
                }
                con.AppendLine();
                con.AppendLine("#endregion");

                con.AppendLine();
                con.AppendLine("#region public accessors");
                con.AppendLine();
                con.AppendLine("#endregion");

                con.AppendLine();
                con.AppendLine();
                con.AppendLine("#region constructor");
                con.AppendLine();
                line.Clear();
                line.Append("public ");
                line.Append(className);
                line.Append("Repository()");
                con.AppendLine(line.ToString());
                con.AppendLine("{");
                line.Clear();

                if (__lookupKey != null && __lookupKey.Length > 0)
                {
                    line.Append("__cache = new Dictionary<int, ");
                    line.Append(className);
                    line.Append(">();");
                    con.AppendLine(line.ToString());

                    line.Clear();
                    line.Append("List<");
                    line.Append(className);
                    line.Append("> list = Read();");
                    con.AppendLine(line.ToString());

                    line.Clear();
                    line.Append("foreach (");
                    line.Append(className);
                    line.Append(" ");
                    line.Append(className[0].ToString().ToLower());
                    line.Append(" in list)");
                    con.AppendLine(line.ToString());

                    con.AppendLine("{");
                    line.Clear();
                    line.Append("if (!__cache.ContainsKey(");
                    line.Append(className[0].ToString().ToLower());
                    line.Append(".");
                    line.Append(__lookupKey);
                    line.Append("))");
                    con.AppendLine(line.ToString());
                    con.AppendLine("{");

                    line.Clear();
                    line.Append("__cache.Add(");
                    line.Append(className[0].ToString().ToLower());
                    line.Append(".");
                    line.Append(__lookupKey);
                    line.Append(", ");
                    line.Append(className[0].ToString().ToLower());
                    line.Append(");");
                    con.AppendLine(line.ToString());
                    con.AppendLine("}");
                    con.AppendLine("}");
                }
                con.AppendLine("}");

                con.AppendLine();
                con.AppendLine("#endregion");
            }

            return con.ToString();
        }

        private string GetGetMethod(List<string> tableLines, string className)
        {
            StringBuilder get = new StringBuilder();
            if (className.Length > 1)
            {
                string instanceName = className[0].ToString().ToLower() + className.Substring(1, className.Length - 1);
                StringBuilder line = new StringBuilder();
                line.Append("public int Get");
                line.Append(__primaryKey);
                line.Append("(");
                line.Append(className);
                line.Append(" ");
                line.Append(instanceName);
                line.Append(")");
                get.AppendLine(line.ToString());
                get.AppendLine("{");

                line.Clear();
                line.Append("if (__cache.ContainsKey(");
                line.Append(instanceName);
                line.Append(".");
                line.Append(__lookupKey);
                line.Append("))");
                get.AppendLine(line.ToString());

                get.AppendLine("{");
                get.AppendLine("//");
                get.AppendLine("// update any fields in case cache is pushed to DB");
                get.AppendLine("//");

                foreach (string str in tableLines)
                {
                    int space = str.IndexOf(" ", 0);
                    string temp = str.Substring(1, space).Trim();
                    string member = CamelCase(temp, "_");

                    string lookupIdMember;
                    string identityIdMember;

                    line.Clear();
                    line.Append(".");
                    line.Append(__lookupKey);
                    line.Append("))");
                    lookupIdMember = line.ToString();

                    line.Clear();
                    line.Append(__primaryKey);
                    identityIdMember = line.ToString();

                    if (!member.Equals(lookupIdMember) && !member.Equals(identityIdMember))
                    {
                        line.Clear();
                        line.Append("__cache[");
                        line.Append(instanceName);
                        line.Append(".");
                        line.Append(__lookupKey);
                        line.Append("].");
                        line.Append(member);
                        line.Append(" = ");
                        line.Append(instanceName);
                        line.Append(".");
                        line.Append(member);
                        line.Append(";");
                        get.AppendLine(line.ToString());
                    }

                }

                get.AppendLine("}");
                get.AppendLine("else");
                get.AppendLine("{");
                get.AppendLine("//");
                get.AppendLine("// adding new");
                get.AppendLine("//");
                line.Clear();
                line.Append(instanceName);
                line.Append(".");
                line.Append(__primaryKey);
                line.Append(" = WriteNew(");
                line.Append(instanceName);
                line.Append(", Environment.UserName);");
                get.AppendLine(line.ToString());
                line.Clear();
                line.Append("__cache.Add(");
                line.Append(instanceName);
                line.Append(".");
                line.Append(__lookupKey);
                line.Append(", ");
                line.Append(instanceName);
                line.Append(");");
                get.AppendLine(line.ToString());

                get.AppendLine("}");

                get.AppendLine("//");
                get.AppendLine("// return requested id");
                get.AppendLine("//");
                line.Clear();
                line.Append("return __cache[");
                line.Append(instanceName);
                line.Append(".");
                line.Append(__lookupKey);
                line.Append("].");
                line.Append(__primaryKey);
                line.Append(";");
                get.AppendLine(line.ToString());

                get.AppendLine("}");

            }

            return get.ToString();
        }

        private string GetLoadMethod(List<string> tableLines, string className)
        {
            StringBuilder load = new StringBuilder();
            if (tableLines != null && tableLines.Count > 0 && className.Length > 1)
            {
                string instanceName = className[0].ToString().ToLower() + className.Substring(1, className.Length - 1);
                StringBuilder line = new StringBuilder();
                line.Append("protected ");
                line.Append(className);
                line.Append(" Load(IDataReader dr, ");
                line.Append(className);
                line.Append(" ");
                line.Append(instanceName);
                line.Append(")");

                load.AppendLine(line.ToString());
                load.AppendLine("{");

                foreach (string str in tableLines)
                {
                    if (str != null && !string.IsNullOrWhiteSpace(str))
                    {
                        line = new StringBuilder();

                        int space = str.IndexOf(" ", 0);
                        string fieldName = str.Substring(1, space).Trim(); // skip comma
                        string dbType = str.Substring(space, str.Length - space).Trim();
                        string classType = ConvertDBTypeToClassType(dbType);

                        //
                        // if (ColumnExists(dr, "field_name"))
                        // {
                        line.Append("if (ColumnExists(dr, \"");
                        line.Append(fieldName);
                        line.Append("\")) ");
                        load.AppendLine(line.ToString());
                        load.AppendLine("{");
                        //      if (dr["field_name"] == DBNull.Value)
                        //      {
                        line.Clear();
                        line.Append("if (dr[\"");
                        line.Append(fieldName);
                        line.Append("\"] == DBNull.Value)");
                        load.AppendLine(line.ToString());
                        load.AppendLine("{");
                        //          instance.FieldName = IFNULLVALUE;
                        //      }
                        line.Clear();
                        line.Append(instanceName);
                        line.Append(".");
                        line.Append(CamelCase(fieldName, "_"));
                        line.Append(" = ");
                        line.Append(ConvertDBTypeToIfNull(dbType));
                        line.Append(";");
                        load.AppendLine(line.ToString());
                        load.AppendLine("}");
                        //      else
                        //      {
                        load.AppendLine("else");
                        load.AppendLine("{");
                        //          instance.FieldName = Convert.ToProperType(dr["field_name"].ToString());
                        //      }
                        line.Clear();
                        line.Append(instanceName);
                        line.Append(".");
                        line.Append(CamelCase(fieldName, "_"));
                        line.Append(" = ");
                        line.Append("Convert");
                        line.Append(ConvertDbTypeToConvertMethod(classType));
                        line.Append("(");
                        line.Append("dr[\"");
                        line.Append(fieldName);
                        line.Append("\"].ToString());");
                        load.AppendLine(line.ToString());
                        load.AppendLine("}");
                        //  }
                        load.AppendLine("}");

                    }

                }

                load.AppendLine("");
                load.AppendLine("");
                line.Clear();
                line.Append("return ");
                line.Append(instanceName);
                line.Append(";");
                load.AppendLine(line.ToString());
                load.AppendLine("}");
            }


            return load.ToString();
        }

        public string GetObjectFromTable(List<string> tableLines, string className)
        {
            string line = string.Empty;
            StringBuilder field = null;
            List<string> objectLines = new List<string>();

            //
            // object header
            //
            string header = "public class " + (className.Length > 0 ? className : "ClassName");
            objectLines.Add(header);
            objectLines.Add("{");
            objectLines.Add(" ");
            objectLines.Add("#region private members");
            objectLines.Add(" ");

            //
            // private members
            //
            int maxTypeLength = 0;
            foreach (string str in tableLines)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    int space = str.IndexOf(" ", 0);
                    string temp = str.Substring(space, str.Length - space).Trim();
                    string typeString = ConvertDBTypeToClassType(temp);

                    if (typeString.Length > maxTypeLength)
                    {
                        maxTypeLength = typeString.Length;
                    }
                }
            }

            foreach (string str in tableLines)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    field = new StringBuilder();
                    //
                    // skip the initial comma
                    //
                    field.Append("private ");

                    int space = str.IndexOf(" ", 0);
                    string temp = str.Substring(space, str.Length - space).Trim();
                    field.Append((ConvertDBTypeToClassType(temp)).PadRight(maxTypeLength, ' '));

                    field.Append(" ");
                    temp = str.Substring(1, space).Trim();
                    field.Append(CamelCasePrivate(temp, "_"));

                    field.Append(";");

                    objectLines.Add(field.ToString());
                }
            }

            objectLines.Add(" ");
            objectLines.Add("#endregion");

            objectLines.Add(" ");
            objectLines.Add("#region public accessors");
            objectLines.Add(" ");

            //
            // public Accessors
            //
            foreach (string str in tableLines)
            {
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    field = new StringBuilder();
                    //
                    // skip the initial comma
                    //
                    field.Append("public ");

                    int space = str.IndexOf(" ", 0);
                    string temp = str.Substring(space, str.Length - space).Trim();
                    field.Append(ConvertDBTypeToClassType(temp));

                    field.Append(" ");
                    temp = str.Substring(1, space).Trim();
                    field.Append(CamelCase(temp, "_"));

                    field.AppendLine();
                    field.AppendLine("{");
                    field.AppendLine("get");
                    field.AppendLine("{");
                    field.AppendLine("return " + CamelCasePrivate(temp, "_") + ";");
                    field.AppendLine("}");
                    field.AppendLine("set");
                    field.AppendLine("{");
                    field.AppendLine(CamelCasePrivate(temp, "_") + " = value;");
                    field.AppendLine("}");
                    field.AppendLine("}");
                    field.AppendLine();

                    objectLines.Add(field.ToString());
                }
            }

            objectLines.Add(" ");
            objectLines.Add("#endregion");
            objectLines.Add("}");

            StringBuilder outString = new StringBuilder();
            foreach (string str in objectLines)
            {
                outString.AppendLine(str);
            }


            return outString.ToString();
        }

        public string GetPushCacheMethod(string className)
        {
            StringBuilder push = new StringBuilder();
            StringBuilder line = new StringBuilder();

            if (className != null && className.Length > 0)
            {
                push.AppendLine("public int PushCache()");
                push.AppendLine("{");
                line.Append("List<");
                line.Append(className);
                line.Append("> list = new List<");
                line.Append(className);
                line.Append(">();");
                push.AppendLine(line.ToString());

                line.Clear();
                line.Append("foreach (");
                line.Append(className);
                line.Append(" ");
                line.Append(className[0].ToString().ToLower());
                line.Append(" in __cache.Values)");
                push.AppendLine(line.ToString());
                push.AppendLine("{");

                line.Clear();
                line.Append("list.Add(");
                line.Append(className[0].ToString().ToLower());
                line.Append(");");
                push.AppendLine(line.ToString());
                push.AppendLine("}");
                push.AppendLine();
                push.AppendLine("return Write(list, Environment.UserName);");
                push.AppendLine("}");
            }

            return push.ToString();
        }

        private string GetReadMethod(string className)
        {
            StringBuilder file = new StringBuilder();
            if (className.Length > 1)
            {
                string instanceName = className[0].ToString().ToLower() + className.Substring(1, className.Length - 1);
                //
                // select list
                //
                StringBuilder line = new StringBuilder();
                line.Append("public List<");
                line.Append(className);
                line.Append("> ");
                line.Append("Read()");
                file.AppendLine(line.ToString());
                file.AppendLine("{");
                
                line.Clear();
                line.Append("List<");
                line.Append(className);
                line.Append("> list = new List<");
                line.Append(className);
                line.Append(">();");
                file.AppendLine(line.ToString());

                line.Clear();
                line.Append("DbCommand command = Database.GetStoredProcCommand(\"prc_");
                line.Append(SQLCase(instanceName));
                line.Append("_sel\");");
                file.AppendLine(line.ToString());

                file.AppendLine("//");
                file.AppendLine("// Optional Parameters:");
                file.AppendLine("//");
                file.AppendLine("//Database.AddInParameter(command, \"@param_name\", DbType.Int32, field_name);");
                file.AppendLine("");
                file.AppendLine("using (IDataReader dr = Database.ExecuteReader(command))");
                file.AppendLine("{");
                file.AppendLine("while (dr.Read())");
                file.AppendLine("{");

                line.Clear();
                line.Append(className);
                line.Append(" ");
                line.Append(instanceName);
                line.Append(" = new ");
                line.Append(className);
                line.Append("();");
                file.AppendLine(line.ToString());

                line.Clear();
                line.Append("list.Add(Load(dr, ");
                line.Append(instanceName);
                line.Append("));");
                file.AppendLine(line.ToString());
                file.AppendLine("}");
                file.AppendLine("}");
                file.AppendLine();

                line.Clear();
                line.Append("return list;");
                file.AppendLine(line.ToString());
                file.AppendLine("}");

                file.AppendLine();
                file.AppendLine();
                //
                // select by id
                //
                if (__lookupKey != null && __lookupKey.Length > 0)
                {
                    line.Clear();
                    line.Append("public ");
                    line.Append(className);
                    line.Append(" ");
                    line.Append("Read(int ");
                    line.Append(__lookupKey);
                    line.Append(")");
                    file.AppendLine(line.ToString());
                    file.AppendLine("{");

                    line.Clear();
                    line.Append(className);
                    line.Append(" ");
                    line.Append(instanceName);
                    line.Append(" = new ");
                    line.Append(className);
                    line.Append("();");
                    file.AppendLine(line.ToString());

                    line.Clear();
                    line.Append("DbCommand command = Database.GetStoredProcCommand(\"prc_");
                    line.Append(SQLCase(instanceName));
                    line.Append("_sel_by_id\");");
                    file.AppendLine(line.ToString());

                    file.AppendLine("//");
                    file.AppendLine("// Optional Parameters:");
                    file.AppendLine("//");

                    line.Clear();
                    line.Append("Database.AddInParameter(command, \"@");
                    line.Append(SQLCase(__primaryKey));
                    line.Append("\", DbType.Int32, ");
                    line.Append(__primaryKey);
                    line.Append(");");
                    file.AppendLine(line.ToString());
                    file.AppendLine("");
                    file.AppendLine("using (IDataReader dr = Database.ExecuteReader(command))");
                    file.AppendLine("{");
                    file.AppendLine("if (dr.Read())");
                    file.AppendLine("{");

                    line.Clear();
                    line.Append(instanceName);
                    line.Append(" = Load(dr, ");
                    line.Append(instanceName);
                    line.Append(");");
                    file.AppendLine(line.ToString());
                    file.AppendLine("}");
                    file.AppendLine("}");
                    file.AppendLine();

                    line.Clear();
                    line.Append("return ");
                    line.Append(instanceName);
                    line.Append(";");
                    file.AppendLine(line.ToString());
                    file.AppendLine("}");
                }
            }

            return file.ToString();
        }

        public string GetRepositoryMethods(List<string> tableLines, string className)
        {
            StringBuilder methods = new StringBuilder();
            StringBuilder line = new StringBuilder();
            line.Append("public class ");
            line.Append(className);
            line.Append("Repository : RepositoryBase");


            methods.AppendLine(line.ToString());
            methods.AppendLine("{");
            methods.AppendLine(GetConstructor(className));
            methods.AppendLine();
            methods.AppendLine("#region public methods");

            if (__lookupKey != null && __lookupKey.Length > 0)
            {
                methods.AppendLine("");
                methods.AppendLine(GetGetMethod(tableLines, className));
                methods.AppendLine("");
                methods.AppendLine(GetPushCacheMethod(className));
            }
            methods.AppendLine("");
            methods.AppendLine(GetReadMethod(className));
            methods.AppendLine("");
            methods.AppendLine(GetWriteMethod(className));
            methods.AppendLine("");
            methods.AppendLine(GetWriteNewMethod(className));
            methods.AppendLine("");
            methods.AppendLine(GetWriteListMethod(className));
            methods.AppendLine("");
            methods.AppendLine("#endregion");
            methods.AppendLine("");
            methods.AppendLine("#region internal methods");
            methods.AppendLine("");
            methods.AppendLine(GetLoadMethod(tableLines, className));
            methods.AppendLine("");
            methods.AppendLine(GetAddMethod(tableLines, className));
            methods.AppendLine("");
            methods.AppendLine(GetSaveMethod(tableLines, className));
            methods.AppendLine("");
            methods.AppendLine(GetSaveListMethod(tableLines, className));
            methods.AppendLine("");
            methods.AppendLine("#endregion");
            methods.AppendLine("");
            methods.AppendLine("}");

            return methods.ToString();
        }
        
        private string GetSaveMethod(List<string> tableLines, string className)
        {
            StringBuilder save = new StringBuilder();
            if (tableLines != null && tableLines.Count > 0 && className.Length > 1)
            {
                string instanceName = className[0].ToString().ToLower() + className.Substring(1, className.Length - 1);
                StringBuilder line = new StringBuilder();
                line.Append("internal int Save(");
                line.Append(className);
                line.Append(" ");
                line.Append(instanceName);
                line.Append(", string updatedBy)");

                save.AppendLine(line.ToString());
                save.AppendLine("{");
                save.AppendLine("");

                line.Clear();
                line.Append("DbCommand command = Database.GetStoredProcCommand(\"prc_");
                line.Append(SQLCase(instanceName));
                line.Append("_upd\");");
                save.AppendLine(line.ToString());

                foreach (string str in tableLines)
                {
                    if (str != null && !string.IsNullOrWhiteSpace(str))
                    {
                        int space = str.IndexOf(" ", 0);
                        string fieldName = str.Substring(1, space).Trim(); // skip comma
                        string dbType = str.Substring(space, str.Length - space).Trim();
                        string classType = ConvertDBTypeToClassType(dbType);

                        line.Clear();
                        line.Append("Database.AddInParameter(command, \"");
                        line.Append("@");
                        line.Append(fieldName);
                        line.Append("\", ");
                        line.Append(ConvertClassTypeToDbTypeSpecifier(classType));
                        line.Append(", ");
                        line.Append(instanceName);
                        line.Append(".");
                        line.Append(CamelCase(fieldName, "_"));
                        line.Append(");");
                        save.AppendLine(line.ToString());
                    }
                }
                save.AppendLine("Database.AddInParameter(command, \"@updated_by\", DbType.String, updatedBy);");
                save.AppendLine();

                save.AppendLine();
                save.AppendLine();
                save.AppendLine("return Database.ExecuteNonQuery(command);");
                save.AppendLine("}");
            }

            return save.ToString();
        }

        private string GetSaveListMethod(List<string> tableLines, string className)
        {
            StringBuilder add = new StringBuilder();
            if (tableLines != null && tableLines.Count > 0 && className.Length > 1)
            {
                string instanceName = className[0].ToString().ToLower() + className.Substring(1, className.Length - 1) + "List";
                StringBuilder line = new StringBuilder();
                line.Append("internal int Save(List<");
                line.Append(className);
                line.Append("> ");
                line.Append(instanceName);
                line.Append(", string updatedBy)");

                add.AppendLine(line.ToString());
                add.AppendLine("{");
                add.AppendLine("");
                add.AppendLine("StringWriter writer = new StringWriter();");

                line.Clear();
                line.Append("XmlSerializer serializer = new XmlSerializer(");
                line.Append(instanceName);
                line.Append(".GetType());");
                add.AppendLine(line.ToString());

                line.Clear();
                line.Append("serializer.Serialize(writer, ");
                line.Append(instanceName);
                line.Append(");");
                add.AppendLine(line.ToString());

                add.AppendLine("string xml = writer.ToString();");

                line.Clear();
                line.Append("DbCommand command = Database.GetStoredProcCommand(\"prc_");
                line.Append(SQLCase(className));
                line.Append("_ups\");");
                add.AppendLine(line.ToString());

                add.AppendLine("Database.AddInParameter(command, \"@xml_list\", DbType.String, xml);");
                add.AppendLine("Database.AddInParameter(command, \"@updated_by\", DbType.String, updatedBy);");

                add.AppendLine();
                add.AppendLine();
                add.AppendLine("return Database.ExecuteNonQuery(command);");
                add.AppendLine("}");
            }

            return add.ToString();
        }

        public string GetTableComparison(List<string> tableLines, string catalog, string schema, string tableName)
        {
            StringBuilder file = new StringBuilder();
            List<DBColumn> cols = new List<DBColumn>();
            foreach (string str in tableLines)
            {
                StringBuilder line = new StringBuilder();
                if (str != null && !string.IsNullOrWhiteSpace(str))
                {
                    //
                    // skip the initial comma and get the field name
                    //
                    int space = str.IndexOf(" ", 0);
                    string fieldName = str.Substring(1, space).Trim();
                    string dbType = str.Substring(space, str.Length - space).Trim();

                    DBColumn col = new DBColumn();
                    col.TableName = tableName;
                    col.ColumnName = fieldName;
                    col.DataType = dbType;
                    col.TableSchema = "tmp";
                    col.TableCatalog = "utility";

                    cols.Add(col);
                }
            }

            List<DBColumn> dbCols = UtilityDataAccess.GetTableDefinition(catalog, schema, tableName);

            if (cols.Count > dbCols.Count)
            {
                file.AppendLine(GetTableComparisonDetail(cols, dbCols));
            }
            else
            {
                file.AppendLine(GetTableComparisonDetail(dbCols, cols));
            }
            

            return file.ToString();
        }

        private string GetTableComparisonDetail(List<DBColumn> largeCols, List<DBColumn> smallCols)
        {
            int maxTypeStringLength = 0;
            int maxTextLength = 0;
            foreach (DBColumn col in largeCols)
            {
                if (col.TypeStringLength > maxTypeStringLength) maxTypeStringLength = col.TypeStringLength;
                if (col.MaxStringLength > maxTextLength) maxTextLength = col.MaxStringLength;
            }
            foreach (DBColumn col in smallCols)
            {
                if (col.TypeStringLength > maxTypeStringLength) maxTypeStringLength = col.TypeStringLength;
                if (col.MaxStringLength > maxTextLength) maxTextLength = col.MaxStringLength;
            }
            maxTypeStringLength += 5;
            maxTextLength += 2;


            StringBuilder summary = new StringBuilder();
            int colsFoundCount = 0;
            foreach (DBColumn col_i in largeCols)
            {
                bool colFound = false;
                StringBuilder line = new StringBuilder();

                foreach (DBColumn col_j in smallCols)
                {
                    if (col_i.ColumnName.Equals(col_j.ColumnName))
                    {
                        colsFoundCount++;
                        colFound = true;
                        if (col_i.DataTypeString.Equals(col_j.DataTypeString))
                        {
                            line.Append("EQUIVALENT> ");
                        }
                        else
                        {
                            line.Append("MISMATCH  > ");
                        }

                        line.Append(col_i.ToString(maxTextLength, maxTextLength + maxTypeStringLength, true));
                        line.Append("  ||  ");
                        line.Append(col_j.ToString(maxTextLength, maxTextLength + maxTypeStringLength, true));
                        summary.AppendLine(line.ToString());

                        break;
                    }
                }

                if (!colFound)
                {
                    line.Append("MISSING   > ");
                    line.Append(col_i.ToString(maxTextLength, maxTextLength + maxTypeStringLength, true));
                    line.Append("  ||  DNE");
                    summary.AppendLine(line.ToString());
                }
            }

            if (colsFoundCount < smallCols.Count)
            {
                foreach (DBColumn col_i in smallCols)
                {
                    bool missing = true;
                    foreach (DBColumn col_j in largeCols)
                    {
                        if (col_i.ColumnName.Equals(col_j.ColumnName))
                        {
                            missing = false;
                            break;
                        }
                    }

                    StringBuilder line = new StringBuilder();
                    if (missing)
                    {
                        line.Append("MISSING   > ");
                        line.Append("DNE".PadRight(maxTextLength + maxTypeStringLength, ' '));
                        line.Append("  ||  ");
                        line.Append(col_i.ToString(maxTextLength, maxTextLength + maxTypeStringLength, true));
                        summary.AppendLine(line.ToString());
                    }
                }
            }

            return summary.ToString();
        }

        private string GetWriteMethod(string className)
        {
            StringBuilder file = new StringBuilder();
            StringBuilder line = new StringBuilder();

            if (className != null && className.Length > 1)
            {
                string instanceName = className[0].ToString().ToLower() + className.Substring(1, className.Length - 1);
                line.Append("public int Write(");
                line.Append(className);
                line.Append(" ");
                line.Append(instanceName);
                line.Append(", string updatedBy)");
                file.AppendLine(line.ToString());

                file.AppendLine("{");

                line.Clear();
                line.Append("return Save(");
                line.Append(instanceName);
                line.Append(", updatedBy);");
                file.AppendLine(line.ToString());

                file.AppendLine("}");
            }

            return file.ToString();
        }

        private string GetWriteNewMethod(string className)
        {
            StringBuilder file = new StringBuilder();
            StringBuilder line = new StringBuilder();

            if (className != null && className.Length > 1)
            {
                string instanceName = className[0].ToString().ToLower() + className.Substring(1, className.Length - 1);
                line.Append("public int WriteNew(");
                line.Append(className);
                line.Append(" ");
                line.Append(instanceName);
                line.Append(", string updatedBy)");
                file.AppendLine(line.ToString());

                file.AppendLine("{");

                line.Clear();
                line.Append("return Add(");
                line.Append(instanceName);
                line.Append(", updatedBy);");
                file.AppendLine(line.ToString());

                file.AppendLine("}");
            }

            return file.ToString();
        }

        private string GetWriteListMethod(string className)
        {
            StringBuilder file = new StringBuilder();
            StringBuilder line = new StringBuilder();

            if (className != null && className.Length > 1)
            {
                string instanceName = className[0].ToString().ToLower() + className.Substring(1, className.Length - 1) + "List";
                line.Append("public int Write(List<");
                line.Append(className);
                line.Append("> ");
                line.Append(instanceName);
                line.Append(", string updatedBy)");
                file.AppendLine(line.ToString());

                file.AppendLine("{");

                line.Clear();
                line.Append("return Save(");
                line.Append(instanceName);
                line.Append(", updatedBy);");
                file.AppendLine(line.ToString());

                file.AppendLine("}");
            }

            return file.ToString();
        }

    }
}
