using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-get-mailboxsettings?view=graph-rest-1.0
    /// </summary>
    public partial class UserGetMailboxSettingsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_MailboxSettings: return $"/me/mailboxSettings";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings: return $"/users/{IdOrUserPrincipalName}/mailboxSettings";
                    case ApiPath.Me_MailboxSettings_AutomaticRepliesSetting: return $"/me/mailboxSettings/automaticRepliesSetting";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_AutomaticRepliesSetting: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/automaticRepliesSetting";
                    case ApiPath.Me_MailboxSettings_DateFormat: return $"/me/mailboxSettings/dateFormat";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_DateFormat: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/dateFormat";
                    case ApiPath.Me_MailboxSettings_DelegateMeetingMessageDeliveryOptions: return $"/me/mailboxSettings/delegateMeetingMessageDeliveryOptions";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_DelegateMeetingMessageDeliveryOptions: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/delegateMeetingMessageDeliveryOptions";
                    case ApiPath.Me_MailboxSettings_Language: return $"/me/mailboxSettings/language";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_Language: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/language";
                    case ApiPath.Me_MailboxSettings_TimeFormat: return $"/me/mailboxSettings/timeFormat";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_TimeFormat: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/timeFormat";
                    case ApiPath.Me_MailboxSettings_TimeZone: return $"/me/mailboxSettings/timeZone";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_TimeZone: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/timeZone";
                    case ApiPath.Me_MailboxSettings_WorkingHours: return $"/me/mailboxSettings/workingHours";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_WorkingHours: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/workingHours";
                    case ApiPath.Me_MailboxSettings_UserPurpose: return $"/me/mailboxSettings/userPurpose";
                    case ApiPath.Users_IdOruserPrincipalName_MailboxSettings_UserPurpose: return $"/users/{IdOrUserPrincipalName}/mailboxSettings/userPurpose";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_MailboxSettings,
            Users_IdOruserPrincipalName_MailboxSettings,
            Me_MailboxSettings_AutomaticRepliesSetting,
            Users_IdOruserPrincipalName_MailboxSettings_AutomaticRepliesSetting,
            Me_MailboxSettings_DateFormat,
            Users_IdOruserPrincipalName_MailboxSettings_DateFormat,
            Me_MailboxSettings_DelegateMeetingMessageDeliveryOptions,
            Users_IdOruserPrincipalName_MailboxSettings_DelegateMeetingMessageDeliveryOptions,
            Me_MailboxSettings_Language,
            Users_IdOruserPrincipalName_MailboxSettings_Language,
            Me_MailboxSettings_TimeFormat,
            Users_IdOruserPrincipalName_MailboxSettings_TimeFormat,
            Me_MailboxSettings_TimeZone,
            Users_IdOruserPrincipalName_MailboxSettings_TimeZone,
            Me_MailboxSettings_WorkingHours,
            Users_IdOruserPrincipalName_MailboxSettings_WorkingHours,
            Me_MailboxSettings_UserPurpose,
            Users_IdOruserPrincipalName_MailboxSettings_UserPurpose,
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
    public partial class UserGetMailboxSettingsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-get-mailboxsettings?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-get-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserGetMailboxSettingsResponse> UserGetMailboxSettingsAsync()
        {
            var p = new UserGetMailboxSettingsParameter();
            return await this.SendAsync<UserGetMailboxSettingsParameter, UserGetMailboxSettingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-get-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserGetMailboxSettingsResponse> UserGetMailboxSettingsAsync(CancellationToken cancellationToken)
        {
            var p = new UserGetMailboxSettingsParameter();
            return await this.SendAsync<UserGetMailboxSettingsParameter, UserGetMailboxSettingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-get-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserGetMailboxSettingsResponse> UserGetMailboxSettingsAsync(UserGetMailboxSettingsParameter parameter)
        {
            return await this.SendAsync<UserGetMailboxSettingsParameter, UserGetMailboxSettingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-get-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserGetMailboxSettingsResponse> UserGetMailboxSettingsAsync(UserGetMailboxSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserGetMailboxSettingsParameter, UserGetMailboxSettingsResponse>(parameter, cancellationToken);
        }
    }
}
