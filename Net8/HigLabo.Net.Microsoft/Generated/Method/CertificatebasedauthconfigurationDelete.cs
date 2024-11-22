using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-delete?view=graph-rest-1.0
/// </summary>
public partial class CertificatebasedauthConfigurationDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? OrganizationId { get; set; }
        public string? CertificateBasedAuthConfigurationId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Organization_Id_CertificateBasedAuthConfiguration_Id: return $"/organization/{OrganizationId}/certificateBasedAuthConfiguration/{CertificateBasedAuthConfigurationId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Organization_Id_CertificateBasedAuthConfiguration_Id,
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
public partial class CertificatebasedauthConfigurationDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CertificatebasedauthConfigurationDeleteResponse> CertificatebasedauthConfigurationDeleteAsync()
    {
        var p = new CertificatebasedauthConfigurationDeleteParameter();
        return await this.SendAsync<CertificatebasedauthConfigurationDeleteParameter, CertificatebasedauthConfigurationDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CertificatebasedauthConfigurationDeleteResponse> CertificatebasedauthConfigurationDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new CertificatebasedauthConfigurationDeleteParameter();
        return await this.SendAsync<CertificatebasedauthConfigurationDeleteParameter, CertificatebasedauthConfigurationDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CertificatebasedauthConfigurationDeleteResponse> CertificatebasedauthConfigurationDeleteAsync(CertificatebasedauthConfigurationDeleteParameter parameter)
    {
        return await this.SendAsync<CertificatebasedauthConfigurationDeleteParameter, CertificatebasedauthConfigurationDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/certificatebasedauthconfiguration-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CertificatebasedauthConfigurationDeleteResponse> CertificatebasedauthConfigurationDeleteAsync(CertificatebasedauthConfigurationDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CertificatebasedauthConfigurationDeleteParameter, CertificatebasedauthConfigurationDeleteResponse>(parameter, cancellationToken);
    }
}
