using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/agreement-list-acceptances?view=graph-rest-1.0
/// </summary>
public partial class AgreementListAcceptancesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AgreementsId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.IdentityGovernance_TermsOfUse_Agreements_AgreementsId_Acceptances: return $"/identityGovernance/termsOfUse/agreements/{AgreementsId}/acceptances";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        IdentityGovernance_TermsOfUse_Agreements_AgreementsId_Acceptances,
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
public partial class AgreementListAcceptancesResponse : RestApiResponse<AgreementAcceptance>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/agreement-list-acceptances?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-list-acceptances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementListAcceptancesResponse> AgreementListAcceptancesAsync()
    {
        var p = new AgreementListAcceptancesParameter();
        return await this.SendAsync<AgreementListAcceptancesParameter, AgreementListAcceptancesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-list-acceptances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementListAcceptancesResponse> AgreementListAcceptancesAsync(CancellationToken cancellationToken)
    {
        var p = new AgreementListAcceptancesParameter();
        return await this.SendAsync<AgreementListAcceptancesParameter, AgreementListAcceptancesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-list-acceptances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementListAcceptancesResponse> AgreementListAcceptancesAsync(AgreementListAcceptancesParameter parameter)
    {
        return await this.SendAsync<AgreementListAcceptancesParameter, AgreementListAcceptancesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-list-acceptances?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementListAcceptancesResponse> AgreementListAcceptancesAsync(AgreementListAcceptancesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AgreementListAcceptancesParameter, AgreementListAcceptancesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-list-acceptances?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AgreementAcceptance> AgreementListAcceptancesEnumerateAsync(AgreementListAcceptancesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AgreementListAcceptancesParameter, AgreementListAcceptancesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AgreementAcceptance>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
