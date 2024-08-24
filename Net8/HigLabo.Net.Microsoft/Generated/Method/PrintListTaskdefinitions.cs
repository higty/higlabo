using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-taskdefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class PrintListTaskDefinitionsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class PrintListTaskDefinitionsResponse : RestApiResponse<PrintTaskDefinition>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/print-list-taskdefinitions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListTaskDefinitionsResponse> PrintListTaskDefinitionsAsync()
        {
            var p = new PrintListTaskDefinitionsParameter();
            return await this.SendAsync<PrintListTaskDefinitionsParameter, PrintListTaskDefinitionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListTaskDefinitionsResponse> PrintListTaskDefinitionsAsync(CancellationToken cancellationToken)
        {
            var p = new PrintListTaskDefinitionsParameter();
            return await this.SendAsync<PrintListTaskDefinitionsParameter, PrintListTaskDefinitionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListTaskDefinitionsResponse> PrintListTaskDefinitionsAsync(PrintListTaskDefinitionsParameter parameter)
        {
            return await this.SendAsync<PrintListTaskDefinitionsParameter, PrintListTaskDefinitionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrintListTaskDefinitionsResponse> PrintListTaskDefinitionsAsync(PrintListTaskDefinitionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrintListTaskDefinitionsParameter, PrintListTaskDefinitionsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/print-list-taskdefinitions?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<PrintTaskDefinition> PrintListTaskDefinitionsEnumerateAsync(PrintListTaskDefinitionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PrintListTaskDefinitionsParameter, PrintListTaskDefinitionsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<PrintTaskDefinition>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
