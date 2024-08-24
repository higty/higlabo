using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryroleTemplateGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class DirectoryroleTemplateGetResponse : RestApiResponse
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
        public async ValueTask<DirectoryroleTemplateGetResponse> DirectoryroleTemplateGetAsync()
        {
            var p = new DirectoryroleTemplateGetParameter();
            return await this.SendAsync<DirectoryroleTemplateGetParameter, DirectoryroleTemplateGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryroleTemplateGetResponse> DirectoryroleTemplateGetAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroleTemplateGetParameter();
            return await this.SendAsync<DirectoryroleTemplateGetParameter, DirectoryroleTemplateGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryroleTemplateGetResponse> DirectoryroleTemplateGetAsync(DirectoryroleTemplateGetParameter parameter)
        {
            return await this.SendAsync<DirectoryroleTemplateGetParameter, DirectoryroleTemplateGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryroletemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryroleTemplateGetResponse> DirectoryroleTemplateGetAsync(DirectoryroleTemplateGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroleTemplateGetParameter, DirectoryroleTemplateGetResponse>(parameter, cancellationToken);
        }
    }
}
