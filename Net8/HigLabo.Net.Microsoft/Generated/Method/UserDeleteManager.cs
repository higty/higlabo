using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-delete-manager?view=graph-rest-1.0
/// </summary>
public partial class UserDeleteManagerParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Users_Id_Manager_ref: return $"/users/{Id}/manager/$ref";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Users_Id_Manager_ref,
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
public partial class UserDeleteManagerResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-delete-manager?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-delete-manager?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserDeleteManagerResponse> UserDeleteManagerAsync()
    {
        var p = new UserDeleteManagerParameter();
        return await this.SendAsync<UserDeleteManagerParameter, UserDeleteManagerResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-delete-manager?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserDeleteManagerResponse> UserDeleteManagerAsync(CancellationToken cancellationToken)
    {
        var p = new UserDeleteManagerParameter();
        return await this.SendAsync<UserDeleteManagerParameter, UserDeleteManagerResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-delete-manager?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserDeleteManagerResponse> UserDeleteManagerAsync(UserDeleteManagerParameter parameter)
    {
        return await this.SendAsync<UserDeleteManagerParameter, UserDeleteManagerResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-delete-manager?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserDeleteManagerResponse> UserDeleteManagerAsync(UserDeleteManagerParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserDeleteManagerParameter, UserDeleteManagerResponse>(parameter, cancellationToken);
    }
}
