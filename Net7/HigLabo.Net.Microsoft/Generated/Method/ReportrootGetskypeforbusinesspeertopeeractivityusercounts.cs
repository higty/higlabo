using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetskypeforbusinesspeertopeeractivityUsercountsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetskypeforbusinesspeertopeeractivityUsercountsResponse : RestApiResponse
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
        public async Task<ReportRootGetskypeforbusinesspeertopeeractivityUsercountsResponse> ReportRootGetskypeforbusinesspeertopeeractivityUsercountsAsync()
        {
            var p = new ReportRootGetskypeforbusinesspeertopeeractivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinesspeertopeeractivityUsercountsParameter, ReportRootGetskypeforbusinesspeertopeeractivityUsercountsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinesspeertopeeractivityUsercountsResponse> ReportRootGetskypeforbusinesspeertopeeractivityUsercountsAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetskypeforbusinesspeertopeeractivityUsercountsParameter();
            return await this.SendAsync<ReportRootGetskypeforbusinesspeertopeeractivityUsercountsParameter, ReportRootGetskypeforbusinesspeertopeeractivityUsercountsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinesspeertopeeractivityUsercountsResponse> ReportRootGetskypeforbusinesspeertopeeractivityUsercountsAsync(ReportRootGetskypeforbusinesspeertopeeractivityUsercountsParameter parameter)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinesspeertopeeractivityUsercountsParameter, ReportRootGetskypeforbusinesspeertopeeractivityUsercountsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getskypeforbusinesspeertopeeractivityusercounts?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetskypeforbusinesspeertopeeractivityUsercountsResponse> ReportRootGetskypeforbusinesspeertopeeractivityUsercountsAsync(ReportRootGetskypeforbusinesspeertopeeractivityUsercountsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetskypeforbusinesspeertopeeractivityUsercountsParameter, ReportRootGetskypeforbusinesspeertopeeractivityUsercountsResponse>(parameter, cancellationToken);
        }
    }
}
