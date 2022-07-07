using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SecurescorecontrolprofileGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Securescorecontrolprofiles_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Security_Securescorecontrolprofiles_Id: return $"/security/securescorecontrolprofiles/{Id}";
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
        public string Id { get; set; }
    }
    public partial class SecurescorecontrolprofileGetResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/securescorecontrolprofile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurescorecontrolprofileGetResponse> SecurescorecontrolprofileGetAsync()
        {
            var p = new SecurescorecontrolprofileGetParameter();
            return await this.SendAsync<SecurescorecontrolprofileGetParameter, SecurescorecontrolprofileGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/securescorecontrolprofile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurescorecontrolprofileGetResponse> SecurescorecontrolprofileGetAsync(CancellationToken cancellationToken)
        {
            var p = new SecurescorecontrolprofileGetParameter();
            return await this.SendAsync<SecurescorecontrolprofileGetParameter, SecurescorecontrolprofileGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/securescorecontrolprofile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurescorecontrolprofileGetResponse> SecurescorecontrolprofileGetAsync(SecurescorecontrolprofileGetParameter parameter)
        {
            return await this.SendAsync<SecurescorecontrolprofileGetParameter, SecurescorecontrolprofileGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/securescorecontrolprofile-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurescorecontrolprofileGetResponse> SecurescorecontrolprofileGetAsync(SecurescorecontrolprofileGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurescorecontrolprofileGetParameter, SecurescorecontrolprofileGetResponse>(parameter, cancellationToken);
        }
    }
}
