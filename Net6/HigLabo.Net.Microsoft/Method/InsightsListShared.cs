using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class InsightsListSharedParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Me_Insights_Shared: return $"/me/insights/shared";
                    case ApiPath.Users_IdOrUserPrincipalName_Insights_Shared: return $"/users/{IdOrUserPrincipalName}/insights/shared";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Me_Insights_Shared_Id_Resource: return $"/ttps://graph.microsoft.com/v1.0/me/insights/shared/{Id}/resource";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Insights_Shared,
            Users_IdOrUserPrincipalName_Insights_Shared,
            Ttps__Graphmicrosoftcom_V10_Me_Insights_Shared_Id_Resource,
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
    public partial class InsightsListSharedResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public SharingDetail? LastShared { get; set; }
        public ResourceVisualization? ResourceVisualization { get; set; }
        public ResourceReference? ResourceReference { get; set; }
        public Entity[]? Resource { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/insights-list-shared?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListSharedResponse> InsightsListSharedAsync()
        {
            var p = new InsightsListSharedParameter();
            return await this.SendAsync<InsightsListSharedParameter, InsightsListSharedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/insights-list-shared?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListSharedResponse> InsightsListSharedAsync(CancellationToken cancellationToken)
        {
            var p = new InsightsListSharedParameter();
            return await this.SendAsync<InsightsListSharedParameter, InsightsListSharedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/insights-list-shared?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListSharedResponse> InsightsListSharedAsync(InsightsListSharedParameter parameter)
        {
            return await this.SendAsync<InsightsListSharedParameter, InsightsListSharedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/insights-list-shared?view=graph-rest-1.0
        /// </summary>
        public async Task<InsightsListSharedResponse> InsightsListSharedAsync(InsightsListSharedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<InsightsListSharedParameter, InsightsListSharedResponse>(parameter, cancellationToken);
        }
    }
}
