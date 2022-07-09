using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListManagerParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Manager: return $"/me/manager";
                    case ApiPath.Users_IdOrUserPrincipalName_Manager: return $"/users/{IdOrUserPrincipalName}/manager";
                    case ApiPath.Me: return $"/me";
                    case ApiPath.Users: return $"/users";
                    case ApiPath.Users_IdOrUserPrincipalName_: return $"/users/{IdOrUserPrincipalName}/";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Manager,
            Users_IdOrUserPrincipalName_Manager,
            Me,
            Users,
            Users_IdOrUserPrincipalName_,
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
    public partial class UserListManagerResponse : RestApiResponse
    {
        public DateTimeOffset? DeletedDateTime { get; set; }
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListManagerResponse> UserListManagerAsync()
        {
            var p = new UserListManagerParameter();
            return await this.SendAsync<UserListManagerParameter, UserListManagerResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListManagerResponse> UserListManagerAsync(CancellationToken cancellationToken)
        {
            var p = new UserListManagerParameter();
            return await this.SendAsync<UserListManagerParameter, UserListManagerResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListManagerResponse> UserListManagerAsync(UserListManagerParameter parameter)
        {
            return await this.SendAsync<UserListManagerParameter, UserListManagerResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-manager?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListManagerResponse> UserListManagerAsync(UserListManagerParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListManagerParameter, UserListManagerResponse>(parameter, cancellationToken);
        }
    }
}
