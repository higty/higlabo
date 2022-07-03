using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/chart?view=graph-rest-1.0
    /// </summary>
    public partial class Chart
    {
        public Double? Height { get; set; }
        public String? Id { get; set; }
        public Double? Left { get; set; }
        public String? Name { get; set; }
        public Double? Top { get; set; }
        public Double? Width { get; set; }
    }
}
