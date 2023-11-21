using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
	public class TableCacheUpdateSubscriberDefaultSettings
	{
		public Int32 WaitMilliSeconds { get; set; } = 3000;
	}
	public class TableCacheUpdateSubscriber : IDisposable
	{
		public static TableCacheUpdateSubscriberDefaultSettings DefaultSettings { get; set; } = new();
		public static event EventHandler<TableCacheUpdateSubscribeTimeoutEventArgs>? Timeout;

		private bool _IsDisposed = false;
        private Boolean _Loaded = false;
        private AutoResetEvent _AutoResetEvent = new AutoResetEvent(false);

		public ITableCache Table { get; init; }

		public TableCacheUpdateSubscriber(ITableCache table)
		{
			this.Table = table;
			this.Table.Loaded += this.Table_Loaded;
		}

		private void Table_Loaded(object? sender, EventArgs e)
		{
			if (_IsDisposed == true) { throw new ObjectDisposedException("TableCacheUpdateSubscriber"); }
            _Loaded = true;
            _AutoResetEvent.Set();
        }
        public TableCacheUpdateWaitResult Wait()
		{
			return this.Wait(TimeSpan.FromMilliseconds(DefaultSettings.WaitMilliSeconds));
		}
		public TableCacheUpdateWaitResult Wait(Int32 milliSeconds)
		{
			return this.Wait(TimeSpan.FromMilliseconds(milliSeconds));
		}
		public TableCacheUpdateWaitResult Wait(TimeSpan timeout)
		{
			if (_Loaded) { return TableCacheUpdateWaitResult.Success; }

			if (_AutoResetEvent.WaitOne(timeout) == true)
			{
				//Cache updated within timeout
				return TableCacheUpdateWaitResult.Success;
			}
			else
			{
				//Timeout occured...
				Timeout?.Invoke(null, new TableCacheUpdateSubscribeTimeoutEventArgs(this.Table.TableName));
				return TableCacheUpdateWaitResult.Timeout;
			}
		}

		public void Dispose()
		{
			try
			{
                this.Table.Loaded -= this.Table_Loaded;
                _AutoResetEvent.Dispose();
			}
			catch { }
            _IsDisposed = true;
        }
    }
}
