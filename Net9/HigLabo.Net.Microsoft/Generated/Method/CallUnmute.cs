using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/call-unmute?view=graph-rest-1.0
/// </summary>
public partial class CallUnmuteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Communications_Calls_Id_Unmute: return $"/communications/calls/{Id}/unmute";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Communications_Calls_Id_Unmute,
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
    public string? ClientContext { get; set; }
    public string? Id { get; set; }
    public ResultInfo? ResultInfo { get; set; }
    public string? Status { get; set; }
}
public partial class CallUnmuteResponse : RestApiResponse
{
    public string? ClientContext { get; set; }
    public string? Id { get; set; }
    public ResultInfo? ResultInfo { get; set; }
    public string? Status { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/call-unmute?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-unmute?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallUnmuteResponse> CallUnmuteAsync()
    {
        var p = new CallUnmuteParameter();
        return await this.SendAsync<CallUnmuteParameter, CallUnmuteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-unmute?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallUnmuteResponse> CallUnmuteAsync(CancellationToken cancellationToken)
    {
        var p = new CallUnmuteParameter();
        return await this.SendAsync<CallUnmuteParameter, CallUnmuteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-unmute?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallUnmuteResponse> CallUnmuteAsync(CallUnmuteParameter parameter)
    {
        return await this.SendAsync<CallUnmuteParameter, CallUnmuteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-unmute?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallUnmuteResponse> CallUnmuteAsync(CallUnmuteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CallUnmuteParameter, CallUnmuteResponse>(parameter, cancellationToken);
    }
}
