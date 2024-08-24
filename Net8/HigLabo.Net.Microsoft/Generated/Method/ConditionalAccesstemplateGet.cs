using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccesstemplate-get?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessTemplateGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ConditionalAccess_Templates_Id: return $"/identity/conditionalAccess/templates/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_ConditionalAccess_Templates_Id,
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
    public partial class ConditionalAccessTemplateGetResponse : RestApiResponse
    {
        public enum ConditionalAccessTemplateTemplateScenarios
        {
            New,
            SecureFoundation,
            ZeroTrust,
            RemoteWork,
            ProtectAdmins,
            EmergingThreats,
            UnknownFutureValue,
            Has,
        }

        public string? Description { get; set; }
        public ConditionalAccessPolicyDetail? Details { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public ConditionalAccessTemplateTemplateScenarios Scenarios { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccesstemplate-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccesstemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessTemplateGetResponse> ConditionalAccessTemplateGetAsync()
        {
            var p = new ConditionalAccessTemplateGetParameter();
            return await this.SendAsync<ConditionalAccessTemplateGetParameter, ConditionalAccessTemplateGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccesstemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessTemplateGetResponse> ConditionalAccessTemplateGetAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalAccessTemplateGetParameter();
            return await this.SendAsync<ConditionalAccessTemplateGetParameter, ConditionalAccessTemplateGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccesstemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessTemplateGetResponse> ConditionalAccessTemplateGetAsync(ConditionalAccessTemplateGetParameter parameter)
        {
            return await this.SendAsync<ConditionalAccessTemplateGetParameter, ConditionalAccessTemplateGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccesstemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessTemplateGetResponse> ConditionalAccessTemplateGetAsync(ConditionalAccessTemplateGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalAccessTemplateGetParameter, ConditionalAccessTemplateGetResponse>(parameter, cancellationToken);
        }
    }
}
