using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/openshift-update?view=graph-rest-1.0
/// </summary>
public partial class OpenShiftUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? OpenShiftId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_Id_Schedule_OpenShifts_OpenShiftId: return $"/teams/{Id}/schedule/openShifts/{OpenShiftId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Teams_Id_Schedule_OpenShifts_OpenShiftId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "PUT";
    public OpenShiftItem? DraftOpenShift { get; set; }
    public string? SchedulingGroupId { get; set; }
    public OpenShiftItem? SharedOpenShift { get; set; }
}
public partial class OpenShiftUpdateResponse : RestApiResponse
{
    public OpenShiftItem? DraftOpenShift { get; set; }
    public string? SchedulingGroupId { get; set; }
    public OpenShiftItem? SharedOpenShift { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/openshift-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftUpdateResponse> OpenShiftUpdateAsync()
    {
        var p = new OpenShiftUpdateParameter();
        return await this.SendAsync<OpenShiftUpdateParameter, OpenShiftUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftUpdateResponse> OpenShiftUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new OpenShiftUpdateParameter();
        return await this.SendAsync<OpenShiftUpdateParameter, OpenShiftUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftUpdateResponse> OpenShiftUpdateAsync(OpenShiftUpdateParameter parameter)
    {
        return await this.SendAsync<OpenShiftUpdateParameter, OpenShiftUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshift-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftUpdateResponse> OpenShiftUpdateAsync(OpenShiftUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OpenShiftUpdateParameter, OpenShiftUpdateResponse>(parameter, cancellationToken);
    }
}
