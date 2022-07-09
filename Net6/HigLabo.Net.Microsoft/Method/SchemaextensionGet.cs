using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SchemaextensionGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class SchemaextensionGetResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? Id { get; set; }
        public string? Owner { get; set; }
        public ExtensionSchemaProperty[]? Properties { get; set; }
        public string? Status { get; set; }
        public String[]? TargetTypes { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionGetResponse> SchemaextensionGetAsync()
        {
            var p = new SchemaextensionGetParameter();
            return await this.SendAsync<SchemaextensionGetParameter, SchemaextensionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionGetResponse> SchemaextensionGetAsync(CancellationToken cancellationToken)
        {
            var p = new SchemaextensionGetParameter();
            return await this.SendAsync<SchemaextensionGetParameter, SchemaextensionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionGetResponse> SchemaextensionGetAsync(SchemaextensionGetParameter parameter)
        {
            return await this.SendAsync<SchemaextensionGetParameter, SchemaextensionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-get?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionGetResponse> SchemaextensionGetAsync(SchemaextensionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchemaextensionGetParameter, SchemaextensionGetResponse>(parameter, cancellationToken);
        }
    }
}
