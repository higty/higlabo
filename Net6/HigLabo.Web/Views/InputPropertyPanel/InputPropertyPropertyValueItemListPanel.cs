using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public abstract class InputPropertyPropertyValueItemListPanel : InputPropertyPanel
    {
        public static readonly HtmlAttributes EmptyAttributes = new();

        public String SelectedDuration { get; set; } = "";
        public List<PropertyValueItem> ItemList { get; set; } = new List<PropertyValueItem>();
    }
    public class InputPropertyRadioButtonListPanel : InputPropertyPropertyValueItemListPanel
    {
        public override InputElementType ElementType => InputElementType.RadioButtonList;

        public String GroupName { get; set; } = "";
        public String PartialViewName { get; set; } = "";
    }
    public class InputPropertySelectButtonPanel : InputPropertyRadioButtonListPanel
    {
        public override InputElementType ElementType => InputElementType.SelectButton;
    }
    public class InputPropertyDropDownListPanel : InputPropertyPropertyValueItemListPanel
    {
        public class RootSelect
        {
            public HtmlAttributes Attributes { get; private set; } = new HtmlAttributes();
        }
        public override InputElementType ElementType => InputElementType.DropDownList;
        public RootSelect Select { get; init; } = new();
    }
    public class InputPropertyCheckBoxListPanel : InputPropertyPropertyValueItemListPanel
    {
        public override InputElementType ElementType => InputElementType.CheckBoxList;
        public String GroupName { get; set; } = "";
    }
}
