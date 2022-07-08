using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentitycontainerListB2xUserflowsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows: return $"/identity/b2xUserFlows";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            UserFlowType,
            UserFlowTypeVersion,
            ApiConnectorConfiguration,
            IdentityProviders,
            UserAttributeAssignments,
            Languages,
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows,
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
    public partial class IdentitycontainerListB2xUserflowsResponse : RestApiResponse
    {
        public B2xIdentityUserFlow[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListB2xUserflowsResponse> IdentitycontainerListB2xUserflowsAsync()
        {
            var p = new IdentitycontainerListB2xUserflowsParameter();
            return await this.SendAsync<IdentitycontainerListB2xUserflowsParameter, IdentitycontainerListB2xUserflowsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListB2xUserflowsResponse> IdentitycontainerListB2xUserflowsAsync(CancellationToken cancellationToken)
        {
            var p = new IdentitycontainerListB2xUserflowsParameter();
            return await this.SendAsync<IdentitycontainerListB2xUserflowsParameter, IdentitycontainerListB2xUserflowsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListB2xUserflowsResponse> IdentitycontainerListB2xUserflowsAsync(IdentitycontainerListB2xUserflowsParameter parameter)
        {
            return await this.SendAsync<IdentitycontainerListB2xUserflowsParameter, IdentitycontainerListB2xUserflowsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identitycontainer-list-b2xuserflows?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentitycontainerListB2xUserflowsResponse> IdentitycontainerListB2xUserflowsAsync(IdentitycontainerListB2xUserflowsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentitycontainerListB2xUserflowsParameter, IdentitycontainerListB2xUserflowsResponse>(parameter, cancellationToken);
        }
    }
}
