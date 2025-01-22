using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-changepassword?view=graph-rest-1.0
/// </summary>
public partial class UserChangepasswordParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_ChangePassword: return $"/me/changePassword";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_ChangePassword,
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
    public string? CurrentPassword { get; set; }
    public string? NewPassword { get; set; }
}
public partial class UserChangepasswordResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-changepassword?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-changepassword?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserChangepasswordResponse> UserChangepasswordAsync()
    {
        var p = new UserChangepasswordParameter();
        return await this.SendAsync<UserChangepasswordParameter, UserChangepasswordResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-changepassword?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserChangepasswordResponse> UserChangepasswordAsync(CancellationToken cancellationToken)
    {
        var p = new UserChangepasswordParameter();
        return await this.SendAsync<UserChangepasswordParameter, UserChangepasswordResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-changepassword?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserChangepasswordResponse> UserChangepasswordAsync(UserChangepasswordParameter parameter)
    {
        return await this.SendAsync<UserChangepasswordParameter, UserChangepasswordResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-changepassword?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserChangepasswordResponse> UserChangepasswordAsync(UserChangepasswordParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserChangepasswordParameter, UserChangepasswordResponse>(parameter, cancellationToken);
    }
}
