using System;

namespace HigLabo.Core
{
    /// <summary>
    /// 付加情報を保持するEventArgsクラスです。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventArgs<T> : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public T Info { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EventArgs()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public EventArgs(T info)
        {
            this.Info = info;
        }
    }
}
