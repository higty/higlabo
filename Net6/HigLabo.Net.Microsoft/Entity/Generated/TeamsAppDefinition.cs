using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/teamsappdefinition?view=graph-rest-1.0
    /// </summary>
    public partial class TeamsAppDefinition
    {
        public enum TeamsAppDefinitionstring
        {
            Submitted,
            Published,
            Rejected,
        }

        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public TeamsAppDefinitionstring PublishingState { get; set; }
        public string? ShortDescription { get; set; }
        public string? TeamsAppId { get; set; }
        public string? Version { get; set; }
        public TeamworkBot? Bot { get; set; }
    }
}
