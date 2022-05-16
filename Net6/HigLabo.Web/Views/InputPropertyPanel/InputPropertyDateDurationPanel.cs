using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class InputPropertyDateDurationPanel : InputPropertyPanel
    {
        public class RootFlexPanel
        {
            public HtmlAttributes Attributes { get; private set; } = new HtmlAttributes();
            public TextBoxElement StartDate { get; init; } = new TextBoxElement();
            public TextBoxElement EndDate { get; init; } = new TextBoxElement();
        }

        public override InputElementType ElementType => InputElementType.DateDuration;
        public RootFlexPanel FlexPanel { get; init; } = new RootFlexPanel();
    }
}
