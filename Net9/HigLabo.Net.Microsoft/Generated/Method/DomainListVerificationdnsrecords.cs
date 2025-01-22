using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/domain-list-verificationdnsrecords?view=graph-rest-1.0
/// </summary>
public partial class DomainListVerificationdnsrecordsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Domains_Id_VerificationDnsRecords: return $"/domains/{Id}/verificationDnsRecords";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Domains_Id_VerificationDnsRecords,
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
public partial class DomainListVerificationdnsrecordsResponse : RestApiResponse<DomainDnsRecord>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/domain-list-verificationdnsrecords?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-list-verificationdnsrecords?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DomainListVerificationdnsrecordsResponse> DomainListVerificationdnsrecordsAsync()
    {
        var p = new DomainListVerificationdnsrecordsParameter();
        return await this.SendAsync<DomainListVerificationdnsrecordsParameter, DomainListVerificationdnsrecordsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-list-verificationdnsrecords?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DomainListVerificationdnsrecordsResponse> DomainListVerificationdnsrecordsAsync(CancellationToken cancellationToken)
    {
        var p = new DomainListVerificationdnsrecordsParameter();
        return await this.SendAsync<DomainListVerificationdnsrecordsParameter, DomainListVerificationdnsrecordsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-list-verificationdnsrecords?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DomainListVerificationdnsrecordsResponse> DomainListVerificationdnsrecordsAsync(DomainListVerificationdnsrecordsParameter parameter)
    {
        return await this.SendAsync<DomainListVerificationdnsrecordsParameter, DomainListVerificationdnsrecordsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-list-verificationdnsrecords?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<DomainListVerificationdnsrecordsResponse> DomainListVerificationdnsrecordsAsync(DomainListVerificationdnsrecordsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<DomainListVerificationdnsrecordsParameter, DomainListVerificationdnsrecordsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-list-verificationdnsrecords?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<DomainDnsRecord> DomainListVerificationdnsrecordsEnumerateAsync(DomainListVerificationdnsrecordsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<DomainListVerificationdnsrecordsParameter, DomainListVerificationdnsrecordsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<DomainDnsRecord>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
