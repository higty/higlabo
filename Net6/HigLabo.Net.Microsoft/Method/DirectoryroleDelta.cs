using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryroleDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DirectoryRoles_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DirectoryRoles_Delta: return $"/directoryRoles/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class DirectoryroleDeltaResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/directoryrole?view=graph-rest-1.0
        /// </summary>
        public partial class DirectoryRole
        {
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public string? RoleTemplateId { get; set; }
        }

        public DirectoryRole[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeltaResponse> DirectoryroleDeltaAsync()
        {
            var p = new DirectoryroleDeltaParameter();
            return await this.SendAsync<DirectoryroleDeltaParameter, DirectoryroleDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeltaResponse> DirectoryroleDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroleDeltaParameter();
            return await this.SendAsync<DirectoryroleDeltaParameter, DirectoryroleDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeltaResponse> DirectoryroleDeltaAsync(DirectoryroleDeltaParameter parameter)
        {
            return await this.SendAsync<DirectoryroleDeltaParameter, DirectoryroleDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/directoryrole-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<DirectoryroleDeltaResponse> DirectoryroleDeltaAsync(DirectoryroleDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroleDeltaParameter, DirectoryroleDeltaResponse>(parameter, cancellationToken);
        }
    }
}
