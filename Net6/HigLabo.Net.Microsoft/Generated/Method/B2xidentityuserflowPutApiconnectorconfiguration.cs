using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-put-apiconnectorconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class B2xidentityUserflowPutApiConnectorConfigurationParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? B2xUserFlowId { get; set; }
            public string? Step { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows_B2xUserFlowId_ApiConnectorConfiguration_Step_ref: return $"/identity/b2xUserFlows/{B2xUserFlowId}/apiConnectorConfiguration/{Step}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Identity_B2xUserFlows_B2xUserFlowId_ApiConnectorConfiguration_Step_ref,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
    }
    public partial class B2xidentityUserflowPutApiConnectorConfigurationResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-put-apiconnectorconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-put-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowPutApiConnectorConfigurationResponse> B2xidentityUserflowPutApiConnectorConfigurationAsync()
        {
            var p = new B2xidentityUserflowPutApiConnectorConfigurationParameter();
            return await this.SendAsync<B2xidentityUserflowPutApiConnectorConfigurationParameter, B2xidentityUserflowPutApiConnectorConfigurationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-put-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowPutApiConnectorConfigurationResponse> B2xidentityUserflowPutApiConnectorConfigurationAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityUserflowPutApiConnectorConfigurationParameter();
            return await this.SendAsync<B2xidentityUserflowPutApiConnectorConfigurationParameter, B2xidentityUserflowPutApiConnectorConfigurationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-put-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowPutApiConnectorConfigurationResponse> B2xidentityUserflowPutApiConnectorConfigurationAsync(B2xidentityUserflowPutApiConnectorConfigurationParameter parameter)
        {
            return await this.SendAsync<B2xidentityUserflowPutApiConnectorConfigurationParameter, B2xidentityUserflowPutApiConnectorConfigurationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-put-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowPutApiConnectorConfigurationResponse> B2xidentityUserflowPutApiConnectorConfigurationAsync(B2xidentityUserflowPutApiConnectorConfigurationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityUserflowPutApiConnectorConfigurationParameter, B2xidentityUserflowPutApiConnectorConfigurationResponse>(parameter, cancellationToken);
        }
    }
}
