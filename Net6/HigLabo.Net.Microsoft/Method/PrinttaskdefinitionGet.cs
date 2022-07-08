using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrinttaskdefinitionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string PrintTaskDefinitionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_TaskDefinitions_PrintTaskDefinitionId: return $"/print/taskDefinitions/{PrintTaskDefinitionId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_TaskDefinitions_PrintTaskDefinitionId,
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
    public partial class PrinttaskdefinitionGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public AppIdentity? CreatedBy { get; set; }
        public PrintTask[]? Tasks { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtaskdefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskdefinitionGetResponse> PrinttaskdefinitionGetAsync()
        {
            var p = new PrinttaskdefinitionGetParameter();
            return await this.SendAsync<PrinttaskdefinitionGetParameter, PrinttaskdefinitionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtaskdefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskdefinitionGetResponse> PrinttaskdefinitionGetAsync(CancellationToken cancellationToken)
        {
            var p = new PrinttaskdefinitionGetParameter();
            return await this.SendAsync<PrinttaskdefinitionGetParameter, PrinttaskdefinitionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtaskdefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskdefinitionGetResponse> PrinttaskdefinitionGetAsync(PrinttaskdefinitionGetParameter parameter)
        {
            return await this.SendAsync<PrinttaskdefinitionGetParameter, PrinttaskdefinitionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/printtaskdefinition-get?view=graph-rest-1.0
        /// </summary>
        public async Task<PrinttaskdefinitionGetResponse> PrinttaskdefinitionGetAsync(PrinttaskdefinitionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinttaskdefinitionGetParameter, PrinttaskdefinitionGetResponse>(parameter, cancellationToken);
        }
    }
}
