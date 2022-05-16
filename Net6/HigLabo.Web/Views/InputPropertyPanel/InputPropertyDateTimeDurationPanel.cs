using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class InputPropertyDateTimeDurationPanel : InputPropertyPanel
    {
        public class RootSetByEndPanel
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();
            public CheckBoxPanel CheckBoxPanel { get; init; } = new();
        }
        public class CheckBoxPanel
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();
        }
        public class RootFlexPanel
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();
            public DurationStartPanel DurationStartPanel { get; init; } = new();
            public DurationListPanel DurationListPanel { get; init; } = new();
            public DurationEndPanel DurationEndPanel { get; init; } = new();
        }
        public class DurationStartPanel
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();
            public TextBoxElement StartDate { get; init; } = new TextBoxElement();
            public TextBoxElement StartHourMinute { get; init; } = new TextBoxElement();
        }
        public class DurationListPanel
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();

        }
        public class DurationEndPanel
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();
            public DurationEndPanelFlexPanel FlexPanel { get; init; } = new();
        }
        public class DurationEndPanelFlexPanel
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();
            public TextBoxElement EndDate { get; init; } = new TextBoxElement();
            public TextBoxElement EndHourMinute { get; init; } = new TextBoxElement();
        }

        public override InputElementType ElementType => InputElementType.DateTimeDuration;
        public RootSetByEndPanel SetByEndPanel { get; init; } = new();
        public RootFlexPanel FlexPanel { get; init; } = new();
        public List<PropertyValueItem> DurationList { get; set; } = new List<PropertyValueItem>();
        public String SelectedDuration { get; set; } = "1:00";

        public InputPropertyDateTimeDurationPanel()
        {
            foreach (var item in Default.DurationList)
            {
                this.DurationList.Add(new PropertyValueItem(item.Value));
            }
        }
    }
}
