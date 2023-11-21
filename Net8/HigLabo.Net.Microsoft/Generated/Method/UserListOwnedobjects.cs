using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public partial class UserListOwnedobjectsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_OwnedObjects: return $"/me/ownedObjects";
                    case ApiPath.Users_IdOrUserPrincipalName_OwnedObjects: return $"/users/{IdOrUserPrincipalName}/ownedObjects";
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
            Me_OwnedObjects,
            Users_IdOrUserPrincipalName_OwnedObjects,
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
    public partial class UserListOwnedobjectsResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOwnedobjectsResponse> UserListOwnedobjectsAsync()
        {
            var p = new UserListOwnedobjectsParameter();
            return await this.SendAsync<UserListOwnedobjectsParameter, UserListOwnedobjectsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOwnedobjectsResponse> UserListOwnedobjectsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListOwnedobjectsParameter();
            return await this.SendAsync<UserListOwnedobjectsParameter, UserListOwnedobjectsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOwnedobjectsResponse> UserListOwnedobjectsAsync(UserListOwnedobjectsParameter parameter)
        {
            return await this.SendAsync<UserListOwnedobjectsParameter, UserListOwnedobjectsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListOwnedobjectsResponse> UserListOwnedobjectsAsync(UserListOwnedobjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListOwnedobjectsParameter, UserListOwnedobjectsResponse>(parameter, cancellationToken);
        }
    }
}
