using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp.MetaData
{
    public class Table : DatabaseObject
    {
        public new DatabaseObjectType ObjectType
        {
            get { return base.ObjectType; }
        }
        public List<Column> Columns { get; private set; }
        public Table()
            : this("")
        {
        }
        public Table(String name)
            : base(DatabaseObjectType.Table)
        {
            this.Name = name;
            this.Columns = new List<Column>();
        }
        public IEnumerable<Column> GetColumns(Boolean? primaryKey, Boolean includeServerAutomaticallyInsertValueColumn)
        {
            if (primaryKey.HasValue == true)
            {
                if (includeServerAutomaticallyInsertValueColumn == true)
                {
                    return this.Columns.Where(el => el.IsPrimaryKey == primaryKey.Value);
                }
                else
                {
                    return this.Columns.Where(el => el.IsPrimaryKey == primaryKey.Value &&
                        el.IsServerAutomaticallyInsertValueColumn() == false);
                }
            }
            else
            {
                if (includeServerAutomaticallyInsertValueColumn == true)
                {
                    return this.Columns;
                }
                else
                {
                    return this.Columns.Where(el => el.IsServerAutomaticallyInsertValueColumn() == false);
                }
            }
        }
        public IEnumerable<Column> GetPrimaryKeyColumns()
        {
            return this.Columns.Where(el => el.IsPrimaryKey == true);
        }
        public IEnumerable<Column> GetPrimaryKeyOrTimestampColumns()
        {
            return this.Columns.Where(el => el.IsPrimaryKey == true || el.DbType.IsTimestamp() == true);
        }
        public Boolean HasPrimaryKeyColumn()
        {
            return this.Columns.Any(el => el.IsPrimaryKey == true);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
