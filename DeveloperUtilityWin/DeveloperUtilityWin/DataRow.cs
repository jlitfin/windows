using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeveloperUtilityWin
{
    public class DataRow
    {
        Dictionary<string, string> __colValues;

        public string this[string key]
        {
            get
            {
                if (__colValues.ContainsKey(key))
                {
                    return __colValues[key];
                }
                else
                {
                    throw new NullReferenceException(key + " is not a valid column");
                }
            }
            set
            {
                if (__colValues.ContainsKey(key))
                {
                    __colValues[key] = value;
                }
                else
                {
                    throw new NullReferenceException(key + " is not a valid column");
                }
            }
        }

        public void Add(string col, string value)
        {
            if (__colValues == null)
            {
                __colValues = new Dictionary<string, string>();
            }

            if (!__colValues.ContainsKey(col))
            {
                __colValues.Add(col, value);
            }
            else
            {
                __colValues[col] = value;
            }
        }

        public List<string> ColumnValues
        {
            get
            {
                if (__colValues != null)
                {
                    return __colValues.Values.ToList<string>();
                }

                return null;
            }
        }

        public bool CompareRow(DataRow right)
        {
            foreach (string key in __colValues.Keys)
            {
                if (__colValues[key] != right[key])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (__colValues != null)
            {
                foreach (KeyValuePair<string, string> kv in __colValues)
                {
                    sb.Append(kv.Value.ToString());
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }
    }
}
