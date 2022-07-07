using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftUpdateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_Id_Schedule_OpenShifts_OpenShiftId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_Id_Schedule_OpenShifts_OpenShiftId: return $"/teams/{Id}/schedule/openShifts/{OpenShiftId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public OpenShiftItem? DraftOpenShift { get; set; }
        public string? SchedulingGroupId { get; set; }
        public OpenShiftItem? SharedOpenShift { get; set; }
        public string Id { get; set; }
        public string OpenShiftId { get; set; }
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
