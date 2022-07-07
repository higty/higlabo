using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamUserGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string UsersId { get; set; }
    }
    public partial class IntuneMamUserGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserGetResponse> IntuneMamUserGetAsync()
        {
            var p = new IntuneMamUserGetParameter();
            return await this.SendAsync<IntuneMamUserGetParameter, IntuneMamUserGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserGetResponse> IntuneMamUserGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamUserGetParameter();
            return await this.SendAsync<IntuneMamUserGetParameter, IntuneMamUserGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserGetResponse> IntuneMamUserGetAsync(IntuneMamUserGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamUserGetParameter, IntuneMamUserGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-user-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamUserGetResponse> IntuneMamUserGetAsync(IntuneMamUserGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamUserGetParameter, IntuneMamUserGetResponse>(parameter, cancellationToken);
        }
    }
}
