using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SchemaextensionListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            SchemaExtensions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.SchemaExtensions: return $"/schemaExtensions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class SchemaextensionListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/schemaextension?view=graph-rest-1.0
        /// </summary>
        public partial class SchemaExtension
        {
            public string? Description { get; set; }
            public string? Id { get; set; }
            public string? Owner { get; set; }
            public ExtensionSchemaProperty[]? Properties { get; set; }
            public string? Status { get; set; }
            public String[]? TargetTypes { get; set; }
        }

        public SchemaExtension[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionListResponse> SchemaextensionListAsync()
        {
            var p = new SchemaextensionListParameter();
            return await this.SendAsync<SchemaextensionListParameter, SchemaextensionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionListResponse> SchemaextensionListAsync(CancellationToken cancellationToken)
        {
            var p = new SchemaextensionListParameter();
            return await this.SendAsync<SchemaextensionListParameter, SchemaextensionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionListResponse> SchemaextensionListAsync(SchemaextensionListParameter parameter)
        {
            return await this.SendAsync<SchemaextensionListParameter, SchemaextensionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionListResponse> SchemaextensionListAsync(SchemaextensionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchemaextensionListParameter, SchemaextensionListResponse>(parameter, cancellationToken);
        }
    }
}
