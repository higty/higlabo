using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/alert-get?view=graph-rest-1.0
    /// </summary>
    public partial class AlertGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Alert_id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Alerts_Alert_id: return $"/security/alerts/{Alert_id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Alerts_Alert_id,
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
    public partial class AlertGetResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/alert-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/alert-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AlertGetResponse> AlertGetAsync()
        {
            var p = new AlertGetParameter();
            return await this.SendAsync<AlertGetParameter, AlertGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/alert-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AlertGetResponse> AlertGetAsync(CancellationToken cancellationToken)
        {
            var p = new AlertGetParameter();
            return await this.SendAsync<AlertGetParameter, AlertGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/alert-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AlertGetResponse> AlertGetAsync(AlertGetParameter parameter)
        {
            return await this.SendAsync<AlertGetParameter, AlertGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/alert-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AlertGetResponse> AlertGetAsync(AlertGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AlertGetParameter, AlertGetResponse>(parameter, cancellationToken);
        }
    }
}
