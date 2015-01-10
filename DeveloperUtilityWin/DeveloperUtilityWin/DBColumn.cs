using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeveloperUtilityWin
{
    public class DBColumn
    {
        public string TableCatalog { get; set; }
        public string TableName { get; set; }
        public string TableSchema { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string CharacterLength { get; set; }
        public string NumericPrecision { get; set; }
        public string NumericScale { get; set; }


        public string DataTypeString
        {
            get
            {
                if (DataType.Equals("varchar") || DataType.Equals("nvarchar"))
                {
                    string l = CharacterLength;
                    if (CharacterLength.Equals("-1"))
                    {
                        l = "MAX";
                    }
                    return DataType + "(" + l + ")";
                }
                else if (DataType.Equals("decimal"))
                {
                    return DataType + "(" + NumericPrecision + "," + NumericScale + ")";
                }


                return DataType;
            }
        }

        public int MaxLength
        {
            get
            {
                return this.ToString().Length;
            }
        }

        public int MaxStringLength
        {
            get
            {
                return this.ToString(false).Length;
            }
        }

        public int TypeStringLength
        {
            get
            {
                return this.DataTypeString.Length;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(TableCatalog);
            sb.Append(".");
            sb.Append(TableSchema);
            sb.Append(".");
            sb.Append("TABLE");
            sb.Append(".");
            sb.Append(ColumnName);
            sb.Append(" : ");
            sb.Append(DataTypeString);

            return sb.ToString();
        }

        public string ToString(int textWidth, int totalWidth, bool includeDataTypeString)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder full = new StringBuilder();
            sb.Append(TableCatalog);
            sb.Append(".");
            sb.Append(TableSchema);
            sb.Append(".");
            sb.Append("TABLE");
            sb.Append(".");
            sb.Append(ColumnName);

            full.Append(sb.ToString().PadRight(textWidth, ' '));

            if (includeDataTypeString)
            {
                sb.Clear();
                sb.Append(" : ");
                sb.Append(DataTypeString);
                full.Append(sb.ToString().PadRight(totalWidth - textWidth, ' '));
            }

            return full.ToString();
        }

        public string ToString(bool includeDataTypeString)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(TableCatalog);
            sb.Append(".");
            sb.Append(TableSchema);
            sb.Append(".");
            sb.Append("TABLE");
            sb.Append(".");
            sb.Append(ColumnName);

            if (includeDataTypeString)
            {
                sb.Append(" : ");
                sb.Append(DataTypeString);
            }

            return sb.ToString();
  
        }
    }
}
