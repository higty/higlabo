using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
    public class RecordListLoadingContext<TItem>
    {
        public List<TItem> RecordList { get; init; } 

		public RecordListLoadingContext(List<TItem> recordList)
		{
			this.RecordList = recordList;
		}
	}
	public class RecordListLoadingContext<TItem, TFilterItem>
	{
		public List<TItem> RecordList { get; init; }
		public string SearchText { get; set; } = "";
		public TFilterItem? Filter { get; set; }

		public RecordListLoadingContext(List<TItem> recordList, string searchText, TFilterItem? filter)
		{
			this.RecordList = recordList;
			this.SearchText = searchText;
			this.Filter = filter;
		}
	}
}
