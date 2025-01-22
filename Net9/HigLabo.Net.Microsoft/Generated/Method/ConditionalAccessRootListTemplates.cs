using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-templates?view=graph-rest-1.0
/// </summary>
public partial class ConditionalAccessRootListTemplatesParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.Identity_ConditionalAccess_Templates: return $"/identity/conditionalAccess/templates";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        Identity_ConditionalAccess_Templates,
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
public partial class ConditionalAccessRootListTemplatesResponse : RestApiResponse<ConditionalAccessTemplate>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-templates?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-templates?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConditionalAccessRootListTemplatesResponse> ConditionalAccessRootListTemplatesAsync()
    {
        var p = new ConditionalAccessRootListTemplatesParameter();
        return await this.SendAsync<ConditionalAccessRootListTemplatesParameter, ConditionalAccessRootListTemplatesResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-templates?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConditionalAccessRootListTemplatesResponse> ConditionalAccessRootListTemplatesAsync(CancellationToken cancellationToken)
    {
        var p = new ConditionalAccessRootListTemplatesParameter();
        return await this.SendAsync<ConditionalAccessRootListTemplatesParameter, ConditionalAccessRootListTemplatesResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-templates?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConditionalAccessRootListTemplatesResponse> ConditionalAccessRootListTemplatesAsync(ConditionalAccessRootListTemplatesParameter parameter)
    {
        return await this.SendAsync<ConditionalAccessRootListTemplatesParameter, ConditionalAccessRootListTemplatesResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-templates?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<ConditionalAccessRootListTemplatesResponse> ConditionalAccessRootListTemplatesAsync(ConditionalAccessRootListTemplatesParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<ConditionalAccessRootListTemplatesParameter, ConditionalAccessRootListTemplatesResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-list-templates?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<ConditionalAccessTemplate> ConditionalAccessRootListTemplatesEnumerateAsync(ConditionalAccessRootListTemplatesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<ConditionalAccessRootListTemplatesParameter, ConditionalAccessRootListTemplatesResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<ConditionalAccessTemplate>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
