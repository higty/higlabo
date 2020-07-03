using System;
using System.Collections.Generic;
using HigLabo.Data;

namespace HigLabo.DbSharp
{
    public interface ITable 
    {
        String TableName { get; }

        TableRecord CreateRecord();
        List<TableRecord> SelectAllRecords();
        List<TableRecord> SelectAllRecords(Database database);
        List<TableRecord> SelectAllRecords(TransactionContext context);
        TableRecord SelectByPrimaryKey(TableRecord record);
        TableRecord SelectByPrimaryKey(Database database, TableRecord record);
        TableRecord SelectByPrimaryKey(TransactionContext context, TableRecord record);
        Int32 Insert(TableRecord record);
        Int32 Update(TableRecord record);
        Int32 Delete(TableRecord record);
        Int32 Insert(Database database, TableRecord record);
        Int32 Update(Database database, TableRecord record);
        Int32 Delete(Database database, TableRecord record);
        Int32 Insert(TransactionContext context, TableRecord record);
        Int32 Update(TransactionContext context, TableRecord record);
        Int32 Delete(TransactionContext context, TableRecord record);
        Int32 Insert(IEnumerable<TableRecord> records);
        Int32 Update(IEnumerable<TableRecord> records);
        Int32 Delete(IEnumerable<TableRecord> records);
        Int32 Insert(Database database, IEnumerable<TableRecord> records);
        Int32 Update(Database database, IEnumerable<TableRecord> records);
        Int32 Delete(Database database, IEnumerable<TableRecord> records);
        Int32 Insert(TransactionContext context, IEnumerable<TableRecord> records);
        Int32 Update(TransactionContext context, IEnumerable<TableRecord> records);
        Int32 Delete(TransactionContext context, IEnumerable<TableRecord> records);
    }
}
