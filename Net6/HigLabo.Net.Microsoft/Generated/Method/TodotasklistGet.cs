using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotasklist-get?view=graph-rest-1.0
    /// </summary>
    public partial class TodotasklistGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TodoTaskListId { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Todo_Lists_TodoTaskListId: return $"/me/todo/lists/{TodoTaskListId}";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId: return $"/users/{IdOrUserPrincipalName}/todo/lists/{TodoTaskListId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Todo_Lists_TodoTaskListId,
            Users_IdOruserPrincipalName_Todo_Lists_TodoTaskListId,
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
    public partial class TodotasklistGetResponse : RestApiResponse
    {
        public enum TodoTaskListWellknownListName
        {
            None,
            DefaultList,
            FlaggedEmails,
            UnknownFutureValue,
        }

        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsOwner { get; set; }
        public bool? IsShared { get; set; }
        public TodoTaskListWellknownListName WellknownListName { get; set; }
        public Extension[]? Extensions { get; set; }
        public TodoTask[]? Tasks { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/todotasklist-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotasklist-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistGetResponse> TodotasklistGetAsync()
        {
            var p = new TodotasklistGetParameter();
            return await this.SendAsync<TodotasklistGetParameter, TodotasklistGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotasklist-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistGetResponse> TodotasklistGetAsync(CancellationToken cancellationToken)
        {
            var p = new TodotasklistGetParameter();
            return await this.SendAsync<TodotasklistGetParameter, TodotasklistGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotasklist-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistGetResponse> TodotasklistGetAsync(TodotasklistGetParameter parameter)
        {
            return await this.SendAsync<TodotasklistGetParameter, TodotasklistGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/todotasklist-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistGetResponse> TodotasklistGetAsync(TodotasklistGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotasklistGetParameter, TodotasklistGetResponse>(parameter, cancellationToken);
        }
    }
}
