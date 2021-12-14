using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
