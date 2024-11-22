using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
/// </summary>
public partial class AccessPackageGetapplicablePolicyRequirementsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AccessPackageId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_AccessPackageId_GetApplicablePolicyRequirements: return $"/identityGovernance/entitlementManagement/accessPackages/{AccessPackageId}/getApplicablePolicyRequirements";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        IdentityGovernance_EntitlementManagement_AccessPackages_AccessPackageId_GetApplicablePolicyRequirements,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
}
public partial class AccessPackageGetapplicablePolicyRequirementsResponse : RestApiResponse<AccessPackageAssignmentRequestRequirements>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageGetapplicablePolicyRequirementsResponse> AccessPackageGetapplicablePolicyRequirementsAsync()
    {
        var p = new AccessPackageGetapplicablePolicyRequirementsParameter();
        return await this.SendAsync<AccessPackageGetapplicablePolicyRequirementsParameter, AccessPackageGetapplicablePolicyRequirementsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageGetapplicablePolicyRequirementsResponse> AccessPackageGetapplicablePolicyRequirementsAsync(CancellationToken cancellationToken)
    {
        var p = new AccessPackageGetapplicablePolicyRequirementsParameter();
        return await this.SendAsync<AccessPackageGetapplicablePolicyRequirementsParameter, AccessPackageGetapplicablePolicyRequirementsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageGetapplicablePolicyRequirementsResponse> AccessPackageGetapplicablePolicyRequirementsAsync(AccessPackageGetapplicablePolicyRequirementsParameter parameter)
    {
        return await this.SendAsync<AccessPackageGetapplicablePolicyRequirementsParameter, AccessPackageGetapplicablePolicyRequirementsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AccessPackageGetapplicablePolicyRequirementsResponse> AccessPackageGetapplicablePolicyRequirementsAsync(AccessPackageGetapplicablePolicyRequirementsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AccessPackageGetapplicablePolicyRequirementsParameter, AccessPackageGetapplicablePolicyRequirementsResponse>(parameter, cancellationToken);
    }
}
