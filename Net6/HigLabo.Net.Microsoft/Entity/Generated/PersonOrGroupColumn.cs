using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/personorgroupcolumn?view=graph-rest-1.0
    /// </summary>
    public partial class PersonOrGroupColumn
    {
        public Boolean? AllowMultipleSelection { get; set; }
        public String? DisplayAs { get; set; }
        public String? ChooseFromType { get; set; }
    }
}
