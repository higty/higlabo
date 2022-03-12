using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class SelectTimePopupPanel
    {
        public class Setting
        {
            public String DisplayAll { get; set; } = "Display All";
            public String Hour { get; set; } = "Hour";
            public String Minute { get; set; } = "Minute";
        }
        public class TextSetting
        {
            public String DisplayAll { get; set; } = SelectTimePopupPanel.Default.DisplayAll;
            public String Hour { get; set; } = SelectTimePopupPanel.Default.Hour;
            public String Minute { get; set; } = SelectTimePopupPanel.Default.Minute;
        }
        public static Setting Default = new Setting();
 
        public TextSetting TextSettings { get; set; } = new TextSetting();
        public Int32 StartHour { get; set; } = 9;
        public Int32 EndHour { get; set; } = 18;

        public Int32 MaxHour { get; set; } = 30;
        public List<Int32> MinuteList { get; private set; } = new List<int>();
        public List<Int32> DurationList { get; private set; } = new List<int>();

        public SelectTimePopupPanel()
        {
            this.MinuteList.Add(0);
            this.MinuteList.Add(10);
            this.MinuteList.Add(15);
            this.MinuteList.Add(20);
            this.MinuteList.Add(30);
            this.MinuteList.Add(40);
            this.MinuteList.Add(45);
            this.MinuteList.Add(50);

            this.DurationList.Add(15);
            this.DurationList.Add(30);
            this.DurationList.Add(45);
            this.DurationList.Add(60);
            this.DurationList.Add(90);
            for (int i = 2; i < 14; i++)
            {
                this.DurationList.Add(i * 60);
            }
        }
    }
}
