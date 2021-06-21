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
    }
}
