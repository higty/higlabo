using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/call-changescreensharingrole?view=graph-rest-1.0
/// </summary>
public partial class CallChangescreensharingroleParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Communications_Calls_Id_ChangeScreenSharingRole: return $"/communications/calls/{Id}/changeScreenSharingRole";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Communications_Calls_Id_ChangeScreenSharingRole,
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
    public string? Role { get; set; }
}
public partial class CallChangescreensharingroleResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/call-changescreensharingrole?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-changescreensharingrole?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallChangescreensharingroleResponse> CallChangescreensharingroleAsync()
    {
        var p = new CallChangescreensharingroleParameter();
        return await this.SendAsync<CallChangescreensharingroleParameter, CallChangescreensharingroleResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-changescreensharingrole?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallChangescreensharingroleResponse> CallChangescreensharingroleAsync(CancellationToken cancellationToken)
    {
        var p = new CallChangescreensharingroleParameter();
        return await this.SendAsync<CallChangescreensharingroleParameter, CallChangescreensharingroleResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-changescreensharingrole?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallChangescreensharingroleResponse> CallChangescreensharingroleAsync(CallChangescreensharingroleParameter parameter)
    {
        return await this.SendAsync<CallChangescreensharingroleParameter, CallChangescreensharingroleResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/call-changescreensharingrole?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<CallChangescreensharingroleResponse> CallChangescreensharingroleAsync(CallChangescreensharingroleParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<CallChangescreensharingroleParameter, CallChangescreensharingroleResponse>(parameter, cancellationToken);
    }
}
