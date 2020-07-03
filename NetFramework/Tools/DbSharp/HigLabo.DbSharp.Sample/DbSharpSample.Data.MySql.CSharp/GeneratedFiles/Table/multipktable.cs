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
    public partial class multipktable : Table<multipktable.Record>
    {
        public const String Name = "multipktable";

        public override String TableName
        {
            get
            {
                return multipktable.Name;
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
            var spInsert = storedProcedure as multipktableInsert;
            if (spInsert != null)
            {
                record.TimestampColumn = spInsert.TimestampColumn;
            }
            var spUpdate = storedProcedure as multipktableUpdate;
            if (spUpdate != null)
            {
                record.TimestampColumn = spUpdate.TimestampColumn;
            }
        }
        public Record SelectByPrimaryKey(Int64 bigIntColumn, Int32 intColumn, Single floatColumn)
        {
            return this.SelectByPrimaryKey(this.GetDatabase(), bigIntColumn, intColumn, floatColumn);
        }
        public Record SelectByPrimaryKeyOrNull(Int64 bigIntColumn, Int32 intColumn, Single floatColumn)
        {
            return this.SelectByPrimaryKeyOrNull(this.GetDatabase(), bigIntColumn, intColumn, floatColumn);
        }
        public Record SelectByPrimaryKey(Database database, Int64 bigIntColumn, Int32 intColumn, Single floatColumn)
        {
            var r = this.SelectByPrimaryKeyOrNull(database, bigIntColumn, intColumn, floatColumn);
            if (r == null) throw new TableRecordNotFoundException();
            return r;
        }
        public Record SelectByPrimaryKeyOrNull(Database database, Int64 bigIntColumn, Int32 intColumn, Single floatColumn)
        {
            var sp = new multipktableSelectByPrimaryKey();
            sp.PK_BigIntColumn = bigIntColumn;
            sp.PK_IntColumn = intColumn;
            sp.PK_FloatColumn = floatColumn;
            var rs = sp.GetFirstResultSet(database);
            if (rs == null) return null;
            var r = new Record(rs);
            r.SetOldRecordProperty();
            return r;
        }
        public Int32 Delete(Int64 bigIntColumn, Int32 intColumn, Single floatColumn, DateTime timestampColumn)
        {
            return this.Delete(this.GetDatabase(), bigIntColumn, intColumn, floatColumn, timestampColumn);
        }
        public Int32 Delete(Database database, Int64 bigIntColumn, Int32 intColumn, Single floatColumn, DateTime timestampColumn)
        {
            var sp = new multipktableDelete();
            ((IDatabaseContext)sp).TransactionKey = this.TransactionKey;
            sp.PK_BigIntColumn = bigIntColumn;
            sp.PK_IntColumn = intColumn;
            sp.PK_FloatColumn = floatColumn;
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
        public multipktableSelectAll CreateSelectAllStoredProcedure()
        {
            return new multipktableSelectAll();
        }
        public multipktableSelectByPrimaryKey CreateSelectByPrimaryKeyStoredProcedure(Record record)
        {
            var sp = new multipktableSelectByPrimaryKey();
            ((IDatabaseContext)sp).TransactionKey = this.TransactionKey;
            if (record == null) return sp;
            if (record.OldRecord == null) throw new OldRecordIsNullException();
            sp.PK_BigIntColumn = record.OldRecord.BigIntColumn;
            sp.PK_IntColumn = record.OldRecord.IntColumn;
            sp.PK_FloatColumn = record.OldRecord.FloatColumn;
            return sp;
        }
        public multipktableInsert CreateInsertStoredProcedure(Record record)
        {
            var sp = new multipktableInsert();
            ((IDatabaseContext)sp).TransactionKey = this.TransactionKey;
            if (record == null) return sp;
            sp.BigIntColumn = record.BigIntColumn;
            sp.IntColumn = record.IntColumn;
            sp.FloatColumn = record.FloatColumn;
            sp.BinaryColumn = record.BinaryColumn;
            sp.TimestampColumn = record.TimestampColumn;
            sp.VarBinaryColumn = record.VarBinaryColumn;
            sp.BitColumn = record.BitColumn;
            sp.NCharColumn = record.NCharColumn;
            sp.NVarCharColumn = record.NVarCharColumn;
            return sp;
        }
        public multipktableUpdate CreateUpdateStoredProcedure(Record record)
        {
            var sp = new multipktableUpdate();
            ((IDatabaseContext)sp).TransactionKey = this.TransactionKey;
            if (record == null) return sp;
            if (record.OldRecord == null) throw new OldRecordIsNullException();
            sp.BigIntColumn = record.BigIntColumn;
            sp.IntColumn = record.IntColumn;
            sp.FloatColumn = record.FloatColumn;
            sp.BinaryColumn = record.BinaryColumn;
            sp.TimestampColumn = record.TimestampColumn;
            sp.VarBinaryColumn = record.VarBinaryColumn;
            sp.BitColumn = record.BitColumn;
            sp.NCharColumn = record.NCharColumn;
            sp.NVarCharColumn = record.NVarCharColumn;
            sp.PK_BigIntColumn = record.OldRecord.BigIntColumn;
            sp.PK_IntColumn = record.OldRecord.IntColumn;
            sp.PK_FloatColumn = record.OldRecord.FloatColumn;
            sp.PK_TimestampColumn = record.OldRecord.TimestampColumn;
            return sp;
        }
        public multipktableDelete CreateDeleteStoredProcedure(Record record)
        {
            var sp = new multipktableDelete();
            ((IDatabaseContext)sp).TransactionKey = this.TransactionKey;
            if (record == null) return sp;
            if (record.OldRecord == null) throw new OldRecordIsNullException();
            sp.PK_BigIntColumn = record.OldRecord.BigIntColumn;
            sp.PK_IntColumn = record.OldRecord.IntColumn;
            sp.PK_FloatColumn = record.OldRecord.FloatColumn;
            sp.PK_TimestampColumn = record.OldRecord.TimestampColumn;
            return sp;
        }
        protected override DataTable CreateDataTable()
        {
            var dt = new DataTable(Name);
            dt.Columns.Add("@PK_BigIntColumn", typeof(Int64));
            dt.Columns.Add("@PK_IntColumn", typeof(Int32));
            dt.Columns.Add("@PK_FloatColumn", typeof(Single));
            dt.Columns.Add("@BigIntColumn", typeof(Int64));
            dt.Columns.Add("@IntColumn", typeof(Int32));
            dt.Columns.Add("@FloatColumn", typeof(Single));
            dt.Columns.Add("@BinaryColumn", typeof(Byte[]));
            dt.Columns.Add("@TimestampColumn", typeof(DateTime));
            dt.Columns.Add("@VarBinaryColumn", typeof(Byte[]));
            dt.Columns.Add("@BitColumn", typeof(Boolean));
            dt.Columns.Add("@NCharColumn", typeof(String));
            dt.Columns.Add("@NVarCharColumn", typeof(String));
            return dt;
        }
        protected override DataRow SetDataRow(DataRow dataRow, Record record, SaveMode saveMode)
        {
            if (saveMode != SaveMode.Insert)
            {
                if (record.OldRecord == null) throw new OldRecordIsNullException();
                dataRow["@PK_BigIntColumn"] = GetValueOrDBNull(record.OldRecord.BigIntColumn);
                dataRow["@PK_IntColumn"] = GetValueOrDBNull(record.OldRecord.IntColumn);
                dataRow["@PK_FloatColumn"] = GetValueOrDBNull(record.OldRecord.FloatColumn);
            }
            dataRow["@BigIntColumn"] = GetValueOrDBNull(record.BigIntColumn);
            dataRow["@IntColumn"] = GetValueOrDBNull(record.IntColumn);
            dataRow["@FloatColumn"] = GetValueOrDBNull(record.FloatColumn);
            dataRow["@BinaryColumn"] = GetValueOrDBNull(record.BinaryColumn);
            dataRow["@TimestampColumn"] = GetValueOrDBNull(record.TimestampColumn);
            dataRow["@VarBinaryColumn"] = GetValueOrDBNull(record.VarBinaryColumn);
            dataRow["@BitColumn"] = GetValueOrDBNull(record.BitColumn);
            dataRow["@NCharColumn"] = GetValueOrDBNull(record.NCharColumn);
            dataRow["@NVarCharColumn"] = GetValueOrDBNull(record.NVarCharColumn);
            return dataRow;
        }
    }
}
