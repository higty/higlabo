using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public abstract class InputPropertySelectRecordPanel : InputPropertyPanel
    {
        public Boolean CanAdd { get; set; } = true;
        public AddRecordMode AddRecordMode { get; set; } = AddRecordMode.Search;
        public Boolean CanSort { get; set; } = false;
        public SelectRecordMode SelectRecordMode { get; set; } = SelectRecordMode.Html;
        public Boolean CanCreateRecord { get; set; } = false;

        public String ApiPathSearch { get; set; } = "";
        public String ApiPathDefaultGet { get; set; } = "";
        public String ApiParameter { get; set; } = "{}";
        public String TemplateID { get; set; } = "";
        public String SearchTemplateID { get; set; } = "";
        public Object DefaultRecord { get; set; } = new { };
        public String ApiPathSearchByText { get; set; } = "";
        public String ApiPathCreateRecord { get; set; } = "";

        public List<Tab> TabList { get; private set; } = new List<Tab>();
        public List<InputPropertyPanel> InputList { get; private set; } = new List<InputPropertyPanel>();

        public InputPropertySearchRecordListPanel SearchRecordListPanel { get; init; }

        public String GetSearchTemplateID()
        {
            if (String.IsNullOrEmpty(this.SearchTemplateID))
            {
                return this.TemplateID;
            }
            return SearchTemplateID;
        }
    }
    public class InputPropertySearchRecordListPanel
    {
        public HtmlAttributes Attributes { get; private set; } = new HtmlAttributes();
        public InputPropertySelectRecordPanel SelectRecordPanel { get; init; }

        public InputPropertySearchRecordListPanel(InputPropertySelectRecordPanel panel)
        {
            this.SelectRecordPanel = panel;
        }
    }
    public class InputPropertyRecordPanel : InputPropertySelectRecordPanel
    {
        public class RootSelectRecordPanel
        {
            public HtmlAttributes Attributes { get; private set; } = new HtmlAttributes();
        }

        public override InputElementType ElementType => InputElementType.Record;
        public RootSelectRecordPanel SelectRecordPanel { get; init; } = new RootSelectRecordPanel();

        public InputPropertyRecordPanel()
        {
            this.SearchRecordListPanel = new InputPropertySearchRecordListPanel(this);
        }
    }
    public class InputPropertyRecordListPanel : InputPropertySelectRecordPanel
    {
        public class RootSelectRecordListPanel
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();
        }
        public class RootButtonListPanel
        {
            public HtmlAttributes Attributes { get; init; } = new HtmlAttributes();
            public Button AddButton { get; init; } = new();
            public Button SortButton { get; init; } = new();
        }
        public class Button
        {
            public HtmlAttributes Attributes { get; private set; } = new HtmlAttributes();
        }

        public override InputElementType ElementType => InputElementType.RecordList;
        public RootSelectRecordListPanel SelectRecordListPanel { get; init; } = new RootSelectRecordListPanel();
        public RootButtonListPanel ButtonListPanel { get; init; } = new();

        public InputPropertyRecordListPanel()
        {
            this.SearchRecordListPanel = new InputPropertySearchRecordListPanel(this);
        }
    }
}
