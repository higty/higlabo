using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListPeopleParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_People,
            Users_IdOrUserPrincipalName_People,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_People: return $"/me/people";
                    case ApiPath.Users_IdOrUserPrincipalName_People: return $"/users/{IdOrUserPrincipalName}/people";
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
    public partial class UserListPeopleResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/person?view=graph-rest-1.0
        /// </summary>
        public partial class Person
        {
            public string? Birthday { get; set; }
            public string? CompanyName { get; set; }
            public string? Department { get; set; }
            public string? DisplayName { get; set; }
            public ScoredEmailAddress[]? ScoredEmailAddresses { get; set; }
            public string? GivenName { get; set; }
            public string? Id { get; set; }
            public string? ImAddress { get; set; }
            public bool? IsFavorite { get; set; }
            public string? JobTitle { get; set; }
            public string? OfficeLocation { get; set; }
            public string? PersonNotes { get; set; }
            public PersonType? PersonType { get; set; }
            public Phone[]? Phones { get; set; }
            public Location[]? PostalAddresses { get; set; }
            public string? Profession { get; set; }
            public string? Surname { get; set; }
            public string? UserPrincipalName { get; set; }
            public Website[]? Websites { get; set; }
            public string? YomiCompany { get; set; }
        }

        public Person[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-people?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListPeopleResponse> UserListPeopleAsync()
        {
            var p = new UserListPeopleParameter();
            return await this.SendAsync<UserListPeopleParameter, UserListPeopleResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-people?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListPeopleResponse> UserListPeopleAsync(CancellationToken cancellationToken)
        {
            var p = new UserListPeopleParameter();
            return await this.SendAsync<UserListPeopleParameter, UserListPeopleResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-people?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListPeopleResponse> UserListPeopleAsync(UserListPeopleParameter parameter)
        {
            return await this.SendAsync<UserListPeopleParameter, UserListPeopleResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-people?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListPeopleResponse> UserListPeopleAsync(UserListPeopleParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListPeopleParameter, UserListPeopleResponse>(parameter, cancellationToken);
        }
    }
}
