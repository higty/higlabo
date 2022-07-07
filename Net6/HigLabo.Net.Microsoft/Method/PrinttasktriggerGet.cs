using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinttasktriggerGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Printers_PrinterId_TaskTriggers_PrintTaskTriggerId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Print_Printers_PrinterId_TaskTriggers_PrintTaskTriggerId: return $"/print/printers/{PrinterId}/taskTriggers/{PrintTaskTriggerId}";
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
        public string PrinterId { get; set; }
        public string PrintTaskTriggerId { get; set; }
    }
    public partial class PrinttasktriggerGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public PrintEvent? Event { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtasktrigger-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttasktriggerGetResponse> PrinttasktriggerGetAsync()
        {
            var p = new PrinttasktriggerGetParameter();
            return await this.SendAsync<PrinttasktriggerGetParameter, PrinttasktriggerGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtasktrigger-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttasktriggerGetResponse> PrinttasktriggerGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrinttasktriggerGetParameter();
            return await this.SendAsync<PrinttasktriggerGetParameter, PrinttasktriggerGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtasktrigger-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttasktriggerGetResponse> PrinttasktriggerGetAsync(PrinttasktriggerGetParameter parameter)
        {
            return await this.SendAsync<PrinttasktriggerGetParameter, PrinttasktriggerGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtasktrigger-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttasktriggerGetResponse> PrinttasktriggerGetAsync(PrinttasktriggerGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinttasktriggerGetParameter, PrinttasktriggerGetResponse>(parameter, cancellationToken);
        }
    }
}
