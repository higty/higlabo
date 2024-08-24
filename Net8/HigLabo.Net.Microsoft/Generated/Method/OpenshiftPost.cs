using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-post?view=graph-rest-1.0
    /// </summary>
    public partial class OpenShiftPostParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShifts: return $"/teams/{Id}/schedule/openShifts";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShifts,
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
        public OpenShiftItem? DraftOpenShift { get; set; }
        public string? SchedulingGroupId { get; set; }
        public OpenShiftItem? SharedOpenShift { get; set; }
    }
    public partial class OpenShiftPostResponse : RestApiResponse
    {
        public OpenShiftItem? DraftOpenShift { get; set; }
        public string? SchedulingGroupId { get; set; }
        public OpenShiftItem? SharedOpenShift { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-post?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftPostResponse> OpenShiftPostAsync()
        {
            var p = new OpenShiftPostParameter();
            return await this.SendAsync<OpenShiftPostParameter, OpenShiftPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftPostResponse> OpenShiftPostAsync(CancellationToken cancellationToken)
        {
            var p = new OpenShiftPostParameter();
            return await this.SendAsync<OpenShiftPostParameter, OpenShiftPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftPostResponse> OpenShiftPostAsync(OpenShiftPostParameter parameter)
        {
            return await this.SendAsync<OpenShiftPostParameter, OpenShiftPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-post?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenShiftPostResponse> OpenShiftPostAsync(OpenShiftPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenShiftPostParameter, OpenShiftPostResponse>(parameter, cancellationToken);
        }
    }
}
