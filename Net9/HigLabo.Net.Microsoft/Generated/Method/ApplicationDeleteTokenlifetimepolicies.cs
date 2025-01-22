using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenlifetimepolicies?view=graph-rest-1.0
/// </summary>
public partial class ApplicationDeleteTokenlifetimepoliciesParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? ApplicationsId { get; set; }
        public string? TokenLifetimePoliciesId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Applications_Id_TokenLifetimePolicies_Id_ref: return $"/applications/{ApplicationsId}/tokenLifetimePolicies/{TokenLifetimePoliciesId}/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Applications_Id_TokenLifetimePolicies_Id_ref,
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
public partial class ApplicationDeleteTokenlifetimepoliciesResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenlifetimepolicies?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenlifetimepolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationDeleteTokenlifetimepoliciesResponse> ApplicationDeleteTokenlifetimepoliciesAsync()
    {
        var p = new ApplicationDeleteTokenlifetimepoliciesParameter();
        return await this.SendAsync<ApplicationDeleteTokenlifetimepoliciesParameter, ApplicationDeleteTokenlifetimepoliciesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenlifetimepolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationDeleteTokenlifetimepoliciesResponse> ApplicationDeleteTokenlifetimepoliciesAsync(CancellationToken cancellationToken)
    {
        var p = new ApplicationDeleteTokenlifetimepoliciesParameter();
        return await this.SendAsync<ApplicationDeleteTokenlifetimepoliciesParameter, ApplicationDeleteTokenlifetimepoliciesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenlifetimepolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationDeleteTokenlifetimepoliciesResponse> ApplicationDeleteTokenlifetimepoliciesAsync(ApplicationDeleteTokenlifetimepoliciesParameter parameter)
    {
        return await this.SendAsync<ApplicationDeleteTokenlifetimepoliciesParameter, ApplicationDeleteTokenlifetimepoliciesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/application-delete-tokenlifetimepolicies?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ApplicationDeleteTokenlifetimepoliciesResponse> ApplicationDeleteTokenlifetimepoliciesAsync(ApplicationDeleteTokenlifetimepoliciesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ApplicationDeleteTokenlifetimepoliciesParameter, ApplicationDeleteTokenlifetimepoliciesResponse>(parameter, cancellationToken);
    }
}
