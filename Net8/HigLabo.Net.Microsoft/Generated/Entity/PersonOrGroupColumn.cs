using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/personorgroupcolumn?view=graph-rest-1.0
    /// </summary>
    public partial class PersonOrGroupColumn
    {
        public bool? AllowMultipleSelection { get; set; }
        public string? ChooseFromType { get; set; }
        public string? DisplayAs { get; set; }
    }
}
