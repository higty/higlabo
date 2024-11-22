using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/subscribedsku-get?view=graph-rest-1.0
/// </summary>
public partial class SubscribedskuGetParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.SubscribedSkus_Id: return $"/subscribedSkus/{Id}";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        SubscribedSkus_Id,
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
public partial class SubscribedskuGetResponse : RestApiResponse
{
    public string? AppliesTo { get; set; }
    public string? CapabilityStatus { get; set; }
    public Int32? ConsumedUnits { get; set; }
    public string? Id { get; set; }
    public LicenseUnitsDetail? PrepaidUnits { get; set; }
    public ServicePlanInfo[]? ServicePlans { get; set; }
    public Guid? SkuId { get; set; }
    public string? SkuPartNumber { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/subscribedsku-get?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscribedsku-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubscribedskuGetResponse> SubscribedskuGetAsync()
    {
        var p = new SubscribedskuGetParameter();
        return await this.SendAsync<SubscribedskuGetParameter, SubscribedskuGetResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscribedsku-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubscribedskuGetResponse> SubscribedskuGetAsync(CancellationToken cancellationToken)
    {
        var p = new SubscribedskuGetParameter();
        return await this.SendAsync<SubscribedskuGetParameter, SubscribedskuGetResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscribedsku-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubscribedskuGetResponse> SubscribedskuGetAsync(SubscribedskuGetParameter parameter)
    {
        return await this.SendAsync<SubscribedskuGetParameter, SubscribedskuGetResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/subscribedsku-get?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SubscribedskuGetResponse> SubscribedskuGetAsync(SubscribedskuGetParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SubscribedskuGetParameter, SubscribedskuGetResponse>(parameter, cancellationToken);
    }
}
