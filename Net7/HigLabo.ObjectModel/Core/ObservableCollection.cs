using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class ObservableCollection<T> : System.Collections.ObjectModel.ObservableCollection<T>
    {
        public ObservableCollection()
           : base()
        {

        }

        public ObservableCollection(IEnumerable<T> source)
            : base(source)
        {

        }

        public ObservableCollection(List<T> source)
            : base(source)
        {

        }

        public Boolean AddIfNotExist(T item, Func<T, Boolean> selectorFunc)
        {
            if (this.Exists(el => Object.Equals(selectorFunc(item), selectorFunc(el))) == false)
            {
                this.Add(item);
                return true;
            }
            return false;
        }

        public virtual void AddRange(IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                this.Items.Add(item);
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public virtual void InsertRange(Int32 index, IEnumerable<T> collection)
        {
            foreach (T item in collection)
            {
                this.Items.Insert(index++, item);
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public virtual void RemoveRange(IEnumerable<T> collection)
        {
            Boolean isChanged = false;
            foreach (T item in collection)
            {
                if (this.Items.Remove(item))
                {
                    isChanged = true;
                }
            }

            if (isChanged)
            {
                this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
                this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
                this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        public virtual void RemoveAll(Func<T, Boolean> predicate)
        {
            Boolean isChanged = false;
            foreach (T item in this.ToArray())
            {
                if (predicate(item))
                {
                    this.Remove(item);
                    isChanged = true;
                }
            }

            if (isChanged)
            {
                this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
                this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
                this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        public virtual void ReplaceAll(T item)
        {
            this.ReplaceAll(new List<T>() { item });
        }

        public virtual void ReplaceAll(IEnumerable<T> collection)
        {
            var count = this.Count;

            this.Items.Clear();
            foreach (T item in collection)
            {
                this.Items.Add(item);
            }

            if (this.Count != count)
            {
                this.OnPropertyChanged(new PropertyChangedEventArgs("Count"));
            }
            this.OnPropertyChanged(new PropertyChangedEventArgs("Item[]"));
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
}
