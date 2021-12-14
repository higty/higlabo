using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public class TableRecordReader : IDataReader
    {
        private readonly IEnumerable<TableRecord> _Enumerable;
        private IEnumerator<TableRecord> _Records;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="records"></param>
        public TableRecordReader(IEnumerable<TableRecord> records)
        {
            if (records == null)
                throw new ArgumentNullException("records");

            _Enumerable = records;
            _Records = _Enumerable.GetEnumerator();
        }
        /// <summary>
        /// 
        /// </summary>
        public int FieldCount
        {
            get
            {
                var first = _Enumerable.FirstOrDefault();
                return first == null ? 0 : first.GetColumnCount();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            var b = _Records.MoveNext();
            return b;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public object GetValue(int i)
        {
            var r = _Records.Current;
            return r.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            _Records.Dispose();
            _Records = null;
        }

        #region NotSupportedException
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string GetName(int i)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string GetDataTypeName(int i)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Type GetFieldType(int i)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public int GetValues(object[] values)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetOrdinal(string name)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool GetBoolean(int i)
        {
            return (bool)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public byte GetByte(int i)
        {
            return (byte)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="fieldOffset"></param>
        /// <param name="buffer"></param>
        /// <param name="bufferoffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public char GetChar(int i)
        {
            return (char)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="fieldoffset"></param>
        /// <param name="buffer"></param>
        /// <param name="bufferoffset"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Guid GetGuid(int i)
        {
            return (Guid)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Int16 GetInt16(int i)
        {
            return (Int16)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Int32 GetInt32(int i)
        {
            return (Int32)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Int64 GetInt64(int i)
        {
            return (Int64)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public float GetFloat(int i)
        {
            return (float)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public double GetDouble(int i)
        {
            return (double)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string GetString(int i)
        {
            return (String)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public decimal GetDecimal(int i)
        {
            return (decimal)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public DateTime GetDateTime(int i)
        {
            return (DateTime)this.GetValue(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public IDataReader GetData(int i)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool IsDBNull(int i)
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        object IDataRecord.this[int i]
        {
            get { throw new NotSupportedException(); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object IDataRecord.this[string name]
        {
            get { throw new NotSupportedException(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Close()
        {
            Dispose();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetSchemaTable()
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool NextResult()
        {
            throw new NotSupportedException();
        }
        /// <summary>
        /// 
        /// </summary>
        public int Depth
        {
            get { throw new NotSupportedException(); }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsClosed
        {
            get { return _Records == null; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RecordsAffected
        {
            get { throw new NotSupportedException(); }
        }

        #endregion
    }
}
