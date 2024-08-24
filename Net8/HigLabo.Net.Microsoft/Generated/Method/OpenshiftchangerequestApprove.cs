using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-approve?view=graph-rest-1.0
    /// </summary>
    public partial class OpenShiftChangeRequestApproveParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? OpenShiftChangeRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftChangeRequestId_Approve: return $"/teams/{Id}/schedule/openShiftChangeRequests/{OpenShiftChangeRequestId}/approve";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftChangeRequestId_Approve,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Message { get; set; }
    }
    public partial class OpenShiftChangeRequestApproveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-approve?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftChangeRequestApproveResponse> OpenShiftChangeRequestApproveAsync()
        {
            var p = new OpenShiftChangeRequestApproveParameter();
            return await this.SendAsync<OpenShiftChangeRequestApproveParameter, OpenShiftChangeRequestApproveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftChangeRequestApproveResponse> OpenShiftChangeRequestApproveAsync(CancellationToken cancellationToken)
        {
            var p = new OpenShiftChangeRequestApproveParameter();
            return await this.SendAsync<OpenShiftChangeRequestApproveParameter, OpenShiftChangeRequestApproveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftChangeRequestApproveResponse> OpenShiftChangeRequestApproveAsync(OpenShiftChangeRequestApproveParameter parameter)
        {
            return await this.SendAsync<OpenShiftChangeRequestApproveParameter, OpenShiftChangeRequestApproveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-approve?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftChangeRequestApproveResponse> OpenShiftChangeRequestApproveAsync(OpenShiftChangeRequestApproveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenShiftChangeRequestApproveParameter, OpenShiftChangeRequestApproveResponse>(parameter, cancellationToken);
        }
    }
}
