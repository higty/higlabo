using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Types;
using HigLabo.Data;
using HigLabo.DbSharp;
using HigLabo.DbSharpSample.SqlServer;
using System.Data;
using System.IO;
using System.Globalization;

namespace HigLabo.DbSharp.GeneratedFilesApplication
{
    class Program
    {
        private static String DatabaseKey = "DbSharpSample_SqlServer";
        static void Main(string[] args)
        {
            var ss = Environment.GetCommandLineArgs();
            DatabaseFactory.Current.SetCreateDatabaseMethod(DatabaseKey, () => new SqlServerDatabase(ss[1]));

            try
            {
                CrudOperationTest();
                Usp_StructureTest();
                SetOutputParameterTest();
                InsertAutoIncrementColumnTest();
                InsertRowGuidColumnTest();
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
            var deleted = db.ExecuteCommand("Delete AllDataTypeTable");
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
        private static Int32 InsertRecord(Int32 primaryKeyColumnValue)
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

            sp.EnumColumn = MyEnum.Value1;

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

            sp.NotNullEnumColumn = MyEnum.Value1;

            var x = sp.ExecuteNonQuery();
            return x;
        }
        private static void Usp_StructureTest()
        {
            var sp = new Usp_Structure();
            sp.BigIntColumn = 1;
            var l = sp.StructuredColumn.Records;
            l.Add(new MyTableType.Record()
            {
                BigIntColumn = 1,
                EnumColumn = MyEnum.Default
            });
            l.Add(new MyTableType.Record()
            {
                BigIntColumn = 2,
                EnumColumn = MyEnum.Default
            });
            l.Add(new MyTableType.Record()
            {
                BigIntColumn = 3,
                EnumColumn = MyEnum.Value1
            });

            var x = sp.ExecuteNonQuery();
            //Create Procedure Usp_Structure
            //(@BigIntColumn bigint out
            //,@StructuredColumn as MyTableType readonly
            //) As 
            //Set @BigIntColumn = @BigIntColumn + 
            //(
            //    select Sum(BigIntColumn) from @StructuredColumn where EnumColumn = 'Default'
            //) 
            OutputTestResult(String.Format("Usp_Structure.BigIntColumn must be 1+1+2=4", sp.BigIntColumn), sp.BigIntColumn == 4);
        }
        private static void SetOutputParameterTest()
        {
            var sp = new Usp_OutputParameter();
            sp.BigIntColumn = DateTime.Now.Millisecond;
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
            sp.TextColumn = "Text";
            sp.TimeColumn = new TimeSpan(9, 0, 0);
            sp.TinyIntColumn = 3;
            sp.UniqueIdentifierColumn = Guid.NewGuid();
            sp.VarBinaryColumn = new Byte[] { 1, 2, 3, 4 };
            sp.VarCharColumn = "VarChar";
            sp.XmlColumn = "<xml></xml>";
            sp.GeographyColumn = null;

            var oldBigIntColumnValue = sp.BigIntColumn;
            var oldSmallIntColumnValue = sp.SmallIntColumn;

            var x = sp.ExecuteNonQuery();
            OutputTestResult("SetOutputParameter.BigIntColumn must be incremented +1", oldBigIntColumnValue + 1 == sp.BigIntColumn);
            OutputTestResult("SetOutputParameter.SmallIntColumn must be incremented +1", oldSmallIntColumnValue + 1 == sp.SmallIntColumn);
        }
        private static void InsertAutoIncrementColumnTest()
        {
            var db = CreateDatabase();
            var x = db.ExecuteCommand("Delete IdentityTable");

            OutputTestResult("Query: Delete IdentityTable", true);

            Int32 pk = 0;
            for (int i = 0; i < 3; i++)
            {
                var sp = new IdentityTableInsert();
                sp.NVarCharColumn = "NVarChar";
                var x1 = sp.ExecuteNonQuery();
                pk = sp.IntColumn;
                OutputTestResult("IdentityTable.Insert", x1 == 1);
            }
            var t = new IdentityTable();
            var r = t.SelectByPrimaryKey(pk);
            var x2 = t.Update(r);
            OutputTestResult("IdentityTable.Update", x2 == 1);

            var x3 = t.Delete(r);
            OutputTestResult("IdentityTable.Delete", x3 == 1);
        }
        private static void InsertRowGuidColumnTest()
        {
            var db = CreateDatabase();

            var x = db.ExecuteCommand("Delete RowGuidColTable");
            OutputTestResult("Query: Delete RowGuidColTable", true);

            Guid pk = Guid.Empty;
            for (int i = 0; i < 3; i++)
            {
                var sp = new RowGuidColTableInsert();
                sp.NVarCharColumn = "NVarChar";
                var x1 = sp.ExecuteNonQuery();
                pk = sp.RowGuidColumn;
                OutputTestResult("RowGuidColTable Insert", sp.RowGuidColumn != null);
            }
            var t = new RowGuidColTable();
            var r = t.SelectByPrimaryKey(pk);
            r.RowGuidColumn = Guid.NewGuid();
            var x2 = t.Update(r);
            OutputTestResult("RowGuidColTable.Update", x2 == 1);

            var x3 = t.Delete(r);
            OutputTestResult("RowGuidColTable.Delete", x3 == 1);
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
        private static Database CreateDatabase()
        {
            return DatabaseFactory.Current.CreateDatabase(DatabaseKey);
        }
    }
    public class DbSharpTestFailureException : Exception
    {
    }
}
