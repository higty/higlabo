using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-memberof?view=graph-rest-1.0
    /// </summary>
    public partial class UserListMemberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_MemberOf: return $"/me/memberOf";
                    case ApiPath.Users_IdOrUserPrincipalName_MemberOf: return $"/users/{IdOrUserPrincipalName}/memberOf";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DeletedDateTime,
            Id,
        }
        public enum ApiPath
        {
            Me_MemberOf,
            Users_IdOrUserPrincipalName_MemberOf,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class UserListMemberofResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-memberof?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMemberofResponse> UserListMemberofAsync()
        {
            var p = new UserListMemberofParameter();
            return await this.SendAsync<UserListMemberofParameter, UserListMemberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMemberofResponse> UserListMemberofAsync(CancellationToken cancellationToken)
        {
            var p = new UserListMemberofParameter();
            return await this.SendAsync<UserListMemberofParameter, UserListMemberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMemberofResponse> UserListMemberofAsync(UserListMemberofParameter parameter)
        {
            return await this.SendAsync<UserListMemberofParameter, UserListMemberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListMemberofResponse> UserListMemberofAsync(UserListMemberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListMemberofParameter, UserListMemberofResponse>(parameter, cancellationToken);
        }
    }
}
