using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public abstract class InputPropertyInputElementPanel : InputPropertyPanel
    {
        public class RootInput
        {
            public HtmlAttributes Attributes { get; private set; } = new HtmlAttributes();
        }
        public class RootTextArea
        {
            public HtmlAttributes Attributes { get; private set; } = new HtmlAttributes();
        }
    }
    public class InputPropertyHiddenPanel : InputPropertyInputElementPanel
    {
        public override InputElementType ElementType => InputElementType.Hidden;
        public RootInput Input { get; init; } = new();
    }
    public class InputPropertyTextBoxPanel : InputPropertyInputElementPanel
    {
        public override InputElementType ElementType => InputElementType.TextBox;
        public RootInput Input { get; init; } = new();
    }
    public class InputPropertyTextAreaPanel : InputPropertyInputElementPanel
    {
        public override InputElementType ElementType => InputElementType.TextArea;
        public RootTextArea TextArea { get; init; } = new();
    }
    public class InputPropertyRichTextBoxPanel : InputPropertyInputElementPanel
    {
        public override InputElementType ElementType => InputElementType.RichTextBox;
        public String ID { get; set; } = "RichTextBox";
        public RootTextArea TextArea { get; init; } = new();
    }
    public class InputPropertyReadonlyTextBoxPanel : InputPropertyInputElementPanel
    {
        public override InputElementType ElementType => InputElementType.ReadonlyTextBox;
        public RootInput Input { get; init; } = new();
    }
    public class InputPropertyPasswordPanel : InputPropertyInputElementPanel
    {
        public override InputElementType ElementType => InputElementType.Password;
        public RootInput Input { get; init; } = new();
    }
    public class InputPropertyCalendarPanel : InputPropertyInputElementPanel
    {
        public override InputElementType ElementType => InputElementType.Calendar;
        public RootInput Input { get; init; } = new();
    }
    public class InputPropertyDatePanel : InputPropertyInputElementPanel
    {
        public override InputElementType ElementType => InputElementType.Date;
        public RootInput Input { get; init; } = new();
    }
    public class InputPropertyTimePanel : InputPropertyInputElementPanel
    {
        public override InputElementType ElementType => InputElementType.Time;
        public RootInput Input { get; init; } = new();
    }
}
