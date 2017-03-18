using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Data;
using MySql.Data.MySqlClient;
using HigLabo.DbSharp.MetaData;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class MySqlTableStoredProcedureFactory : TableStoredProcedureFactory
    {
        public override DatabaseServer DatabaseServer
        {
            get { return DatabaseServer.MySql; }
        }
        public MySqlTableStoredProcedureFactory(DatabaseSchemaReader reader)
            : base(reader)
        {
        }
        protected override void ExecuteCommand(Database database, string query)
        {
            var db = database as MySqlDatabase;
            var script = new MySqlScript();
            script.Delimiter = "//";
            script.Query = query;
            db.ExecuteCommand(script);
        }
        public override String CreateQueryOfTableNameSelectAll(Table table)
        {
            var cNames = CreateText(table.GetColumns(null, true), column => column.Name, ",", true);
            return String.Format("Create Procedure {0}SelectAll () " + Environment.NewLine + Environment.NewLine
                + "select {1} from {0}", table.Name, cNames);
        }
        public override String CreateQueryOfTableNameSelectByPrimaryKey(Table table)
        {
            StringBuilder sb = new StringBuilder(32);

            sb.AppendFormat("Create Procedure {0}SelectByPrimaryKey", table.Name);
            sb.Append("(");
            sb.Append(CreateText(table.GetPrimaryKeyColumns(), column => String.Format("PK_{0}", column.GetDeclareParameterText()), ",", true));
            sb.AppendLine(")");
            sb.AppendLine();

            var cNames = CreateText(table.GetColumns(null, true), column => column.Name, ",", true);
            sb.AppendFormat("select {0}", cNames);
            sb.AppendFormat("from {0}", table.Name);
            sb.AppendLine();
            sb.Append("where ");
            sb.Append(CreateText(table.GetPrimaryKeyColumns(), column => String.Format("{0} = PK_{0}", column.Name), "and ", true));

            return sb.ToString();
        }
        public override String CreateQueryOfTableNameInsert(Table table)
        {
            StringBuilder sb = new StringBuilder(32);
            Column isIdentityColumn = null;
            Column timestampColumn = null;

            foreach (var column in table.Columns)
            {
                if (column.IsIdentity == true) isIdentityColumn = column;
                if (column.DbType.IsTimestamp() == true) timestampColumn = column;
            }

            sb.AppendFormat("Create Procedure {0}Insert", table.Name);
            sb.AppendLine();
            sb.Append("(");
            sb.Append(CreateText(table.Columns, column =>
            {
                if (column.IsServerAutomaticallyInsertValueColumn() == true)
                {
                    return "Out " + column.GetDeclareParameterText();
                }
                else
                {
                    return column.GetDeclareParameterText();
                }
            }, ",", true));
            sb.AppendLine(") ");
            sb.AppendLine();

            sb.AppendLine("Begin");
            sb.AppendFormat("insert into {0}", table.Name);
            sb.AppendLine();

            sb.Append("(");
            sb.Append(CreateText(table.GetColumns(null, false), column => column.Name, ",", true));
            sb.AppendLine(")");

            sb.AppendLine("values");

            sb.Append("(");
            sb.Append(CreateText(table.GetColumns(null, false), column => column.Name, ",", true));
            sb.AppendLine(");");

            if (isIdentityColumn != null)
            {
                sb.AppendFormat("set {0} = LAST_INSERT_ID();", isIdentityColumn.Name);
                sb.AppendLine();
            }
            if (timestampColumn != null)
            {
                sb.AppendFormat("set {0} = CURRENT_TIMESTAMP();", timestampColumn.Name);
                sb.AppendLine();
            }

            sb.AppendLine("End;");
            sb.AppendLine("//");

            return sb.ToString();
        }
        public override String CreateQueryOfTableNameUpdate(Table table)
        {
            StringBuilder sb = new StringBuilder(32);
            List<Column> columns = null;
            Column timestampColumn = null;
            String whereQuery = this.CreateWhereQuery(table.GetPrimaryKeyOrTimestampColumns(), "T01.", true);

            foreach (var column in table.Columns)
            {
                if (column.DbType.IsTimestamp() == true) timestampColumn = column;
            }

            sb.AppendFormat("Create Procedure {0}Update", table.Name);
            sb.AppendLine();
            sb.Append("(");
            sb.Append(CreateText(table.Columns, column =>
            {
                if (column.CanUpdateValueColumn() == true)
                {
                    return column.GetDeclareParameterText();
                }
                else
                {
                    return "Out " + column.GetDeclareParameterText();
                }
            }, ",", true));
            sb.Append(",");
            sb.Append(CreateText(table.GetPrimaryKeyOrTimestampColumns(), column => String.Format("PK_{0}", column.GetDeclareParameterText()), ",", true));
            sb.AppendLine(") ");
            sb.AppendLine();

            sb.AppendLine("Begin");
            sb.AppendLine("if(");
            sb.Append(CreateText(table.GetPrimaryKeyColumns(), column => String.Format("{0} = PK_{0}", column.Name), "and ", true));
            sb.AppendLine(") Then");

            columns = table.GetColumns(false, false).ToList();
            if (columns.Count == 0)
            {
                sb.AppendFormat("Set {0} = {0};", table.Columns[0].Name);
                sb.AppendLine();
            }
            else if (columns.Count > 0)
            {
                sb.AppendFormat("update {0} As T01 set ", table.Name);
                sb.AppendLine();

                sb.Append(CreateText(columns, column => String.Format("T01.{0} = {0}", column.Name), ",", true));
                sb.AppendLine();
                sb.Append(whereQuery);
            }
            sb.AppendLine(";");

            sb.AppendLine("else");

            sb.AppendFormat("update {0} As T01 set ", table.Name);
            sb.AppendLine();

            sb.Append(CreateText(table.Columns.Where(column => column.CanUpdateValueColumn()), column => String.Format("T01.{0} = {0}", column.Name), ",", true));
            sb.AppendLine();
            sb.Append(whereQuery);
            sb.AppendLine(";");

            sb.AppendLine("end if;");

            if (timestampColumn != null)
            {
                sb.AppendFormat("set {0} = CURRENT_TIMESTAMP();", timestampColumn.Name);
                sb.AppendLine();
            }

            sb.AppendLine("End;");
            sb.AppendLine("//");

            return sb.ToString();
        }
        public override String CreateQueryOfTableNameDelete(Table table)
        {
            StringBuilder sb = new StringBuilder(32);
            String whereQuery = this.CreateWhereQuery(table.GetPrimaryKeyOrTimestampColumns(), "", true);

            sb.AppendFormat("Create Procedure {0}Delete", table.Name);
            sb.Append("(");
            sb.Append(CreateText(table.GetPrimaryKeyOrTimestampColumns(), column => String.Format("PK_{0}", column.GetDeclareParameterText()), ",", true));
            sb.AppendLine(") ");
            sb.AppendLine();

            sb.AppendLine("Begin");

            sb.AppendFormat("delete from {0}", table.Name);
            sb.AppendLine();
            sb.Append(whereQuery);
            sb.AppendLine(";");

            sb.AppendLine("End;");
            sb.AppendLine("//");

            return sb.ToString();
        }

        private String CreateWhereQuery(IEnumerable<Column> columns, String tablePrefix, Boolean addPK_Prefix)
        {
            StringBuilder sb = new StringBuilder(32);

            sb.Append("where ");
            sb.Append(CreateText(columns, column =>
            {
                if (addPK_Prefix == true)
                {
                    return String.Format("{0}{1} = PK_{1}", tablePrefix, column.Name);
                }
                return String.Format("{0}{1} = {1}", tablePrefix, column.Name);
            }, "and ", true));
            return sb.ToString();
        }
    }
}
