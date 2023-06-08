using System;
using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
    public abstract class TableCache
    {
        private static Object _LockObject = new object();
        private static Hashtable _TableList = new();

        public static void Add(String tableName, TableCache table)
        {
            lock (_LockObject)
            {
                _TableList.Add(tableName, table);
            }
        }
        public static TableCache Get(String tableName)
        {
            return _TableList[tableName] as TableCache;
        }
        public static async Task LoadData(String tableName)
        {
            var t = _TableList[tableName] as TableCache;
            if (t == null) { throw new ArgumentException($"{tableName} is not found."); }
            await t.LoadDataAsync();
        }

        public abstract Task LoadDataAsync();
        public abstract Int32 GetRecordCount();
    }
    public class TableCache<T, TPrimaryKey, TStoredProcedure, TResultSet> : TableCache
        where T : class, new()
        where TPrimaryKey: notnull
        where TStoredProcedure : StoredProcedureWithResultSet, new()
        where TResultSet : class
    {
        private Int32 _RecordCount = 0;
        private ConcurrentDictionary<TPrimaryKey, T> _Records = new();
        private Func<T, TPrimaryKey> _SelectByPrimaryKeySelector;

        public String TableName { get; set; }

        public TableCache(String tableName, Func<T, TPrimaryKey> selectByPrimaryKeySelector)
        {
            TableCache.Add(tableName, this);
            this.TableName = tableName;
            _SelectByPrimaryKeySelector = selectByPrimaryKeySelector;
        }

        public override int GetRecordCount()
        {
            return _RecordCount;
        }

        public override async Task LoadDataAsync()
        {
            var l = new List<T>();
            var sp = new TStoredProcedure();
            foreach (var item in await sp.GetResultSetsAsync())
            {
                var r = (item as TResultSet).Map(new T());
                l.Add(r);
            }
            this.LoadData(l);
        }
        protected void LoadData(IEnumerable<T> records)
        {
            var d = new ConcurrentDictionary<TPrimaryKey, T>();
            _RecordCount = 0;
            foreach (var item in records)
            {
                if (d.TryAdd(_SelectByPrimaryKeySelector(item), item))
                {
                    _RecordCount++;
                }
            }
            Interlocked.Exchange(ref _Records, d);
        }

        public virtual IReadOnlyList<T> SelectAll()
        {
            return _Records.Values.ToArray();
        }
        public T SelectByPrimaryKey(TPrimaryKey value)
        {
            var r = this.SelectByPrimaryKeyOrNull(value);
            if (r == null) { throw new TableRecordNotFoundException(this.TableName, value); }
            return r;
        }
        public T SelectByPrimaryKeyOrNull(TPrimaryKey value)
        {
            T r = default(T);
            _Records.TryGetValue(value, out r);
            if (r == null) { return null; }
            return r.Map(new T());
        }
        public IEnumerable<T> Where(Func<T, Boolean> func)
        {
            return _Records.Values.Where(func).Select(el => el.Map(new T()));
        }
        public T First(Func<T, Boolean> func)
        {
            return _Records.Values.First(func).Map(new T());
        }
        public T? FirstOrDefault(Func<T, Boolean> func)
        {
            var r = _Records.Values.FirstOrDefault(func);
            if (r == null) { return null; }
            return r.Map(new T());
        }
        public void InsertOrReplace(T record)
        {
            var pk = _SelectByPrimaryKeySelector(record);
            _Records.TryRemove(pk, out _);
            _Records.TryAdd(pk, record);
        }
        public void Delete(TPrimaryKey value)
        {
            _Records.TryRemove(value, out _);
        }
    }
}
