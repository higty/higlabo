using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementManagementSettingsUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Settings: return $"/identityGovernance/entitlementManagement/settings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Settings,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class EntitlementManagementSettingsUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagementsettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementSettingsUpdateResponse> EntitlementManagementSettingsUpdateAsync()
        {
            var p = new EntitlementManagementSettingsUpdateParameter();
            return await this.SendAsync<EntitlementManagementSettingsUpdateParameter, EntitlementManagementSettingsUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagementsettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementSettingsUpdateResponse> EntitlementManagementSettingsUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementSettingsUpdateParameter();
            return await this.SendAsync<EntitlementManagementSettingsUpdateParameter, EntitlementManagementSettingsUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagementsettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementSettingsUpdateResponse> EntitlementManagementSettingsUpdateAsync(EntitlementManagementSettingsUpdateParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementSettingsUpdateParameter, EntitlementManagementSettingsUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagementsettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementSettingsUpdateResponse> EntitlementManagementSettingsUpdateAsync(EntitlementManagementSettingsUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementSettingsUpdateParameter, EntitlementManagementSettingsUpdateResponse>(parameter, cancellationToken);
        }
    }
}
