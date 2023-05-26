using System;

namespace HigLabo.Core
{
    public class EventArgs<T> : EventArgs
    {
        public T Info { get; init; }

        public EventArgs(T info)
        {
            this.Info = info;
        }
    }
}
