﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/accessreviewinstancedecisionitemserviceprincipalresource?view=graph-rest-1.0
/// </summary>
public partial class AccessReviewInstanceDecisionItemServicePrincipalResource
{
    public string? AppId { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? Type { get; set; }
}
