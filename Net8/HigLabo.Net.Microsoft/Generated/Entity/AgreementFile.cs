﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/agreementfile?view=graph-rest-1.0
/// </summary>
public partial class AgreementFile
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public AgreementFileData? FileData { get; set; }
    public string? FileName { get; set; }
    public string? Id { get; set; }
    public bool? IsDefault { get; set; }
    public bool? IsMajorVersion { get; set; }
    public string? Language { get; set; }
    public AgreementFileLocalization[]? Localizations { get; set; }
}
