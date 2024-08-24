using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/alert-list?view=graph-rest-1.0
    /// </summary>
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
    public partial class AlertListResponse : RestApiResponse<Microsoft>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/alert-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/alert-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AlertListResponse> AlertListAsync()
        {
            var p = new AlertListParameter();
            return await this.SendAsync<AlertListParameter, AlertListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/alert-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AlertListResponse> AlertListAsync(CancellationToken cancellationToken)
        {
            var p = new AlertListParameter();
            return await this.SendAsync<AlertListParameter, AlertListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/alert-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AlertListResponse> AlertListAsync(AlertListParameter parameter)
        {
            return await this.SendAsync<AlertListParameter, AlertListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/alert-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AlertListResponse> AlertListAsync(AlertListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AlertListParameter, AlertListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/alert-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Microsoft> AlertListEnumerateAsync(AlertListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AlertListParameter, AlertListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Microsoft>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
