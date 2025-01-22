using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-list-overrides?view=graph-rest-1.0
/// </summary>
public partial class InferenceClassificationListOverridesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }
        public string? Id { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Me_InferenceClassification_Overrides: return $"/me/inferenceClassification/overrides";
                case ApiPath.Users_Id_InferenceClassification_Overrides: return $"/users/{Id}/inferenceClassification/overrides";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Me_InferenceClassification_Overrides,
        Users_Id_InferenceClassification_Overrides,
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
public partial class InferenceClassificationListOverridesResponse : RestApiResponse<InferenceClassificationOverride>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-list-overrides?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-list-overrides?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationListOverridesResponse> InferenceClassificationListOverridesAsync()
    {
        var p = new InferenceClassificationListOverridesParameter();
        return await this.SendAsync<InferenceClassificationListOverridesParameter, InferenceClassificationListOverridesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-list-overrides?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationListOverridesResponse> InferenceClassificationListOverridesAsync(CancellationToken cancellationToken)
    {
        var p = new InferenceClassificationListOverridesParameter();
        return await this.SendAsync<InferenceClassificationListOverridesParameter, InferenceClassificationListOverridesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-list-overrides?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationListOverridesResponse> InferenceClassificationListOverridesAsync(InferenceClassificationListOverridesParameter parameter)
    {
        return await this.SendAsync<InferenceClassificationListOverridesParameter, InferenceClassificationListOverridesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-list-overrides?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<InferenceClassificationListOverridesResponse> InferenceClassificationListOverridesAsync(InferenceClassificationListOverridesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<InferenceClassificationListOverridesParameter, InferenceClassificationListOverridesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/inferenceclassification-list-overrides?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<InferenceClassificationOverride> InferenceClassificationListOverridesEnumerateAsync(InferenceClassificationListOverridesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<InferenceClassificationListOverridesParameter, InferenceClassificationListOverridesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<InferenceClassificationOverride>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
