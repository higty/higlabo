using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-delete?view=graph-rest-1.0
    /// </summary>
    public partial class OpenshiftDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class OpenshiftDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftDeleteResponse> OpenshiftDeleteAsync()
        {
            var p = new OpenshiftDeleteParameter();
            return await this.SendAsync<OpenshiftDeleteParameter, OpenshiftDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftDeleteResponse> OpenshiftDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new OpenshiftDeleteParameter();
            return await this.SendAsync<OpenshiftDeleteParameter, OpenshiftDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftDeleteResponse> OpenshiftDeleteAsync(OpenshiftDeleteParameter parameter)
        {
            return await this.SendAsync<OpenshiftDeleteParameter, OpenshiftDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/openshift-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OpenshiftDeleteResponse> OpenshiftDeleteAsync(OpenshiftDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OpenshiftDeleteParameter, OpenshiftDeleteResponse>(parameter, cancellationToken);
        }
    }
}
