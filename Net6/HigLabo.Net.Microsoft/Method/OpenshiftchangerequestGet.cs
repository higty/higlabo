using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftchangerequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? OpenShiftsChangeRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftsChangeRequestId: return $"/teams/{Id}/schedule/openShiftChangeRequests/{OpenShiftsChangeRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftsChangeRequestId,
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
    public partial class OpenshiftchangerequestGetResponse : RestApiResponse
    {
        public string? OpenShiftId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync()
        {
            var p = new OpenshiftchangerequestGetParameter();
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftchangerequestGetParameter();
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync(OpenshiftchangerequestGetParameter parameter)
        {
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync(OpenshiftchangerequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(parameter, cancellationToken);
        }
    }
}
