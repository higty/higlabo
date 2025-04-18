﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/certificationcontrol?view=graph-rest-1.0
/// </summary>
public partial class CertificationControl
{
    public string? Name { get; set; }
    public string? Url { get; set; }
}
