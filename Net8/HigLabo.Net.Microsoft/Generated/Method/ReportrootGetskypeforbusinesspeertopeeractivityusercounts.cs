using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessPeerToPeerActivityUserCounts: return $"/reports/getSkypeForBusinessPeerToPeerActivityUserCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessPeerToPeerActivityUserCounts,
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
    public partial class ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsResponse> ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsAsync()
        {
            var p = new ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsParameter, ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsResponse> ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsParameter, ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsResponse> ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsAsync(ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsParameter, ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsResponse> ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsAsync(ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsParameter, ReportRootGetSkypeforBusinesspeertopeerActivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
