using System;
using System.Collections.Concurrent;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Core;
using HigLabo.Data;
using Azure.Core;

namespace HigLabo.DbSharp
{
    public interface ITableCache
    {
        event EventHandler<TableCacheUpdatedEventArgs>? Loaded;
		string TableName { get; }
		int GetRecordCount();
        Task LoadDataAsync();
        Task LoadDataAsync(Database database);
        Task LoadDataAsync(IEnumerable<Database> databaseList);
        List<object> SelectAll();
        object SelectByPrimaryKey(object primaryKey);
        object? SelectByPrimaryKeyOrNull(object primaryKey);
        IEnumerable<object> Where(Func<object, Boolean> func);
        object? FirstOrDefault(Func<object, Boolean> func);
        void InsertOrReplace(object record);
        void Delete(object value);
    }

    public class TableCache<TPrimaryKey, TStoredProcedure, TResultSet> : ITableCache
        where TPrimaryKey: notnull
        where TStoredProcedure : StoredProcedureWithResultSet, new()
        where TResultSet : class, new()
    {
        public	event EventHandler<TableCacheUpdatedEventArgs>? Loaded;
		
        private Int32 _RecordCount = 0;
        private ConcurrentDictionary<TPrimaryKey, TResultSet> _Records = new();
        private Func<TResultSet, TPrimaryKey> _SelectByPrimaryKeySelector;

        public String TableName { get; set; }

        public TableCache(String tableName, Func<TResultSet, TPrimaryKey> selectByPrimaryKeySelector)
        {
            this.TableName = tableName;
            _SelectByPrimaryKeySelector = selectByPrimaryKeySelector;
        }

        public int GetRecordCount()
        {
            return _RecordCount;
        }

        protected virtual void SetProperty(TStoredProcedure storedProcedure)
        {

        }
        public async Task LoadDataAsync()
        {
            var l = new List<TResultSet>();
            var sp = new TStoredProcedure();
            this.SetProperty(sp);
            foreach (var item in await sp.GetResultSetsAsync())
            {
                var r = item.Map(new TResultSet());
                l.Add(r);
            }
            this.ReplaceRecordList(l);
        }
        public async Task LoadDataAsync(Database database)
        {
            await this.LoadDataAsync(new Database[] { database });
        }
        public async Task LoadDataAsync(IEnumerable<Database> databaseList)
        {
            var l = new List<TResultSet>();
            var sp = new TStoredProcedure();
            this.SetProperty(sp);
            foreach (var item in await sp.GetResultSetsAsync(databaseList))
            {
                var r = item.Map(new TResultSet());
                l.Add(r);
            }
            this.ReplaceRecordList(l);
            this.OnLoaded();
        }
        private void ReplaceRecordList(IEnumerable<TResultSet> records)
        {
            var d = new ConcurrentDictionary<TPrimaryKey, TResultSet>();
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
        protected void OnLoaded()
        {
            var md = this.Loaded;
            if (md == null) { return; }
            var e = new TableCacheUpdatedEventArgs();
            e.TableNameList.Add(this.TableName);
			md(this, e);
		}

		List<object> ITableCache.SelectAll()
        {
            return this.SelectAll().Select(el => (object)el).ToList();
        }
        public virtual List<TResultSet> SelectAll()
        {
            return _Records.Values.Select(el => el.Map(new TResultSet())).ToList();
        }
        object ITableCache.SelectByPrimaryKey(object primaryKey)
        {
            if (primaryKey is TPrimaryKey)
            {
                return this.SelectByPrimaryKey((TPrimaryKey)primaryKey) as object;
            }
            throw new TableRecordNotFoundException(this.TableName, primaryKey);
        }
        public TResultSet SelectByPrimaryKey(TPrimaryKey value)
        {
            var r = this.SelectByPrimaryKeyOrNull(value);
            if (r == null) { throw new TableRecordNotFoundException(this.TableName, value); }
            return r;
        }
        object? ITableCache.SelectByPrimaryKeyOrNull(object primaryKey)
        {
            if (primaryKey is TPrimaryKey)
            {
                return this.SelectByPrimaryKeyOrNull((TPrimaryKey)primaryKey) as object;
            }
            return null;
        }
        public TResultSet? SelectByPrimaryKeyOrNull(TPrimaryKey value)
        {
            TResultSet? r = default(TResultSet);
            _Records.TryGetValue(value, out r);
            if (r == null) { return null; }
            return r.Map(new TResultSet());
        }

        IEnumerable<object> ITableCache.Where(Func<object, Boolean> func)
        {
            return this.Where(func).Select(el => (object)el);
        }
        public IEnumerable<TResultSet> Where(Func<TResultSet, Boolean> func)
        {
            return _Records.Values.Where(func).Select(el => el.Map(new TResultSet()));
        }
        public TResultSet First(Func<TResultSet, Boolean> func)
        {
            return _Records.Values.First(func).Map(new TResultSet());
        }
        object? ITableCache.FirstOrDefault(Func<object, Boolean> func)
        {
            return this.FirstOrDefault(func) as object;
        }
        public TResultSet? FirstOrDefault(Func<TResultSet, Boolean> func)
        {
            var r = _Records.Values.FirstOrDefault(func);
            if (r == null) { return null; }
            return r.Map(new TResultSet());
        }
        void ITableCache.InsertOrReplace(object record)
        {
            if (record is TResultSet)
            {
                this.InsertOrReplace((TResultSet)record);
            }
        }
        public void InsertOrReplace(TResultSet record)
        {
            var pk = _SelectByPrimaryKeySelector(record);
            _Records.TryRemove(pk, out _);
            _Records.TryAdd(pk, record);
        }
        void ITableCache.Delete(object value)
        {
            if (value is TPrimaryKey)
            {
                this.Delete((TPrimaryKey)value);
            };
        }
        public void Delete(TPrimaryKey value)
        {
            _Records.TryRemove(value, out _);
        }
    }
}
