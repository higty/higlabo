using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryroleListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryRoles: return $"/directoryRoles";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Description,
            DisplayName,
            Id,
            RoleTemplateId,
            Members,
            ScopedMembers,
        }
        public enum ApiPath
        {
            DirectoryRoles,
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
    public partial class DirectoryroleListResponse : RestApiResponse
    {
        public DirectoryRole[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListResponse> DirectoryroleListAsync()
        {
            var p = new DirectoryroleListParameter();
            return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListResponse> DirectoryroleListAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroleListParameter();
            return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListResponse> DirectoryroleListAsync(DirectoryroleListParameter parameter)
        {
            return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-list?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleListResponse> DirectoryroleListAsync(DirectoryroleListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroleListParameter, DirectoryroleListResponse>(parameter, cancellationToken);
        }
    }
}
