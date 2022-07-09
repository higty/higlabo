using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InsightsListUsedParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Insights_Used: return $"/me/insights/used";
                    case ApiPath.Users_IdOrUserPrincipalName_Insights_Used: return $"/users/{IdOrUserPrincipalName}/insights/used";
                    case ApiPath.Me_Insights_Used_Id_Resource: return $"/me/insights/used/{Id}/resource";
                    case ApiPath.Users_IdOrUserPrincipalName_Insights_Used_Id_Resource: return $"/users/{IdOrUserPrincipalName}/insights/used/{Id}/resource";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Insights_Used,
            Users_IdOrUserPrincipalName_Insights_Used,
            Me_Insights_Used_Id_Resource,
            Users_IdOrUserPrincipalName_Insights_Used_Id_Resource,
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
    public partial class InsightsListUsedResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public UsageDetails? LastUsed { get; set; }
        public ResourceVisualization? ResourceVisualization { get; set; }
        public ResourceReference? ResourceReference { get; set; }
        public Entity[]? Resource { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/insights-list-used?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListUsedResponse> InsightsListUsedAsync()
        {
            var p = new InsightsListUsedParameter();
            return await this.SendAsync<InsightsListUsedParameter, InsightsListUsedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/insights-list-used?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListUsedResponse> InsightsListUsedAsync(CancellationToken cancellationToken)
        {
            var p = new InsightsListUsedParameter();
            return await this.SendAsync<InsightsListUsedParameter, InsightsListUsedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/insights-list-used?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListUsedResponse> InsightsListUsedAsync(InsightsListUsedParameter parameter)
        {
            return await this.SendAsync<InsightsListUsedParameter, InsightsListUsedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/insights-list-used?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListUsedResponse> InsightsListUsedAsync(InsightsListUsedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InsightsListUsedParameter, InsightsListUsedResponse>(parameter, cancellationToken);
        }
    }
}
