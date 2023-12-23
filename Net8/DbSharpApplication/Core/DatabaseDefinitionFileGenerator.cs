using HigLabo.Core;
using HigLabo.DbSharp.MetaData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DbSharpApplication
{
    public class DatabaseObjectDefinitionLoadedEventArgs : EventArgs
    {
        public String Name { get; set; }

        public DatabaseObjectDefinitionLoadedEventArgs(String name)
        {
            this.Name = name;
        }
    }
    public class DatabaseDefinitionFileGenerator
    {
        public static class RegexList
        {
            public static Regex From_Object = new Regex("from[\\s]+(?<Name>[^\\s]*)\\s");
        }
        public class SchemeData
        {
            public List<Table> Tables { get; init; } = new();
        }
        public event EventHandler<DatabaseObjectDefinitionLoadedEventArgs>? Loaded;

        public String ConnectionString { get; set; } = "";

        public DatabaseDefinitionFileGenerator(String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public async Task<String> CreateTableFile()
        {
            var l = new List<DatabaseObjectDefinition>();
            var reader = new SqlServerDatabaseSchemaReader(this.ConnectionString);
            var tableList = await reader.GetTablesAsync();

            var tt = new List<Table>();
            foreach (var item in tableList)
            {
                var t = await reader.GetTableAsync(item.Name);
                if (t.HasPrimaryKeyColumn() == false) { continue; }
                tt.Add(t);
                this.Loaded?.Invoke(this, new DatabaseObjectDefinitionLoadedEventArgs(t.Name));
            }
            foreach (var t in tt)
            {
                if (l.Exists(el => el.Name == t.Name)) { continue; }

                var o = new DatabaseObjectDefinition(t);
                o.BodyText = reader.GetDefinitionText(t);

                FindDependencyTable(l, o, tt, reader);

                l.Add(o);
            }
            return this.CreateFileText(l);
        }
        private void FindDependencyTable(List<DatabaseObjectDefinition> list, DatabaseObjectDefinition obj
            , List<Table> tableList, SqlServerDatabaseSchemaReader reader)
        {
            var t = tableList.Find(el => el.Name == obj.Name);
            if (t == null) { return; }
            foreach (var c in t.Columns.Where(el => el.ForeignKey != null))
            {
                if (c.ForeignKey == null) { continue; }
                var parentTable = tableList.Find(el => el.Name == c.ForeignKey.ParentTableName);

                if (parentTable == null) { continue; }
                if (parentTable.Name == t.Name) { continue; }
                if (list.Exists(el => el.Name == parentTable.Name)) { continue; }

                var o = new DatabaseObjectDefinition(parentTable);
                o.BodyText = reader.GetDefinitionText(parentTable);

                FindDependencyTable(list, o, tableList, reader);

                obj.DependencyList.Add(o);
                list.Add(o);
            }
        }

        public async Task<String> CreateStoredProcedureFile()
        {
            var l = new List<DatabaseObjectDefinition>();
            var reader = new SqlServerDatabaseSchemaReader(this.ConnectionString);
            var viewList = await reader.GetViewsAsync();
            var udtList = await reader.GetUserDefinedTableTypesAsync();
            var spList = await reader.GetStoredProceduresAsync();

            foreach (var item in viewList)
            {
                var o = new DatabaseObjectDefinition(item);
                l.Add(o);
                this.Loaded?.Invoke(this, new DatabaseObjectDefinitionLoadedEventArgs(o.Name));
            }
            foreach (var item in udtList)
            {
                var o = new DatabaseObjectDefinition(item);
                var u = await reader.GetUserDefinedTableTypeAsync(o.Name);
                o.BodyText = u.GetDefinitionText();
                l.Add(o);
                this.Loaded?.Invoke(this, new DatabaseObjectDefinitionLoadedEventArgs(o.Name));
            }
            foreach (var item in await reader.GetStoredFunctionsAsync())
            {
                var o = new DatabaseObjectDefinition(item);
                l.Add(o);
                this.Loaded?.Invoke(this, new DatabaseObjectDefinitionLoadedEventArgs(o.Name));
            }
            foreach (var sp in spList)
            {
                var o = new DatabaseObjectDefinition(sp);

                FindDependencyStoredProcedure(o, spList);

                l.Add(o);
                this.Loaded?.Invoke(this, new DatabaseObjectDefinitionLoadedEventArgs(o.Name));
            }
            return this.CreateFileText(l);
        }
        private String CreateFileText(List<DatabaseObjectDefinition> objectList)
        {
            var l = objectList;
            var nameList = new List<String>();
            var sb = new StringBuilder();
            foreach (var item in l)
            {
                if (nameList.Contains(item.Name)) { continue; }
                nameList.Add(item.Name);

                foreach (var parentItem in item.DependencyList)
                {
                    if (nameList.Contains(parentItem.Name)) { continue; }
                    nameList.Add(parentItem.Name);

                    sb.AppendLine(CreateScript(parentItem));
                }
                sb.AppendLine(CreateScript(item));
            }

            return sb.ToString();
        }
        private void FindDependencyStoredProcedure(DatabaseObjectDefinition obj, List<DatabaseObject> list)
        {
            foreach (var item in list.FindAll(el => obj.BodyText.Contains(" " + el.Name + " ")))
            {
                if (obj.Name == item.Name) { continue; }

                var o = new DatabaseObjectDefinition(item);
                obj.DependencyList.Add(o);

                FindDependencyStoredProcedure(o, list);
            }

        }
        private String CreateScript(DatabaseObjectDefinition obj)
        {
            var sb = new StringBuilder();

            sb.AppendLine("/*-------------------------------------");
            sb.AppendLine(obj.Name);
            foreach (var item in obj.DependencyList)
            {
                sb.Append(item.ObjectType).Append(":").AppendLine(item.Name);
            }
            sb.AppendLine("-------------------------------------*/");
            switch (obj.ObjectType)
            {
                case DatabaseObjectType.View:
                    sb.AppendFormat("DROP VIEW IF EXISTS dbo.[{0}]", obj.Name).AppendLine().AppendLine("GO");
                    break;
                case DatabaseObjectType.StoredProcedure:
                    sb.AppendFormat("DROP PROCEDURE IF EXISTS dbo.[{0}]", obj.Name).AppendLine().AppendLine("GO");
                    break;
                case DatabaseObjectType.StoredFunction:
                    sb.AppendFormat("DROP FUNCTION IF EXISTS dbo.[{0}]", obj.Name).AppendLine().AppendLine("GO");
                    break;
                default:break;
            }
            var sr = new StringReader(obj.BodyText);
            var commentPassed = false;
            if (obj.ObjectType == DatabaseObjectType.Table ||
                obj.ObjectType == DatabaseObjectType.UserDefinedTableType)
            {
                commentPassed = true;
            }
            while (sr.Peek() > -1)
            {
                var line = sr.ReadLine() ?? "";
                if (commentPassed == false)
                {
                    if (line.EndsWith("--------*/"))
                    {
                        commentPassed = true;
                    }
                    continue;
                }
                sb.AppendLine(line);
            }
            if (commentPassed)
            {
                if (obj.ObjectType == DatabaseObjectType.StoredProcedure ||
                    obj.ObjectType == DatabaseObjectType.StoredFunction)
                {
                    sb.AppendLine("");
                    sb.AppendLine("");
                }
            }
            else
            {
                sb.AppendLine(obj.BodyText);
            }
            if (obj.ObjectType != DatabaseObjectType.Table)
            {
                sb.AppendLine("GO");
            }
            sb.AppendLine("");

            return sb.ToString();
        }

        public async Task<String> CreateTableSchemeJsonText()
        {
            var l = new List<DatabaseObjectDefinition>();
            var reader = new SqlServerDatabaseSchemaReader(this.ConnectionString);
            var tableList = await reader.GetTablesAsync();

            var schemeData = new SchemeData();
            foreach (var item in tableList)
            {
                var t = await reader.GetTableAsync(item.Name);
                if (t.HasPrimaryKeyColumn() == false) { continue; }
                schemeData.Tables.Add(t);
                this.Loaded?.Invoke(this, new DatabaseObjectDefinitionLoadedEventArgs(t.Name));
            }
            return JsonConvert.SerializeObject(schemeData);
        }
    }
}
