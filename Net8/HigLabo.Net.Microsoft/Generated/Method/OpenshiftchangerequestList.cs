using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
    /// </summary>
    public partial class OpenShiftChangeRequestListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

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
    public partial class OpenShiftChangeRequestListResponse : RestApiResponse
    {
        public string? OpenShiftId { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftChangeRequestListResponse> OpenShiftChangeRequestListAsync()
        {
            var p = new OpenShiftChangeRequestListParameter();
            return await this.SendAsync<OpenShiftChangeRequestListParameter, OpenShiftChangeRequestListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftChangeRequestListResponse> OpenShiftChangeRequestListAsync(CancellationToken cancellationToken)
        {
            var p = new OpenShiftChangeRequestListParameter();
            return await this.SendAsync<OpenShiftChangeRequestListParameter, OpenShiftChangeRequestListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftChangeRequestListResponse> OpenShiftChangeRequestListAsync(OpenShiftChangeRequestListParameter parameter)
        {
            return await this.SendAsync<OpenShiftChangeRequestListParameter, OpenShiftChangeRequestListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftChangeRequestListResponse> OpenShiftChangeRequestListAsync(OpenShiftChangeRequestListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenShiftChangeRequestListParameter, OpenShiftChangeRequestListResponse>(parameter, cancellationToken);
        }
    }
}
