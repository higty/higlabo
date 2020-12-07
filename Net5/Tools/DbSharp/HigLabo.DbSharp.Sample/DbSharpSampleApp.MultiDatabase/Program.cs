using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.DbSharpSample.SqlServer;
using HigLabo.DbSharpSample.MySql;
using HigLabo.Data;
using HigLabo.DbSharp;
using Microsoft.SqlServer.Types;
using System.Data;
using MySql.Data.Types;

namespace HigLaboSampleApp.MultiDatabase
{
    class Program
    {
        private static String DatabaseKey_SqlServer = "DbSharpSample_SqlServer";
        private static String DatabaseKey_MySql = "DbSharpSample_MySql";
        private static String DatabaseKey_Postgres = "DatabaseKey_Postgres";
        private static String DatabaseKey_Oracle = "DatabaseKey_Oracle";

        static void Main(string[] args)
        {
            var ss = Environment.GetCommandLineArgs();
            DatabaseFactory.Current.SetCreateDatabaseMethod(DatabaseKey_SqlServer, () => new SqlServerDatabase(ss[1]));
            DatabaseFactory.Current.SetCreateDatabaseMethod(DatabaseKey_MySql, () => new MySqlDatabase(ss[2]));

            try
            {
                //CrudOperationTest_SqlServer();
                //CrudOperationTest_SqlServer_Azure();
                //CrudOperationTest_MySql();
            }
            catch (DbSharpTestFailureException)
            {
                Console.WriteLine("Test failed");
            }
            catch (DatabaseException)
            {
                Console.WriteLine("Test failed");
            }
            Console.WriteLine("All test done!");
            Console.Read();
        }
 
