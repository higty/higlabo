using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public static class NvarcharTableExtensions
    {
        public static void AddRecord(this Nvarchar32Table table, String value)
        {
            var r = new Nvarchar32Table.Record();
            r.Value = value;
            table.AddRecord(r);
        }
        public static void AddRecord(this Nvarchar64Table table, String value)
        {
            var r = new Nvarchar64Table.Record();
            r.Value = value;
            table.AddRecord(r);
        }
        public static void AddRecord(this Nvarchar128Table table, String value)
        {
            var r = new Nvarchar128Table.Record();
            r.Value = value;
            table.AddRecord(r);
        }
        public static void AddRecord(this Nvarchar256Table table, String value)
        {
            var r = new Nvarchar256Table.Record();
            r.Value = value;
            table.AddRecord(r);
        }
        public static void AddRecord(this Nvarchar400Table table, String value)
        {
            var r = new Nvarchar400Table.Record();
            r.Value = value;
            table.AddRecord(r);
        }
        public static void AddRecord(this NvarcharMaxTable table, String value)
        {
            var r = new NvarcharMaxTable.Record();
            r.Value = value;
            table.AddRecord(r);
        }

        public static void AddRecords(this Nvarchar32Table table, IEnumerable<String> values)
        {
            foreach (var value in values)
            {
                var r = new Nvarchar32Table.Record();
                r.Value = value;
                table.AddRecord(r);
            }
        }
        public static void AddRecords(this Nvarchar64Table table, IEnumerable<String> values)
        {
            foreach (var value in values)
            {
                var r = new Nvarchar64Table.Record();
                r.Value = value;
                table.AddRecord(r);
            }
        }
        public static void AddRecords(this Nvarchar128Table table, IEnumerable<String> values)
        {
            foreach (var value in values)
            {
                var r = new Nvarchar128Table.Record();
                r.Value = value;
                table.AddRecord(r);
            }
        }
        public static void AddRecords(this Nvarchar256Table table, IEnumerable<String> values)
        {
            foreach (var value in values)
            {
                var r = new Nvarchar256Table.Record();
                r.Value = value;
                table.AddRecord(r);
            }
        }
        public static void AddRecords(this Nvarchar400Table table, IEnumerable<String> values)
        {
            foreach (var value in values)
            {
                var r = new Nvarchar400Table.Record();
                r.Value = value;
                table.AddRecord(r);
            }
        }
        public static void AddRecords(this NvarcharMaxTable table, IEnumerable<String> values)
        {
            foreach (var value in values)
            {
                var r = new NvarcharMaxTable.Record();
                r.Value = value;
                table.AddRecord(r);
            }
        }
    }
}
