using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/artifactquery?view=graph-rest-1.0
    /// </summary>
    public partial class ArtifactQuery
    {
        public enum ArtifactQueryRestorableArtifact
        {
            Message,
            UnknownFutureValue,
        }

        public ArtifactQuery? ArtifactType { get; set; }
        public string? QueryExpression { get; set; }
    }
}
