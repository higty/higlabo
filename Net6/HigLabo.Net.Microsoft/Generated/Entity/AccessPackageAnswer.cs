using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/accesspackageanswer?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAnswer
    {
        public AccessPackageQuestion? AnsweredQuestion { get; set; }
        public string? DisplayValue { get; set; }
    }
}
