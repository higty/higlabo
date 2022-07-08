using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SchemaextensionUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

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
    public partial class SchemaextensionUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionUpdateResponse> SchemaextensionUpdateAsync()
        {
            var p = new SchemaextensionUpdateParameter();
            return await this.SendAsync<SchemaextensionUpdateParameter, SchemaextensionUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionUpdateResponse> SchemaextensionUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new SchemaextensionUpdateParameter();
            return await this.SendAsync<SchemaextensionUpdateParameter, SchemaextensionUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionUpdateResponse> SchemaextensionUpdateAsync(SchemaextensionUpdateParameter parameter)
        {
            return await this.SendAsync<SchemaextensionUpdateParameter, SchemaextensionUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionUpdateResponse> SchemaextensionUpdateAsync(SchemaextensionUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchemaextensionUpdateParameter, SchemaextensionUpdateResponse>(parameter, cancellationToken);
        }
    }
}
