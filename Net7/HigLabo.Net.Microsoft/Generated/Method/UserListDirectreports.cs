using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
    /// </summary>
    public partial class UserListDirectreportsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_DirectReports: return $"/me/directReports";
                    case ApiPath.Users_IdOrUserPrincipalName_DirectReports: return $"/users/{IdOrUserPrincipalName}/directReports";
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
            Me_DirectReports,
            Users_IdOrUserPrincipalName_DirectReports,
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
    public partial class UserListDirectreportsResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListDirectreportsResponse> UserListDirectreportsAsync()
        {
            var p = new UserListDirectreportsParameter();
            return await this.SendAsync<UserListDirectreportsParameter, UserListDirectreportsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListDirectreportsResponse> UserListDirectreportsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListDirectreportsParameter();
            return await this.SendAsync<UserListDirectreportsParameter, UserListDirectreportsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListDirectreportsResponse> UserListDirectreportsAsync(UserListDirectreportsParameter parameter)
        {
            return await this.SendAsync<UserListDirectreportsParameter, UserListDirectreportsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-directreports?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListDirectreportsResponse> UserListDirectreportsAsync(UserListDirectreportsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListDirectreportsParameter, UserListDirectreportsResponse>(parameter, cancellationToken);
        }
    }
}
