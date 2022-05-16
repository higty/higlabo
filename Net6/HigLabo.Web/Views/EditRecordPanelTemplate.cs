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
    public enum EditRecordPanelHeaderMode
    {
        Label,
        TextBox,
    }
    public class EditRecordPanelTemplate
    {
        public String ID { get; set; } = "";
        public String Key { get; set; } = "";
        public ToggleState ToggleState { get; set; } = ToggleState.Collapse;
        public Boolean CanToggle { get; set; } = true;
        public Boolean CanDelete { get; set; } = true;

        public EditRecordPanelHeaderMode HeaderMode { get; private set; } = EditRecordPanelHeaderMode.Label;
        public String HeaderName { get; set; } = "DisplayName";
        public ValidationResultMessagePanel HeaderValidationPanel { get; set; }
        public InputPropertyPanel? HeaderTextBindingPanel { get; set; }
        public List<InputPropertyPanel> InputList { get; private set; } = new List<InputPropertyPanel>();

        public EditRecordPanelTemplate(String id, String key)
        {
            this.ID = id;
            this.Key = key;
        }
        public void SetHeaderMode(EditRecordPanelHeaderMode headerMode)
        {
            this.HeaderMode = headerMode;
            if (headerMode == EditRecordPanelHeaderMode.TextBox)
            {
                this.CanToggle = false;
                this.ToggleState = ToggleState.Collapse;
            }
        }
        public static InputPropertyPanel CreateInputPropertyPanel(String name, String text, String validationValue)
        {
            var pl = InputPropertyPanel.Create(name, text);
            pl.ValidationResultMessagePanel.ValidationName.SetVueValue(validationValue);
            return pl;
        }
    }
}
