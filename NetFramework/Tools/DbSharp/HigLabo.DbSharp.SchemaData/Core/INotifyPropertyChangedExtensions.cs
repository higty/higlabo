using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.ComponentModel
{
    internal static class INotifyPropertyChangedExtensions
    {
        public static void SetPropertyValue<T, TProperty>(this T obj, ref TProperty field, TProperty value
            , PropertyChangedEventHandler onPropertyChanged, [CallerMemberName]  String propertyName = "")
            where T : INotifyPropertyChanged
        {
            if (Object.Equals(field, value) == true) return;
            field = value;
            var eh = onPropertyChanged;
            if (eh != null)
            {
                eh(obj, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
