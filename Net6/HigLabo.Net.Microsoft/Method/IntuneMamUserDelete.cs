using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamUserDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UsersId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId: return $"/users/{UsersId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string UsersId { get; set; }
    }
    public partial class IntuneMamUserDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserDeleteResponse> IntuneMamUserDeleteAsync()
        {
            var p = new IntuneMamUserDeleteParameter();
            return await this.SendAsync<IntuneMamUserDeleteParameter, IntuneMamUserDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserDeleteResponse> IntuneMamUserDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamUserDeleteParameter();
            return await this.SendAsync<IntuneMamUserDeleteParameter, IntuneMamUserDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserDeleteResponse> IntuneMamUserDeleteAsync(IntuneMamUserDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneMamUserDeleteParameter, IntuneMamUserDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserDeleteResponse> IntuneMamUserDeleteAsync(IntuneMamUserDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamUserDeleteParameter, IntuneMamUserDeleteResponse>(parameter, cancellationToken);
        }
    }
}
