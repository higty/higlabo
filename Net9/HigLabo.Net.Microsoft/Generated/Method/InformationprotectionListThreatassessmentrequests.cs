using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
/// </summary>
public partial class InformationProtectionListThreatassessmentRequestsParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.InformationProtection_ThreatAssessmentRequests: return $"/informationProtection/threatAssessmentRequests";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        InformationProtection_ThreatAssessmentRequests,
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
public partial class InformationProtectionListThreatassessmentRequestsResponse : RestApiResponse<ThreatAssessmentRequest>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InformationProtectionListThreatassessmentRequestsResponse> InformationProtectionListThreatassessmentRequestsAsync()
    {
        var p = new InformationProtectionListThreatassessmentRequestsParameter();
        return await this.SendAsync<InformationProtectionListThreatassessmentRequestsParameter, InformationProtectionListThreatassessmentRequestsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InformationProtectionListThreatassessmentRequestsResponse> InformationProtectionListThreatassessmentRequestsAsync(CancellationToken cancellationToken)
    {
        var p = new InformationProtectionListThreatassessmentRequestsParameter();
        return await this.SendAsync<InformationProtectionListThreatassessmentRequestsParameter, InformationProtectionListThreatassessmentRequestsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InformationProtectionListThreatassessmentRequestsResponse> InformationProtectionListThreatassessmentRequestsAsync(InformationProtectionListThreatassessmentRequestsParameter parameter)
    {
        return await this.SendAsync<InformationProtectionListThreatassessmentRequestsParameter, InformationProtectionListThreatassessmentRequestsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InformationProtectionListThreatassessmentRequestsResponse> InformationProtectionListThreatassessmentRequestsAsync(InformationProtectionListThreatassessmentRequestsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<InformationProtectionListThreatassessmentRequestsParameter, InformationProtectionListThreatassessmentRequestsResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/informationprotection-list-threatassessmentrequests?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ThreatAssessmentRequest> InformationProtectionListThreatassessmentRequestsEnumerateAsync(InformationProtectionListThreatassessmentRequestsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<InformationProtectionListThreatassessmentRequestsParameter, InformationProtectionListThreatassessmentRequestsResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ThreatAssessmentRequest>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
