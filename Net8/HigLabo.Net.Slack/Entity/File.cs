using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class File
    {
        public string? ID { get; set; }
        public int Created { get; set; }
        public int Timestamp { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? MimeType { get; set; }
        public string? FileType { get; set; }
        public string? Pretty_Type { get; set; }
        public string? User { get; set; }
        public Boolean Editable { get; set; }
        public int Size { get; set; }
        public string? Mode { get; set; }
        public bool Is_External { get; set; }
        public string? External_type { get; set; }
        public bool Is_Public { get; set; }
        public bool Public_Url_Shared { get; set; }
        public bool Display_As_Bot { get; set; }
        public string? UserName { get; set; }
        public string? Url_Private { get; set; }
        public string? Url_Private_Download { get; set; }
        public string? Media_Display_Type { get; set; }
        public string? Permalink { get; set; }
        public string? Permalink_Public { get; set; }
        public bool Is_Starred { get; set; }
        public bool Has_Rich_Preview { get; set; }

        public string? Thumb_64 { get; set; }
        public string? Thumb_80 { get; set; }
        public string? Thumb_360 { get; set; }
        public int Thumb_360_w { get; set; }
        public int Thumb_360_h { get; set; }
        public string? Thumb_480 { get; set; }
        public int Thumb_480_w { get; set; }
        public int Thumb_480_h { get; set; }
        public string? Thumb_160 { get; set; }
        public string? Thumb_720 { get; set; }
        public int Thumb_720_w { get; set; }
        public int Thumb_720_h { get; set; }
        public string? Thumb_800 { get; set; }
        public int Thumb_800_w { get; set; }
        public int Thumb_800_h { get; set; }
        public string? Thumb_960 { get; set; }
        public int Thumb_960_w { get; set; }
        public int Thumb_960_h { get; set; }
        public string? Thumb_1024 { get; set; }
        public int Thumb_1024_w { get; set; }
        public int Thumb_1024_h { get; set; }
        public int Original_w { get; set; }
        public int Original_h { get; set; }
        public string? Thumb_Tiny { get; set; }
    }
}
