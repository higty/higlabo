using HigLabo.Core;
using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HigLabo.Web.UI
{
    public enum InputElementType
    {
        Hidden,
        TextBox,
        TextArea,
        RichTextBox,
        Password,
        Color,
        Date,
        Time,
        DateTime,
        DateDuration,
        DateTimeDuration,

        CheckBox,
        SelectButton,
        RadioButtonList,
        DropDownList,
        CheckBoxList,

        Record,
        RecordList,
    }
    public enum AddRecordMode
    {
        Search,
        Api,
    }
    public enum SelectRecordMode
    {
        Html,
        Template,
    }
    public class InputPropertyPanel
    {
        public class Setting
        {
            public String SetByEndTime { get; set; } = "Set by EndTime";
            public String SelectUserDefaultText { get; set; } = "Select By Click";
            public String AddRecord { get; set; } = "Add Record";
            public String SearchRecord { get; set; } = "Search Record";
            public String Search { get; set; } = "Search";
            public String SortBy { get; set; } = "SortBy";
            public String Close { get; set; } = "Close";
            public List<PropertyValueItem> DurationList { get; set; } = new List<PropertyValueItem>();
            public List<ColorTableRow> ColorTableRowList { get; private set; } = new List<ColorTableRow>();

            public Setting()
            {
                var l = DurationList;
                l.Add(new PropertyValueItem("0:30"));
                l.Add(new PropertyValueItem("1:00"));
                l.Add(new PropertyValueItem("1:30"));
                l.Add(new PropertyValueItem("2:00"));

                InitializeMaterialDesignColorList();
            }
            private void InitializeMaterialDesignColorList()
            {
                var l = ColorTableRowList;
                l.Add(new ColorTableRow(new String[] { "#ffebee", "#ffcdd2", "#ef9a9a", "#e57373", "#ef5350", "#f44336", "#e53935", "#d32f2f", "#c62828", "#b71c1c" }));
                l.Add(new ColorTableRow(new String[] { "#fce4ec", "#f8bbd0", "#f48fb1", "#f06292", "#ec407a", "#e91e63", "#d81b60", "#c2185b", "#ad1457", "#880e4f" }));
                l.Add(new ColorTableRow(new String[] { "#f3e5f5", "#e1bee7", "#ce93d8", "#ba68c8", "#ab47bc", "#9c27b0", "#8e24aa", "#7b1fa2", "#6a1b9a", "#4a148c" }));
                l.Add(new ColorTableRow(new String[] { "#ede7f6", "#d1c4e9", "#b39ddb", "#9575cd", "#7e57c2", "#673ab7", "#5e35b1", "#512da8", "#512da8", "#311b92" }));
                l.Add(new ColorTableRow(new String[] { "#e8eaf6", "#c5cae9", "#9fa8da", "#7986cb", "#5c6bc0", "#3f51b5", "#3949ab", "#303f9f", "#283593", "#1a237e" }));
                l.Add(new ColorTableRow(new String[] { "#e3f2fd", "#bbdefb", "#90caf9", "#64b5f6", "#42a5f5", "#2196f3", "#1e88e5", "#1976d2", "#1565c0", "#0d47a1" }));
                l.Add(new ColorTableRow(new String[] { "#e1f5fe", "#b3e5fc", "#81d4fa", "#4fc3f7", "#29b6f6", "#03a9f4", "#039be5", "#0288d1", "#0277bd", "#01579b" }));
                l.Add(new ColorTableRow(new String[] { "#e0f7fa", "#b2ebf2", "#80deea", "#4dd0e1", "#26c6da", "#00bcd4", "#00acc1", "#0097a7", "#00838f", "#006064" }));
                l.Add(new ColorTableRow(new String[] { "#e0f2f1", "#b2dfdb", "#80cbc4", "#4db6ac", "#26a69a", "#009688", "#00897b", "#00796b", "#00695c", "#004d40" }));
                l.Add(new ColorTableRow(new String[] { "#e8f5e9", "#c8e6c9", "#a5d6a7", "#81c784", "#66bb6a", "#4caf50", "#43a047", "#388e3c", "#2e7d32", "#1b5e20" }));
                l.Add(new ColorTableRow(new String[] { "#f1f8e9", "#dcedc8", "#c5e1a5", "#aed581", "#9ccc65", "#8bc34a", "#7cb342", "#689f38", "#558b2f", "#33691e" }));
                l.Add(new ColorTableRow(new String[] { "#f9fbe7", "#f0f4c3", "#e6ee9c", "#dce775", "#d4e157", "#cddc39", "#c0ca33", "#afb42b", "#9e9d24", "#827717" }));
                l.Add(new ColorTableRow(new String[] { "#fffde7", "#fff9c4", "#fff59d", "#fff176", "#fff176", "#ffeb3b", "#fdd835", "#fbc02d", "#f9a825", "#f57f17" }));
                l.Add(new ColorTableRow(new String[] { "#fff8e1", "#ffecb3", "#ffe082", "#ffd54f", "#ffca28", "#ffc107", "#ffb300", "#ffa000", "#ff8f00", "#ff6f00" }));
                l.Add(new ColorTableRow(new String[] { "#fff3e0", "#ffe0b2", "#ffcc80", "#ffb74d", "#ffa726", "#ff9800", "#fb8c00", "#f57c00", "#ef6c00", "#e65100" }));
                l.Add(new ColorTableRow(new String[] { "#fbe9e7", "#ffccbc", "#ffab91", "#ff8a65", "#ff7043", "#ff5722", "#f4511e", "#e64a19", "#d84315", "#bf360c" }));
                l.Add(new ColorTableRow(new String[] { "#efebe9", "#d7ccc8", "#bcaaa4", "#a1887f", "#8d6e63", "#795548", "#6d4c41", "#5d4037", "#4e342e", "#3e2723" }));
                l.Add(new ColorTableRow(new String[] { "#fafafa", "#f5f5f5", "#eeeeee", "#e0e0e0", "#bdbdbd", "#9e9e9e", "#757575", "#616161", "#424242", "#212121" }));
                l.Add(new ColorTableRow(new String[] { "#eceff1", "#cfd8dc", "#b0bec5", "#90a4ae", "#78909c", "#607d8b", "#546e7a", "#455a64", "#37474f", "#263238" }));
            }
        }
        public class TextSetting
        {
            public String SetByEndTime { get; set; } = InputPropertyPanel.Default.SetByEndTime;
            public String SelectUserDefaultText { get; set; } = InputPropertyPanel.Default.SelectUserDefaultText;
            public String AddRecord { get; set; } = InputPropertyPanel.Default.AddRecord;
            public String SearchRecord { get; set; } = InputPropertyPanel.Default.SearchRecord;
            public String Search { get; set; } = InputPropertyPanel.Default.Search;
            public String SortBy { get; set; } = InputPropertyPanel.Default.SortBy;
            public String Close { get; set; } = InputPropertyPanel.Default.Close;
        }

        public class DateTimeItem
        {
            private DateTime? _DateTime = null;

            public DateTime? DateTime
            {
                get { return _DateTime; }
                set
                {
                    if (value == null) { return; }
                    _DateTime = value;
                    if (_DateTime.HasValue)
                    {
                        this.Date = _DateTime.Value.ToString("yyyy/MM/dd");
                        this.HourMinute = _DateTime.Value.ToString("HH:mm");
                    }
                }
            }
            public String Date { get; set; } = "";
            public String HourMinute { get; set; } = "";
            public DateTime? GetDateTime()
            {
                var dtime = this.Date.ToDateTime();
                if (dtime.HasValue == false) { return null; }
                if (TimeSpan.TryParse(this.HourMinute, out var ts))
                {
                    return dtime + ts;
                }
                return null;
            }
        }
        public class DateTimeDuration
        {
            private DateTime? _StartTime = null;
            private DateTime? _EndTime = null;

            public DateTime? StartTime
            {
                get { return _StartTime; }
                set
                {
                    if (value == null) { return; }
                    _StartTime = value;
                    if (_StartTime.HasValue)
                    {
                        this.StartDate = _StartTime.Value.ToString("yyyy/MM/dd");
                        this.StartHourMinute = _StartTime.Value.ToString("HH:mm");
                    }
                }
            }
            public DateTime? EndTime
            {
                get { return _EndTime; }
                set
                {
                    if (value == null) { return; }
                    _EndTime = value;
                    if (this.EndTime.HasValue)
                    {
                        this.EndDate = _EndTime.Value.ToString("yyyy/MM/dd");
                        this.EndHourMinute = _EndTime.Value.ToString("HH:mm");
                    }
                }
            }

            public String StartDate { get; set; } = "";
            public String StartHourMinute { get; set; } = "";
            public String EndDate { get; set; } = "";
            public String EndHourMinute { get; set; } = "";
            public String Duration { get; set; } = "";
            public Boolean SetByEndTime { get; set; }

            public DateTime? GetStartTime()
            {
                var dtime = this.StartDate.ToDateTime();
                if (dtime.HasValue == false) { return null; }
                if (TimeSpan.TryParse(this.StartHourMinute, out var ts))
                {
                    return dtime + ts;
                }
                return null;
            }
            public DateTime? GetEndTime()
            {
                if (this.SetByEndTime)
                {
                    return String.Format("{0} {1}", this.EndDate, this.EndHourMinute).ToDateTime();
                }
                else
                {
                    var startTime = this.GetStartTime();
                    if (startTime.HasValue)
                    {
                        if (TimeSpan.TryParse(this.Duration, out var ts))
                        {
                            return startTime + ts;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            public DateTimeOffset? GetStartTime(TimeSpan offset)
            {
                var dtime = this.GetStartTime();
                if (dtime == null) { return null; }
                return new DateTimeOffset(dtime.Value, offset);
            }
            public DateTimeOffset? GetEndTime(TimeSpan offset)
            {
                var dtime = this.GetEndTime();
                if (dtime == null) { return null; }
                return new DateTimeOffset(dtime.Value, offset);
            }

            public override string ToString()
            {
                return String.Format("{0} - {1}"
                    , this.StartTime?.ToString("yyyy/MM/dd HH:mm")
                    , this.EndTime?.ToString("yyyy/MM/dd HH:mm"));
            }
        }
        public class CheckeBoxItem
        {
            public String Value { get; set; } = "";
            public Boolean Checked { get; set; }

            public CheckeBoxItem() { }
            public CheckeBoxItem(String value, Boolean @checked)
            {
                this.Value = value;
                this.Checked = @checked;
            }
        }
        public class ColorTableRow
        {
            public List<String> ColorList { get; private set; } = new List<String>();

            public ColorTableRow() { }
            public ColorTableRow(IEnumerable<String> colorList)
            {
                this.ColorList.AddRange(colorList);
            }
        }

        public static Setting Default = new Setting();

        public TextSetting TextSettings { get; set; } = new TextSetting();
        public InputElementType ElementType { get; set; } = InputElementType.TextBox;
        public String Name { get; set; } = "";
        public String Text { get; set; } = "";
        public String Value { get; set; } = "";
        public String RadioButtonGroupName { get; set; } = "";
        public InputPropertyPanelMessagePanel InputPropertyPanelMessagePanel { get; private set; } = new InputPropertyPanelMessagePanel("");
        public ValidationResultMessagePanel ValidationResultMessagePanel { get; private set; } = new ValidationResultMessagePanel();

        public List<PropertyValueItem> DurationList { get; set; } = new List<PropertyValueItem>();
        public String SelectedDuration { get; set; } = "";
        public List<PropertyValueItem> ItemList { get; set; } = new List<PropertyValueItem>();
        public List<ColorTableRow> ColorTableRowList { get; private set; } = new List<ColorTableRow>();

        public Boolean CanAdd { get; set; } = true;
        public AddRecordMode AddRecordMode { get; set; } = AddRecordMode.Search;
        public Boolean CanSort { get; set; } = false;
        public SelectRecordMode SelectRecordMode { get; set; } = SelectRecordMode.Html;
        public String ApiPathSearch { get; set; } = "";
        public String ApiPathDefaultGet { get; set; } = "";
        public String ApiParameter { get; set; } = "{}";
        public String TemplateID { get; set; } = "";
        public String SearchTemplateID { get; set; } = "";
        public Object DefaultRecord { get; set; } = new { };
        public HtmlAttributes PanelAttributes { get; private set; } = new HtmlAttributes();
        public HtmlAttributes InputAttributes { get; private set; } = new HtmlAttributes();

        public InputPropertyPanel() { }
        public InputPropertyPanel(String name, String text)
            : this(InputElementType.TextBox, name, text)
        {
        }
        public InputPropertyPanel(InputElementType elementType, String name)
            : this(elementType, name, "", "")
        {
        }
        public InputPropertyPanel(InputElementType elementType, String name, String text)
            : this(elementType, name, text, "")
        {
        }
        public InputPropertyPanel(InputElementType elementType, String name, String text, Boolean value)
            : this(elementType, name, text, value.ToString().ToLower())
        {
        }
        public InputPropertyPanel(InputElementType elementType, String name, String text, Guid value)
            : this(elementType, name, text, value.ToString())
        {
        }
        public InputPropertyPanel(InputElementType elementType, String name, String text, String value)
        {
            this.ElementType = elementType;
            if (this.ElementType == InputElementType.Color)
            {
                this.LoadDefaultColor();
            }
            this.Name = name;
            this.Text = text;
            this.RadioButtonGroupName = name;
            this.ValidationResultMessagePanel.ValidationName.SetValue(name);
            this.Value = value;
            
            foreach (var item in Default.DurationList)
            {
                this.DurationList.Add(new PropertyValueItem(item.Value));
            }
            this.SelectedDuration = "1:00";
        }
        public void LoadItem<T>(Func<T, String> textFunc) where T : Enum
        {
            foreach (var item in Enum<T>.GetValues())
            {
                var v = new PropertyValueItem(item.ToStringFromEnum(), textFunc(item));
            }
        }

        public HtmlString GetRecordTypeAttributeHtmlString()
        {
            var s = "";
            if (this.ElementType == InputElementType.DateTime ||
                this.ElementType == InputElementType.DateDuration ||
                this.ElementType == InputElementType.DateTimeDuration)
            {
                s =  String.Format("h-record=\"{0}\"", this.Name);
            }
            else if (this.ElementType == InputElementType.CheckBoxList ||
                this.ElementType == InputElementType.RecordList)
            {
                s = String.Format("h-record-list=\"{0}\"", this.Name);
            }
            else
            {
                s = String.Format("h-name=\"{0}\"", this.Name);
            }
            return new HtmlString(s);
        }
        public String GetSearchTemplateID()
        {
            if (String.IsNullOrEmpty(this.SearchTemplateID))
            {
                return this.TemplateID;
            }
            return SearchTemplateID;
        }
        public String GetDefaultRecordJson()
        {
            try
            {
                return JsonConvert.SerializeObject(this.DefaultRecord);
            }
            catch { }
            return "";
        }
        public void LoadDefaultColor()
        {
            foreach (var item in Default.ColorTableRowList)
            {
                var row = new ColorTableRow();
                row.ColorList.AddRange(item.ColorList);
                this.ColorTableRowList.Add(row);
            }
        }
    }
    public class PropertyValueItem
    {
        public String Value { get; set; } = "";
        public String Text { get; set; } = "";
        public Boolean Checked { get; set; }

        /// <summary>
        /// For deserialization
        /// </summary>
        public PropertyValueItem() { }
        public PropertyValueItem(String value)
        {
            this.Value = value;
            this.Text = value;
        }
        public PropertyValueItem(String value, String text)
        {
            this.Value = value;
            this.Text = text;
        }
    }
}
