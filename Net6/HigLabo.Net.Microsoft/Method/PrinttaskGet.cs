using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinttaskGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_TaskDefinitions_TaskDefinitionId_Tasks_TaskId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_TaskDefinitions_TaskDefinitionId_Tasks_TaskId: return $"/print/taskDefinitions/{TaskDefinitionId}/tasks/{TaskId}";
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
        public string TaskDefinitionId { get; set; }
        public string TaskId { get; set; }
    }
    public partial class PrinttaskGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public PrintTaskStatus? Status { get; set; }
        public string? ParentUrl { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskGetResponse> PrinttaskGetAsync()
        {
            var p = new PrinttaskGetParameter();
            return await this.SendAsync<PrinttaskGetParameter, PrinttaskGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskGetResponse> PrinttaskGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrinttaskGetParameter();
            return await this.SendAsync<PrinttaskGetParameter, PrinttaskGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskGetResponse> PrinttaskGetAsync(PrinttaskGetParameter parameter)
        {
            return await this.SendAsync<PrinttaskGetParameter, PrinttaskGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtask-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskGetResponse> PrinttaskGetAsync(PrinttaskGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinttaskGetParameter, PrinttaskGetResponse>(parameter, cancellationToken);
        }
    }
}
