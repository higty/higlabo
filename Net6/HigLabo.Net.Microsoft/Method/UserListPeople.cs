using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
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
            Birthday,
            CompanyName,
            Department,
            DisplayName,
            ScoredEmailAddresses,
            GivenName,
            Id,
            ImAddress,
            IsFavorite,
            JobTitle,
            OfficeLocation,
            PersonNotes,
            PersonType,
            Phones,
            PostalAddresses,
            Profession,
            Surname,
            UserPrincipalName,
            Websites,
            YomiCompany,
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
    public partial class UserListPeopleResponse : RestApiResponse
    {
        public Person[]? Value { get; set; }
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
