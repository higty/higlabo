using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Core;

namespace HigLabo.DbSharp
{
    public abstract class TableRecord : DatabaseRecord, ISaveMode
    {
        public static readonly Object SkipSetValue = new object();
        public static TypeConverter TypeConverter { get; set; }

        SaveMode ISaveMode.SaveMode { get; set; }

        static TableRecord()
        {
            TypeConverter = AppEnvironment.Settings.TypeConverter;
        }
        public abstract String GetTableName();
        public abstract Int32 GetColumnCount();
        public void EnsureOlderRecordProperty()
        {
            if (this.HasOldRecord() == false)
            {
                this.SetOldRecordProperty();
            }
        }
        public abstract Boolean HasOldRecord();
        public abstract void SetOldRecordProperty();
        public abstract object GetValue(Int32 index);
        public abstract Boolean SetValue(Int32 index, Object value);

        public Object[] GetValues()
        {
            var count = this.GetColumnCount();
            var oo = new Object[count];
            for (int i = 0; i < count; i++)
            {
                oo[i] = this.GetValue(i);
            }
            return oo;
        }
        public SetValueResult[] SetValues(params Object[] values)
        {
            var count = values.Length;
            var bb = new SetValueResult[count];
            for (int i = 0; i < count; i++)
            {
                if (values[i] == TableRecord.SkipSetValue)
                {
                    bb[i] = SetValueResult.Skip;
                    continue;
                }
                if (this.SetValue(i, values[i]) == true)
                {
                    bb[i] = SetValueResult.Success;
                }
                else
                {
                    bb[i] = SetValueResult.Failure;
                }
            }
            return bb;
        }
        public Object[] CreateValueArray()
        {
            return this.CreateValueArray(SkipSetValue);
        }
        public Object[] CreateValueArray(Object defaultValue)
        {
            var count = this.GetColumnCount();
            var oo = new Object[count];
            for (int i = 0; i < count; i++)
            {
                oo[i] = defaultValue;
            }
            return oo;
        }

        public static IEnumerable<T> SetSaveMode<T>(IEnumerable<T> oldRecords, IEnumerable<T> newRecords)
            where T : TableRecord<T>, new()
        {
            return SetSaveMode(oldRecords, newRecords, (x, y) => x.ComparePrimaryKeyColumn(y));
        }
        public static IEnumerable<T> SetSaveMode<T>(IEnumerable<T> oldRecords, IEnumerable<T> newRecords, Func<T, T, Boolean> equalityFunc)
            where T : TableRecord<T>, new()
        {
            var deleteList = oldRecords.Except(newRecords, equalityFunc);
            var updateList = newRecords.Intersect(oldRecords, equalityFunc);
            var addList = newRecords.Except(oldRecords, equalityFunc);

            foreach (var item in deleteList)
            {
                ((ISaveMode)item).SaveMode = SaveMode.Delete;
                yield return item;
            }
            foreach (var item in updateList)
            {
                ((ISaveMode)item).SaveMode = SaveMode.Update;
                yield return item;
            }
            foreach (var item in addList)
            {
                ((ISaveMode)item).SaveMode = SaveMode.Insert;
                yield return item;
            }
        }
    }
    public abstract class TableRecord<T> : TableRecord
        where T : TableRecord<T>, new()
    {
        public T OldRecord
        {
            get;
            protected set;
        }

        public Boolean IsChanged()
        {
            if (this.OldRecord == null) throw new InvalidOperationException("You must call SetOldRecordProperty method before call IsChanged method.");
            return this.CompareAllColumn(this.OldRecord);
        }
        public override bool HasOldRecord()
        {
            return this.OldRecord != null;
        }
        public override void SetOldRecordProperty()
        {
            if (this.OldRecord == null)
            {
                this.OldRecord = new T();
            }
            this.OldRecord.SetProperty(this as T);
        }
        public abstract void SetProperty(T record);
        public abstract Boolean CompareAllColumn(T record);
        public abstract Boolean ComparePrimaryKeyColumn(T record);
    }
}
