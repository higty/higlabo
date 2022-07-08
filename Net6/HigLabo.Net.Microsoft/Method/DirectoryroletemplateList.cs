using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryroletemplateListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryRoleTemplates: return $"/directoryRoleTemplates";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Description,
            DisplayName,
            Id,
        }
        public enum ApiPath
        {
            DirectoryRoleTemplates,
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
    public partial class DirectoryroletemplateListResponse : RestApiResponse
    {
        public DirectoryRoleTemplate[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateListResponse> DirectoryroletemplateListAsync()
        {
            var p = new DirectoryroletemplateListParameter();
            return await this.SendAsync<DirectoryroletemplateListParameter, DirectoryroletemplateListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateListResponse> DirectoryroletemplateListAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroletemplateListParameter();
            return await this.SendAsync<DirectoryroletemplateListParameter, DirectoryroletemplateListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateListResponse> DirectoryroletemplateListAsync(DirectoryroletemplateListParameter parameter)
        {
            return await this.SendAsync<DirectoryroletemplateListParameter, DirectoryroletemplateListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryroletemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroletemplateListResponse> DirectoryroletemplateListAsync(DirectoryroletemplateListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroletemplateListParameter, DirectoryroletemplateListResponse>(parameter, cancellationToken);
        }
    }
}
