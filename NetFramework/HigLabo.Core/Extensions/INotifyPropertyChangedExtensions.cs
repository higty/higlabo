using HigLabo.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.ComponentModel
{
    public static partial class INotifyPropertyChangedExtensions
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
        public static void SetPropertyValue<T>(this T obj, ref DateTimeOffset field, DateTimeOffset value
            , PropertyChangedEventHandler onPropertyChanged, [CallerMemberName]  String propertyName = "")
         where T : INotifyPropertyChanged
        {
            if (field == null && value == null) return; 
            if (field != null && value != null &&
                field.EqualsExact(value) == true) return;
            field = value;
            var eh = onPropertyChanged;
            if (eh != null)
            {
                eh(obj, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
