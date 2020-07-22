using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Types;
using HigLabo.Data;
using HigLabo.DbSharp;
using HigLabo.DbSharpSample.MySql;
using System.Data;
using System.IO;
using System.Globalization;

namespace HigLaboSampleApp.MySql
{
    class Program
    {
        private static String DatabaseKey = "DbSharpSample_MySql";
        static void Main(string[] args)
        {
            var ss = Environment.GetCommandLineArgs();
            DatabaseFactory.Current.SetCreateDatabaseMethod(DatabaseKey, () => new MySqlDatabase(ss[1]));
            try
            {
                InsertAutoIncrementColumnTest();
                CrudOperationTest();
                SetOutputParameterTest();
            }
            catch (DbSharpTestFailureException)
            {
                Console.WriteLine("Test failed");
            }
            catch (DatabaseException)
            {
                Console.WriteLine("Test failed");
            }
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
        private static void CrudOperationTest()
        {

            var db = CreateDatabase();
            var deleted = db.ExecuteCommand("Delete From AllDataTypeTable");
            OutputTestResult("Query: Delete AllDataTypeTable", true);

            using (TransactionContext tx = new TransactionContext(CreateDatabase()))
            {
                tx.BeginTransaction(IsolationLevel.ReadCommitted);
                for (int i = 0; i < 3; i++)
                {
                    var inserted = InsertRecord(i);
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
        private static Int32 InsertRecord(Int32 primaryKeyColumnValue)
        {
            var sp = new alldatatypetableInsert();
            sp.PrimaryKeyColumn = primaryKeyColumnValue;
            sp.TimestampColumn = new DateTime(2000, 1, 1);

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
            sp.MediumTextColumn ="MediumText";
            sp.TextColumn = "Text";
            sp.LongTextColumn = "LongText";
            sp.GeometryColumn = new MySqlGeometry(137, 42, 4320);
            sp.EnumColumn = MyEnum.Value1;
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
            sp.NotNullEnumColumn = MyEnum.Value1;
            sp.NotNullSetColumn = MySet.Value0;

            var x = sp.ExecuteNonQuery();
            return x;
        }
        private static void SetOutputParameterTest()
        {
            var sp = new Usp_OutputParameter();
            sp.BigIntColumn = DateTime.Now.Millisecond;
            sp.BinaryColumn = null;
            sp.BitColumn = false;
            sp.CharColumn = "Char";
            sp.DateColumn = DateTime.Now;
            sp.DateTimeColumn = DateTime.Now;
            sp.DecimalColumn = 0;
            sp.FloatColumn = 3;
            sp.IntColumn = 14;
            sp.NCharColumn = "NChar";
            sp.NVarCharColumn = "NVarChar";
            sp.SmallIntColumn = 2;
            sp.TextColumn = "Text";
            sp.TimeColumn = new TimeSpan(9, 0, 0);
            sp.TinyIntColumn = 3;
            sp.VarBinaryColumn = new Byte[] { 1, 2, 3, 4 };
            sp.VarCharColumn = "VarChar";
            sp.EnumColumn = MyEnum.Default;
            sp.SetColumn = MySet.Value1;

            var oldBigIntColumnValue = sp.BigIntColumn;
            var oldSmallIntColumnValue = sp.SmallIntColumn;

            var x = sp.ExecuteNonQuery();
            OutputTestResult("SetOutputParameter.BigIntColumn must be incremented +1", oldBigIntColumnValue + 1 == sp.BigIntColumn);
            OutputTestResult("SetOutputParameter.SmallIntColumn must be incremented +1", oldSmallIntColumnValue + 1 == sp.SmallIntColumn);
        }
        private static void InsertAutoIncrementColumnTest()
        {
            var db = CreateDatabase();
            var x = db.ExecuteCommand("Delete from IdentityTable");

            OutputTestResult("Query: Delete IdentityTable", true);

            Int32 pk = 0;
            for (int i = 0; i < 3; i++)
            {
                var sp = new identitytableInsert();
                sp.NVarCharColumn = "NVarChar";
                var x1 = sp.ExecuteNonQuery();
                pk = sp.IntColumn;
                OutputTestResult("IdentityTable.Insert", x1 == 1);
            }
            var t = new identitytable();
            var r = t.SelectByPrimaryKey(pk);
            r.NVarCharColumn = "New NVarChar2";
            var x2 = t.Update(r);
            OutputTestResult("IdentityTable.Update", x2 == 1);

            var x3 = t.Delete(r);
            OutputTestResult("IdentityTable.Delete", x3 == 1);
        }
        private static Byte[] CreateBytes(Int32 length)
        {
            var bb = new Byte[length];
            for (int i = 0; i < length; i++)
            {
                bb[i] = (Byte) (i % 256);
            }
            return bb;
        }
        private static Database CreateDatabase()
        {
            return DatabaseFactory.Current.CreateDatabase(DatabaseKey);
        }

        public class DbSharpTestFailureException : Exception
        {
        }
    }
}


