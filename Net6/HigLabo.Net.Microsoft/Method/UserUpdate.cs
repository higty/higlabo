using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_IdOrUserPrincipalName: return $"/users/{IdOrUserPrincipalName}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum UserUpdateParameterAgeGroup
        {
            Null,
            Minor,
            NotAdult,
            Adult,
        }
        public enum UserUpdateParameterConsentProvidedForMinor
        {
            Null,
            Granted,
            Denied,
            NotRequired,
        }
        public enum ApiPath
        {
            Users_IdOrUserPrincipalName,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? AboutMe { get; set; }
        public bool? AccountEnabled { get; set; }
        public UserUpdateParameterAgeGroup AgeGroup { get; set; }
        public DateTimeOffset? Birthday { get; set; }
        public String[]? BusinessPhones { get; set; }
        public string? City { get; set; }
        public string? CompanyName { get; set; }
        public UserUpdateParameterConsentProvidedForMinor ConsentProvidedForMinor { get; set; }
        public string? Country { get; set; }
        public string? Department { get; set; }
        public string? DisplayName { get; set; }
        public string? EmployeeId { get; set; }
        public string? EmployeeType { get; set; }
        public string? GivenName { get; set; }
        public DateTimeOffset? EmployeeHireDate { get; set; }
        public String[]? Interests { get; set; }
        public string? JobTitle { get; set; }
        public string? Mail { get; set; }
        public string? MailNickname { get; set; }
        public string? MobilePhone { get; set; }
        public string? MySite { get; set; }
        public string? OfficeLocation { get; set; }
        public OnPremisesExtensionAttributes? OnPremisesExtensionAttributes { get; set; }
        public string? OnPremisesImmutableId { get; set; }
        public String[]? OtherMails { get; set; }
        public string? PasswordPolicies { get; set; }
        public PasswordProfile PasswordProfile { get; set; }
        public String[]? PastProjects { get; set; }
        public string? PostalCode { get; set; }
        public string? PreferredLanguage { get; set; }
        public String[]? Responsibilities { get; set; }
        public String[]? Schools { get; set; }
        public String[]? Skills { get; set; }
        public string? State { get; set; }
        public string? StreetAddress { get; set; }
        public string? Surname { get; set; }
        public string? UsageLocation { get; set; }
        public string? UserPrincipalName { get; set; }
        public string? UserType { get; set; }
    }
    public partial class UserUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UserUpdateResponse> UserUpdateAsync()
        {
            var p = new UserUpdateParameter();
            return await this.SendAsync<UserUpdateParameter, UserUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UserUpdateResponse> UserUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new UserUpdateParameter();
            return await this.SendAsync<UserUpdateParameter, UserUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UserUpdateResponse> UserUpdateAsync(UserUpdateParameter parameter)
        {
            return await this.SendAsync<UserUpdateParameter, UserUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UserUpdateResponse> UserUpdateAsync(UserUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserUpdateParameter, UserUpdateResponse>(parameter, cancellationToken);
        }
    }
}
