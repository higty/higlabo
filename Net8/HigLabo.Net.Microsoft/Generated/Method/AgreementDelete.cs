using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/agreement-delete?view=graph-rest-1.0
/// </summary>
public partial class AgreementDeleteParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "DELETE";
}
public partial class AgreementDeleteResponse : RestApiResponse
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/agreement-delete?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementDeleteResponse> AgreementDeleteAsync()
    {
        var p = new AgreementDeleteParameter();
        return await this.SendAsync<AgreementDeleteParameter, AgreementDeleteResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementDeleteResponse> AgreementDeleteAsync(CancellationToken cancellationToken)
    {
        var p = new AgreementDeleteParameter();
        return await this.SendAsync<AgreementDeleteParameter, AgreementDeleteResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementDeleteResponse> AgreementDeleteAsync(AgreementDeleteParameter parameter)
    {
        return await this.SendAsync<AgreementDeleteParameter, AgreementDeleteResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-delete?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementDeleteResponse> AgreementDeleteAsync(AgreementDeleteParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AgreementDeleteParameter, AgreementDeleteResponse>(parameter, cancellationToken);
    }
}
