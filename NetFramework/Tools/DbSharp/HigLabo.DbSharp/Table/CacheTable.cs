using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public abstract class CacheTable
    {
        public abstract void LoadData();
    }
    public class CacheTable<T> : CacheTable
        where T : TableRecord<T>, new()
    {
        private Table<T> _Table = null;
        private List<T> _Records = new List<T>();

        public String TableName
        {
            get { return _Table.TableName; }
        }
        public Int32 RecordCount
        {
            get { return _Records.Count; }
        }

        public CacheTable(Table<T> table)
        {
            _Table = table;
        }
        public override void LoadData()
        {
            var l = _Table.SelectAll();
            System.Threading.Interlocked.Exchange(ref _Records, l);
        }

        public IEnumerable<T> SelectAll()
        {
            return _Records.Select(el =>
            {
                var r = new T();
                r.SetProperty(el);
                return r;
            });
        }
        public IEnumerable<T> Where(Func<T, Boolean> predicate)
        {
            return this.SelectAll().Where(predicate);
        }
        public T FirstOrDefault(Func<T, Boolean> predicate)
        {
            return this.SelectAll().FirstOrDefault(predicate);
        }
    }
}
