using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/teamworkactivitytopic?view=graph-rest-1.0
/// </summary>
public partial class TeamworkActivityTopic
{
    public enum TeamworkActivityTopicTeamworkActivityTopicSource
    {
        EntityUrl,
        Text,
    }

    public TeamworkActivityTopicTeamworkActivityTopicSource Source { get; set; }
    public string? Value { get; set; }
    public string? WebUrl { get; set; }
}
