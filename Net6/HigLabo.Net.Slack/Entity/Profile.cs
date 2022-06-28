using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Net.Slack
{
    public class Profile
    {
        public String Title { get; set; }
        public String Phone { get; set; }
        public String Skype { get; set; }
        public String Avatar_Hash { get; set; }
        public String Status_Text { get; set; }
        public String Status_Emoji { get; set; }
        public String[] Status_Emoji_Display_Info { get; set; }
        public Int32 Status_Expiration { get; set; }
        public String Real_Name { get; set; }
        public String Display_Name { get; set; }
        public String Real_Name_Normalized { get; set; }
        public String Display_Name_Normalized { get; set; }
        public String EMail { get; set; }
        public String First_Name { get; set; }
        public String Last_Name { get; set; }
        public Boolean Is_Custom_Image { get; set; }
        public String Image_Original { get; set; }
        public String Image_24 { get; set; }
        public String Image_32 { get; set; }
        public String Image_48 { get; set; }
        public String Image_72 { get; set; }
        public String Image_192 { get; set; }
        public String Image_512 { get; set; }
        public String Image_1024 { get; set; }
        public String Team { get; set; }
        public String Status_Text_Canonical { get; set; }
    }
}
