using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Data;
using HigLabo.DbSharp.MetaData;

namespace HigLabo.DbSharp.CodeGenerator
{
    public class SqlServerTableStoredProcedureFactory : TableStoredProcedureFactory
    {
        public override DatabaseServer DatabaseServer
        {
            get { return DatabaseServer.SqlServer; }
        }
        public SqlServerTableStoredProcedureFactory(DatabaseSchemaReader reader)
            : base(reader)
        {
        }
        public override String CreateQueryOfTableNameSelectAll(Table table)
        {
            var cNames = CreateText(table.GetColumns(null, true), column => column.Name, ",", true);
            return String.Format("Create Procedure {0}SelectAll As " + Environment.NewLine + Environment.NewLine
                + "select {1}from [{0}] with(nolock)", table.Name, cNames);
        }
        public override String CreateQueryOfTableNameSelectByPrimaryKey(Table table)
        {
            StringBuilder sb = new StringBuilder(32);

            sb.AppendFormat("Create Procedure {0}SelectByPrimaryKey", table.Name);
            sb.AppendLine();
            sb.Append("(");
            sb.Append(CreateText(table.GetPrimaryKeyColumns(), column => String.Format("@PK_{0}", column.GetDeclareParameterText()), ",", true));
            sb.AppendLine(") As");
            sb.AppendLine();

            var cNames = CreateText(table.GetColumns(null, true), column => column.Name, ",", true);
            sb.AppendFormat("select {0}", cNames);
            sb.AppendFormat("from [{0}] with(nolock)", table.Name);
            sb.AppendLine();
            sb.Append("where ");
            sb.Append(CreateText(table.GetPrimaryKeyColumns(), column => String.Format("[{0}] = @PK_{0}", column.Name), "and ", true));

            return sb.ToString();
        }
        public override String CreateQueryOfTableNameInsert(Table table)
        {
            StringBuilder sb = new StringBuilder(32);
            List<Column> outputColumns = new List<Column>();
            List<Column> insertedColumns = new List<Column>();

            foreach (var column in table.Columns)
            {
                if (column.IsServerAutomaticallyInsertValueColumn() == true)
                {
                    if (column.IsRowGuidCol == true ||
                        column.IsIdentity == true)
                    {
                        insertedColumns.Add(column);
                    }
                    else
                    {
                        outputColumns.Add(column);
                    }
                }
            }

            sb.AppendFormat("Create Procedure {0}Insert", table.Name);
            sb.AppendLine();
            sb.Append("(");
            sb.Append(CreateText(table.Columns, column =>
            {
                if (column.IsServerAutomaticallyInsertValueColumn() == true)
                {
                    return "@" + column.GetDeclareParameterText() + " output";
                }
                else
                {
                    return "@" + column.GetDeclareParameterText();
                }
            }, ",", true));
            sb.AppendLine(") As");
            sb.AppendLine();

            if (insertedColumns.Count > 0)
            {
                sb.Append("declare @InsertedTable table(");
                sb.Append(this.CreateText(insertedColumns, column => column.GetDeclareParameterText(), ", ", false));
                sb.AppendLine(");");
                sb.AppendLine();
            }
            sb.AppendFormat("insert into [{0}]", table.Name);
            sb.AppendLine();

            sb.Append("(");
            sb.Append(CreateText(table.GetColumns(null, false), column => String.Format("[{0}]", column.Name), ",", true));
            sb.AppendLine(")");
            if (insertedColumns.Count > 0)
            {
                sb.Append("output ");
                sb.Append(CreateText(insertedColumns, column => String.Format("inserted.{0}", column.Name), ", ", false));
                sb.AppendFormat(" into @InsertedTable");
                sb.AppendLine();
            }
            sb.AppendLine("values");

            sb.Append("(");
            sb.Append(CreateText(table.GetColumns(null, false), column => "@" + column.Name, ",", true));
            sb.AppendLine(")");

            if (outputColumns.Count > 0)
            {
                sb.AppendLine();
                sb.Append("select ");
                sb.Append(CreateText(outputColumns, column => String.Format("@{0} = {0}", column.Name), ", ", false));
                sb.AppendFormat(" from {0} with(nolock)", table.Name);
                sb.AppendLine();
                sb.AppendLine(this.CreateWhereQuery(table.GetPrimaryKeyColumns(), false));
            }
            if (insertedColumns.Count > 0)
            {
                sb.Append("select ");
                sb.Append(CreateText(insertedColumns, column => String.Format("@{0} = {0}", column.Name), ", ", false));
                sb.Append(" from @InsertedTable");
                sb.AppendLine();
            }

            return sb.ToString();
        }
        public override String CreateQueryOfTableNameUpdate(Table table)
        {
            StringBuilder sb = new StringBuilder(32);
            List<Column> columns = null;
            List<Column> outputColumns = new List<Column>();
            String whereQuery = this.CreateWhereQuery(table.GetPrimaryKeyOrTimestampColumns(), true);

            foreach (var column in table.Columns)
            {
                if (column.CanUpdateValueColumn() == false)
                {
                    outputColumns.Add(column);
                }
            }

            sb.AppendFormat("Create Procedure {0}Update", table.Name);
            sb.AppendLine();
            sb.Append("(");
            sb.Append(CreateText(table.Columns, column =>
            {
                if (column.CanUpdateValueColumn() == true)
                {
                    return "@" + column.GetDeclareParameterText();
                }
                else
                {
                    return "@" + column.GetDeclareParameterText() + " output";
                }
            }, ",", true));
            sb.Append(",");
            sb.Append(CreateText(table.GetPrimaryKeyOrTimestampColumns(), column => String.Format("@PK_{0}", column.GetDeclareParameterText()), ",", true));
            sb.AppendLine(") As");
            sb.AppendLine();

            sb.AppendLine("if(");
            sb.Append(CreateText(table.GetPrimaryKeyColumns(), column => String.Format("@{0} = @PK_{0}", column.Name), "and ", true));
            sb.AppendLine(")");

            columns = table.GetColumns(false, false).ToList();
            sb.AppendLine("begin");
            if (columns.Count == 0)
            {
                sb.AppendFormat("Set @{0} = @{0}", table.Columns[0].Name);
                sb.AppendLine();
            }
            else if (columns.Count > 0)
            {
                sb.AppendFormat("update [{0}] set ", table.Name);
                sb.AppendLine();

                sb.Append(CreateText(columns, column => String.Format("[{0}] = @{0}", column.Name), ",", true));
                sb.AppendLine();
                sb.Append(whereQuery);
            }
            sb.AppendLine("end");

            sb.AppendLine("else");

            sb.AppendLine("begin");
            sb.AppendFormat("update [{0}] set ", table.Name);
            sb.AppendLine();

            sb.Append(CreateText(table.Columns.Where(column => column.CanUpdateValueColumn()), column => String.Format("[{0}] = @{0}", column.Name), ",", true));
            sb.AppendLine();
            sb.Append(whereQuery);
            sb.AppendLine("end");

            if (outputColumns.Count > 0)
            {
                sb.AppendLine();
                sb.Append("select ");
                sb.Append(CreateText(outputColumns, column => String.Format("@{0} = {0}", column.Name), ", ", false));
                sb.AppendFormat(" from {0} with(nolock)", table.Name);
                sb.AppendLine();
                sb.AppendLine(this.CreateWhereQuery(table.GetPrimaryKeyColumns(), false));
            }

            return sb.ToString();
        }
        public override String CreateQueryOfTableNameDelete(Table table)
        {
            StringBuilder sb = new StringBuilder(32);
            String whereQuery = this.CreateWhereQuery(table.GetPrimaryKeyOrTimestampColumns(), true);

            sb.AppendFormat("Create Procedure {0}Delete", table.Name);
            sb.AppendLine();
            sb.Append("(");
            sb.Append(CreateText(table.GetPrimaryKeyOrTimestampColumns(), column => String.Format("@PK_{0}", column.GetDeclareParameterText()), ",", true));
            sb.AppendLine(") As");
            sb.AppendLine();

            sb.AppendFormat("delete [{0}]", table.Name);
            sb.AppendLine();
            sb.Append(whereQuery);

            return sb.ToString();
        }

        private String CreateWhereQuery(IEnumerable<Column> columns, Boolean addPK_Prefix)
        {
            StringBuilder sb = new StringBuilder(32);

            sb.Append("where ");
            sb.Append(CreateText(columns, column =>
            {
                if (addPK_Prefix == true)
                {
                    return String.Format("[{0}] = @PK_{0}", column.Name);
                }
                return String.Format("[{0}] = @{0}", column.Name);
            }, "and ", true));
            return sb.ToString();
        }
    }
}
