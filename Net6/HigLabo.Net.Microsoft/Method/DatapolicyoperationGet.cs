using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/datapolicyoperation-get?view=graph-rest-1.0
    /// </summary>
    public partial class DataPolicyOperationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DataPolicyOperations_Id: return $"/dataPolicyOperations/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CompletedDateTime,
            Id,
            Status,
            StorageLocation,
            UserId,
            SubmittedDateTime,
            Progress,
        }
        public enum ApiPath
        {
            DataPolicyOperations_Id,
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
    public partial class DataPolicyOperationGetResponse : RestApiResponse
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/datapolicyoperation-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/datapolicyoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DataPolicyOperationGetResponse> DataPolicyOperationGetAsync()
        {
            var p = new DataPolicyOperationGetParameter();
            return await this.SendAsync<DataPolicyOperationGetParameter, DataPolicyOperationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/datapolicyoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DataPolicyOperationGetResponse> DataPolicyOperationGetAsync(CancellationToken cancellationToken)
        {
            var p = new DataPolicyOperationGetParameter();
            return await this.SendAsync<DataPolicyOperationGetParameter, DataPolicyOperationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/datapolicyoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DataPolicyOperationGetResponse> DataPolicyOperationGetAsync(DataPolicyOperationGetParameter parameter)
        {
            return await this.SendAsync<DataPolicyOperationGetParameter, DataPolicyOperationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/datapolicyoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<DataPolicyOperationGetResponse> DataPolicyOperationGetAsync(DataPolicyOperationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DataPolicyOperationGetParameter, DataPolicyOperationGetResponse>(parameter, cancellationToken);
        }
    }
}
