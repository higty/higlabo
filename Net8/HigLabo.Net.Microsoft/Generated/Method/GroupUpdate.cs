using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-update?view=graph-rest-1.0
/// </summary>
public partial class GroupUpdateParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public bool? AllowExternalSenders { get; set; }
    public AssignedLabel[]? AssignedLabels { get; set; }
    public bool? AutoSubscribeNewMembers { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? MailNickname { get; set; }
    public string? PreferredDataLocation { get; set; }
    public bool? SecurityEnabled { get; set; }
    public string? Visibility { get; set; }
}
public partial class GroupUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/group-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupUpdateResponse> GroupUpdateAsync()
    {
        var p = new GroupUpdateParameter();
        return await this.SendAsync<GroupUpdateParameter, GroupUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupUpdateResponse> GroupUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new GroupUpdateParameter();
        return await this.SendAsync<GroupUpdateParameter, GroupUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupUpdateResponse> GroupUpdateAsync(GroupUpdateParameter parameter)
    {
        return await this.SendAsync<GroupUpdateParameter, GroupUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<GroupUpdateResponse> GroupUpdateAsync(GroupUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<GroupUpdateParameter, GroupUpdateResponse>(parameter, cancellationToken);
    }
}
