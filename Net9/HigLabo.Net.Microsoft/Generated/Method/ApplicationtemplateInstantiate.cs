using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-instantiate?view=graph-rest-1.0
/// </summary>
public partial class ApplicationTemplateInstantiateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ApplicationTemplateId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.ApplicationTemplates_ApplicationTemplateId_Instantiate: return $"/applicationTemplates/{ApplicationTemplateId}/instantiate";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        ApplicationTemplates_ApplicationTemplateId_Instantiate,
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
    public string? DisplayName { get; set; }
    public Application? Application { get; set; }
    public ServicePrincipal? ServicePrincipal { get; set; }
}
public partial class ApplicationTemplateInstantiateResponse : RestApiResponse
{
    public Application? Application { get; set; }
    public ServicePrincipal? ServicePrincipal { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-instantiate?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-instantiate?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationTemplateInstantiateResponse> ApplicationTemplateInstantiateAsync()
    {
        var p = new ApplicationTemplateInstantiateParameter();
        return await this.SendAsync<ApplicationTemplateInstantiateParameter, ApplicationTemplateInstantiateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-instantiate?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationTemplateInstantiateResponse> ApplicationTemplateInstantiateAsync(CancellationToken cancellationToken)
    {
        var p = new ApplicationTemplateInstantiateParameter();
        return await this.SendAsync<ApplicationTemplateInstantiateParameter, ApplicationTemplateInstantiateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-instantiate?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationTemplateInstantiateResponse> ApplicationTemplateInstantiateAsync(ApplicationTemplateInstantiateParameter parameter)
    {
        return await this.SendAsync<ApplicationTemplateInstantiateParameter, ApplicationTemplateInstantiateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-instantiate?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationTemplateInstantiateResponse> ApplicationTemplateInstantiateAsync(ApplicationTemplateInstantiateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ApplicationTemplateInstantiateParameter, ApplicationTemplateInstantiateResponse>(parameter, cancellationToken);
    }
}
