using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
    /// </summary>
    public partial class AdministrativeunitListMembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Directory_AdministrativeUnits_Id_Members: return $"/directory/administrativeUnits/{Id}/members";
                    case ApiPath.Directory_AdministrativeUnits_Id_Members_ref: return $"/directory/administrativeUnits/{Id}/members/$ref";
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
            EmployeeLeaveDateTime,
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
            SecurityIdentifier,
            ShowInAddressList,
            SignInActivity,
            SignInSessionsValidFromDateTime,
            Skills,
            State,
            StreetAddress,
            Surname,
            UsageLocation,
            UserPrincipalName,
            UserType,
            Activities,
            AgreementAcceptances,
            AppRoleAssignments,
            Authentication,
            Calendar,
            CalendarGroups,
            Calendars,
            CalendarView,
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
            TransitiveMemberOf,
        }
        public enum ApiPath
        {
            Directory_AdministrativeUnits_Id_Members,
            Directory_AdministrativeUnits_Id_Members_ref,
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
    public partial class AdministrativeunitListMembersResponse : RestApiResponse
    {
        public User[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitListMembersResponse> AdministrativeunitListMembersAsync()
        {
            var p = new AdministrativeunitListMembersParameter();
            return await this.SendAsync<AdministrativeunitListMembersParameter, AdministrativeunitListMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitListMembersResponse> AdministrativeunitListMembersAsync(CancellationToken cancellationToken)
        {
            var p = new AdministrativeunitListMembersParameter();
            return await this.SendAsync<AdministrativeunitListMembersParameter, AdministrativeunitListMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitListMembersResponse> AdministrativeunitListMembersAsync(AdministrativeunitListMembersParameter parameter)
        {
            return await this.SendAsync<AdministrativeunitListMembersParameter, AdministrativeunitListMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/administrativeunit-list-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AdministrativeunitListMembersResponse> AdministrativeunitListMembersAsync(AdministrativeunitListMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdministrativeunitListMembersParameter, AdministrativeunitListMembersResponse>(parameter, cancellationToken);
        }
    }
}
