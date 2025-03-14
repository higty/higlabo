﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/shift?view=graph-rest-1.0
/// </summary>
public partial class Shift
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public ShiftItem? DraftShift { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? SchedulingGroupId { get; set; }
    public ShiftItem? SharedShift { get; set; }
    public string? UserId { get; set; }
}
