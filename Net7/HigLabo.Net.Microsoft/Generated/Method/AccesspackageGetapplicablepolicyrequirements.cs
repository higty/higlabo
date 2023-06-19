using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackageGetapplicablePolicyRequirementsParameter : IRestApiParameter
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
    public partial class AccesspackageGetapplicablePolicyRequirementsResponse : RestApiResponse
    {
        public AccessPackageAssignmentRequestRequirements[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageGetapplicablePolicyRequirementsResponse> AccesspackageGetapplicablePolicyRequirementsAsync()
        {
            var p = new AccesspackageGetapplicablePolicyRequirementsParameter();
            return await this.SendAsync<AccesspackageGetapplicablePolicyRequirementsParameter, AccesspackageGetapplicablePolicyRequirementsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageGetapplicablePolicyRequirementsResponse> AccesspackageGetapplicablePolicyRequirementsAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageGetapplicablePolicyRequirementsParameter();
            return await this.SendAsync<AccesspackageGetapplicablePolicyRequirementsParameter, AccesspackageGetapplicablePolicyRequirementsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageGetapplicablePolicyRequirementsResponse> AccesspackageGetapplicablePolicyRequirementsAsync(AccesspackageGetapplicablePolicyRequirementsParameter parameter)
        {
            return await this.SendAsync<AccesspackageGetapplicablePolicyRequirementsParameter, AccesspackageGetapplicablePolicyRequirementsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-getapplicablepolicyrequirements?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageGetapplicablePolicyRequirementsResponse> AccesspackageGetapplicablePolicyRequirementsAsync(AccesspackageGetapplicablePolicyRequirementsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageGetapplicablePolicyRequirementsParameter, AccesspackageGetapplicablePolicyRequirementsResponse>(parameter, cancellationToken);
        }
    }
}
