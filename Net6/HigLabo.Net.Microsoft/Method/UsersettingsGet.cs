using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UsersettingsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Settings_,
            Users_IdOrUserPrincipalName_Settings_,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Settings_: return $"/me/settings/";
                    case ApiPath.Users_IdOrUserPrincipalName_Settings_: return $"/users/{IdOrUserPrincipalName}/settings/";
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class UsersettingsGetResponse : RestApiResponse
    {
        public bool? ContributionToContentDiscoveryDisabled { get; set; }
        public bool? ContributionToContentDiscoveryAsOrganizationDisabled { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/usersettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UsersettingsGetResponse> UsersettingsGetAsync()
        {
            var p = new UsersettingsGetParameter();
            return await this.SendAsync<UsersettingsGetParameter, UsersettingsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/usersettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UsersettingsGetResponse> UsersettingsGetAsync(CancellationToken cancellationToken)
        {
            var p = new UsersettingsGetParameter();
            return await this.SendAsync<UsersettingsGetParameter, UsersettingsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/usersettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UsersettingsGetResponse> UsersettingsGetAsync(UsersettingsGetParameter parameter)
        {
            return await this.SendAsync<UsersettingsGetParameter, UsersettingsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/usersettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UsersettingsGetResponse> UsersettingsGetAsync(UsersettingsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UsersettingsGetParameter, UsersettingsGetResponse>(parameter, cancellationToken);
        }
    }
}
