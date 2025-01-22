using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-decline?view=graph-rest-1.0
/// </summary>
public partial class OpenShiftChangeRequestDeclineParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? OpenShiftChangeRequestId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftChangeRequestId_Decline: return $"/teams/{Id}/schedule/openShiftChangeRequests/{OpenShiftChangeRequestId}/decline";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftChangeRequestId_Decline,
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
    public string? Message { get; set; }
}
public partial class OpenShiftChangeRequestDeclineResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-decline?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-decline?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestDeclineResponse> OpenShiftChangeRequestDeclineAsync()
    {
        var p = new OpenShiftChangeRequestDeclineParameter();
        return await this.SendAsync<OpenShiftChangeRequestDeclineParameter, OpenShiftChangeRequestDeclineResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-decline?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestDeclineResponse> OpenShiftChangeRequestDeclineAsync(CancellationToken cancellationToken)
    {
        var p = new OpenShiftChangeRequestDeclineParameter();
        return await this.SendAsync<OpenShiftChangeRequestDeclineParameter, OpenShiftChangeRequestDeclineResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-decline?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestDeclineResponse> OpenShiftChangeRequestDeclineAsync(OpenShiftChangeRequestDeclineParameter parameter)
    {
        return await this.SendAsync<OpenShiftChangeRequestDeclineParameter, OpenShiftChangeRequestDeclineResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-decline?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestDeclineResponse> OpenShiftChangeRequestDeclineAsync(OpenShiftChangeRequestDeclineParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OpenShiftChangeRequestDeclineParameter, OpenShiftChangeRequestDeclineResponse>(parameter, cancellationToken);
    }
}
