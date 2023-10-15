using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
	public class TableCacheUpdateSubscribeTimeoutEventArgs : EventArgs
	{
		public String TableName { get; set; }

		public TableCacheUpdateSubscribeTimeoutEventArgs(String tableName)
		{
			this.TableName = tableName;
		}
	}
}
