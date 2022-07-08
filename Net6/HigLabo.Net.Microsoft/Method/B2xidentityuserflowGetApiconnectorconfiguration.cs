using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityUserflowGetApiConnectorConfigurationParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Dentity_B2xUserFlows_Id_ApiConnectorConfiguration: return $"/dentity/b2xUserFlows/{Id}/apiConnectorConfiguration";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Dentity_B2xUserFlows_Id_ApiConnectorConfiguration,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class B2xidentityUserflowGetApiConnectorConfigurationResponse : RestApiResponse
    {
        public IdentityApiConnector? PostFederationSignup { get; set; }
        public IdentityApiConnector? PostAttributeCollection { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowGetApiConnectorConfigurationResponse> B2xidentityUserflowGetApiConnectorConfigurationAsync()
        {
            var p = new B2xidentityUserflowGetApiConnectorConfigurationParameter();
            return await this.SendAsync<B2xidentityUserflowGetApiConnectorConfigurationParameter, B2xidentityUserflowGetApiConnectorConfigurationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowGetApiConnectorConfigurationResponse> B2xidentityUserflowGetApiConnectorConfigurationAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityUserflowGetApiConnectorConfigurationParameter();
            return await this.SendAsync<B2xidentityUserflowGetApiConnectorConfigurationParameter, B2xidentityUserflowGetApiConnectorConfigurationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowGetApiConnectorConfigurationResponse> B2xidentityUserflowGetApiConnectorConfigurationAsync(B2xidentityUserflowGetApiConnectorConfigurationParameter parameter)
        {
            return await this.SendAsync<B2xidentityUserflowGetApiConnectorConfigurationParameter, B2xidentityUserflowGetApiConnectorConfigurationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityUserflowGetApiConnectorConfigurationResponse> B2xidentityUserflowGetApiConnectorConfigurationAsync(B2xidentityUserflowGetApiConnectorConfigurationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityUserflowGetApiConnectorConfigurationParameter, B2xidentityUserflowGetApiConnectorConfigurationResponse>(parameter, cancellationToken);
        }
    }
}
