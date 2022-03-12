using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("/Api/Image/Upload")]
        public async Task<Object> Api_Image_Upload()
        {
            var bb = await this.GetBodyData();

            return new { Location = "https://hignull.blob.core.windows.net/user/a6c4772fe0bc2f41f04e39dc2a1e93f4/profile_20210325_181105.png" };
        }
        [HttpPost("/Api/File/Upload")]
        public async Task<Object> Api_File_Upload()
        {
            var bb = await this.GetBodyData();

            return new { Href = "https://sample.com/myfile.txt", Text = "MyFile.txt" };
        }
        [HttpPost("/Api/RichTextBox/Post")]
        public async Task<Object> Api_RichTextBox_Post()
        {
            var bb = await this.GetBodyData();
            var bodyText = Encoding.UTF8.GetString(bb);

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
        public Object Api_User_Search()
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

    }
}
