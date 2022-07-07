using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeleteEventParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_Events_Id,
            Groups_Id_Calendar_Events_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_Events_Id: return $"/groups/{GroupsId}/events/{EventsId}";
                    case ApiPath.Groups_Id_Calendar_Events_Id: return $"/groups/{GroupsId}/calendar/events/{EventsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string GroupsId { get; set; }
        public string EventsId { get; set; }
    }
    public partial class GroupDeleteEventResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteEventResponse> GroupDeleteEventAsync()
        {
            var p = new GroupDeleteEventParameter();
            return await this.SendAsync<GroupDeleteEventParameter, GroupDeleteEventResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteEventResponse> GroupDeleteEventAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteEventParameter();
            return await this.SendAsync<GroupDeleteEventParameter, GroupDeleteEventResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteEventResponse> GroupDeleteEventAsync(GroupDeleteEventParameter parameter)
        {
            return await this.SendAsync<GroupDeleteEventParameter, GroupDeleteEventResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteEventResponse> GroupDeleteEventAsync(GroupDeleteEventParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteEventParameter, GroupDeleteEventResponse>(parameter, cancellationToken);
        }
    }
}
