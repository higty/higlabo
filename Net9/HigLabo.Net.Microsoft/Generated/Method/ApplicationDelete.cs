using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
/// </summary>
public partial class ApplicationDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ApplicationObjectId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Applications_ApplicationObjectId: return $"/applications/{ApplicationObjectId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Applications_ApplicationObjectId,
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
public partial class ApplicationDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationDeleteResponse> ApplicationDeleteAsync()
    {
        var p = new ApplicationDeleteParameter();
        return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationDeleteResponse> ApplicationDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new ApplicationDeleteParameter();
        return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationDeleteResponse> ApplicationDeleteAsync(ApplicationDeleteParameter parameter)
    {
        return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationDeleteResponse> ApplicationDeleteAsync(ApplicationDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(parameter, cancellationToken);
    }
}
