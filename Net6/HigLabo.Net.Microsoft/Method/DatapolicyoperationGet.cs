using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class DatapolicyoperationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DataPolicyOperations_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DataPolicyOperations_Id: return $"/dataPolicyOperations/{Id}";
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
        public string Id { get; set; }
    }
    public partial class DatapolicyoperationGetResponse : RestApiResponse
    {
        public enum DataPolicyOperationDataPolicyOperationStatus
        {
            NotStarted,
            Running,
            Complete,
            Failed,
            UnknownFutureValue,
        }

        public DateTimeOffset? CompletedDateTime { get; set; }
        public string? Id { get; set; }
        public DataPolicyOperationDataPolicyOperationStatus Status { get; set; }
        public string? StorageLocation { get; set; }
        public string? UserId { get; set; }
        public DateTimeOffset? SubmittedDateTime { get; set; }
        public string? Progress { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/datapolicyoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DatapolicyoperationGetResponse> DatapolicyoperationGetAsync()
        {
            var p = new DatapolicyoperationGetParameter();
            return await this.SendAsync<DatapolicyoperationGetParameter, DatapolicyoperationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/datapolicyoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DatapolicyoperationGetResponse> DatapolicyoperationGetAsync(CancellationToken cancellationToken)
        {
            var p = new DatapolicyoperationGetParameter();
            return await this.SendAsync<DatapolicyoperationGetParameter, DatapolicyoperationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/datapolicyoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DatapolicyoperationGetResponse> DatapolicyoperationGetAsync(DatapolicyoperationGetParameter parameter)
        {
            return await this.SendAsync<DatapolicyoperationGetParameter, DatapolicyoperationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/datapolicyoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DatapolicyoperationGetResponse> DatapolicyoperationGetAsync(DatapolicyoperationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DatapolicyoperationGetParameter, DatapolicyoperationGetResponse>(parameter, cancellationToken);
        }
    }
}
