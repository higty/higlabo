using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/agreement-update?view=graph-rest-1.0
/// </summary>
public partial class AgreementUpdateParameter : IRestApiParameter
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_TermsOfUse_Agreements_Id: return $"/identityGovernance/termsOfUse/agreements/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum ApiPath
    {
        IdentityGovernance_TermsOfUse_Agreements_Id,
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
    public string? DisplayName { get; set; }
    public bool? IsViewingBeforeAcceptanceRequired { get; set; }
}
public partial class AgreementUpdateResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/agreement-update?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementUpdateResponse> AgreementUpdateAsync()
    {
        var p = new AgreementUpdateParameter();
        return await this.SendAsync<AgreementUpdateParameter, AgreementUpdateResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementUpdateResponse> AgreementUpdateAsync(CancellationToken cancellationToken)
    {
        var p = new AgreementUpdateParameter();
        return await this.SendAsync<AgreementUpdateParameter, AgreementUpdateResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementUpdateResponse> AgreementUpdateAsync(AgreementUpdateParameter parameter)
    {
        return await this.SendAsync<AgreementUpdateParameter, AgreementUpdateResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-update?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementUpdateResponse> AgreementUpdateAsync(AgreementUpdateParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AgreementUpdateParameter, AgreementUpdateResponse>(parameter, cancellationToken);
    }
}
