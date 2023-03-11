using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigLabo.Web.UI
{
    public class FileUploadPanel
    {
        public String SelectFileText { get; set; } = "";
        public String TakePhotoText { get; set; } = "";
        public String UseCameraText { get; set; } = "";
        public String ApiPath { get; set; } = "";
        public Boolean AllowSelectFile { get; set; } = true;
        public Boolean AllowTakePhoto { get; set; } = false;

        public FileUploadPanel(String selectFileText, String useCameraText, String takePhotoText, String apiPath, Boolean allowSelectFile, Boolean allowTakePhoto)
        {
            this.SelectFileText = selectFileText;
            this.UseCameraText = useCameraText;
            this.TakePhotoText = takePhotoText;
            this.ApiPath = apiPath;
            this.AllowSelectFile = allowSelectFile;
            this.AllowTakePhoto = allowTakePhoto;
        }
    }
}
