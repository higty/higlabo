using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
/// </summary>
public partial class UserTranslateExChangeidsParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? IdOrUserPrincipalName { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_TranslateExchangeIds: return $"/me/translateExchangeIds";
                case ApiPath.Users_IdOruserPrincipalName_TranslateExchangeIds: return $"/users/{IdOrUserPrincipalName}/translateExchangeIds";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        Me_TranslateExchangeIds,
        Users_IdOruserPrincipalName_TranslateExchangeIds,
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
    public String[]? InputIds { get; set; }
    public string? SourceIdType { get; set; }
    public string? TargetIdType { get; set; }
}
public partial class UserTranslateExChangeidsResponse : RestApiResponse<ConvertIdResult>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserTranslateExChangeidsResponse> UserTranslateExChangeidsAsync()
    {
        var p = new UserTranslateExChangeidsParameter();
        return await this.SendAsync<UserTranslateExChangeidsParameter, UserTranslateExChangeidsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserTranslateExChangeidsResponse> UserTranslateExChangeidsAsync(CancellationToken cancellationToken)
    {
        var p = new UserTranslateExChangeidsParameter();
        return await this.SendAsync<UserTranslateExChangeidsParameter, UserTranslateExChangeidsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserTranslateExChangeidsResponse> UserTranslateExChangeidsAsync(UserTranslateExChangeidsParameter parameter)
    {
        return await this.SendAsync<UserTranslateExChangeidsParameter, UserTranslateExChangeidsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-translateexchangeids?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<UserTranslateExChangeidsResponse> UserTranslateExChangeidsAsync(UserTranslateExChangeidsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<UserTranslateExChangeidsParameter, UserTranslateExChangeidsResponse>(parameter, cancellationToken);
    }
}
