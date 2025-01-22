using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class UsersLookupByEmailParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "users.lookupByEmail";
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public string? Email { get; set; }
}
public partial class UsersLookupByEmailResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/users.lookupByEmail
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/users.lookupByEmail
    /// </summary>
    public async ValueTask<UsersLookupByEmailResponse> UsersLookupByEmailAsync(string? email)
    {
        var p = new UsersLookupByEmailParameter();
        p.Email = email;
        return await this.SendAsync<UsersLookupByEmailParameter, UsersLookupByEmailResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.lookupByEmail
    /// </summary>
    public async ValueTask<UsersLookupByEmailResponse> UsersLookupByEmailAsync(string? email, CancellationToken cancellationToken)
    {
        var p = new UsersLookupByEmailParameter();
        p.Email = email;
        return await this.SendAsync<UsersLookupByEmailParameter, UsersLookupByEmailResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.lookupByEmail
    /// </summary>
    public async ValueTask<UsersLookupByEmailResponse> UsersLookupByEmailAsync(UsersLookupByEmailParameter parameter)
    {
        return await this.SendAsync<UsersLookupByEmailParameter, UsersLookupByEmailResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/users.lookupByEmail
    /// </summary>
    public async ValueTask<UsersLookupByEmailResponse> UsersLookupByEmailAsync(UsersLookupByEmailParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UsersLookupByEmailParameter, UsersLookupByEmailResponse>(parameter, cancellationToken);
    }
}
