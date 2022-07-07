using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/authorednote?view=graph-rest-1.0
    /// </summary>
    public partial class AuthoredNote
    {
        public Identity? Author { get; set; }
        public ItemBody? Content { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
    }
}
