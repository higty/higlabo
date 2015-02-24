using System;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Collections.Generic;
using HigLabo.Data;
using HigLabo.DbSharp;

namespace HigLabo.DbSharpSample.MySql
{
    public partial class identitytable : Table<identitytable.Record>
    {
        public const String Name = "identitytable";

        public override String TableName
        {
            get
            {
                return identitytable.Name;
            }
        }

        public override String GetDatabaseKey()
        {
            return "DbSharpSample_MySql";
        }
        public override Record CreateRecord()
        {
            return new Record();
        }
        protected override void SetRecordProperty(StoredProcedureResultSet resultSet, Record record)
        {
            record.SetProperty(resultSet as IRecord);
        }
        protected override void SetOutputParameterValue(Record record, StoredProcedure storedProcedure)
        {
            var spInsert = storedProcedure as identitytableInsert;
            if (spInsert != null)
            {
                record.IntColumn = spInsert.IntColumn;
                record.TimestampColumn = spInsert.TimestampColumn;
            }
            var spUpdate = storedProcedure as identitytableUpdate;
            if (spUpdate != null)
            {
                record.IntColumn = spUpdate.IntColumn;
                record.TimestampColumn = spUpdate.TimestampColumn;
            }
        }
        public Record SelectByPrimaryKey(Int32 intColumn)
        {
            return this.SelectByPrimaryKey(this.GetDatabase(), intColumn);
        }
        public Record SelectByPrimaryKeyOrNull(Int32 intColumn)
        {
            return this.SelectByPrimaryKeyOrNull(this.GetDatabase(), intColumn);
        }
        public Record SelectByPrimaryKey(Database database, Int32 intColumn)
        {
            var r = this.SelectByPrimaryKeyOrNull(database, intColumn);
            if (r == null) throw new TableRecordNotFoundException();
            return r;
        }
        public Record SelectByPrimaryKeyOrNull(Database database, Int32 intColumn)
        {
            var sp = new identitytableSelectByPrimaryKey();
            sp.PK_IntColumn = intColumn;
            var rs = sp.GetFirstResultSet(database);
            if (rs == null) return null;
            var r = new Record(rs);
            r.SetOldRecordProperty();
            return r;
        }
        public Int32 Delete(Int32 intColumn, DateTime timestampColumn)
        {
            return this.Delete(this.GetDatabase(), intColumn, timestampColumn);
        }
        public Int32 Delete(Database database, Int32 intColumn, DateTime timestampColumn)
        {
            var sp = new identitytableDelete();
            ((IDatabaseContext)sp).TransactionKey = this.TransactionKey;
            sp.PK_IntColumn = intColumn;
            sp.PK_TimestampColumn = timestampColumn;
            return sp.ExecuteNonQuery(database);
        }
        public override StoredProcedureWithResultSet CreateStoredProcedureWithResultSet(TableStoredProcedureTypeWithResultSet type, Record record)
        {
            switch (type)
            {
                case TableStoredProcedureTypeWithResultSet.SelectAll: return CreateSelectAllStoredProcedure();
                case TableStoredProcedureTypeWithResultSet.SelectByPrimaryKey: return this.CreateSelectByPrimaryKeyStoredProcedure(record);
                default: throw new InvalidOperationException();
            }
        }
        public override StoredProcedure CreateStoredProcedure(TableStoredProcedureType type, Record record)
        {
            switch (type)
            {
                case TableStoredProcedureType.Insert: return this.CreateInsertStoredProcedure(record);
                case TableStoredProcedureType.Update: return this.CreateUpdateStoredProcedure(record);
                case TableStoredProcedureType.Delete: return this.CreateDeleteStoredProcedure(record);
                default: throw new InvalidOperationException();
            }
        }
        public identitytableSelectAll CreateSelectAllStoredProcedure()
        {
            return new identitytableSelectAll();
        }
        public identitytableSelectByPrimaryKey CreateSelectByPrimaryKeyStoredProcedure(Record record)
        {
            var sp = new identitytableSelectByPrimaryKey();
            ((IDatabaseContext)sp).TransactionKey = this.TransactionKey;
            if (record == null) return sp;
            if (record.OldRecord == null) throw new OldRecordIsNullException();
            sp.PK_IntColumn = record.OldRecord.IntColumn;
            return sp;
        }
        public identitytableInsert CreateInsertStoredProcedure(Record record)
        {
            var sp = new identitytableInsert();
            ((IDatabaseContext)sp).TransactionKey = this.TransactionKey;
            if (record == null) return sp;
            sp.IntColumn = record.IntColumn;
            sp.TimestampColumn = record.TimestampColumn;
            sp.NVarCharColumn = record.NVarCharColumn;
            return sp;
        }
        public identitytableUpdate CreateUpdateStoredProcedure(Record record)
        {
            var sp = new identitytableUpdate();
            ((IDatabaseContext)sp).TransactionKey = this.TransactionKey;
            if (record == null) return sp;
            if (record.OldRecord == null) throw new OldRecordIsNullException();
            sp.IntColumn = record.IntColumn;
            sp.TimestampColumn = record.TimestampColumn;
            sp.NVarCharColumn = record.NVarCharColumn;
            sp.PK_IntColumn = record.OldRecord.IntColumn;
            sp.PK_TimestampColumn = record.OldRecord.TimestampColumn;
            return sp;
        }
        public identitytableDelete CreateDeleteStoredProcedure(Record record)
        {
            var sp = new identitytableDelete();
            ((IDatabaseContext)sp).TransactionKey = this.TransactionKey;
            if (record == null) return sp;
            if (record.OldRecord == null) throw new OldRecordIsNullException();
            sp.PK_IntColumn = record.OldRecord.IntColumn;
            sp.PK_TimestampColumn = record.OldRecord.TimestampColumn;
            return sp;
        }
        protected override DataTable CreateDataTable()
        {
            var dt = new DataTable(Name);
            dt.Columns.Add("@PK_IntColumn", typeof(Int32));
            dt.Columns.Add("@IntColumn", typeof(Int32));
            dt.Columns.Add("@TimestampColumn", typeof(DateTime));
            dt.Columns.Add("@NVarCharColumn", typeof(String));
            return dt;
        }
        protected override DataRow SetDataRow(DataRow dataRow, Record record, SaveMode saveMode)
        {
            if (saveMode != SaveMode.Insert)
            {
                if (record.OldRecord == null) throw new OldRecordIsNullException();
                dataRow["@PK_IntColumn"] = GetValueOrDBNull(record.OldRecord.IntColumn);
            }
            dataRow["@IntColumn"] = GetValueOrDBNull(record.IntColumn);
            dataRow["@TimestampColumn"] = GetValueOrDBNull(record.TimestampColumn);
            dataRow["@NVarCharColumn"] = GetValueOrDBNull(record.NVarCharColumn);
            return dataRow;
        }
    }
}
