using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
    /// </summary>
    public partial class PrinttaskDefinitionListTasksParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TaskDefinitionId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Print_TaskDefinitions_TaskDefinitionId_Tasks: return $"/print/taskDefinitions/{TaskDefinitionId}/tasks";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Print_TaskDefinitions_TaskDefinitionId_Tasks,
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
    public partial class PrinttaskDefinitionListTasksResponse : RestApiResponse<PrintTask>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskDefinitionListTasksResponse> PrinttaskDefinitionListTasksAsync()
        {
            var p = new PrinttaskDefinitionListTasksParameter();
            return await this.SendAsync<PrinttaskDefinitionListTasksParameter, PrinttaskDefinitionListTasksResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskDefinitionListTasksResponse> PrinttaskDefinitionListTasksAsync(CancellationToken cancellationToken)
        {
            var p = new PrinttaskDefinitionListTasksParameter();
            return await this.SendAsync<PrinttaskDefinitionListTasksParameter, PrinttaskDefinitionListTasksResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskDefinitionListTasksResponse> PrinttaskDefinitionListTasksAsync(PrinttaskDefinitionListTasksParameter parameter)
        {
            return await this.SendAsync<PrinttaskDefinitionListTasksParameter, PrinttaskDefinitionListTasksResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<PrinttaskDefinitionListTasksResponse> PrinttaskDefinitionListTasksAsync(PrinttaskDefinitionListTasksParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PrinttaskDefinitionListTasksParameter, PrinttaskDefinitionListTasksResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/printtaskdefinition-list-tasks?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<PrintTask> PrinttaskDefinitionListTasksEnumerateAsync(PrinttaskDefinitionListTasksParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<PrinttaskDefinitionListTasksParameter, PrinttaskDefinitionListTasksResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<PrintTask>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
