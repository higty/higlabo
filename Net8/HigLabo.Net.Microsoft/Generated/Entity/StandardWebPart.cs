using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/standardwebpart?view=graph-rest-1.0
    /// </summary>
    public partial class StandardWebPart
    {
        public string? ContainerTextWebPartId { get; set; }
        public WebPartData? Data { get; set; }
        public string? Id { get; set; }
        public string? WebPartType { get; set; }
    }
}
