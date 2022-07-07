using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ExternalconnectorsConnectionoperationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            External_Connections_ConnectionsId_Operations_ConnectionOperationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.External_Connections_ConnectionsId_Operations_ConnectionOperationId: return $"/external/connections/{ConnectionsId}/operations/{ConnectionOperationId}";
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
        public string ConnectionOperationId { get; set; }
    }
    public partial class ExternalconnectorsConnectionoperationGetResponse : RestApiResponse
    {
        public enum ConnectionOperationExternalConnectorsConnectionOperationStatus
        {
            Unspecified,
            Inprogress,
            Completed,
            Failed,
            UnknownFutureValue,
        }

        public PublicError? Error { get; set; }
        public string? Id { get; set; }
        public ConnectionOperationExternalConnectorsConnectionOperationStatus Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-connectionoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsConnectionoperationGetResponse> ExternalconnectorsConnectionoperationGetAsync()
        {
            var p = new ExternalconnectorsConnectionoperationGetParameter();
            return await this.SendAsync<ExternalconnectorsConnectionoperationGetParameter, ExternalconnectorsConnectionoperationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-connectionoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsConnectionoperationGetResponse> ExternalconnectorsConnectionoperationGetAsync(CancellationToken cancellationToken)
        {
            var p = new ExternalconnectorsConnectionoperationGetParameter();
            return await this.SendAsync<ExternalconnectorsConnectionoperationGetParameter, ExternalconnectorsConnectionoperationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-connectionoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsConnectionoperationGetResponse> ExternalconnectorsConnectionoperationGetAsync(ExternalconnectorsConnectionoperationGetParameter parameter)
        {
            return await this.SendAsync<ExternalconnectorsConnectionoperationGetParameter, ExternalconnectorsConnectionoperationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/externalconnectors-connectionoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ExternalconnectorsConnectionoperationGetResponse> ExternalconnectorsConnectionoperationGetAsync(ExternalconnectorsConnectionoperationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ExternalconnectorsConnectionoperationGetParameter, ExternalconnectorsConnectionoperationGetResponse>(parameter, cancellationToken);
        }
    }
}
