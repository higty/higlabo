using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? OpenShiftId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShifts_OpenShiftId: return $"/teams/{Id}/schedule/openShifts/{OpenShiftId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShifts_OpenShiftId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public OpenShiftItem? DraftOpenShift { get; set; }
        public string? SchedulingGroupId { get; set; }
        public OpenShiftItem? SharedOpenShift { get; set; }
    }
    public partial class OpenshiftUpdateResponse : RestApiResponse
    {
        public OpenShiftItem? DraftOpenShift { get; set; }
        public string? SchedulingGroupId { get; set; }
        public OpenShiftItem? SharedOpenShift { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftUpdateResponse> OpenshiftUpdateAsync()
        {
            var p = new OpenshiftUpdateParameter();
            return await this.SendAsync<OpenshiftUpdateParameter, OpenshiftUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftUpdateResponse> OpenshiftUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftUpdateParameter();
            return await this.SendAsync<OpenshiftUpdateParameter, OpenshiftUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftUpdateResponse> OpenshiftUpdateAsync(OpenshiftUpdateParameter parameter)
        {
            return await this.SendAsync<OpenshiftUpdateParameter, OpenshiftUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-update?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftUpdateResponse> OpenshiftUpdateAsync(OpenshiftUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftUpdateParameter, OpenshiftUpdateResponse>(parameter, cancellationToken);
        }
    }
}
