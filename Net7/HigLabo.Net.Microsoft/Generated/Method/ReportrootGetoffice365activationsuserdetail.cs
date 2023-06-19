using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class ReportRootGetoffice365activationsUserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Reports_GetOffice365ActivationsUserDetail: return $"/reports/getOffice365ActivationsUserDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetOffice365ActivationsUserDetail,
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
    public partial class ReportRootGetoffice365activationsUserdetailResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsuserdetail?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activationsUserdetailResponse> ReportRootGetoffice365activationsUserdetailAsync()
        {
            var p = new ReportRootGetoffice365activationsUserdetailParameter();
            return await this.SendAsync<ReportRootGetoffice365activationsUserdetailParameter, ReportRootGetoffice365activationsUserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activationsUserdetailResponse> ReportRootGetoffice365activationsUserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportRootGetoffice365activationsUserdetailParameter();
            return await this.SendAsync<ReportRootGetoffice365activationsUserdetailParameter, ReportRootGetoffice365activationsUserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activationsUserdetailResponse> ReportRootGetoffice365activationsUserdetailAsync(ReportRootGetoffice365activationsUserdetailParameter parameter)
        {
            return await this.SendAsync<ReportRootGetoffice365activationsUserdetailParameter, ReportRootGetoffice365activationsUserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/reportroot-getoffice365activationsuserdetail?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ReportRootGetoffice365activationsUserdetailResponse> ReportRootGetoffice365activationsUserdetailAsync(ReportRootGetoffice365activationsUserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportRootGetoffice365activationsUserdetailParameter, ReportRootGetoffice365activationsUserdetailResponse>(parameter, cancellationToken);
        }
    }
}
