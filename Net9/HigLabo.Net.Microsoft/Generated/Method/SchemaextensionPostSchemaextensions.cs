using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schemaextension-post-schemaextensions?view=graph-rest-1.0
/// </summary>
public partial class SchemaExtensionPostSchemaExtensionsParameter : IRestApiParameter
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
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Description { get; set; }
    public string? Id { get; set; }
    public string? Owner { get; set; }
    public ExtensionSchemaProperty[]? Properties { get; set; }
    public String[]? TargetTypes { get; set; }
    public string? Status { get; set; }
}
public partial class SchemaExtensionPostSchemaExtensionsResponse : RestApiResponse
{
    public string? Description { get; set; }
    public string? Id { get; set; }
    public string? Owner { get; set; }
    public ExtensionSchemaProperty[]? Properties { get; set; }
    public string? Status { get; set; }
    public String[]? TargetTypes { get; set; }
}
/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/schemaextension-post-schemaextensions?view=graph-rest-1.0
/// </summary>
public partial class MicrosoftClient
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-post-schemaextensions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchemaExtensionPostSchemaExtensionsResponse> SchemaExtensionPostSchemaExtensionsAsync()
    {
        var p = new SchemaExtensionPostSchemaExtensionsParameter();
        return await this.SendAsync<SchemaExtensionPostSchemaExtensionsParameter, SchemaExtensionPostSchemaExtensionsResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-post-schemaextensions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchemaExtensionPostSchemaExtensionsResponse> SchemaExtensionPostSchemaExtensionsAsync(CancellationToken cancellationToken)
    {
        var p = new SchemaExtensionPostSchemaExtensionsParameter();
        return await this.SendAsync<SchemaExtensionPostSchemaExtensionsParameter, SchemaExtensionPostSchemaExtensionsResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-post-schemaextensions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchemaExtensionPostSchemaExtensionsResponse> SchemaExtensionPostSchemaExtensionsAsync(SchemaExtensionPostSchemaExtensionsParameter parameter)
    {
        return await this.SendAsync<SchemaExtensionPostSchemaExtensionsParameter, SchemaExtensionPostSchemaExtensionsResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-post-schemaextensions?view=graph-rest-1.0
    /// </summary>
    public async ValueTask<SchemaExtensionPostSchemaExtensionsResponse> SchemaExtensionPostSchemaExtensionsAsync(SchemaExtensionPostSchemaExtensionsParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<SchemaExtensionPostSchemaExtensionsParameter, SchemaExtensionPostSchemaExtensionsResponse>(parameter, cancellationToken);
    }
}
