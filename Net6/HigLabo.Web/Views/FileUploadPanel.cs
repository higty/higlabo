using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class FileUploadPanel
    {
        public String Text { get; set; } = "";
        public String ApiPath { get; set; } = "";

        public FileUploadPanel(String text, String apiPath)
        {
            this.Text = text;
            this.ApiPath = apiPath;
        }
    }
}
