using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
    /// </summary>
    public partial class PrintershareListAllowedUsersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? PrinterShareId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Shares_PrinterShareId_AllowedUsers: return $"/print/shares/{PrinterShareId}/allowedUsers";
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
            Print_Shares_PrinterShareId_AllowedUsers,
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
    public partial class PrintershareListAllowedUsersResponse : RestApiResponse
    {
        public User[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListAllowedUsersResponse> PrintershareListAllowedUsersAsync()
        {
            var p = new PrintershareListAllowedUsersParameter();
            return await this.SendAsync<PrintershareListAllowedUsersParameter, PrintershareListAllowedUsersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListAllowedUsersResponse> PrintershareListAllowedUsersAsync(CancellationToken cancellationToken)
        {
            var p = new PrintershareListAllowedUsersParameter();
            return await this.SendAsync<PrintershareListAllowedUsersParameter, PrintershareListAllowedUsersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListAllowedUsersResponse> PrintershareListAllowedUsersAsync(PrintershareListAllowedUsersParameter parameter)
        {
            return await this.SendAsync<PrintershareListAllowedUsersParameter, PrintershareListAllowedUsersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printershare-list-allowedusers?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintershareListAllowedUsersResponse> PrintershareListAllowedUsersAsync(PrintershareListAllowedUsersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintershareListAllowedUsersParameter, PrintershareListAllowedUsersResponse>(parameter, cancellationToken);
        }
    }
}
