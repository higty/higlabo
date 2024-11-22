using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-delete?view=graph-rest-1.0
/// </summary>
public partial class GroupDeleteParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Groups_Id: return $"/groups/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Groups_Id,
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
public partial class GroupDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupDeleteResponse> GroupDeleteAsync()
    {
        var p = new GroupDeleteParameter();
        return await this.SendAsync<GroupDeleteParameter, GroupDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupDeleteResponse> GroupDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new GroupDeleteParameter();
        return await this.SendAsync<GroupDeleteParameter, GroupDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupDeleteResponse> GroupDeleteAsync(GroupDeleteParameter parameter)
    {
        return await this.SendAsync<GroupDeleteParameter, GroupDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupDeleteResponse> GroupDeleteAsync(GroupDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupDeleteParameter, GroupDeleteResponse>(parameter, cancellationToken);
    }
}
