using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryroletemplateGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryRoleTemplates_Id: return $"/directoryRoleTemplates/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            DirectoryRoleTemplates_Id,
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
    public partial class DirectoryroletemplateGetResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryroletemplateGetResponse> DirectoryroletemplateGetAsync()
        {
            var p = new DirectoryroletemplateGetParameter();
            return await this.SendAsync<DirectoryroletemplateGetParameter, DirectoryroletemplateGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryroletemplateGetResponse> DirectoryroletemplateGetAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroletemplateGetParameter();
            return await this.SendAsync<DirectoryroletemplateGetParameter, DirectoryroletemplateGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryroletemplateGetResponse> DirectoryroletemplateGetAsync(DirectoryroletemplateGetParameter parameter)
        {
            return await this.SendAsync<DirectoryroletemplateGetParameter, DirectoryroletemplateGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryroletemplateGetResponse> DirectoryroletemplateGetAsync(DirectoryroletemplateGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroletemplateGetParameter, DirectoryroletemplateGetResponse>(parameter, cancellationToken);
        }
    }
}
