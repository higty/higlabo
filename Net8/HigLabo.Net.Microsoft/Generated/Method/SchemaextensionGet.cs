using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-get?view=graph-rest-1.0
    /// </summary>
    public partial class SchemaExtensionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.SchemaExtensions_Id: return $"/schemaExtensions/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            SchemaExtensions_Id,
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
    public partial class SchemaExtensionGetResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? Id { get; set; }
        public string? Owner { get; set; }
        public ExtensionSchemaProperty[]? Properties { get; set; }
        public string? Status { get; set; }
        public String[]? TargetTypes { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionGetResponse> SchemaExtensionGetAsync()
        {
            var p = new SchemaExtensionGetParameter();
            return await this.SendAsync<SchemaExtensionGetParameter, SchemaExtensionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionGetResponse> SchemaExtensionGetAsync(CancellationToken cancellationToken)
        {
            var p = new SchemaExtensionGetParameter();
            return await this.SendAsync<SchemaExtensionGetParameter, SchemaExtensionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionGetResponse> SchemaExtensionGetAsync(SchemaExtensionGetParameter parameter)
        {
            return await this.SendAsync<SchemaExtensionGetParameter, SchemaExtensionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionGetResponse> SchemaExtensionGetAsync(SchemaExtensionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchemaExtensionGetParameter, SchemaExtensionGetResponse>(parameter, cancellationToken);
        }
    }
}
