using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-delete?view=graph-rest-1.0
/// </summary>
public partial class Fido2authenticationmethodDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_Authentication_Fido2Methods_Id: return $"/me/authentication/fido2Methods/{Id}";
                case ApiPath.Users_IdOrUserPrincipalName_Authentication_Fido2Methods_Id: return $"/users/{IdOrUserPrincipalName}/authentication/fido2Methods/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_Authentication_Fido2Methods_Id,
        Users_IdOrUserPrincipalName_Authentication_Fido2Methods_Id,
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
public partial class Fido2authenticationmethodDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Fido2authenticationmethodDeleteResponse> Fido2authenticationmethodDeleteAsync()
    {
        var p = new Fido2authenticationmethodDeleteParameter();
        return await this.SendAsync<Fido2authenticationmethodDeleteParameter, Fido2authenticationmethodDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Fido2authenticationmethodDeleteResponse> Fido2authenticationmethodDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new Fido2authenticationmethodDeleteParameter();
        return await this.SendAsync<Fido2authenticationmethodDeleteParameter, Fido2authenticationmethodDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Fido2authenticationmethodDeleteResponse> Fido2authenticationmethodDeleteAsync(Fido2authenticationmethodDeleteParameter parameter)
    {
        return await this.SendAsync<Fido2authenticationmethodDeleteParameter, Fido2authenticationmethodDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/fido2authenticationmethod-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<Fido2authenticationmethodDeleteResponse> Fido2authenticationmethodDeleteAsync(Fido2authenticationmethodDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<Fido2authenticationmethodDeleteParameter, Fido2authenticationmethodDeleteResponse>(parameter, cancellationToken);
    }
}
