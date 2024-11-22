using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-get?view=graph-rest-1.0
/// </summary>
public partial class SecureScorecontrolprofileGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Security_SecureScoreControlProfiles_Id: return $"/security/secureScoreControlProfiles/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Security_SecureScoreControlProfiles_Id,
    }

    public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
    string IRestApiParameter.ApiPath
    {
        get
        {
            return this.ApiPathSetting.GetApiPath();
        }
    }
    string IRestApiParameter.HttpMethod { get; } = "GET";
    public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
    IQueryParameter IQueryParameterProperty.Query
    {
        get
        {
            return this.Query;
        }
    }
}
public partial class SecureScorecontrolprofileGetResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecureScorecontrolprofileGetResponse> SecureScorecontrolprofileGetAsync()
    {
        var p = new SecureScorecontrolprofileGetParameter();
        return await this.SendAsync<SecureScorecontrolprofileGetParameter, SecureScorecontrolprofileGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecureScorecontrolprofileGetResponse> SecureScorecontrolprofileGetAsync(CancellationToken cancellationToken)
    {
        var p = new SecureScorecontrolprofileGetParameter();
        return await this.SendAsync<SecureScorecontrolprofileGetParameter, SecureScorecontrolprofileGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecureScorecontrolprofileGetResponse> SecureScorecontrolprofileGetAsync(SecureScorecontrolprofileGetParameter parameter)
    {
        return await this.SendAsync<SecureScorecontrolprofileGetParameter, SecureScorecontrolprofileGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecureScorecontrolprofileGetResponse> SecureScorecontrolprofileGetAsync(SecureScorecontrolprofileGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecureScorecontrolprofileGetParameter, SecureScorecontrolprofileGetResponse>(parameter, cancellationToken);
    }
}
