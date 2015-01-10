using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DeveloperUtilityWin
{
    public class Table
    {
        private List<DataRow> __rows;

        public Table(string name, List<string> columns, IDataReader dr)
        {
            Name = name;
            Columns = columns;
            __rows = new List<DataRow>();

            while (dr.Read())
            {
                DataRow row = new DataRow();
                foreach (string colName in Columns)
                {
                    string val = dr[colName].ToString();
                    row.Add(colName, val);
                }

                __rows.Add(row);
            }
        }

        public List<string> Columns { get; set; }
        public string Name { get; set; }

        public List<DataRow> Rows
        {
            get
            {
                return __rows;
            }
        }


        public bool CompareTables(Table right)
        {
            if (Rows.Count != right.Rows.Count)
            {
                return false;
            }


            return true;
        }



    }
}
