using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace HigLabo.Wpf
{
    public static class DispatcherExtensions
    {
        public static EventHandler CreateEventHander(this Dispatcher dispatcher, EventHandler eventHandler)
        {
            return (o, e) => dispatcher.BeginInvoke((Action)(() => eventHandler(o, e)), null);
        }
        public static EventHandler<T> CreateEventHander<T>(this Dispatcher dispatcher, EventHandler<T> eventHandler)
            where T : EventArgs
        {
            return (o, e) => dispatcher.BeginInvoke((Action)(() => eventHandler(o, e)), null);
        }
    }
}
