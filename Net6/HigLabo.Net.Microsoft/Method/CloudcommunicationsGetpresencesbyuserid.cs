using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CloudcommunicationsGetpresencesbyuseridParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_GetPresencesByUserId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_GetPresencesByUserId: return $"/communications/getPresencesByUserId";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public String[]? Ids { get; set; }
    }
    public partial class CloudcommunicationsGetpresencesbyuseridResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/presence?view=graph-rest-1.0
        /// </summary>
        public partial class Presence
        {
            public enum Presencestring
            {
                Available,
                AvailableIdle,
                Away,
                BeRightBack,
                Busy,
                BusyIdle,
                DoNotDisturb,
                Offline,
                PresenceUnknown,
            }

            public string? Id { get; set; }
            public Presencestring Availability { get; set; }
            public Presencestring Activity { get; set; }
        }

        public Presence[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/cloudcommunications-getpresencesbyuserid?view=graph-rest-1.0
        /// </summary>
        public async Task<CloudcommunicationsGetpresencesbyuseridResponse> CloudcommunicationsGetpresencesbyuseridAsync()
        {
            var p = new CloudcommunicationsGetpresencesbyuseridParameter();
            return await this.SendAsync<CloudcommunicationsGetpresencesbyuseridParameter, CloudcommunicationsGetpresencesbyuseridResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/cloudcommunications-getpresencesbyuserid?view=graph-rest-1.0
        /// </summary>
        public async Task<CloudcommunicationsGetpresencesbyuseridResponse> CloudcommunicationsGetpresencesbyuseridAsync(CancellationToken cancellationToken)
        {
            var p = new CloudcommunicationsGetpresencesbyuseridParameter();
            return await this.SendAsync<CloudcommunicationsGetpresencesbyuseridParameter, CloudcommunicationsGetpresencesbyuseridResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/cloudcommunications-getpresencesbyuserid?view=graph-rest-1.0
        /// </summary>
        public async Task<CloudcommunicationsGetpresencesbyuseridResponse> CloudcommunicationsGetpresencesbyuseridAsync(CloudcommunicationsGetpresencesbyuseridParameter parameter)
        {
            return await this.SendAsync<CloudcommunicationsGetpresencesbyuseridParameter, CloudcommunicationsGetpresencesbyuseridResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/cloudcommunications-getpresencesbyuserid?view=graph-rest-1.0
        /// </summary>
        public async Task<CloudcommunicationsGetpresencesbyuseridResponse> CloudcommunicationsGetpresencesbyuseridAsync(CloudcommunicationsGetpresencesbyuseridParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CloudcommunicationsGetpresencesbyuseridParameter, CloudcommunicationsGetpresencesbyuseridResponse>(parameter, cancellationToken);
        }
    }
}
