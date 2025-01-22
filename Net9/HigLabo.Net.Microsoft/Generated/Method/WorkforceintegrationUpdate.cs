using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/workforceintegration-update?view=graph-rest-1.0
/// </summary>
public partial class WorkforceintegrationUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? WorkforceIntegrationId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teamwork_WorkforceIntegrations_WorkforceIntegrationId: return $"/teamwork/workforceIntegrations/{WorkforceIntegrationId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum WorkforceintegrationUpdateParameterstring
    {
        None,
        Shift,
        SwapRequest,
        Openshift,
        OpenShiftRequest,
        UserShiftPreferences,
    }
    public enum ApiPath
    {
        Teamwork_WorkforceIntegrations_WorkforceIntegrationId,
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
    public Int32? ApiVersion { get; set; }
    public string? DisplayName { get; set; }
    public WorkforceIntegrationEncryption? Encryption { get; set; }
    public bool? IsActive { get; set; }
    public WorkforceintegrationUpdateParameterstring SupportedEntities { get; set; }
    public string? Url { get; set; }
}
public partial class WorkforceintegrationUpdateResponse : RestApiResponse
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
/// https://learn.microsoft.com/en-us/graph/api/workforceintegration-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkforceintegrationUpdateResponse> WorkforceintegrationUpdateAsync()
    {
        var p = new WorkforceintegrationUpdateParameter();
        return await this.SendAsync<WorkforceintegrationUpdateParameter, WorkforceintegrationUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkforceintegrationUpdateResponse> WorkforceintegrationUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new WorkforceintegrationUpdateParameter();
        return await this.SendAsync<WorkforceintegrationUpdateParameter, WorkforceintegrationUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkforceintegrationUpdateResponse> WorkforceintegrationUpdateAsync(WorkforceintegrationUpdateParameter parameter)
    {
        return await this.SendAsync<WorkforceintegrationUpdateParameter, WorkforceintegrationUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/workforceintegration-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<WorkforceintegrationUpdateResponse> WorkforceintegrationUpdateAsync(WorkforceintegrationUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<WorkforceintegrationUpdateParameter, WorkforceintegrationUpdateResponse>(parameter, cancellationToken);
    }
}
