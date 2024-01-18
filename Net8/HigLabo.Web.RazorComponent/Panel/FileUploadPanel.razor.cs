using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace HigLabo.Web.RazorComponent.Panel
{
    public partial class FileUploadPanel : ComponentBase
    {
        public enum FileSelectMode
        {
            Single,
            Multiple,
        }
        [Parameter]
        public string Text { get; set; } = T.Text.Upload;
        [Parameter]
        public FileSelectMode SelectMode { get; set; } = FileSelectMode.Single;
        [Parameter]
        public EventCallback<InputFileChangeEventArgs> OnChange { get; set; }

    }
}
