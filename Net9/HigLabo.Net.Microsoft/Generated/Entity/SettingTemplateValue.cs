﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/settingtemplatevalue?view=graph-rest-1.0
/// </summary>
public partial class SettingTemplateValue
{
    public string? DefaultValue { get; set; }
    public string? Description { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
}
