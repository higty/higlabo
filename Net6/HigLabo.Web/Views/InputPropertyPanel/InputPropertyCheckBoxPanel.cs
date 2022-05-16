using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class InputPropertyCheckBoxPanel : InputPropertyPanel
    {
        public class RootCheckBoxPanel
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();
            public CheckBox CheckBox { get; init; } = new();
        }
        public class RootLabel
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();
        }
        public class CheckBox
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();
        }

        public override InputElementType ElementType => InputElementType.CheckBox;
        public RootCheckBoxPanel CheckBoxPanel { get; init; } = new();
        public RootLabel Label { get; init; } = new();
    }
}
