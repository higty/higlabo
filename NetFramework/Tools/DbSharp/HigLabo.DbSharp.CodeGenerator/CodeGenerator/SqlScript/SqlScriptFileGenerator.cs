using HigLabo.CodeGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using HigLabo.DbSharp.MetaData;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class SqlScriptFileGenerator
    {
        public TableStoredProcedureFactory Factory { get; private set; }
        public List<Table> Tables { get; private set; }
        public String FolderPath { get; set; }
        public event EventHandler<SqlScriptFileGeneratedEventArgs> FileGenerated;
        public event EventHandler Completed;
        public SqlScriptFileGenerator(TableStoredProcedureFactory factory)
        {
            this.Factory = factory;
            this.Tables = new List<Table>();
        }
        public void Start()
        {
            if (Directory.Exists(this.FolderPath) == false)
            {
                Directory.CreateDirectory(this.FolderPath);
            }
            ThreadPool.QueueUserWorkItem(new WaitCallback(o => this.Execute()));
        }
        private void Execute()
        {
            SqlScriptFile sql = null;
            String filePath = "";

            this.CreateTableStoredProcedureSqlScriptFile();

            filePath = this.FolderPath + "DataConvert.sql";
            sql = new DataConvertSqlScriptFile(this.Factory.DatabaseServer);
            sql.Tables.AddRange(this.Tables);
            sql.WriteAllText(filePath, Encoding.UTF8);
            this.OnFileGenerated(new SqlScriptFileGeneratedEventArgs(filePath));

            this.OnCompleted();
        }
        private void CreateTableStoredProcedureSqlScriptFile()
        {
            var r = this.Factory;
            StringBuilder sb = new StringBuilder(1024);

            foreach (var table in this.Tables)
            {
                sb.AppendLine(r.CreateQueryOfTableNameSelectAll(table));
                this.AddGoAndLine(sb);
                sb.AppendLine(r.CreateQueryOfTableNameSelectByPrimaryKey(table));
                this.AddGoAndLine(sb);
                sb.AppendLine(r.CreateQueryOfTableNameInsert(table));
                this.AddGoAndLine(sb);
                sb.AppendLine(r.CreateQueryOfTableNameUpdate(table));
                this.AddGoAndLine(sb);
                sb.AppendLine(r.CreateQueryOfTableNameDelete(table));
                this.AddGoAndLine(sb);
            }
            var filePath = String.Format("{0}TableStoredProcedure.{1}.sql", this.FolderPath, r.DatabaseServer.ToString());
            File.WriteAllText(filePath, sb.ToString());
            this.OnFileGenerated(new SqlScriptFileGeneratedEventArgs(filePath));
        }
        private void AddGoAndLine(StringBuilder builder)
        {
            var sb = builder;
            sb.AppendLine("Go"); 
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine();
        }
        protected void OnFileGenerated(SqlScriptFileGeneratedEventArgs e)
        {
            var eh = this.FileGenerated;
            if (eh != null)
            {
                eh(this, e);
            }
        }
        protected void OnCompleted()
        {
            var eh = this.Completed;
            if (eh != null)
            {
                eh(this, EventArgs.Empty);
            }
        }
    }
}
