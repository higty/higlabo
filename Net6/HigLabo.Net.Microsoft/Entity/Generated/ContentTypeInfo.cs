using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/contenttypeinfo?view=graph-rest-1.0
    /// </summary>
    public partial class ContentTypeInfo
    {
        public String? Id { get; set; }
        public String? Name { get; set; }
    }
}