        private static void OutputTestResult(String text, Boolean success)
        {
            if (success == true)
            {
                Console.WriteLine("○ " + text);
            }
            else
            {
                Console.WriteLine("× " + text);
                throw new DbSharpTestFailureException();
            }
        }
        private static void CrudOperationTest_SqlServer()
        {
            var db = DatabaseFactory.Current.CreateDatabase(DatabaseKey_SqlServer);
            var deleted = db.ExecuteCommand("Delete AllDataTypeTable");
            OutputTestResult("Query: Delete AllDataTypeTable", true);

            using (TransactionContext tx = new TransactionContext(DatabaseFactory.Current.CreateDatabase(DatabaseKey_SqlServer)))
            {
                tx.BeginTransaction(IsolationLevel.ReadCommitted);
                for (int i = 0; i < 3; i++)
                {
                    var sp = InsertRecord_SqlServer(i);
                    var inserted = sp.ExecuteNonQuery(tx);
                    OutputTestResult("AllDataTypeTableInsert with transaction", inserted == 1);
                }
                tx.CommitTransaction();
            }
            var t = new AllDataTypeTable();
            var r = t.SelectByPrimaryKey(1);
            r.PrimaryKeyColumn = 11;
            var x1 = t.Insert(r);
            OutputTestResult("AllDataTypeTable.Insert", x1 == 1);

            r = t.SelectByPrimaryKey(11);
            r.PrimaryKeyColumn = 12;
            var x2 = t.Update(r);
            OutputTestResult("AllDataTypeTable.Update", x2 == 1);

            var x3 = t.Delete(12, r.TimestampColumn);
            OutputTestResult("AllDataTypeTable.Delete", x3 == 1);
        }
        private static StoredProcedure InsertRecord_SqlServer(Int32 primaryKeyColumnValue)
        {
            var sp = new AllDataTypeTableInsert();
            sp.PrimaryKeyColumn = primaryKeyColumnValue;
            sp.TimestampColumn = new Byte[] { 1, 2, 3, };

            sp.BigIntColumn = 1;
            sp.BinaryColumn = null;
            sp.BitColumn = true;
            sp.CharColumn = "Char";
            sp.DateColumn = DateTime.Now;
            sp.DateTime2Column = DateTime.Now;
            sp.DateTimeColumn = DateTime.Now;
            sp.DateTimeOffsetColumn = DateTime.Now;
            sp.DecimalColumn = 0;
            sp.FloatColumn = 3;
            sp.ImageColumn = new Byte[0];
            sp.IntColumn = 14;
            sp.MoneyColumn = 122;
            sp.NCharColumn = "NChar";
            sp.NTextColumn = "NText";
            sp.NVarCharColumn = "NVarChar";
            sp.RealColumn = 100;
            sp.SmallDateTimeColumn = new DateTime(2013, 2, 2);
            sp.SmallIntColumn = 2;
            sp.SmallMoneyColumn = 200;
            switch (primaryKeyColumnValue % 4)
            {
                case 0: sp.SqlVariantColumn = 1; break;
                case 1: sp.SqlVariantColumn = "Variant1"; break;
                case 2: sp.SqlVariantColumn = DateTime.Now; break;
                case 3: sp.SqlVariantColumn = true; break;
            }
            sp.TextColumn = "Text";
            sp.TimeColumn = new TimeSpan(9, 0, 0);
            sp.TinyIntColumn = 3;
            sp.UniqueIdentifierColumn = Guid.NewGuid();
            sp.VarBinaryColumn = new Byte[] { 1, 2, 3, 4 };
            sp.VarCharColumn = "VarChar";
            sp.XmlColumn = "<xml></xml>";

            sp.GeometryColumn = SqlGeometry.Point(137, 42, 4320);
            sp.GeographyColumn = SqlGeography.Point(42, 135, 4326);
            sp.HierarchyIDColumn = SqlHierarchyId.Parse("/1/2/" + primaryKeyColumnValue + "/");

            sp.EnumColumn = HigLabo.DbSharpSample.SqlServer.MyEnum.Value1;

            sp.NotNullBigIntColumn = 1;
            sp.NotNullBinaryColumn = new Byte[] { 3, 2, 7 };
            sp.NotNullBitColumn = true;
            sp.NotNullCharColumn = "Char";
            sp.NotNullDateColumn = DateTime.Now;
            sp.NotNullDateTime2Column = DateTime.Now;
            sp.NotNullDateTimeColumn = DateTime.Now;
            sp.NotNullDateTimeOffsetColumn = DateTime.Now;
            sp.NotNullDecimalColumn = 0;
            sp.NotNullFloatColumn = 3;
            sp.NotNullImageColumn = new Byte[0];
            sp.NotNullIntColumn = 14;
            sp.NotNullMoneyColumn = 122;
            sp.NotNullNCharColumn = "NChar";
            sp.NotNullNTextColumn = "NText";
            sp.NotNullNVarCharColumn = "NVarChar";
            sp.NotNullRealColumn = 100;
            sp.NotNullSmallDateTimeColumn = new DateTime(2013, 2, 2);
            sp.NotNullSmallIntColumn = 2;
            sp.NotNullSmallMoneyColumn = 200;
            switch (primaryKeyColumnValue % 4)
            {
                case 0: sp.NotNullSqlVariantColumn = 1; break;
                case 1: sp.NotNullSqlVariantColumn = "Variant1"; break;
                case 2: sp.NotNullSqlVariantColumn = DateTime.Now; break;
                case 3: sp.NotNullSqlVariantColumn = true; break;
            }
            sp.NotNullTextColumn = "Text";
            sp.NotNullTimeColumn = new TimeSpan(9, 0, 0);
            sp.NotNullTinyIntColumn = 3;
            sp.NotNullUniqueIdentifierColumn = Guid.NewGuid();
            sp.NotNullVarBinaryColumn = new Byte[] { 1, 2, 3, 4 };
            sp.NotNullVarCharColumn = "VarChar";
            sp.NotNullXmlColumn = "<xml></xml>";

            sp.NotNullGeometryColumn = SqlGeometry.Point(137, 42, 4320);
            sp.NotNullGeographyColumn = SqlGeography.Point(42, 135, 4326);
            sp.NotNullHierarchyIDColumn = SqlHierarchyId.Parse("/1/2/" + primaryKeyColumnValue + "/");

            sp.NotNullEnumColumn = HigLabo.DbSharpSample.SqlServer.MyEnum.Value1;

            return sp;
        }
        private static void CrudOperationTest_SqlServer_Azure()
        {
            var db = DatabaseFactory.Current.CreateDatabase(DatabaseKey_SqlServer);
            var deleted = db.ExecuteCommand("Delete AllDataTypeTable_Azure");
            OutputTestResult("Query: Delete AllDataTypeTable_Azure", true);

            using (TransactionContext tx = new TransactionContext(DatabaseFactory.Current.CreateDatabase(DatabaseKey_SqlServer)))
            {
                tx.BeginTransaction(IsolationLevel.ReadCommitted);
                for (int i = 0; i < 3; i++)
                {
                    var sp = InsertRecord_SqlServer_Azure(i);
                    var inserted = sp.ExecuteNonQuery(tx);
                    OutputTestResult("AllDataTypeTable_AzureInsert with transaction", inserted == 1);
                }
                tx.CommitTransaction();
            }
            var t = new AllDataTypeTable_Azure();
            var r = t.SelectByPrimaryKey(1);
            r.PrimaryKeyColumn = 11;
            var x1 = t.Insert(r);
            OutputTestResult("AllDataTypeTable_Azure.Insert", x1 == 1);

            r = t.SelectByPrimaryKey(11);
            r.PrimaryKeyColumn = 12;
            var x2 = t.Update(r);
            OutputTestResult("AllDataTypeTable_Azure.Update", x2 == 1);

            var x3 = t.Delete(12, r.TimestampColumn);
            OutputTestResult("AllDataTypeTable_Azure.Delete", x3 == 1);
        }
        private static StoredProcedure InsertRecord_SqlServer_Azure(Int32 primaryKeyColumnValue)
        {
            var sp = new AllDataTypeTable_AzureInsert();
            sp.PrimaryKeyColumn = primaryKeyColumnValue;
            sp.TimestampColumn = new Byte[] { 1, 2, 3, };

            sp.BigIntColumn = 1;
            sp.BinaryColumn = null;
            sp.BitColumn = true;
            sp.CharColumn = "Char";
            sp.DateColumn = DateTime.Now;
            sp.DateTime2Column = DateTime.Now;
            sp.DateTimeColumn = DateTime.Now;
            sp.DateTimeOffsetColumn = DateTime.Now;
            sp.DecimalColumn = 0;
            sp.FloatColumn = 3;
            sp.ImageColumn = new Byte[0];
            sp.IntColumn = 14;
            sp.MoneyColumn = 122;
            sp.NCharColumn = "NChar";
            sp.NTextColumn = "NText";
            sp.NVarCharColumn = "NVarChar";
            sp.RealColumn = 100;
            sp.SmallDateTimeColumn = new DateTime(2013, 2, 2);
            sp.SmallIntColumn = 2;
            sp.SmallMoneyColumn = 200;
            switch (primaryKeyColumnValue % 4)
            {
                case 0: sp.SqlVariantColumn = 1; break;
                case 1: sp.SqlVariantColumn = "Variant1"; break;
                case 2: sp.SqlVariantColumn = DateTime.Now; break;
                case 3: sp.SqlVariantColumn = true; break;
            }
            sp.TextColumn = "Text";
            sp.TimeColumn = new TimeSpan(9, 0, 0);
            sp.TinyIntColumn = 3;
            sp.UniqueIdentifierColumn = Guid.NewGuid();
            sp.VarBinaryColumn = new Byte[] { 1, 2, 3, 4 };
            sp.VarCharColumn = "VarChar";
            sp.XmlColumn = "<xml></xml>";

            sp.EnumColumn = HigLabo.DbSharpSample.SqlServer.MyEnum.Value1;

            sp.NotNullBigIntColumn = 1;
            sp.NotNullBinaryColumn = new Byte[] { 3, 2, 7 };
            sp.NotNullBitColumn = true;
            sp.NotNullCharColumn = "Char";
            sp.NotNullDateColumn = DateTime.Now;
            sp.NotNullDateTime2Column = DateTime.Now;
            sp.NotNullDateTimeColumn = DateTime.Now;
            sp.NotNullDateTimeOffsetColumn = DateTime.Now;
            sp.NotNullDecimalColumn = 0;
            sp.NotNullFloatColumn = 3;
            sp.NotNullImageColumn = new Byte[0];
            sp.NotNullIntColumn = 14;
            sp.NotNullMoneyColumn = 122;
            sp.NotNullNCharColumn = "NChar";
            sp.NotNullNTextColumn = "NText";
            sp.NotNullNVarCharColumn = "NVarChar";
            sp.NotNullRealColumn = 100;
            sp.NotNullSmallDateTimeColumn = new DateTime(2013, 2, 2);
            sp.NotNullSmallIntColumn = 2;
            sp.NotNullSmallMoneyColumn = 200;
            switch (primaryKeyColumnValue % 4)
            {
                case 0: sp.NotNullSqlVariantColumn = 1; break;
                case 1: sp.NotNullSqlVariantColumn = "Variant1"; break;
                case 2: sp.NotNullSqlVariantColumn = DateTime.Now; break;
                case 3: sp.NotNullSqlVariantColumn = true; break;
            }
            sp.NotNullTextColumn = "Text";
            sp.NotNullTimeColumn = new TimeSpan(9, 0, 0);
            sp.NotNullTinyIntColumn = 3;
            sp.NotNullUniqueIdentifierColumn = Guid.NewGuid();
            sp.NotNullVarBinaryColumn = new Byte[] { 1, 2, 3, 4 };
            sp.NotNullVarCharColumn = "VarChar";
            sp.NotNullXmlColumn = "<xml></xml>";

            sp.NotNullEnumColumn = HigLabo.DbSharpSample.SqlServer.MyEnum.Value1;

            return sp;
        }

