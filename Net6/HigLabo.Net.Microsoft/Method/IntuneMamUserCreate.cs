using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamUserCreateParameter : IRestApiParameter
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
    public partial class IntuneMamUserCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserCreateResponse> IntuneMamUserCreateAsync()
        {
            var p = new IntuneMamUserCreateParameter();
            return await this.SendAsync<IntuneMamUserCreateParameter, IntuneMamUserCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserCreateResponse> IntuneMamUserCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamUserCreateParameter();
            return await this.SendAsync<IntuneMamUserCreateParameter, IntuneMamUserCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserCreateResponse> IntuneMamUserCreateAsync(IntuneMamUserCreateParameter parameter)
        {
            return await this.SendAsync<IntuneMamUserCreateParameter, IntuneMamUserCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserCreateResponse> IntuneMamUserCreateAsync(IntuneMamUserCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamUserCreateParameter, IntuneMamUserCreateResponse>(parameter, cancellationToken);
        }
    }
}
