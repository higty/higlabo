using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetOneDriveusagestorageParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ReportRootGetOneDriveusagestorageResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusagestorageResponse> ReportRootGetOneDriveusagestorageAsync()
        {
            var p = new ReportRootGetOneDriveusagestorageParameter();
            return await this.SendAsync<ReportRootGetOneDriveusagestorageParameter, ReportRootGetOneDriveusagestorageResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusagestorageResponse> ReportRootGetOneDriveusagestorageAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetOneDriveusagestorageParameter();
            return await this.SendAsync<ReportRootGetOneDriveusagestorageParameter, ReportRootGetOneDriveusagestorageResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusagestorageResponse> ReportRootGetOneDriveusagestorageAsync(ReportRootGetOneDriveusagestorageParameter parameter)
        {
            return await this.SendAsync<ReportRootGetOneDriveusagestorageParameter, ReportRootGetOneDriveusagestorageResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getonedriveusagestorage?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetOneDriveusagestorageResponse> ReportRootGetOneDriveusagestorageAsync(ReportRootGetOneDriveusagestorageParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetOneDriveusagestorageParameter, ReportRootGetOneDriveusagestorageResponse>(parameter, cancellationToken);
        }
    }
}
