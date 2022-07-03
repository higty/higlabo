using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/worksheet?view=graph-rest-1.0
    /// </summary>
    public partial class Worksheet
    {
        public String? Id { get; set; }
        public String? Name { get; set; }
        public int Position { get; set; }
        public WorksheetString Visibility { get; set; }
    }
}
