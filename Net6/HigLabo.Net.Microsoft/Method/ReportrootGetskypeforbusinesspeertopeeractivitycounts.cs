using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetskypeforbusinesspeertopeeractivitycountsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetSkypeForBusinessPeerToPeerActivityCounts: return $"/reports/getSkypeForBusinessPeerToPeerActivityCounts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetSkypeForBusinessPeerToPeerActivityCounts,
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
    public partial class ReportRootGetskypeforbusinesspeertopeeractivitycountsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinesspeertopeeractivitycountsResponse> ReportRootGetskypeforbusinesspeertopeeractivitycountsAsync()
        {
            var p = new ReportRootGetskypeforbusinesspeertopeeractivitycountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinesspeertopeeractivitycountsParameter, ReportRootGetskypeforbusinesspeertopeeractivitycountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinesspeertopeeractivitycountsResponse> ReportRootGetskypeforbusinesspeertopeeractivitycountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinesspeertopeeractivitycountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinesspeertopeeractivitycountsParameter, ReportRootGetskypeforbusinesspeertopeeractivitycountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinesspeertopeeractivitycountsResponse> ReportRootGetskypeforbusinesspeertopeeractivitycountsAsync(ReportRootGetskypeforbusinesspeertopeeractivitycountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinesspeertopeeractivitycountsParameter, ReportRootGetskypeforbusinesspeertopeeractivitycountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivitycounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinesspeertopeeractivitycountsResponse> ReportRootGetskypeforbusinesspeertopeeractivitycountsAsync(ReportRootGetskypeforbusinesspeertopeeractivitycountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinesspeertopeeractivitycountsParameter, ReportRootGetskypeforbusinesspeertopeeractivitycountsResponse>(parameter, cancellationToken);
        }
    }
}
