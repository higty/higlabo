using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/onpremisesdirectorysynchronizationconfiguration?view=graph-rest-1.0
/// </summary>
public partial class OnPremisesDirectorySynchronizationConfiguration
{
    public OnPremisesAccidentalDeletionPrevention? AccidentalDeletionPrevention { get; set; }
}
