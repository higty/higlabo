using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class InputPropertyTimeDurationPanel : InputPropertyPanel
    {
        public enum EndTimeSelectMode
        {
            EndTime,
            Duration,
        }
        public class RootFlexPanel
        {
            public HtmlAttributes Attributes { get; private set; } = new HtmlAttributes();
            public TextBoxElement StartTime { get; init; } = new TextBoxElement();
            public TextBoxElement EndTime { get; init; } = new TextBoxElement();
        }

        public override InputElementType ElementType => InputElementType.TimeDuration;
        public RootFlexPanel FlexPanel { get; init; } = new RootFlexPanel();
        public EndTimeSelectMode SelectMode { get; set; } = EndTimeSelectMode.EndTime;
        public Boolean SelectEndTime
        {
            get { return this.SelectMode == EndTimeSelectMode.EndTime; }
        }
        public Boolean SelectDuration
        {
            get { return this.SelectMode == EndTimeSelectMode.Duration; }
        }
    }
}
