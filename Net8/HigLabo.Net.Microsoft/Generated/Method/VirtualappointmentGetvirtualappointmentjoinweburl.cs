using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/virtualappointment-getvirtualappointmentjoinweburl?view=graph-rest-1.0
/// </summary>
public partial class VirtualAppointmentGetvirtualAppointmentjoinweburlParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? OnlineMeetingId { get; set; }
        public string? UserId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_OnlineMeetings_OnlineMeetingId_GetVirtualAppointmentJoinWebUrl: return $"/me/onlineMeetings/{OnlineMeetingId}/getVirtualAppointmentJoinWebUrl";
                case ApiPath.Users_UserId_OnlineMeetings_OnlineMeetingId_GetVirtualAppointmentJoinWebUrl: return $"/users/{UserId}/onlineMeetings/{OnlineMeetingId}/getVirtualAppointmentJoinWebUrl";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_OnlineMeetings_OnlineMeetingId_GetVirtualAppointmentJoinWebUrl,
        Users_UserId_OnlineMeetings_OnlineMeetingId_GetVirtualAppointmentJoinWebUrl,
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
public partial class VirtualAppointmentGetvirtualAppointmentjoinweburlResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/virtualappointment-getvirtualappointmentjoinweburl?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/virtualappointment-getvirtualappointmentjoinweburl?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<VirtualAppointmentGetvirtualAppointmentjoinweburlResponse> VirtualAppointmentGetvirtualAppointmentjoinweburlAsync()
    {
        var p = new VirtualAppointmentGetvirtualAppointmentjoinweburlParameter();
        return await this.SendAsync<VirtualAppointmentGetvirtualAppointmentjoinweburlParameter, VirtualAppointmentGetvirtualAppointmentjoinweburlResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/virtualappointment-getvirtualappointmentjoinweburl?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<VirtualAppointmentGetvirtualAppointmentjoinweburlResponse> VirtualAppointmentGetvirtualAppointmentjoinweburlAsync(CancellationToken cancellationToken)
    {
        var p = new VirtualAppointmentGetvirtualAppointmentjoinweburlParameter();
        return await this.SendAsync<VirtualAppointmentGetvirtualAppointmentjoinweburlParameter, VirtualAppointmentGetvirtualAppointmentjoinweburlResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/virtualappointment-getvirtualappointmentjoinweburl?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<VirtualAppointmentGetvirtualAppointmentjoinweburlResponse> VirtualAppointmentGetvirtualAppointmentjoinweburlAsync(VirtualAppointmentGetvirtualAppointmentjoinweburlParameter parameter)
    {
        return await this.SendAsync<VirtualAppointmentGetvirtualAppointmentjoinweburlParameter, VirtualAppointmentGetvirtualAppointmentjoinweburlResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/virtualappointment-getvirtualappointmentjoinweburl?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<VirtualAppointmentGetvirtualAppointmentjoinweburlResponse> VirtualAppointmentGetvirtualAppointmentjoinweburlAsync(VirtualAppointmentGetvirtualAppointmentjoinweburlParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<VirtualAppointmentGetvirtualAppointmentjoinweburlParameter, VirtualAppointmentGetvirtualAppointmentjoinweburlResponse>(parameter, cancellationToken);
    }
}
