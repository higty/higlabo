using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodotasklistDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Todo_Lists_Delta,
            Users_IdOruserPrincipalName_Todo_Lists_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Me_Todo_Lists_Delta: return $"/me/todo/lists/delta";
                    case ApiPath.Users_IdOruserPrincipalName_Todo_Lists_Delta: return $"/users/{IdOrUserPrincipalName}/todo/lists/delta";
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
        public string IdOrUserPrincipalName { get; set; }
    }
    public partial class TodotasklistDeltaResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/todotasklist?view=graph-rest-1.0
        /// </summary>
        public partial class TodoTaskList
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
        }

        public TodoTaskList[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistDeltaResponse> TodotasklistDeltaAsync()
        {
            var p = new TodotasklistDeltaParameter();
            return await this.SendAsync<TodotasklistDeltaParameter, TodotasklistDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistDeltaResponse> TodotasklistDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new TodotasklistDeltaParameter();
            return await this.SendAsync<TodotasklistDeltaParameter, TodotasklistDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistDeltaResponse> TodotasklistDeltaAsync(TodotasklistDeltaParameter parameter)
        {
            return await this.SendAsync<TodotasklistDeltaParameter, TodotasklistDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistDeltaResponse> TodotasklistDeltaAsync(TodotasklistDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotasklistDeltaParameter, TodotasklistDeltaResponse>(parameter, cancellationToken);
        }
    }
}
