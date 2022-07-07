using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class OpenshiftDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string OpenShiftId { get; set; }
    }
    public partial class OpenshiftDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftDeleteResponse> OpenshiftDeleteAsync()
        {
            var p = new OpenshiftDeleteParameter();
            return await this.SendAsync<OpenshiftDeleteParameter, OpenshiftDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftDeleteResponse> OpenshiftDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftDeleteParameter();
            return await this.SendAsync<OpenshiftDeleteParameter, OpenshiftDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftDeleteResponse> OpenshiftDeleteAsync(OpenshiftDeleteParameter parameter)
        {
            return await this.SendAsync<OpenshiftDeleteParameter, OpenshiftDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/openshift-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<OpenshiftDeleteResponse> OpenshiftDeleteAsync(OpenshiftDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftDeleteParameter, OpenshiftDeleteResponse>(parameter, cancellationToken);
        }
    }
}
