using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/profilecardproperty?view=graph-rest-1.0
/// </summary>
public partial class ProfileCardProperty
{
    public ProfileCardAnnotation[]? Annotations { get; set; }
    public string? DirectoryPropertyName { get; set; }
}
