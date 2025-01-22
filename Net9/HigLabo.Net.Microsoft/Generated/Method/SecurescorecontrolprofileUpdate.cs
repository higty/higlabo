using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-update?view=graph-rest-1.0
/// </summary>
public partial class SecureScorecontrolprofileUpdateParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "PATCH";
    public string? AssignedTo { get; set; }
    public string? Comment { get; set; }
    public string? State { get; set; }
    public SecurityVendorInformation? VendorInformation { get; set; }
}
public partial class SecureScorecontrolprofileUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecureScorecontrolprofileUpdateResponse> SecureScorecontrolprofileUpdateAsync()
    {
        var p = new SecureScorecontrolprofileUpdateParameter();
        return await this.SendAsync<SecureScorecontrolprofileUpdateParameter, SecureScorecontrolprofileUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecureScorecontrolprofileUpdateResponse> SecureScorecontrolprofileUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new SecureScorecontrolprofileUpdateParameter();
        return await this.SendAsync<SecureScorecontrolprofileUpdateParameter, SecureScorecontrolprofileUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecureScorecontrolprofileUpdateResponse> SecureScorecontrolprofileUpdateAsync(SecureScorecontrolprofileUpdateParameter parameter)
    {
        return await this.SendAsync<SecureScorecontrolprofileUpdateParameter, SecureScorecontrolprofileUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/securescorecontrolprofile-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SecureScorecontrolprofileUpdateResponse> SecureScorecontrolprofileUpdateAsync(SecureScorecontrolprofileUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SecureScorecontrolprofileUpdateParameter, SecureScorecontrolprofileUpdateResponse>(parameter, cancellationToken);
    }
}
