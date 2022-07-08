using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportRootGetonedriveusagestorageParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOneDriveUsageStorage: return $"/reports/getOneDriveUsageStorage";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOneDriveUsageStorage,
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
    public partial class ReportRootGetonedriveusagestorageResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveusagestorageResponse> ReportRootGetonedriveusagestorageAsync()
        {
            var p = new ReportRootGetonedriveusagestorageParameter();
            return await this.SendAsync<ReportRootGetonedriveusagestorageParameter, ReportRootGetonedriveusagestorageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveusagestorageResponse> ReportRootGetonedriveusagestorageAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetonedriveusagestorageParameter();
            return await this.SendAsync<ReportRootGetonedriveusagestorageParameter, ReportRootGetonedriveusagestorageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveusagestorageResponse> ReportRootGetonedriveusagestorageAsync(ReportRootGetonedriveusagestorageParameter parameter)
        {
            return await this.SendAsync<ReportRootGetonedriveusagestorageParameter, ReportRootGetonedriveusagestorageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportRootGetonedriveusagestorageResponse> ReportRootGetonedriveusagestorageAsync(ReportRootGetonedriveusagestorageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetonedriveusagestorageParameter, ReportRootGetonedriveusagestorageResponse>(parameter, cancellationToken);
        }
    }
}
