using System;
using System.Collections.Generic;
using System.Text;

namespace HigLabo.Data
{
    public class DatabaseDefaultSettings
    {
        private List<Int32> _RetryIntervalMillisecondList = new List<int>();

        public IEnumerable<Int32> RetryIntervalMillisecondList
        {
            get { return _RetryIntervalMillisecondList; }
        }

        public void SetInterval(IEnumerable<Int32> retryIntervalMillisecondList)
        {
            this._RetryIntervalMillisecondList.Clear();
            this._RetryIntervalMillisecondList.AddRange(retryIntervalMillisecondList);
        }
    }
}
