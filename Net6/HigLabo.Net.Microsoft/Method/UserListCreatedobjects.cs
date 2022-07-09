using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListCreatedobjectsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_CreatedObjects: return $"/users/{IdOrUserPrincipalName}/createdObjects";
                    case ApiPath.Me_CreatedObjects: return $"/me/createdObjects";
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
            Users_IdOrUserPrincipalName_CreatedObjects,
            Me_CreatedObjects,
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
    public partial class UserListCreatedobjectsResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCreatedobjectsResponse> UserListCreatedobjectsAsync()
        {
            var p = new UserListCreatedobjectsParameter();
            return await this.SendAsync<UserListCreatedobjectsParameter, UserListCreatedobjectsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCreatedobjectsResponse> UserListCreatedobjectsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListCreatedobjectsParameter();
            return await this.SendAsync<UserListCreatedobjectsParameter, UserListCreatedobjectsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCreatedobjectsResponse> UserListCreatedobjectsAsync(UserListCreatedobjectsParameter parameter)
        {
            return await this.SendAsync<UserListCreatedobjectsParameter, UserListCreatedobjectsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListCreatedobjectsResponse> UserListCreatedobjectsAsync(UserListCreatedobjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListCreatedobjectsParameter, UserListCreatedobjectsResponse>(parameter, cancellationToken);
        }
    }
}
