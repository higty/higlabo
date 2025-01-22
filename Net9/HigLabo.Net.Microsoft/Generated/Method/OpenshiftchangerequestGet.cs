using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
/// </summary>
public partial class OpenShiftChangeRequestGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }
        public string? OpenShiftsChangeRequestId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftsChangeRequestId: return $"/teams/{Id}/schedule/openShiftChangeRequests/{OpenShiftsChangeRequestId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Teams_Id_Schedule_OpenShiftChangeRequests_OpenShiftsChangeRequestId,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class OpenShiftChangeRequestGetResponse : RestApiResponse
{
    public string? OpenShiftId { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestGetResponse> OpenShiftChangeRequestGetAsync()
    {
        var p = new OpenShiftChangeRequestGetParameter();
        return await this.SendAsync<OpenShiftChangeRequestGetParameter, OpenShiftChangeRequestGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestGetResponse> OpenShiftChangeRequestGetAsync(CancellationToken cancellationToken)
    {
        var p = new OpenShiftChangeRequestGetParameter();
        return await this.SendAsync<OpenShiftChangeRequestGetParameter, OpenShiftChangeRequestGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestGetResponse> OpenShiftChangeRequestGetAsync(OpenShiftChangeRequestGetParameter parameter)
    {
        return await this.SendAsync<OpenShiftChangeRequestGetParameter, OpenShiftChangeRequestGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/openshiftchangerequest-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<OpenShiftChangeRequestGetResponse> OpenShiftChangeRequestGetAsync(OpenShiftChangeRequestGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<OpenShiftChangeRequestGetParameter, OpenShiftChangeRequestGetResponse>(parameter, cancellationToken);
    }
}
