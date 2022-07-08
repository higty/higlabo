using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PrintListTaskdefinitionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_TaskDefinitions: return $"/print/taskDefinitions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            DisplayName,
            CreatedBy,
            Tasks,
        }
        public enum ApiPath
        {
            Print_TaskDefinitions,
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
    public partial class PrintListTaskdefinitionsResponse : RestApiResponse
    {
        public PrintTaskDefinition[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListTaskdefinitionsResponse> PrintListTaskdefinitionsAsync()
        {
            var p = new PrintListTaskdefinitionsParameter();
            return await this.SendAsync<PrintListTaskdefinitionsParameter, PrintListTaskdefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListTaskdefinitionsResponse> PrintListTaskdefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListTaskdefinitionsParameter();
            return await this.SendAsync<PrintListTaskdefinitionsParameter, PrintListTaskdefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListTaskdefinitionsResponse> PrintListTaskdefinitionsAsync(PrintListTaskdefinitionsParameter parameter)
        {
            return await this.SendAsync<PrintListTaskdefinitionsParameter, PrintListTaskdefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/print-list-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async Task<PrintListTaskdefinitionsResponse> PrintListTaskdefinitionsAsync(PrintListTaskdefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListTaskdefinitionsParameter, PrintListTaskdefinitionsResponse>(parameter, cancellationToken);
        }
    }
}
