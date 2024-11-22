using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/workforceintegration-post?view=graph-rest-1.0
/// </summary>
public partial class WorkforceintegrationPostParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teamwork_WorkforceIntegrations: return $"/teamwork/workforceIntegrations";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum WorkforceIntegrationWorkforceIntegrationSupportedEntities
    {
        None,
        Shift,
        SwapRequest,
        UserShiftPreferences,
        Openshift,
        OpenShiftRequest,
        OfferShiftRequest,
        UnknownFutureValue,
    }
    public enum ApiPath
    {
        Teamwork_WorkforceIntegrations,
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
    public Int32? ApiVersion { get; set; }
    public string? DisplayName { get; set; }
    public WorkforceIntegrationEncryption? Encryption { get; set; }
    public bool? IsActive { get; set; }
    public WorkforceIntegrationWorkforceIntegrationSupportedEntities SupportedEntities { get; set; }
    public string? Url { get; set; }
}
public partial class WorkforceintegrationPostResponse : RestApiResponse
{
    public enum WorkforceIntegrationWorkforceIntegrationSupportedEntities
    {
        None,
        Shift,
        SwapRequest,
        UserShiftPreferences,
        Openshift,
        OpenShiftRequest,
        OfferShiftRequest,
        UnknownFutureValue,
    }

    public Int32? ApiVersion { get; set; }
    public string? DisplayName { get; set; }
    public WorkforceIntegrationEncryption? Encryption { get; set; }
    public bool? IsActive { get; set; }
    public WorkforceIntegrationWorkforceIntegrationSupportedEntities SupportedEntities { get; set; }
    public string? Url { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/workforceintegration-post?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkforceintegrationPostResponse> WorkforceintegrationPostAsync()
    {
        var p = new WorkforceintegrationPostParameter();
        return await this.SendAsync<WorkforceintegrationPostParameter, WorkforceintegrationPostResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkforceintegrationPostResponse> WorkforceintegrationPostAsync(CancellationToken cancellationToken)
    {
        var p = new WorkforceintegrationPostParameter();
        return await this.SendAsync<WorkforceintegrationPostParameter, WorkforceintegrationPostResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkforceintegrationPostResponse> WorkforceintegrationPostAsync(WorkforceintegrationPostParameter parameter)
    {
        return await this.SendAsync<WorkforceintegrationPostParameter, WorkforceintegrationPostResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkforceintegrationPostResponse> WorkforceintegrationPostAsync(WorkforceintegrationPostParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<WorkforceintegrationPostParameter, WorkforceintegrationPostResponse>(parameter, cancellationToken);
    }
}
