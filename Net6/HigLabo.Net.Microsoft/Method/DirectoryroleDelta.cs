using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DirectoryroleDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryRoles_Delta: return $"/directoryRoles/delta";
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
            DirectoryRoles_Delta,
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
    public partial class DirectoryroleDeltaResponse : RestApiResponse
    {
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
