using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class Attachment
    {
        public string? From_Url { get; set; }
        public string? Image_Url { get; set; }
        public int Image_Width { get; set; }
        public int Image_Height { get; set; }
        public int Image_Bytes { get; set; }
        public string? Service_Icon { get; set; }
        public int ID { get; set; }
        public string? Original_Url { get; set; }
        public string? Fallback { get; set; }
        public string? Text { get; set; }
        public string? Title { get; set; }
        public string? Title_Link { get; set; }
        public string? Service_Name { get; set; }
    }
}
