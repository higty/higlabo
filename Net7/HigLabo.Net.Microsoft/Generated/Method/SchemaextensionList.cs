using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
    /// </summary>
    public partial class SchemaextensionListParameter : IRestApiParameter, IQueryParameterProperty
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
            Description,
            Id,
            Owner,
            Properties,
            Status,
            TargetTypes,
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
    public partial class SchemaextensionListResponse : RestApiResponse
    {
        public SchemaExtension[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionListResponse> SchemaextensionListAsync()
        {
            var p = new SchemaextensionListParameter();
            return await this.SendAsync<SchemaextensionListParameter, SchemaextensionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionListResponse> SchemaextensionListAsync(CancellationToken cancellationToken)
        {
            var p = new SchemaextensionListParameter();
            return await this.SendAsync<SchemaextensionListParameter, SchemaextensionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionListResponse> SchemaextensionListAsync(SchemaextensionListParameter parameter)
        {
            return await this.SendAsync<SchemaextensionListParameter, SchemaextensionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-list?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionListResponse> SchemaextensionListAsync(SchemaextensionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchemaextensionListParameter, SchemaextensionListResponse>(parameter, cancellationToken);
        }
    }
}
