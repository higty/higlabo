
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/provisioningstep?view=graph-rest-1.0
    /// </summary>
    public enum ProvisioningStepProvisioningStepType
    {
        Import,
        Scoping,
        Matching,
        Processing,
        ReferenceResolution,
        Export,
        UnknownFutureValue,
    }
}
