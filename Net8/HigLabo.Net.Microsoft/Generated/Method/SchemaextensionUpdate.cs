using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-update?view=graph-rest-1.0
    /// </summary>
    public partial class SchemaExtensionUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? Description { get; set; }
        public ExtensionSchemaProperty[]? Properties { get; set; }
        public string? Status { get; set; }
        public String[]? TargetTypes { get; set; }
    }
    public partial class SchemaExtensionUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionUpdateResponse> SchemaExtensionUpdateAsync()
        {
            var p = new SchemaExtensionUpdateParameter();
            return await this.SendAsync<SchemaExtensionUpdateParameter, SchemaExtensionUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionUpdateResponse> SchemaExtensionUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new SchemaExtensionUpdateParameter();
            return await this.SendAsync<SchemaExtensionUpdateParameter, SchemaExtensionUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionUpdateResponse> SchemaExtensionUpdateAsync(SchemaExtensionUpdateParameter parameter)
        {
            return await this.SendAsync<SchemaExtensionUpdateParameter, SchemaExtensionUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionUpdateResponse> SchemaExtensionUpdateAsync(SchemaExtensionUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchemaExtensionUpdateParameter, SchemaExtensionUpdateResponse>(parameter, cancellationToken);
        }
    }
}
