using HigLabo.Core;
using HigLabo.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public abstract class Table<T> : ITable, IDatabaseContext
        where T : TableRecord, new()
    {
        public abstract String TableName { get; }
        public String DatabaseKey { get; set; }

        public Table()
        {
        }
        public abstract T CreateRecord();
        protected abstract void SetRecordProperty(StoredProcedureResultSet source, T target);
        protected abstract void SetOutputParameterValue(T record, StoredProcedure storedProcedure);

        public List<T> SelectAll()
        {
            return this.SelectAll(this.GetDatabase());
        }
        public List<T> SelectAll(Database database)
        {
            var sp = CreateStoredProcedureWithResultSet();
            var l = new List<T>();
            foreach (var rs in sp.GetResultSets(database))
            {
                var r = new T();
                this.SetRecordProperty(rs, r);
                r.SetOldRecordProperty();
                l.Add(r);
            }
            return l;
        }
        public List<T> SelectAll(TransactionContext context)
        {
            return this.SelectAll(context.Database);
        }
        public T SelectByPrimaryKey(T record)
        {
            return this.SelectByPrimaryKey(this.GetDatabase(), record);
        }
        public T SelectByPrimaryKey(Database database, T record)
        {
            var r = this.SelectByPrimaryKeyOrNull(database, record);
            if (r == null) throw new TableRecordNotFoundException(this.TableName);
            return r;
        }
        public T SelectByPrimaryKey(TransactionContext context, T record)
        {
            return this.SelectByPrimaryKey(context.Database, record);
        }
        public T SelectByPrimaryKeyOrNull(T record)
        {
            return this.SelectByPrimaryKeyOrNull(this.GetDatabase(), record);
        }
        public T SelectByPrimaryKeyOrNull(Database database, T record)
        {
            var sp = CreateStoredProcedureWithResultSet(record);
            var rs = sp.GetFirstResultSet(database);
            if (rs == null) return null;
            var r = new T();
            SetRecordProperty(rs, r);
            r.SetOldRecordProperty();
            return r;
        }
        public T SelectByPrimaryKeyOrNull(TransactionContext context, T record)
        {
            return this.SelectByPrimaryKeyOrNull(context.Database, record);
        }
        public Int32 Insert(T record)
        {
            return this.Insert(this.GetDatabase(), record);
        }
        public Int32 Update(T record)
        {
            return this.Update(this.GetDatabase(), record);
        }
        public Int32 Delete(T record)
        {
            return this.Delete(this.GetDatabase(), record);
        }
        public Int32 Insert(Database database, T record)
        {
            if (record == null) throw new ArgumentNullException("record");
            var sp = this.CreateStoredProcedure(TableStoredProcedureType.Insert, record);
            var x = sp.ExecuteNonQuery(database);
            this.SetOutputParameterValue(record, sp);
            record.SetOldRecordProperty();
            return x;
        }
        public Int32 Insert(TransactionContext context, T record)
        {
            return this.Insert(context.Database, record);
        }
        public Int32 Update(Database database, T record)
        {
            if (record == null) throw new ArgumentNullException("record");
            record.EnsureOlderRecordProperty();
            var sp = this.CreateStoredProcedure(TableStoredProcedureType.Update, record);
            var x = sp.ExecuteNonQuery(database);
            this.SetOutputParameterValue(record, sp);
            record.SetOldRecordProperty();
            return x;
        }
        public Int32 Update(TransactionContext context, T record)
        {
            return this.Update(context.Database, record);
        }
        public Int32 Delete(Database database, T record)
        {
            if (record == null) throw new ArgumentNullException("record");
            record.EnsureOlderRecordProperty();
            var sp = this.CreateStoredProcedure(TableStoredProcedureType.Delete, record);
            var x = sp.ExecuteNonQuery(database);
            record.SetOldRecordProperty();
            return x;
        }
        public Int32 Delete(TransactionContext context, T record)
        {
            return this.Delete(context.Database, record);
        }
        public Int32 Insert(IEnumerable<T> records)
        {
            return this.Insert(this.GetDatabase(), records);
        }
        public Int32 Update(IEnumerable<T> records)
        {
            return this.Update(this.GetDatabase(), records);
        }
        public Int32 Delete(IEnumerable<T> records)
        {
            return this.Delete(this.GetDatabase(), records);
        }
        public Int32 Insert(Database database, IEnumerable<T> records)
        {
            var table = this;
            var db = database;
            var da = db.CreateDataAdapter();
            var dt = table.CreateDataTable();
            foreach (var r in records)
            {
                var row = table.SetDataRow(dt.NewRow(), r, SaveMode.Insert);
                dt.Rows.Add(row);
            }
            da.InsertCommand = CreateInsertCommand();
            da.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            return db.Save(da, dt);
        }
        public Int32 Insert(TransactionContext context, IEnumerable<T> records)
        {
            return this.Insert(context.Database, records);
        }
        public Int32 Update(Database database, IEnumerable<T> records)
        {
            var table = this;
            var db = database;
            var da = db.CreateDataAdapter();
            var dt = table.CreateDataTable();
            foreach (var r in records)
            {
                r.EnsureOlderRecordProperty();
                var row = table.SetDataRow(dt.NewRow(), r, SaveMode.Update);
                dt.Rows.Add(row);
                row.AcceptChanges();
                row.SetModified();
            }
            da.UpdateCommand = CreateUpdateCommand();
            da.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            return db.Save(da, dt);
        }
        public Int32 Update(TransactionContext context, IEnumerable<T> records)
        {
            return this.Update(context.Database, records);
        }
        public Int32 Delete(Database database, IEnumerable<T> records)
        {
            var table = this;
            var db = database;
            var da = db.CreateDataAdapter();
            var dt = table.CreateDataTable();
            foreach (var r in records)
            {
                r.EnsureOlderRecordProperty();
                var row = table.SetDataRow(dt.NewRow(), r, SaveMode.Delete);
                dt.Rows.Add(row);
                row.AcceptChanges();
                row.Delete();
            }
            da.DeleteCommand = CreateDeleteCommand();
            da.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            return db.Save(da, dt);
        }
        public Int32 Delete(TransactionContext context, IEnumerable<T> records)
        {
            return this.Delete(context.Database, records);
        }
        public Int32 Save(T record)
        {
            return this.Save(this.GetDatabase(), record);
        }
        public Int32 Save(Database database, T record)
        {
            var saveMode = ((ISaveMode)record).SaveMode;
            switch (saveMode)
            {
                case SaveMode.Unknown: return -1;
                case SaveMode.Insert: return this.Insert(database, record);
                case SaveMode.Update: return this.Update(database, record);
                case SaveMode.Delete: return this.Delete(database, record);
                default: throw new InvalidOperationException();
            }
        }
        public Int32 Save(TransactionContext context, T record)
        {
            return this.Save(context.Database, record);
        }
        public Int32 Save(IEnumerable<T> records)
        {
            return this.Save(this.GetDatabase(), records);
        }
        public Int32 Save(Database database, IEnumerable<T> records)
        {
            var table = this;
            var db = database;
            var da = db.CreateDataAdapter();
            var dt = table.CreateDataTable();
            foreach (var r in records.Where(r => ((ISaveMode)r).SaveMode != SaveMode.Unknown))
            {
                var saveMode = ((ISaveMode)r).SaveMode;
                if (saveMode == SaveMode.Update || saveMode == SaveMode.Delete)
                {
                    r.EnsureOlderRecordProperty();
                }
                var row = table.SetDataRow(dt.NewRow(), r);
                dt.Rows.Add(row);
                switch (saveMode)
                {
                    case SaveMode.Update:
                        row.AcceptChanges();
                        row.SetModified();
                        break;
                    case SaveMode.Delete:
                        row.AcceptChanges();
                        row.Delete();
                        break;
                }
            }
            da.InsertCommand = CreateInsertCommand();
            da.UpdateCommand = CreateUpdateCommand();
            da.DeleteCommand = CreateDeleteCommand();
            da.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
            da.UpdateCommand.UpdatedRowSource = UpdateRowSource.None;
            da.DeleteCommand.UpdatedRowSource = UpdateRowSource.None;
            return db.Save(da, dt);
        }
        public Int32 Save(TransactionContext context, IEnumerable<T> records)
        {
            return this.Save(context.Database, records);
        }

        TableRecord ITable.CreateRecord()
        {
            return this.CreateRecord() as TableRecord;
        }
        List<TableRecord> ITable.SelectAllRecords()
        {
            return this.SelectAll().Select(el => (TableRecord)el).ToList();
        }
        List<TableRecord> ITable.SelectAllRecords(Database database)
        {
            return this.SelectAll(database).Select(el => (TableRecord)el).ToList();
        }
        List<TableRecord> ITable.SelectAllRecords(TransactionContext context)
        {
            return (this as ITable).SelectAllRecords(context.Database);
        }
        TableRecord ITable.SelectByPrimaryKey(TableRecord record)
        {
            return this.SelectByPrimaryKey((T)record);
        }
        TableRecord ITable.SelectByPrimaryKey(Database database, TableRecord record)
        {
            return this.SelectByPrimaryKey(database, (T)record);
        }
        TableRecord ITable.SelectByPrimaryKey(TransactionContext context, TableRecord record)
        {
            return (this as ITable).SelectByPrimaryKey(context.Database, record);
        }
        Int32 ITable.Insert(TableRecord record)
        {
            return this.Insert((T)record);
        }
        Int32 ITable.Update(TableRecord record)
        {
            return this.Update((T)record);
        }
        Int32 ITable.Delete(TableRecord record)
        {
            return this.Delete((T)record);
        }
        Int32 ITable.Insert(Database database, TableRecord record)
        {
            return this.Insert(database, (T)record);
        }
        Int32 ITable.Insert(TransactionContext context, TableRecord record)
        {
            return (this as ITable).Insert(context.Database, record);
        }
        Int32 ITable.Update(Database database, TableRecord record)
        {
            return this.Update(database, (T)record);
        }
        Int32 ITable.Update(TransactionContext context, TableRecord record)
        {
            return (this as ITable).Update(context.Database, record);
        }
        Int32 ITable.Delete(Database database, TableRecord record)
        {
            return this.Delete(database, (T)record);
        }
        Int32 ITable.Delete(TransactionContext context, TableRecord record)
        {
            return (this as ITable).Delete(context.Database, record);
        }
        Int32 ITable.Insert(IEnumerable<TableRecord> records)
        {
            return this.Insert(this.GetDatabase(), records.Select(el => (T)el));
        }
        Int32 ITable.Update(IEnumerable<TableRecord> records)
        {
            return this.Update(this.GetDatabase(), records.Select(el => (T)el));
        }
        Int32 ITable.Delete(IEnumerable<TableRecord> records)
        {
            return this.Delete(this.GetDatabase(), records.Select(el => (T)el));
        }
        Int32 ITable.Insert(Database database, IEnumerable<TableRecord> records)
        {
            return this.Insert(database, records.Select(el => (T)el));
        }
        Int32 ITable.Insert(TransactionContext context, IEnumerable<TableRecord> records)
        {
            return (this as ITable).Insert(context.Database, records);
        }
        Int32 ITable.Update(Database database, IEnumerable<TableRecord> records)
        {
            return this.Update(database, records.Select(el => (T)el));
        }
        Int32 ITable.Update(TransactionContext context, IEnumerable<TableRecord> records)
        {
            return (this as ITable).Update(context.Database, records);
        }
        Int32 ITable.Delete(Database database, IEnumerable<TableRecord> records)
        {
            return this.Delete(database, records.Select(el => (T)el));
        }
        Int32 ITable.Delete(TransactionContext context, IEnumerable<TableRecord> records)
        {
            return (this as ITable).Delete(context.Database, records);
        }

        public StoredProcedureWithResultSet CreateStoredProcedureWithResultSet()
        {
            return CreateStoredProcedureWithResultSet(TableStoredProcedureTypeWithResultSet.SelectAll, null);
        }
        public StoredProcedureWithResultSet CreateStoredProcedureWithResultSet(T record)
        {
            return CreateStoredProcedureWithResultSet(TableStoredProcedureTypeWithResultSet.SelectByPrimaryKey, record);
        }
        public abstract StoredProcedureWithResultSet CreateStoredProcedureWithResultSet(TableStoredProcedureTypeWithResultSet type, T record);
        public abstract StoredProcedure CreateStoredProcedure(TableStoredProcedureType type, T record);

        protected internal abstract DataTable CreateDataTable();
        private DataRow SetDataRow(DataRow dataRow, T record)
        {
            return this.SetDataRow(dataRow, record, ((ISaveMode)record).SaveMode);
        }
        protected internal abstract DataRow SetDataRow(DataRow dataRow, T record, SaveMode saveMode);
        protected DbCommand CreateInsertCommand()
        {
            return this.CreateStoredProcedure(TableStoredProcedureType.Insert, null).CreateCommand();
        }
        protected DbCommand CreateUpdateCommand()
        {
            return this.CreateStoredProcedure(TableStoredProcedureType.Update, null).CreateCommand();
        }
        protected DbCommand CreateDeleteCommand()
        {
            return this.CreateStoredProcedure(TableStoredProcedureType.Delete, null).CreateCommand();
        }
        protected static Object GetValueOrDBNull(Object value)
        {
            if (value == null) return DBNull.Value;
            return value;
        }
    }
}
