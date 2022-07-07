using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsExternalgroupGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Groups_ExternalGroupId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_ConnectionsId_Groups_ExternalGroupId: return $"/external/connections/{ConnectionsId}/groups/{ExternalGroupId}";
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
        public string ConnectionsId { get; set; }
        public string ExternalGroupId { get; set; }
    }
    public partial class ExternalconnectorsExternalgroupGetResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupGetResponse> ExternalconnectorsExternalgroupGetAsync()
        {
            var p = new ExternalconnectorsExternalgroupGetParameter();
            return await this.SendAsync<ExternalconnectorsExternalgroupGetParameter, ExternalconnectorsExternalgroupGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupGetResponse> ExternalconnectorsExternalgroupGetAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsExternalgroupGetParameter();
            return await this.SendAsync<ExternalconnectorsExternalgroupGetParameter, ExternalconnectorsExternalgroupGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupGetResponse> ExternalconnectorsExternalgroupGetAsync(ExternalconnectorsExternalgroupGetParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsExternalgroupGetParameter, ExternalconnectorsExternalgroupGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-externalgroup-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsExternalgroupGetResponse> ExternalconnectorsExternalgroupGetAsync(ExternalconnectorsExternalgroupGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsExternalgroupGetParameter, ExternalconnectorsExternalgroupGetResponse>(parameter, cancellationToken);
        }
    }
}
