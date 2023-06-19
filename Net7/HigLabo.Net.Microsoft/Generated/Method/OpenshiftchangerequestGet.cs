using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
    /// </summary>
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync()
        {
            var p = new OpenshiftchangerequestGetParameter();
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftchangerequestGetParameter();
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync(OpenshiftchangerequestGetParameter parameter)
        {
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftchangerequestGetResponse> OpenshiftchangerequestGetAsync(OpenshiftchangerequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftchangerequestGetParameter, OpenshiftchangerequestGetResponse>(parameter, cancellationToken);
        }
    }
}
