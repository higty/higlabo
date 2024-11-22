using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcdomainjoinconfiguration?view=graph-rest-1.0
/// </summary>
public partial class CloudPcDomainJoinConfiguration
{
    public enum CloudPcDomainJoinConfigurationCloudPcDomainJoinType
    {
        HybridAzureADJoin,
        AzureADJoin,
        UnknownFutureValue,
    }
    public enum CloudPcDomainJoinConfigurationCloudPcRegionGroup
    {
        Default,
        Australia,
        Canada,
        UsCentral,
        UsEast,
        UsWest,
        France,
        Germany,
        EuropeUnion,
        UnitedKingdom,
        Japan,
        Asia,
        India,
        SouthAmerica,
        Euap,
        UsGovernment,
        UsGovernmentDOD,
        UnknownFutureValue,
        Norway,
        Switzerland,
        SouthKorea,
    }

    public CloudPcDomainJoinConfiguration? DomainJoinType { get; set; }
    public string? OnPremisesConnectionId { get; set; }
    public CloudPcDomainJoinConfigurationCloudPcRegionGroup RegionGroup { get; set; }
    public string? RegionName { get; set; }
}
