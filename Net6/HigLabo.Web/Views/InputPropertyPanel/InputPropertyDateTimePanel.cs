using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class InputPropertyDateTimePanel : InputPropertyPanel
    {
        public class RootFlexPanel
        {
            public HtmlAttributes Attributes { get; private set; } = new HtmlAttributes();
            public TextBoxElement Date { get; init; } = new TextBoxElement();
            public TextBoxElement HourMinute { get; init; } = new TextBoxElement();
        }

        public override InputElementType ElementType => InputElementType.DateTime;
        public RootFlexPanel FlexPanel { get; init; } = new RootFlexPanel();
    }
}
