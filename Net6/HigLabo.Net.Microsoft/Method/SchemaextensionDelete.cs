using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class SchemaextensionDeleteParameter : IRestApiParameter
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
    public partial class SchemaextensionDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionDeleteResponse> SchemaextensionDeleteAsync()
        {
            var p = new SchemaextensionDeleteParameter();
            return await this.SendAsync<SchemaextensionDeleteParameter, SchemaextensionDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionDeleteResponse> SchemaextensionDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new SchemaextensionDeleteParameter();
            return await this.SendAsync<SchemaextensionDeleteParameter, SchemaextensionDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionDeleteResponse> SchemaextensionDeleteAsync(SchemaextensionDeleteParameter parameter)
        {
            return await this.SendAsync<SchemaextensionDeleteParameter, SchemaextensionDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/schemaextension-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<SchemaextensionDeleteResponse> SchemaextensionDeleteAsync(SchemaextensionDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SchemaextensionDeleteParameter, SchemaextensionDeleteResponse>(parameter, cancellationToken);
        }
    }
}
