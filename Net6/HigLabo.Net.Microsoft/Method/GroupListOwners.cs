using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListOwnersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Owners: return $"/groups/{Id}/owners";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AboutMe,
            AccountEnabled,
            AgeGroup,
            AssignedLicenses,
            AssignedPlans,
            Birthday,
            BusinessPhones,
            City,
            CompanyName,
            ConsentProvidedForMinor,
            Country,
            CreatedDateTime,
            CreationType,
            DeletedDateTime,
            Department,
            DisplayName,
            EmployeeHireDate,
            EmployeeId,
            EmployeeOrgData,
            EmployeeType,
            ExternalUserState,
            ExternalUserStateChangeDateTime,
            FaxNumber,
            GivenName,
            HireDate,
            Id,
            Identities,
            ImAddresses,
            Interests,
            IsResourceAccount,
            JobTitle,
            LastPasswordChangeDateTime,
            LegalAgeGroupClassification,
            LicenseAssignmentStates,
            Mail,
            MailboxSettings,
            MailNickname,
            MobilePhone,
            MySite,
            OfficeLocation,
            OnPremisesDistinguishedName,
            OnPremisesDomainName,
            OnPremisesExtensionAttributes,
            OnPremisesImmutableId,
            OnPremisesLastSyncDateTime,
            OnPremisesProvisioningErrors,
            OnPremisesSamAccountName,
            OnPremisesSecurityIdentifier,
            OnPremisesSyncEnabled,
            OnPremisesUserPrincipalName,
            OtherMails,
            PasswordPolicies,
            PasswordProfile,
            PastProjects,
            PostalCode,
            PreferredDataLocation,
            PreferredLanguage,
            PreferredName,
            ProvisionedPlans,
            ProxyAddresses,
            RefreshTokensValidFromDateTime,
            Responsibilities,
            Schools,
            ShowInAddressList,
            Skills,
            SignInSessionsValidFromDateTime,
            State,
            StreetAddress,
            Surname,
            UsageLocation,
            UserPrincipalName,
            UserType,
            AgreementAcceptances,
            Activities,
            AppRoleAssignments,
            Authentication,
            Calendar,
            CalendarGroups,
            CalendarView,
            Calendars,
            ContactFolders,
            Contacts,
            CreatedObjects,
            DirectReports,
            Drive,
            Drives,
            Events,
            Extensions,
            InferenceClassification,
            Insights,
            LicenseDetails,
            MailFolders,
            Manager,
            MemberOf,
            Messages,
            Onenote,
            Outlook,
            OwnedDevices,
            OwnedObjects,
            People,
            Photo,
            Planner,
            RegisteredDevices,
            Todo,
        }
        public enum ApiPath
        {
            Groups_Id_Owners,
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
    public partial class GroupListOwnersResponse : RestApiResponse
    {
        public User[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListOwnersResponse> GroupListOwnersAsync()
        {
            var p = new GroupListOwnersParameter();
            return await this.SendAsync<GroupListOwnersParameter, GroupListOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListOwnersResponse> GroupListOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListOwnersParameter();
            return await this.SendAsync<GroupListOwnersParameter, GroupListOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListOwnersResponse> GroupListOwnersAsync(GroupListOwnersParameter parameter)
        {
            return await this.SendAsync<GroupListOwnersParameter, GroupListOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListOwnersResponse> GroupListOwnersAsync(GroupListOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListOwnersParameter, GroupListOwnersResponse>(parameter, cancellationToken);
        }
    }
}
