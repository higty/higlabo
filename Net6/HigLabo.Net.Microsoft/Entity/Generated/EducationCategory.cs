using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/educationcategory?view=graph-rest-1.0
    /// </summary>
    public partial class EducationCategory
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
    }
}