        private static void CrudOperationTest_MySql()
        {

            var db = DatabaseFactory.Current.CreateDatabase(DatabaseKey_MySql);
            var deleted = db.ExecuteCommand("Delete From AllDataTypeTable");
            OutputTestResult("Query: Delete AllDataTypeTable", true);

            using (TransactionContext tx = new TransactionContext(DatabaseFactory.Current.CreateDatabase(DatabaseKey_MySql)))
            {
                tx.BeginTransaction(IsolationLevel.ReadCommitted);
                for (int i = 0; i < 3; i++)
                {
                    var sp = InsertRecord_MySql(i);
                    var inserted = sp.ExecuteNonQuery(tx);
                    OutputTestResult("AllDataTypeTableInsert with transaction", inserted == 1);
                }
                tx.CommitTransaction();
            }
            var t = new alldatatypetable();
            var r = t.SelectByPrimaryKey(1);
            r.PrimaryKeyColumn = 11;
            var x1 = t.Insert(r);
            OutputTestResult("AllDataTypeTable.Insert", x1 == 1);

            r = t.SelectByPrimaryKey(11);
            r.PrimaryKeyColumn = 12;
            var x2 = t.Update(r);
            OutputTestResult("AllDataTypeTable.Update", x2 == 1);

            var x3 = t.Delete(12, r.TimestampColumn);
            OutputTestResult("AllDataTypeTable.Delete", x3 == 1);
        }
        private static StoredProcedure InsertRecord_MySql(Int32 primaryKeyColumnValue)
        {
            var sp = new alldatatypetableInsert();
            sp.PrimaryKeyColumn = primaryKeyColumnValue;
            sp.TimestampColumn = new DateTime(2016, 1, 1);

            sp.CharColumn = "Char";
            sp.VarCharColumn = "VarChar";
            sp.BitColumn = true;
            sp.TinyIntColumn = -12;
            sp.SmallIntColumn = -3456;
            sp.MediumIntColumn = -12345;
            sp.IntColumn = -123456;
            sp.BigIntColumn = -1234567890;
            sp.TinyIntUnsignedColumn = 12;
            sp.SmallIntUnsignedColumn = 3456;
            sp.MediumIntUnsignedColumn = 12345;
            sp.IntUnsignedColumn = 123456;
            sp.BigIntUnsignedColumn = 1234567890;
            sp.FloatColumn = 12.345f;
            sp.DoubleColumn = 1234.56;
            sp.DecimalColumn = 1234.56m;
            sp.NumericColumn = 123.45m;
            sp.DateColumn = new DateTime(2014, 4, 4);
            sp.DateTimeColumn = new DateTime(2014, 4, 4);
            sp.TimeColumn = new TimeSpan(2, 30, 40);
            sp.YearColumn = 2020;
            sp.BinaryColumn = CreateBytes(1);
            sp.VarBinaryColumn = CreateBytes(10);
            sp.TinyBlobColumn = CreateBytes(123);
            sp.MediumBlobColumn = CreateBytes(123);
            sp.BlobColumn = CreateBytes(1234);
            sp.LongBlobColumn = CreateBytes(12345);
            sp.TinyTextColumn = "TinyText";
            sp.MediumTextColumn = "MediumText";
            sp.TextColumn = "Text";
            sp.LongTextColumn = "LongText";
            sp.GeometryColumn = new MySqlGeometry(137, 42, 4320);
            sp.EnumColumn = HigLabo.DbSharpSample.MySql.MyEnum.Value1;
            sp.SetColumn = MySet.Value0;

            sp.NotNullCharColumn = "Char";
            sp.NotNullVarCharColumn = "VarChar";
            sp.NotNullBitColumn = true;
            sp.NotNullTinyIntColumn = -12;
            sp.NotNullSmallIntColumn = -3456;
            sp.NotNullMediumIntColumn = -12345;
            sp.NotNullIntColumn = -123456;
            sp.NotNullBigIntColumn = -1234567890;
            sp.NotNullTinyIntUnsignedColumn = 12;
            sp.NotNullSmallIntUnsignedColumn = 3456;
            sp.NotNullMediumIntUnsignedColumn = 12345;
            sp.NotNullIntUnsignedColumn = 123456;
            sp.NotNullBigIntUnsignedColumn = 1234567890;
            sp.NotNullFloatColumn = 12.345f;
            sp.NotNullDoubleColumn = 1234.56;
            sp.NotNullDecimalColumn = 1234.56m;
            sp.NotNullNumericColumn = 123.456m;
            sp.NotNullDateColumn = new DateTime(2014, 4, 4);
            sp.NotNullDateTimeColumn = new DateTime(2014, 4, 4);
            sp.NotNullTimeColumn = new TimeSpan(2, 30, 40);
            sp.NotNullYearColumn = 2020;
            sp.NotNullBinaryColumn = CreateBytes(1);
            sp.NotNullVarBinaryColumn = CreateBytes(10);
            sp.NotNullTinyBlobColumn = CreateBytes(123);
            sp.NotNullMediumBlobColumn = CreateBytes(123);
            sp.NotNullBlobColumn = CreateBytes(1234);
            sp.NotNullLongBlobColumn = CreateBytes(12345);
            sp.NotNullTinyTextColumn = "TinyText";
            sp.NotNullMediumTextColumn = "MediumText";
            sp.NotNullTextColumn = "Text";
            sp.NotNullLongTextColumn = "LongText";
            sp.NotNullGeometryColumn = new MySqlGeometry(137, 42, 4320);
            sp.NotNullEnumColumn = HigLabo.DbSharpSample.MySql.MyEnum.Value1;
            sp.NotNullSetColumn = MySet.Value0;

            return sp;
        }
        private static Byte[] CreateBytes(Int32 length)
        {
            var bb = new Byte[length];
            for (int i = 0; i < length; i++)
            {
                bb[i] = (Byte)(i % 256);
            }
            return bb;
        }

        public class DbSharpTestFailureException : Exception
        {
        }
    }
}
