using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/itembody?view=graph-rest-1.0
    /// </summary>
    public partial class ItemBody
    {
        public string Content { get; set; }
        public ItemBodyBodyType ContentType { get; set; }
    }
}
