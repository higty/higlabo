using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class CloudcommunicationsGetpresencesbyUseridParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_GetPresencesByUserId: return $"/communications/getPresencesByUserId";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_GetPresencesByUserId,
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
        public String[]? Ids { get; set; }
    }
    public partial class CloudcommunicationsGetpresencesbyUseridResponse : RestApiResponse
    {
        public Presence[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/cloudcommunications-getpresencesbyuserid?view=graph-rest-1.0
        /// </summary>
        public async Task<CloudcommunicationsGetpresencesbyUseridResponse> CloudcommunicationsGetpresencesbyUseridAsync()
        {
            var p = new CloudcommunicationsGetpresencesbyUseridParameter();
            return await this.SendAsync<CloudcommunicationsGetpresencesbyUseridParameter, CloudcommunicationsGetpresencesbyUseridResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/cloudcommunications-getpresencesbyuserid?view=graph-rest-1.0
        /// </summary>
        public async Task<CloudcommunicationsGetpresencesbyUseridResponse> CloudcommunicationsGetpresencesbyUseridAsync(CancellationToken cancellationToken)
        {
            var p = new CloudcommunicationsGetpresencesbyUseridParameter();
            return await this.SendAsync<CloudcommunicationsGetpresencesbyUseridParameter, CloudcommunicationsGetpresencesbyUseridResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/cloudcommunications-getpresencesbyuserid?view=graph-rest-1.0
        /// </summary>
        public async Task<CloudcommunicationsGetpresencesbyUseridResponse> CloudcommunicationsGetpresencesbyUseridAsync(CloudcommunicationsGetpresencesbyUseridParameter parameter)
        {
            return await this.SendAsync<CloudcommunicationsGetpresencesbyUseridParameter, CloudcommunicationsGetpresencesbyUseridResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/cloudcommunications-getpresencesbyuserid?view=graph-rest-1.0
        /// </summary>
        public async Task<CloudcommunicationsGetpresencesbyUseridResponse> CloudcommunicationsGetpresencesbyUseridAsync(CloudcommunicationsGetpresencesbyUseridParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CloudcommunicationsGetpresencesbyUseridParameter, CloudcommunicationsGetpresencesbyUseridResponse>(parameter, cancellationToken);
        }
    }
}
