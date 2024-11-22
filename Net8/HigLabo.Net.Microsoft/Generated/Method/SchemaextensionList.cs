using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
/// </summary>
public partial class SchemaExtensionListParameter : IRestApiParameter, IQueryParameterProperty
{
    public class ApiPathSettings
    {
        public ApiPath ApiPath { get; set; }

        public string GetApiPath()
        {
            switch (this.ApiPath)
            {
                case ApiPath.SchemaExtensions: return $"/schemaExtensions";
                default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
            }
        }
    }

    public enum Field
    {
    }
    public enum ApiPath
    {
        SchemaExtensions,
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
public partial class SchemaExtensionListResponse : RestApiResponse<SchemaExtension>
{
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchemaExtensionListResponse> SchemaExtensionListAsync()
    {
        var p = new SchemaExtensionListParameter();
        return await this.SendAsync<SchemaExtensionListParameter, SchemaExtensionListResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchemaExtensionListResponse> SchemaExtensionListAsync(CancellationToken cancellationToken)
    {
        var p = new SchemaExtensionListParameter();
        return await this.SendAsync<SchemaExtensionListParameter, SchemaExtensionListResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchemaExtensionListResponse> SchemaExtensionListAsync(SchemaExtensionListParameter parameter)
    {
        return await this.SendAsync<SchemaExtensionListParameter, SchemaExtensionListResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchemaExtensionListResponse> SchemaExtensionListAsync(SchemaExtensionListParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SchemaExtensionListParameter, SchemaExtensionListResponse>(parameter, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
    /// </summary>
    public async IAsyncEnumerable<SchemaExtension> SchemaExtensionListEnumerateAsync(SchemaExtensionListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var res = await this.SendAsync<SchemaExtensionListParameter, SchemaExtensionListResponse>(parameter, cancellationToken);
        if (res.Value != null)
        {
            foreach (var item in res.Value)
            {
                yield return item;
            }
            if (res.ODataNextLink.HasValue())
            {
                await foreach (var item in this.GetValueListAsync<SchemaExtension>(res.ODataNextLink, cancellationToken))
                {
                    yield return item;
                }
            }
        }
    }
}
