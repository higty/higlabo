using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class UsersIdentityParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "users.identity";
    string IRestApiParameter.HttpMethod { get; } = "GET";
}
public partial class UsersIdentityResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/users.identity
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/users.identity
    /// </summary>
    public async ValueTask<UsersIdentityResponse> UsersIdentityAsync()
    {
        var p = new UsersIdentityParameter();
        return await this.SendAsync<UsersIdentityParameter, UsersIdentityResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.identity
    /// </summary>
    public async ValueTask<UsersIdentityResponse> UsersIdentityAsync(CancellationToken cancellationToken)
    {
        var p = new UsersIdentityParameter();
        return await this.SendAsync<UsersIdentityParameter, UsersIdentityResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.identity
    /// </summary>
    public async ValueTask<UsersIdentityResponse> UsersIdentityAsync(UsersIdentityParameter parameter)
    {
        return await this.SendAsync<UsersIdentityParameter, UsersIdentityResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.identity
    /// </summary>
    public async ValueTask<UsersIdentityResponse> UsersIdentityAsync(UsersIdentityParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UsersIdentityParameter, UsersIdentityResponse>(parameter, cancellationToken);
    }
}
