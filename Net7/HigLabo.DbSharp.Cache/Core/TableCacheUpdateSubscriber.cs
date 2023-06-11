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
		public static event EventHandler<RedisEventSubscribeTimeoutEventArgs>? Timeout;

		private bool _IsDisposed = false;
		private AutoResetEvent _AutoResetEvent = new AutoResetEvent(false);

		public ITableCache Table { get; init; }

		public TableCacheUpdateSubscriber(ITableCache table)
		{
			this.Table = table;
			this.Table.Loaded += Table_Loaded;
		}

		private void Table_Loaded(object? sender, TableCacheUpdatedEventArgs e)
		{
			if (_IsDisposed == true) { return; }
			if (e.TableNameList.Contains(this.Table.TableName))
			{
				_AutoResetEvent.Set();
			}

		}
		public RedisEventWaitResult Wait()
		{
			return this.Wait(TimeSpan.FromMilliseconds(DefaultSettings.WaitMilliSeconds));
		}
		public RedisEventWaitResult Wait(Int32 milliSeconds)
		{
			return this.Wait(TimeSpan.FromMilliseconds(milliSeconds));
		}
		public RedisEventWaitResult Wait(TimeSpan timeout)
		{
			if (_AutoResetEvent.WaitOne(timeout) == true)
			{
				//Cache updated within timeout
				return RedisEventWaitResult.Success;
			}
			else
			{
				//Timeout occured...
				Timeout?.Invoke(null, new RedisEventSubscribeTimeoutEventArgs(this.Table.TableName));
				return RedisEventWaitResult.Timeout;
			}
		}

		public void Dispose()
		{
			_IsDisposed = true;
			this.Table.Loaded -= Table_Loaded;
			try
			{
				_AutoResetEvent.Dispose();
			}
			catch { }
		}
	}
}
