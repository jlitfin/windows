using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace JPL.Lib.WebContent
{
    public class RepositoryBase
    {
        private static Microsoft.Practices.EnterpriseLibrary.Data.Database __database;
        private int __commandTimeout = 600;

        public Database Database
        {
            get
            {
                if (__database == null)
                {
                    __database = DatabaseFactory.CreateDatabase("media");
                }

                return __database;
            }

            set
            {
                __database = value;
            }
        }

        protected bool ColumnExists(IDataRecord dr, string columnName)
        {
            try
            {
                return dr.GetOrdinal(columnName) >= 0;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        protected int CommandTimeout
        {
            get
            {
                return __commandTimeout;
            }
            set
            {
                __commandTimeout = value;
            }
        }
    }
}
