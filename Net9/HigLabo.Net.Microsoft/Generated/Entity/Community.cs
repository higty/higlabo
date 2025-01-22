using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/community?view=graph-rest-1.0
/// </summary>
public partial class Community
{
    public enum CommunityCommunityPrivacy
    {
        Public,
        Private,
        UnknownFutureValue,
    }

    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? GroupId { get; set; }
    public string? Id { get; set; }
    public Community? Privacy { get; set; }
    public Group? Group { get; set; }
    public User[]? Owners { get; set; }
}
