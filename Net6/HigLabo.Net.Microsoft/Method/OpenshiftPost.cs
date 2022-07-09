using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftPostParameter : IRestApiParameter
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
    public partial class OpenshiftPostResponse : RestApiResponse
    {
        public OpenShiftItem? DraftOpenShift { get; set; }
        public string? SchedulingGroupId { get; set; }
        public OpenShiftItem? SharedOpenShift { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftPostResponse> OpenshiftPostAsync()
        {
            var p = new OpenshiftPostParameter();
            return await this.SendAsync<OpenshiftPostParameter, OpenshiftPostResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftPostResponse> OpenshiftPostAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftPostParameter();
            return await this.SendAsync<OpenshiftPostParameter, OpenshiftPostResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftPostResponse> OpenshiftPostAsync(OpenshiftPostParameter parameter)
        {
            return await this.SendAsync<OpenshiftPostParameter, OpenshiftPostResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-post?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftPostResponse> OpenshiftPostAsync(OpenshiftPostParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftPostParameter, OpenshiftPostResponse>(parameter, cancellationToken);
        }
    }
}
