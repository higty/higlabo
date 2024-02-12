using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.RazorComponent.Panel
{
	public partial class SelectRecordPanel<TItem> : ComponentBase
	{
		public class StateDate
		{
            internal Action<TItem> OnRecordSelected { get; set; } = r => { };
            internal Action OnClosed { get; set; } = () => { };

            internal int RecordIndex { get; set; } = -1;
            internal List<TItem> RecordList { get; set; } = new List<TItem>();

            public bool SearchContainerPanelVisible { get; set; } = true;
            public string SearchText { get; set; } = "";
            public Action<RecordListLoadingContext<TItem>> OnRecordListLoading { get; set; } = r => { };

            internal void RecordPanelSelected(TItem record)
            {
                this.OnRecordSelected(record);
            }
            internal void OnRecordListLoading_Invoke()
            {
                this.RecordList.Clear();
                this.OnRecordListLoading(new RecordListLoadingContext<TItem>(this.RecordList, this.SearchText));
            }
            internal bool SearchTextbox_Keydown(KeyboardEventArgs e)
            {
                var bl = false;
                if (e.Key == "Esc")
                {
                    this.RecordIndex = -1;
                    bl = true;
                }
                else if (e.Key == "Enter")
                {
                    if (this.RecordIndex < 0)
                    {
                        OnRecordListLoading_Invoke();
                    }
                    else
                    {
                        this.RecordPanelSelected(this.RecordList[this.RecordIndex]);
                    }
                }
                else if (e.Key == "ArrowUp")
                {
                    this.RecordIndex = this.RecordIndex - 1;
                    if (this.RecordIndex < -1)
                    {
                        this.RecordIndex = this.RecordList.Count - 1;
                    }
                    bl = true;
                }
                else if (e.Key == "ArrowDown")
                {
                    this.RecordIndex = this.RecordIndex + 1;
                    if (this.RecordIndex >= this.RecordList.Count)
                    {
                        this.RecordIndex = -1;
                    }
                    bl = true;
                }
                return bl;
            }
        }

        [Parameter]
		public StateDate State { get; set; } = new();
        [Parameter]
        [AllowNull]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
			this.OnRecordListLoading_Invoke();
		}
        private void OnRecordListLoading_Invoke()
		{
			this.State.OnRecordListLoading_Invoke();
		}

        private void SearchTextbox_Keydown(KeyboardEventArgs e)
		{
			if (this.State.SearchTextbox_Keydown(e))
            {
                this.StateHasChanged();
            }
        }
        private void SearchButton_Click(MouseEventArgs e)
		{
			OnRecordListLoading_Invoke();
		}

		private void RecordPanel_Click(TItem record)
		{
			this.State.RecordPanelSelected(record);
		}
    }
}
