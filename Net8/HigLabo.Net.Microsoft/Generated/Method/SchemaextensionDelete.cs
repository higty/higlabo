using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-delete?view=graph-rest-1.0
    /// </summary>
    public partial class SchemaExtensionDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class SchemaExtensionDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/schemaextension-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionDeleteResponse> SchemaExtensionDeleteAsync()
        {
            var p = new SchemaExtensionDeleteParameter();
            return await this.SendAsync<SchemaExtensionDeleteParameter, SchemaExtensionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionDeleteResponse> SchemaExtensionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new SchemaExtensionDeleteParameter();
            return await this.SendAsync<SchemaExtensionDeleteParameter, SchemaExtensionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionDeleteResponse> SchemaExtensionDeleteAsync(SchemaExtensionDeleteParameter parameter)
        {
            return await this.SendAsync<SchemaExtensionDeleteParameter, SchemaExtensionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/schemaextension-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SchemaExtensionDeleteResponse> SchemaExtensionDeleteAsync(SchemaExtensionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchemaExtensionDeleteParameter, SchemaExtensionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
