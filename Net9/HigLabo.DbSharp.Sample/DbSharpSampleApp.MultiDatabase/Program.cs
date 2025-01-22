using HigLabo.Data;
using HigLabo.DbSharp;
using HigLabo.DbSharpSample.SqlServer;

namespace DbSharpSampleApp.MultiDatabase
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            StoredProcedure.DatabaseFactory.SetCreateDatabaseMethod("MyDatabaseKey", () => new SqlServerDatabase("My connection string..."));

            var sp = new Usp_Structure();
            sp.BigIntColumn = 1;
            //User defined table type parameter. TVP(table value parameter)
            var r = new MyTableType.Record();
            r.BigIntColumn = 2;
            sp.StructuredColumn.Records.Add(r);
            var spResult = await sp.ExecuteNonQueryAsync();

            var sp1 = new Usp_SelectMultiTable();
            var resultSetList = await sp1.GetResultSetsListAsync();
            foreach (var item in resultSetList.ResultSetList)
            {
                //Do something...
                Console.WriteLine(item.BigIntColumn);
            }
            foreach (var item in resultSetList.ResultSet1List)
            {
                //Do something...
                Console.WriteLine(item.NVarCharColumn);
            }
            foreach (var item in resultSetList.ResultSet2List)
            {
                //Do something...
            }
        }
    }
}