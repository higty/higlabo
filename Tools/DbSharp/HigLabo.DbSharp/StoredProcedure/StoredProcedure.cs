using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data;
using HigLabo.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace HigLabo.DbSharp
{
    public abstract class StoredProcedure : INotifyPropertyChanged, IDatabaseContext
    {
        /// <summary>
        /// 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 
        /// </summary>
        String IDatabaseContext.TransactionKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        protected StoredProcedure()
        {
            ((IDatabaseContext)this).TransactionKey = "";
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract string GetStoredProcedureName();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract DbCommand CreateCommand();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Int32 ExecuteNonQuery()
        {
            return this.ExecuteNonQuery(this.GetDatabase());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public Int32 ExecuteNonQuery(Database database)
        {
            if (database == null) throw new ArgumentNullException("database");
            var affectedRecordCount = -1;
            var previousState = database.ConnectionState;

            try
            {
                var cm = CreateCommand();
                affectedRecordCount = database.ExecuteCommand(cm);
                this.SetOutputParameterValue(cm);
            }
            finally
            {
                if (previousState == ConnectionState.Closed && database.ConnectionState == ConnectionState.Open) { database.Close(); }
                if (previousState == ConnectionState.Closed && database.OnTransaction == false) { database.Dispose(); }
            }
            return affectedRecordCount;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        protected abstract void SetOutputParameterValue(DbCommand command);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static object ToDBValue(object value)
        {
            return value ?? DBNull.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected static T? ToEnum<T>(Object value)
            where T : struct
        {
            if (value == null) return null;
            if (typeof(T).IsEnum == false) throw new ArgumentException("T must be Enum type");
            T result;
            var tp = value.GetType();
            if (tp == typeof(T)) return (T)value;
            if (tp == typeof(String) && Enum.TryParse((String)value, true, out result))
            {
                return result;
            }
            throw new InvalidEnumDataException(typeof(T), value);
        }
        public abstract String GetDatabaseKey();
        protected PropertyChangedEventHandler GetPropertyChangedEventHandler()
        {
            return this.PropertyChanged;
        }
        protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var eh = PropertyChanged;
            if (eh != null)
            {
                eh(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
