using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TodotasklistDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TodoTaskListId { get; set; }
            public string IdOrUserPrincipalName { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class TodotasklistDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistDeleteResponse> TodotasklistDeleteAsync()
        {
            var p = new TodotasklistDeleteParameter();
            return await this.SendAsync<TodotasklistDeleteParameter, TodotasklistDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistDeleteResponse> TodotasklistDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TodotasklistDeleteParameter();
            return await this.SendAsync<TodotasklistDeleteParameter, TodotasklistDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistDeleteResponse> TodotasklistDeleteAsync(TodotasklistDeleteParameter parameter)
        {
            return await this.SendAsync<TodotasklistDeleteParameter, TodotasklistDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/todotasklist-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TodotasklistDeleteResponse> TodotasklistDeleteAsync(TodotasklistDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TodotasklistDeleteParameter, TodotasklistDeleteResponse>(parameter, cancellationToken);
        }
    }
}
