using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesUserCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users: return $"/users";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
    }
    public partial class IntuneDevicesUserCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserCreateResponse> IntuneDevicesUserCreateAsync()
        {
            var p = new IntuneDevicesUserCreateParameter();
            return await this.SendAsync<IntuneDevicesUserCreateParameter, IntuneDevicesUserCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserCreateResponse> IntuneDevicesUserCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesUserCreateParameter();
            return await this.SendAsync<IntuneDevicesUserCreateParameter, IntuneDevicesUserCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserCreateResponse> IntuneDevicesUserCreateAsync(IntuneDevicesUserCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesUserCreateParameter, IntuneDevicesUserCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesUserCreateResponse> IntuneDevicesUserCreateAsync(IntuneDevicesUserCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesUserCreateParameter, IntuneDevicesUserCreateResponse>(parameter, cancellationToken);
        }
    }
}
