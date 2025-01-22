using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-enablesmssignin?view=graph-rest-1.0
/// </summary>
public partial class PhoneauthenticationmethodEnablesmssigninParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? MobilePhoneMethodId { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Authentication_PhoneMethods_MobilePhoneMethodId_EnableSmsSignIn: return $"/me/authentication/phoneMethods/{MobilePhoneMethodId}/enableSmsSignIn";
                case ApiPath.Users_IdOrUserPrincipalName_Authentication_PhoneMethods_MobilePhoneMethodId_EnableSmsSignIn: return $"/users/{IdOrUserPrincipalName}/authentication/phoneMethods/{MobilePhoneMethodId}/enableSmsSignIn";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Authentication_PhoneMethods_MobilePhoneMethodId_EnableSmsSignIn,
        Users_IdOrUserPrincipalName_Authentication_PhoneMethods_MobilePhoneMethodId_EnableSmsSignIn,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "POST";
}
public partial class PhoneauthenticationmethodEnablesmssigninResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-enablesmssignin?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-enablesmssignin?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PhoneauthenticationmethodEnablesmssigninResponse> PhoneauthenticationmethodEnablesmssigninAsync()
    {
        var p = new PhoneauthenticationmethodEnablesmssigninParameter();
        return await this.SendAsync<PhoneauthenticationmethodEnablesmssigninParameter, PhoneauthenticationmethodEnablesmssigninResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-enablesmssignin?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PhoneauthenticationmethodEnablesmssigninResponse> PhoneauthenticationmethodEnablesmssigninAsync(CancellationToken cancellationToken)
    {
        var p = new PhoneauthenticationmethodEnablesmssigninParameter();
        return await this.SendAsync<PhoneauthenticationmethodEnablesmssigninParameter, PhoneauthenticationmethodEnablesmssigninResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-enablesmssignin?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PhoneauthenticationmethodEnablesmssigninResponse> PhoneauthenticationmethodEnablesmssigninAsync(PhoneauthenticationmethodEnablesmssigninParameter parameter)
    {
        return await this.SendAsync<PhoneauthenticationmethodEnablesmssigninParameter, PhoneauthenticationmethodEnablesmssigninResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/phoneauthenticationmethod-enablesmssignin?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<PhoneauthenticationmethodEnablesmssigninResponse> PhoneauthenticationmethodEnablesmssigninAsync(PhoneauthenticationmethodEnablesmssigninParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<PhoneauthenticationmethodEnablesmssigninParameter, PhoneauthenticationmethodEnablesmssigninResponse>(parameter, cancellationToken);
    }
}
