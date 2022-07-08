using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintjobGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string PrintersId { get; set; }
            public string JobsId { get; set; }
            public string SharesId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_Printers_Id_Jobs_Id: return $"/print/printers/{PrintersId}/jobs/{JobsId}";
                    case ApiPath.Print_Shares_Id_Jobs_Id: return $"/print/shares/{SharesId}/jobs/{JobsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_Printers_Id_Jobs_Id,
            Print_Shares_Id_Jobs_Id,
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
    public partial class PrintjobGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public PrintJobStatus? Status { get; set; }
        public PrintJobConfiguration? Configuration { get; set; }
        public Boolean? IsFetchable { get; set; }
        public String? RedirectedFrom { get; set; }
        public String? RedirectedTo { get; set; }
        public UserIdentity? CreatedBy { get; set; }
        public PrintDocument[]? Documents { get; set; }
        public PrintTask[]? Tasks { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobGetResponse> PrintjobGetAsync()
        {
            var p = new PrintjobGetParameter();
            return await this.SendAsync<PrintjobGetParameter, PrintjobGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobGetResponse> PrintjobGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrintjobGetParameter();
            return await this.SendAsync<PrintjobGetParameter, PrintjobGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobGetResponse> PrintjobGetAsync(PrintjobGetParameter parameter)
        {
            return await this.SendAsync<PrintjobGetParameter, PrintjobGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printjob-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintjobGetResponse> PrintjobGetAsync(PrintjobGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintjobGetParameter, PrintjobGetResponse>(parameter, cancellationToken);
        }
    }
}
