using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AlertListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Alerts: return $"/security/alerts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Alerts,
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
    public partial class AlertListResponse : RestApiResponse
    {
        public Microsoft[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-list?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertListResponse> AlertListAsync()
        {
            var p = new AlertListParameter();
            return await this.SendAsync<AlertListParameter, AlertListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-list?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertListResponse> AlertListAsync(CancellationToken cancellationToken)
        {
            var p = new AlertListParameter();
            return await this.SendAsync<AlertListParameter, AlertListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-list?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertListResponse> AlertListAsync(AlertListParameter parameter)
        {
            return await this.SendAsync<AlertListParameter, AlertListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/alert-list?view=graph-rest-1.0
        /// </summary>
        public async Task<AlertListResponse> AlertListAsync(AlertListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AlertListParameter, AlertListResponse>(parameter, cancellationToken);
        }
    }
}
