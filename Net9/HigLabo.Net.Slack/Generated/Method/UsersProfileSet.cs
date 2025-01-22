using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class UsersProfileSetParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "users.profile.set";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Name { get; set; }
    public string? Profile { get; set; }
    public string? User { get; set; }
    public string? Value { get; set; }
}
public partial class UsersProfileSetResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/users.profile.set
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/users.profile.set
    /// </summary>
    public async ValueTask<UsersProfileSetResponse> UsersProfileSetAsync()
    {
        var p = new UsersProfileSetParameter();
        return await this.SendAsync<UsersProfileSetParameter, UsersProfileSetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.profile.set
    /// </summary>
    public async ValueTask<UsersProfileSetResponse> UsersProfileSetAsync(CancellationToken cancellationToken)
    {
        var p = new UsersProfileSetParameter();
        return await this.SendAsync<UsersProfileSetParameter, UsersProfileSetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.profile.set
    /// </summary>
    public async ValueTask<UsersProfileSetResponse> UsersProfileSetAsync(UsersProfileSetParameter parameter)
    {
        return await this.SendAsync<UsersProfileSetParameter, UsersProfileSetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.profile.set
    /// </summary>
    public async ValueTask<UsersProfileSetResponse> UsersProfileSetAsync(UsersProfileSetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UsersProfileSetParameter, UsersProfileSetResponse>(parameter, cancellationToken);
    }
}
