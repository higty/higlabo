using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-post?view=graph-rest-1.0
/// </summary>
public partial class OpenShiftChangeRequestPostParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests: return $"/teams/{Id}/schedule/openShiftChangeRequests";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_Id_Schedule_OpenShiftChangeRequests,
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
    public string? OpenShiftId { get; set; }
}
public partial class OpenShiftChangeRequestPostResponse : RestApiResponse
{
    public string? OpenShiftId { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-post?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestPostResponse> OpenShiftChangeRequestPostAsync()
    {
        var p = new OpenShiftChangeRequestPostParameter();
        return await this.SendAsync<OpenShiftChangeRequestPostParameter, OpenShiftChangeRequestPostResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestPostResponse> OpenShiftChangeRequestPostAsync(CancellationToken cancellationToken)
    {
        var p = new OpenShiftChangeRequestPostParameter();
        return await this.SendAsync<OpenShiftChangeRequestPostParameter, OpenShiftChangeRequestPostResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestPostResponse> OpenShiftChangeRequestPostAsync(OpenShiftChangeRequestPostParameter parameter)
    {
        return await this.SendAsync<OpenShiftChangeRequestPostParameter, OpenShiftChangeRequestPostResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-post?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestPostResponse> OpenShiftChangeRequestPostAsync(OpenShiftChangeRequestPostParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OpenShiftChangeRequestPostParameter, OpenShiftChangeRequestPostResponse>(parameter, cancellationToken);
    }
}
