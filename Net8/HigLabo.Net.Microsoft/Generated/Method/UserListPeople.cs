using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-people?view=graph-rest-1.0
    /// </summary>
    public partial class UserListPeopleParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_People: return $"/me/people";
                    case ApiPath.Users_IdOrUserPrincipalName_People: return $"/users/{IdOrUserPrincipalName}/people";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_People,
            Users_IdOrUserPrincipalName_People,
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
    public partial class UserListPeopleResponse : RestApiResponse<Person>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-list-people?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-people?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListPeopleResponse> UserListPeopleAsync()
        {
            var p = new UserListPeopleParameter();
            return await this.SendAsync<UserListPeopleParameter, UserListPeopleResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-people?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListPeopleResponse> UserListPeopleAsync(CancellationToken cancellationToken)
        {
            var p = new UserListPeopleParameter();
            return await this.SendAsync<UserListPeopleParameter, UserListPeopleResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-people?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListPeopleResponse> UserListPeopleAsync(UserListPeopleParameter parameter)
        {
            return await this.SendAsync<UserListPeopleParameter, UserListPeopleResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-people?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserListPeopleResponse> UserListPeopleAsync(UserListPeopleParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListPeopleParameter, UserListPeopleResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-list-people?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Person> UserListPeopleEnumerateAsync(UserListPeopleParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserListPeopleParameter, UserListPeopleResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Person>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
