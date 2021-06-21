using HigLabo.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public enum ToggleState
    {
        Collapse,
        Expand,
    }
    public class EditRecordPanelTemplate
    {
        public String ID { get; set; } = "";
        public String Key { get; set; } = "";
        public String HeaderName { get; set; } = "DisplayName";
        public ToggleState ToggleState { get; set; } = ToggleState.Collapse;
        public Boolean CanToggle { get; set; } = true;
        public Boolean CanDelete { get; set; } = true;

        public InputPropertyPanel? HeaderTextBindingPanel { get; set; }
        public List<InputPropertyPanel> InputList { get; private set; } = new List<InputPropertyPanel>();

        public EditRecordPanelTemplate(String id, String key)
        {
            this.ID = id;
            this.Key = key;
        }

        public static InputPropertyPanel CreateInputPropertyPanel(String name, String text, String validationValue)
        {
            var pl = new InputPropertyPanel(name, text);
            pl.ValidationResultMessagePanel.ValidationName.SetVueValue(validationValue);
            return pl;
        }
    }
}
