using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/profilephoto?view=graph-rest-1.0
    /// </summary>
    public partial class ProfilePhoto
    {
        public string? Id { get; set; }
        public Int32? Height { get; set; }
        public Int32? Width { get; set; }
    }
}
