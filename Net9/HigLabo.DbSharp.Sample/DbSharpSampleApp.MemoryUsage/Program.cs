using HigLabo.Core;
using HigLabo.Data;
using HigLabo.DbSharpSample.SqlServer;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        private static string ConnectionString = "";

        static async Task Main(string[] args)
        {
            await Test_DbSharpApplication();
        }
        private static async Task Test_HigLaboData()
        {
            var sw = new Stopwatch();
            sw.Start();

            var sql = @"SELECT * FROM OneMillionTable";
            var db = new SqlServerDatabase(ConnectionString);
            await foreach (var r in db.EnumerateRecordListAsync<MyRecord>(sql))
            {
                Console.WriteLine($"{r.Id} - {r.Text1}, {r.Text2}, {r.Text3}");
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString());
        }
        private static async Task Test_DbSharpApplication()
        {
            var sw = new Stopwatch();
            sw.Start();

            var db = new SqlServerDatabase(ConnectionString);
            var sp = new OneMillionTable_SelectAll();
            await foreach (var r in sp.EnumerateResultSetsAsync(db))
            {
                Console.WriteLine($"{r.Id} - {r.Text1}, {r.Text2}, {r.Text3}");
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString());
        }
        private static async Task Test_EF()
        {
            var sw = new Stopwatch();
            sw.Start();

            var sql = @"SELECT * FROM OneMillionTable";
            var option = new DbContextOptionsBuilder<MyDbContext>()
               .UseSqlServer(ConnectionString)
               .Options;
            using var dbContext = new MyDbContext(option);
            var records = dbContext.MyRecords.FromSqlRaw(sql).AsNoTracking();

            foreach (var record in records)
            {
                Console.WriteLine($"{record.Id} - {record.Text1}, {record.Text2}, {record.Text3}");
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed.ToString());

            await Task.CompletedTask;
        }
    }
    public class MyRecord
    {
        public Int64 Id { get; set; }
        public string? Text1 { get; set; }
        public string? Text2 { get; set; }
        public string? Text3 { get; set; }
    }
    public class MyDbContext : DbContext
    {
        public DbSet<MyRecord> MyRecords => Set<MyRecord>();

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}
