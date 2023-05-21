using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/sharepointonedriveoptions?view=graph-rest-1.0
    /// </summary>
    public partial class SharePointOneDriveOptions
    {
        public enum SharePointOneDriveOptionsSearchContent
        {
            SharedContent,
            PrivateContent,
            UnknownFutureValue,
        }

        public SharePointOneDriveOptionsSearchContent IncludeContent { get; set; }
    }
}
