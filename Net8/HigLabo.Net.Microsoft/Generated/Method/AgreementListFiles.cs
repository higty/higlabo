using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/agreement-list-files?view=graph-rest-1.0
/// </summary>
public partial class AgreementListFilesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? AgreementsId { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Agreements_AgreementsId: return $"/agreements/{AgreementsId}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Agreements_AgreementsId,
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
public partial class AgreementListFilesResponse : RestApiResponse<AgreementFileLocalization>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/agreement-list-files?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-list-files?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementListFilesResponse> AgreementListFilesAsync()
    {
        var p = new AgreementListFilesParameter();
        return await this.SendAsync<AgreementListFilesParameter, AgreementListFilesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-list-files?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementListFilesResponse> AgreementListFilesAsync(CancellationToken cancellationToken)
    {
        var p = new AgreementListFilesParameter();
        return await this.SendAsync<AgreementListFilesParameter, AgreementListFilesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-list-files?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementListFilesResponse> AgreementListFilesAsync(AgreementListFilesParameter parameter)
    {
        return await this.SendAsync<AgreementListFilesParameter, AgreementListFilesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-list-files?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<AgreementListFilesResponse> AgreementListFilesAsync(AgreementListFilesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AgreementListFilesParameter, AgreementListFilesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/agreement-list-files?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<AgreementFileLocalization> AgreementListFilesEnumerateAsync(AgreementListFilesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<AgreementListFilesParameter, AgreementListFilesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<AgreementFileLocalization>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
