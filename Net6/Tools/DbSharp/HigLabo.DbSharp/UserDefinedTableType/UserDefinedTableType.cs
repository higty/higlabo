using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient.Server;

namespace HigLabo.DbSharp
{
    public abstract class UserDefinedTableType<T> 
        where T : UserDefinedTableTypeRecord
    {
        private List<T> _Records = new List<T>();
        public List<T> Records
        {
            get { return _Records; }
        }

        public abstract SqlDataRecord CreateSqlDataRecord();
        public List<SqlDataRecord> CreateSqlDataRecords(IEnumerable<T> records)
        {
            var l = new List<SqlDataRecord>();
            foreach (var item in records)
            {
                var r = CreateSqlDataRecord();
                r.SetValues(item.GetValues());
                l.Add(r);
            }
            return l;
        }
    }
}
