using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-update-mailboxsettings?view=graph-rest-1.0
    /// </summary>
    public partial class UserUpdateMailboxSettingsParameter : IRestApiParameter
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
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum UserUpdateMailboxSettingsParameterDelegateMeetingMessageDeliveryOptions
        {
            SendToDelegateAndInformationToPrincipal,
            SendToDelegateAndPrincipal,
            SendToDelegateOnly,
        }
        public enum ApiPath
        {
            Me_MailboxSettings,
            Users_IdOruserPrincipalName_MailboxSettings,
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
        public AutomaticRepliesSetting? AutomaticRepliesSetting { get; set; }
        public string? DateFormat { get; set; }
        public UserUpdateMailboxSettingsParameterDelegateMeetingMessageDeliveryOptions DelegateMeetingMessageDeliveryOptions { get; set; }
        public LocaleInfo? Language { get; set; }
        public string? TimeFormat { get; set; }
        public string? TimeZone { get; set; }
        public WorkingHours? WorkingHours { get; set; }
    }
    public partial class UserUpdateMailboxSettingsResponse : RestApiResponse
    {
        public enum MailboxSettingsDelegateMeetingMessageDeliveryOptions
        {
            SendToDelegateAndInformationToPrincipal,
            SendToDelegateAndPrincipal,
            SendToDelegateOnly,
        }
        public enum MailboxSettingsUserPurpose
        {
            User,
            Linked,
            Shared,
            Room,
            Equipment,
            Others,
            UnknownFutureValue,
        }

        public string? ArchiveFolder { get; set; }
        public AutomaticRepliesSetting? AutomaticRepliesSetting { get; set; }
        public string? DateFormat { get; set; }
        public MailboxSettingsDelegateMeetingMessageDeliveryOptions DelegateMeetingMessageDeliveryOptions { get; set; }
        public LocaleInfo? Language { get; set; }
        public string? TimeFormat { get; set; }
        public string? TimeZone { get; set; }
        public MailboxSettingsUserPurpose UserPurpose { get; set; }
        public WorkingHours? WorkingHours { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-update-mailboxsettings?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-update-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async Task<UserUpdateMailboxSettingsResponse> UserUpdateMailboxSettingsAsync()
        {
            var p = new UserUpdateMailboxSettingsParameter();
            return await this.SendAsync<UserUpdateMailboxSettingsParameter, UserUpdateMailboxSettingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-update-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async Task<UserUpdateMailboxSettingsResponse> UserUpdateMailboxSettingsAsync(CancellationToken cancellationToken)
        {
            var p = new UserUpdateMailboxSettingsParameter();
            return await this.SendAsync<UserUpdateMailboxSettingsParameter, UserUpdateMailboxSettingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-update-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async Task<UserUpdateMailboxSettingsResponse> UserUpdateMailboxSettingsAsync(UserUpdateMailboxSettingsParameter parameter)
        {
            return await this.SendAsync<UserUpdateMailboxSettingsParameter, UserUpdateMailboxSettingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-update-mailboxsettings?view=graph-rest-1.0
        /// </summary>
        public async Task<UserUpdateMailboxSettingsResponse> UserUpdateMailboxSettingsAsync(UserUpdateMailboxSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserUpdateMailboxSettingsParameter, UserUpdateMailboxSettingsResponse>(parameter, cancellationToken);
        }
    }
}
