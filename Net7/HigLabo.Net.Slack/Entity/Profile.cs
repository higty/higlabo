using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class Profile
    {
        public string? Title { get; set; }
        public string? Phone { get; set; }
        public string? Skype { get; set; }
        public string? Avatar_Hash { get; set; }
        public string? Status_Text { get; set; }
        public string? Status_Emoji { get; set; }
        public String[]? Status_Emoji_Display_Info { get; set; }
        public Int32 Status_Expiration { get; set; }
        public string? Real_Name { get; set; }
        public string? Display_Name { get; set; }
        public string? Real_Name_Normalized { get; set; }
        public string? Display_Name_Normalized { get; set; }
        public string? EMail { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public Boolean Is_Custom_Image { get; set; }
        public string? Image_Original { get; set; }
        public string? Image_24 { get; set; }
        public string? Image_32 { get; set; }
        public string? Image_48 { get; set; }
        public string? Image_72 { get; set; }
        public string? Image_192 { get; set; }
        public string? Image_512 { get; set; }
        public string? Image_1024 { get; set; }
        public string? Team { get; set; }
        public string? Status_Text_Canonical { get; set; }
    }
}
