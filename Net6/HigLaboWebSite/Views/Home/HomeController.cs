using HigLabo.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Page
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Root()
        {
            return this.View("Home");
        }
        [HttpGet("/Home")]
        public IActionResult Home()
        {
            return this.View();
        }
        [HttpGet("/TinyMce")]
        public IActionResult TinyMce()
        {
            return this.View();
        }

        [HttpPost("/Api/File/Upload")]
        public async Task<Object> Api_File_Upload()
        {
            var bb = await this.GetBodyData();

            var l = new List<Object>();
            foreach (var f in this.Request.Form.Files)
            {
                if (f.ContentType.StartsWith("image/"))
                {
                    var r = new { Url = "https://www.google.com/images/branding/googlelogo/1x/googlelogo_color_272x92dp.png", FileName = "Dummy.png", IsImage = true };
                    l.Add(r);
                }
                else
                {
                    var r = new { Url = "https://sample.com/myfile.txt", FileName = "Dummy.txt" };
                    l.Add(r);
                }
            }
            return l;
        }
        [HttpPost("/Api/RichTextBox/Post")]
        public async Task<Object> Api_RichTextBox_Post()
        {
            var bodyText = await this.GetBodyText();

            return new {  };
        }
        private async Task<Byte[]> GetBodyData()
        {
            var request = this.Request;
            request.EnableBuffering();
            request.Body.Position = 0;
            var mm = new MemoryStream();
            await request.Body.CopyToAsync(mm);
            var bb = mm.ToArray();
            this.Request.Body.Position = 0;
            return bb;
        }
        private async Task<String> GetBodyText()
        {
            var bb = await this.GetBodyData();
            var bodyText = Encoding.UTF8.GetString(bb);
            return bodyText;
        }
        [HttpPost("/Api/Category/Search")]
        public Object Api_Category_Search()
        {
            var l = new List<CategoryRecord>();
            for (int i = 0; i < 10; i++)
            {
                var r = new CategoryRecord();
                r.CategoryCD = Guid.NewGuid();
                r.DisplayName = "カテゴリ" + i;
                l.Add(r);
            }
            return new { Data = l };
        }
        public class CategoryRecord
        {
            public Guid CategoryCD { get; set; }
            public String DisplayName { get; set; }
        }

        [HttpPost("/Api/User/Search")]
        public async Task<Object> Api_User_Search()
        {
            var l = new List<UserRecord>();
            for (int i = 0; i < 10; i++)
            {
                var r = new UserRecord();
                r.UserCD = Guid.NewGuid();
                r.DisplayName = "ユーザー" + i;
                l.Add(r);
            }
            return new { Data = l };
        }
        public class UserRecord
        {
            public Guid UserCD { get; set; }
            public String DisplayName { get; set; }
        }

        public class MentionUserSearchParameter
        {
            public String SearchText { get; set; } = "";
        }
        [HttpPost("/Api/Mention/User/Search")]
        public async Task<Object> Api_Mention_User_Search()
        {
            var p = new MentionUserSearchParameter();
            try
            {
                var bodyText = await this.GetBodyText();
                p = JsonConvert.DeserializeObject<MentionUserSearchParameter>(bodyText);
            }
            catch (Exception ex)
            {
            }

            var l = new List<MentinoUserRecord>();
            for (int i = 0; i < 10; i++)
            {
                var r = new MentinoUserRecord();
                r.ID = "user" + i;
                r.Name = "ユーザー" + i;
                l.Add(r);
            }
            if (p.SearchText.IsNullOrEmpty() == false)
            {
                l = l.FindAll(el => el.Name.Contains(p.SearchText, StringComparison.OrdinalIgnoreCase));
            }
            return new { Data = l };
        }
        public class MentinoUserRecord
        {
            [JsonProperty("id")]
            public String ID { get; set; }
            [JsonProperty("name")]
            public String Name { get; set; }
            [JsonProperty("image")]
            public String Image { get; set; } = "https://hignull.blob.core.windows.net/user/a6c4772fe0bc2f41f04e39dc2a1e93f4/profile_20210325_181105.png";
        }

    }
}
