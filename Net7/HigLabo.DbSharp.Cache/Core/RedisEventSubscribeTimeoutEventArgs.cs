using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.DbSharp
{
	public class RedisEventSubscribeTimeoutEventArgs : EventArgs
	{
		public String TableName { get; set; }

		public RedisEventSubscribeTimeoutEventArgs(String tableName)
		{
			this.TableName = tableName;
		}
	}
}
