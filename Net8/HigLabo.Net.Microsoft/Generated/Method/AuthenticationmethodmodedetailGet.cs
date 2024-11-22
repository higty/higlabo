using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationmethodmodedetail-get?view=graph-rest-1.0
/// </summary>
public partial class AuthenticationmethodmodedetailGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AuthenticationMethodModeDetailId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_ConditionalAccess_AuthenticationStrength_AuthenticationMethodModes_AuthenticationMethodModeDetailId: return $"/identity/conditionalAccess/authenticationStrength/authenticationMethodModes/{AuthenticationMethodModeDetailId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Identity_ConditionalAccess_AuthenticationStrength_AuthenticationMethodModes_AuthenticationMethodModeDetailId,
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
public partial class AuthenticationmethodmodedetailGetResponse : RestApiResponse
{
    public enum AuthenticationMethodModeDetailBaseAuthenticationMethod
    {
        Password,
        Voice,
        HardwareOath,
        SoftwareOath,
        Sms,
        Fido2,
        WindowsHelloForBusiness,
        MicrosoftAuthenticator,
        TemporaryAccessPass,
        Email,
        X509Certificate,
        Federation,
        UnknownFutureValue,
    }

    public AuthenticationMethodModeDetailBaseAuthenticationMethod AuthenticationMethod { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/authenticationmethodmodedetail-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodmodedetail-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationmethodmodedetailGetResponse> AuthenticationmethodmodedetailGetAsync()
    {
        var p = new AuthenticationmethodmodedetailGetParameter();
        return await this.SendAsync<AuthenticationmethodmodedetailGetParameter, AuthenticationmethodmodedetailGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodmodedetail-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationmethodmodedetailGetResponse> AuthenticationmethodmodedetailGetAsync(CancellationToken cancellationToken)
    {
        var p = new AuthenticationmethodmodedetailGetParameter();
        return await this.SendAsync<AuthenticationmethodmodedetailGetParameter, AuthenticationmethodmodedetailGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodmodedetail-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationmethodmodedetailGetResponse> AuthenticationmethodmodedetailGetAsync(AuthenticationmethodmodedetailGetParameter parameter)
    {
        return await this.SendAsync<AuthenticationmethodmodedetailGetParameter, AuthenticationmethodmodedetailGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/authenticationmethodmodedetail-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AuthenticationmethodmodedetailGetResponse> AuthenticationmethodmodedetailGetAsync(AuthenticationmethodmodedetailGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AuthenticationmethodmodedetailGetParameter, AuthenticationmethodmodedetailGetResponse>(parameter, cancellationToken);
    }
}
