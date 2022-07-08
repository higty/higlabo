using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftchangerequestListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests: return $"/teams/{Id}/schedule/openShiftChangeRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShiftChangeRequests,
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
    public partial class OpenshiftchangerequestListResponse : RestApiResponse
    {
        public string? OpenShiftId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestListResponse> OpenshiftchangerequestListAsync()
        {
            var p = new OpenshiftchangerequestListParameter();
            return await this.SendAsync<OpenshiftchangerequestListParameter, OpenshiftchangerequestListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestListResponse> OpenshiftchangerequestListAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftchangerequestListParameter();
            return await this.SendAsync<OpenshiftchangerequestListParameter, OpenshiftchangerequestListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestListResponse> OpenshiftchangerequestListAsync(OpenshiftchangerequestListParameter parameter)
        {
            return await this.SendAsync<OpenshiftchangerequestListParameter, OpenshiftchangerequestListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestListResponse> OpenshiftchangerequestListAsync(OpenshiftchangerequestListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftchangerequestListParameter, OpenshiftchangerequestListResponse>(parameter, cancellationToken);
        }
    }
}
