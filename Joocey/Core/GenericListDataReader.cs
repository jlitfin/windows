using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Core
{
    public class GenericListDataReader<T> : IDataReader
    {
        private readonly IEnumerator<T> list;
        private readonly List<PropertyInfo> properties;
        private readonly Dictionary<string, int> nameLookup;

        public GenericListDataReader(IEnumerable<T> list)
        {
            this.list = list.GetEnumerator();

            properties = new List<PropertyInfo>(
                typeof(T)
                    .GetProperties(
                        BindingFlags.GetProperty |
                        BindingFlags.Instance |
                        BindingFlags.Public
                    ));

            nameLookup = new Dictionary<string, int>();
            for (var i = 0; i < properties.Count; i++)
            {
                nameLookup[properties[i].Name] = i;
            }
        }

        public void Close()
        {
            list.Dispose();
        }

        public int Depth
        {
            get { throw new NotImplementedException(); }
        }

        public DataTable GetSchemaTable()
        {
            throw new NotImplementedException();
        }

        public bool IsClosed
        {
            get { throw new NotImplementedException(); }
        }

        public bool NextResult()
        {
            throw new NotImplementedException();
        }

        public bool Read()
        {
            return list.MoveNext();
        }

        public int RecordsAffected
        {
            get { throw new NotImplementedException(); }
        }


        public void Dispose()
        {
            Close();
        }

        public int FieldCount => properties.Count;

        public bool GetBoolean(int i)
        {
            return (bool)GetValue(i);
        }

        public byte GetByte(int i)
        {
            return (byte)GetValue(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public char GetChar(int i)
        {
            return (char)GetValue(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotImplementedException();
        }

        public IDataReader GetData(int i)
        {
            throw new NotImplementedException();
        }

        public string GetDataTypeName(int i)
        {
            throw new NotImplementedException();
        }

        public DateTime GetDateTime(int i)
        {
            return (DateTime)GetValue(i);
        }

        public decimal GetDecimal(int i)
        {
            return (decimal)GetValue(i);
        }

        public double GetDouble(int i)
        {
            return (double)GetValue(i);
        }

        public Type GetFieldType(int i)
        {
            return properties[i].PropertyType;
        }

        public float GetFloat(int i)
        {
            return (float)GetValue(i);
        }

        public Guid GetGuid(int i)
        {
            return (Guid)GetValue(i);
        }

        public short GetInt16(int i)
        {
            return (short)GetValue(i);
        }

        public int GetInt32(int i)
        {
            return (int)GetValue(i);
        }

        public long GetInt64(int i)
        {
            return (long)GetValue(i);
        }

        public string GetName(int i)
        {
            return properties[i].Name;
        }

        public int GetOrdinal(string name)
        {
            if (nameLookup.ContainsKey(name))
            {
                return nameLookup[name];
            }
            else
            {
                return -1;
            }
        }

        public string GetString(int i)
        {
            return (string)GetValue(i);
        }

        public object GetValue(int i)
        {
            return properties[i].GetValue(list.Current, null);
        }

        public int GetValues(object[] values)
        {
            int getValues = Math.Max(FieldCount, values.Length);

            for (int i = 0; i < getValues; i++)
            {
                values[i] = GetValue(i);
            }

            return getValues;
        }

        public bool IsDBNull(int i)
        {
            return GetValue(i) == null;
        }

        public object this[string name] => GetValue(GetOrdinal(name));

        public object this[int i] => GetValue(i);
    }
}