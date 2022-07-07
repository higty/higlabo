using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamUserListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneMamUserListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-user?view=graph-rest-1.0
        /// </summary>
        public partial class User
        {
            public string? Id { get; set; }
        }

        public User[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserListResponse> IntuneMamUserListAsync()
        {
            var p = new IntuneMamUserListParameter();
            return await this.SendAsync<IntuneMamUserListParameter, IntuneMamUserListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserListResponse> IntuneMamUserListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamUserListParameter();
            return await this.SendAsync<IntuneMamUserListParameter, IntuneMamUserListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserListResponse> IntuneMamUserListAsync(IntuneMamUserListParameter parameter)
        {
            return await this.SendAsync<IntuneMamUserListParameter, IntuneMamUserListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserListResponse> IntuneMamUserListAsync(IntuneMamUserListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamUserListParameter, IntuneMamUserListResponse>(parameter, cancellationToken);
        }
    }
}
