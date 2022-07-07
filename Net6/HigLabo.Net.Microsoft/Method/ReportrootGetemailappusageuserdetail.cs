using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetemailappusageuserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailAppUsageUserDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetEmailAppUsageUserDetail: return $"/reports/getEmailAppUsageUserDetail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class ReportrootGetemailappusageuserdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageuserdetailResponse> ReportrootGetemailappusageuserdetailAsync()
        {
            var p = new ReportrootGetemailappusageuserdetailParameter();
            return await this.SendAsync<ReportrootGetemailappusageuserdetailParameter, ReportrootGetemailappusageuserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageuserdetailResponse> ReportrootGetemailappusageuserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetemailappusageuserdetailParameter();
            return await this.SendAsync<ReportrootGetemailappusageuserdetailParameter, ReportrootGetemailappusageuserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageuserdetailResponse> ReportrootGetemailappusageuserdetailAsync(ReportrootGetemailappusageuserdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetemailappusageuserdetailParameter, ReportrootGetemailappusageuserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailappusageuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailappusageuserdetailResponse> ReportrootGetemailappusageuserdetailAsync(ReportrootGetemailappusageuserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetemailappusageuserdetailParameter, ReportrootGetemailappusageuserdetailResponse>(parameter, cancellationToken);
        }
    }
}
