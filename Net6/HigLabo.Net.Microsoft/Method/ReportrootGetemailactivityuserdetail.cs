using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ReportrootGetemailactivityuserdetailParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Reports_GetEmailActivityUserDetail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Reports_GetEmailActivityUserDetail: return $"/reports/getEmailActivityUserDetail";
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
    public partial class ReportrootGetemailactivityuserdetailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivityuserdetailResponse> ReportrootGetemailactivityuserdetailAsync()
        {
            var p = new ReportrootGetemailactivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetemailactivityuserdetailParameter, ReportrootGetemailactivityuserdetailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivityuserdetailResponse> ReportrootGetemailactivityuserdetailAsync(CancellationToken cancellationToken)
        {
            var p = new ReportrootGetemailactivityuserdetailParameter();
            return await this.SendAsync<ReportrootGetemailactivityuserdetailParameter, ReportrootGetemailactivityuserdetailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivityuserdetailResponse> ReportrootGetemailactivityuserdetailAsync(ReportrootGetemailactivityuserdetailParameter parameter)
        {
            return await this.SendAsync<ReportrootGetemailactivityuserdetailParameter, ReportrootGetemailactivityuserdetailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/reportroot-getemailactivityuserdetail?view=graph-rest-1.0
        /// </summary>
        public async Task<ReportrootGetemailactivityuserdetailResponse> ReportrootGetemailactivityuserdetailAsync(ReportrootGetemailactivityuserdetailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReportrootGetemailactivityuserdetailParameter, ReportrootGetemailactivityuserdetailResponse>(parameter, cancellationToken);
        }
    }
}
