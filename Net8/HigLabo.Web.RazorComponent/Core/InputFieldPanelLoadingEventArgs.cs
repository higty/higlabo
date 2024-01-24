using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web
{
	public class RecordListLoadingContext
    {
		public string SearchText { get; set; } = "";
		public List<InputFieldPanelRecord> RecordList { get; init; }

		public RecordListLoadingContext(List<InputFieldPanelRecord> recordList)
			: this(recordList, "")
		{
		}
		public RecordListLoadingContext(List<InputFieldPanelRecord> recordList, string searchText)
		{
			this.RecordList = recordList;
			this.SearchText = searchText;
		}
	}
}
