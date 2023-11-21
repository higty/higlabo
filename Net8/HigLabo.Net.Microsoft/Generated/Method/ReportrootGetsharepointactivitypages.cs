using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivitypages?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetsharepointactivitypagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSharePointActivityPages: return $"/reports/getSharePointActivityPages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSharePointActivityPages,
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
    public partial class ReportRootGetsharepointactivitypagesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivitypages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivitypages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivitypagesResponse> ReportRootGetsharepointactivitypagesAsync()
        {
            var p = new ReportRootGetsharepointactivitypagesParameter();
            return await this.SendAsync<ReportRootGetsharepointactivitypagesParameter, ReportRootGetsharepointactivitypagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivitypages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivitypagesResponse> ReportRootGetsharepointactivitypagesAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetsharepointactivitypagesParameter();
            return await this.SendAsync<ReportRootGetsharepointactivitypagesParameter, ReportRootGetsharepointactivitypagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivitypages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivitypagesResponse> ReportRootGetsharepointactivitypagesAsync(ReportRootGetsharepointactivitypagesParameter parameter)
        {
            return await this.SendAsync<ReportRootGetsharepointactivitypagesParameter, ReportRootGetsharepointactivitypagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getsharepointactivitypages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetsharepointactivitypagesResponse> ReportRootGetsharepointactivitypagesAsync(ReportRootGetsharepointactivitypagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetsharepointactivitypagesParameter, ReportRootGetsharepointactivitypagesResponse>(parameter, cancellationToken);
        }
    }
}
