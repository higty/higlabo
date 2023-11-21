using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public partial class SmsauthenticationmethodConfigurationDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Sms: return $"/policies/authenticationMethodsPolicy/authenticationMethodConfigurations/sms";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_AuthenticationMethodsPolicy_AuthenticationMethodConfigurations_Sms,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class SmsauthenticationmethodConfigurationDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SmsauthenticationmethodConfigurationDeleteResponse> SmsauthenticationmethodConfigurationDeleteAsync()
        {
            var p = new SmsauthenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<SmsauthenticationmethodConfigurationDeleteParameter, SmsauthenticationmethodConfigurationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SmsauthenticationmethodConfigurationDeleteResponse> SmsauthenticationmethodConfigurationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new SmsauthenticationmethodConfigurationDeleteParameter();
            return await this.SendAsync<SmsauthenticationmethodConfigurationDeleteParameter, SmsauthenticationmethodConfigurationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SmsauthenticationmethodConfigurationDeleteResponse> SmsauthenticationmethodConfigurationDeleteAsync(SmsauthenticationmethodConfigurationDeleteParameter parameter)
        {
            return await this.SendAsync<SmsauthenticationmethodConfigurationDeleteParameter, SmsauthenticationmethodConfigurationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/smsauthenticationmethodconfiguration-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SmsauthenticationmethodConfigurationDeleteResponse> SmsauthenticationmethodConfigurationDeleteAsync(SmsauthenticationmethodConfigurationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SmsauthenticationmethodConfigurationDeleteParameter, SmsauthenticationmethodConfigurationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
