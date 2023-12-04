using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HigLabo.Wpf
{
    public interface ICheckedItem
    {
        Boolean IsChecked { get; set; }
    }
    public class CheckedItem<T> : ICheckedItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Boolean _IsChecked = false;

        public Boolean IsChecked
        {
            get { return _IsChecked; }
            set
            {
                if (_IsChecked ==  value) return;   
                _IsChecked = value;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsChecked)));
            }
        }
        public T Item { get; set; }
        public CheckedItem(T item)
        {
            this.Item = item;
        }

    }
    public class CheckedItem
    {
        public static CheckedItem<T> Create<T>(T item)
        {
            return new CheckedItem<T>(item);
        }
        public static CheckedItem<T> Create<T>(T item, Boolean isChecked)
        {
            var o = new CheckedItem<T>(item);
            o.IsChecked = isChecked;
            return o;
        }
    }
}
