using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-get?view=graph-rest-1.0
    /// </summary>
    public partial class B2xidentityUserflowGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows_Id: return $"/identity/b2xUserFlows/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id,
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
    public partial class B2xidentityUserflowGetResponse : RestApiResponse
    {
        public UserFlowApiConnectorConfiguration? ApiConnectorConfiguration { get; set; }
        public string? Id { get; set; }
        public string? UserFlowType { get; set; }
        public Single? UserFlowTypeVersion { get; set; }
        public IdentityProvider[]? IdentityProviders { get; set; }
        public UserFlowLanguageConfiguration[]? Languages { get; set; }
        public IdentityUserFlowAttributeAssignment[]? UserAttributeAssignments { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowGetResponse> B2xidentityUserflowGetAsync()
        {
            var p = new B2xidentityUserflowGetParameter();
            return await this.SendAsync<B2xidentityUserflowGetParameter, B2xidentityUserflowGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowGetResponse> B2xidentityUserflowGetAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityUserflowGetParameter();
            return await this.SendAsync<B2xidentityUserflowGetParameter, B2xidentityUserflowGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowGetResponse> B2xidentityUserflowGetAsync(B2xidentityUserflowGetParameter parameter)
        {
            return await this.SendAsync<B2xidentityUserflowGetParameter, B2xidentityUserflowGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowGetResponse> B2xidentityUserflowGetAsync(B2xidentityUserflowGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityUserflowGetParameter, B2xidentityUserflowGetResponse>(parameter, cancellationToken);
        }
    }
}
