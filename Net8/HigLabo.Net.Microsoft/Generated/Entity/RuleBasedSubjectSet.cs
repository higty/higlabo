﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/identitygovernance-rulebasedsubjectset?view=graph-rest-1.0
/// </summary>
public partial class RuleBasedSubjectSet
{
    public string? Rule { get; set; }
}
