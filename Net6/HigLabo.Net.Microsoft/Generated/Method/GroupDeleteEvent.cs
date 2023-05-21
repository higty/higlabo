using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-event?view=graph-rest-1.0
    /// </summary>
    public partial class GroupDeleteEventParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? GroupsId { get; set; }
            public string? EventsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_Events_Id: return $"/groups/{GroupsId}/events/{EventsId}";
                    case ApiPath.Groups_Id_Calendar_Events_Id: return $"/groups/{GroupsId}/calendar/events/{EventsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_Events_Id,
            Groups_Id_Calendar_Events_Id,
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
    public partial class GroupDeleteEventResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delete-event?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteEventResponse> GroupDeleteEventAsync()
        {
            var p = new GroupDeleteEventParameter();
            return await this.SendAsync<GroupDeleteEventParameter, GroupDeleteEventResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteEventResponse> GroupDeleteEventAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteEventParameter();
            return await this.SendAsync<GroupDeleteEventParameter, GroupDeleteEventResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteEventResponse> GroupDeleteEventAsync(GroupDeleteEventParameter parameter)
        {
            return await this.SendAsync<GroupDeleteEventParameter, GroupDeleteEventResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delete-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteEventResponse> GroupDeleteEventAsync(GroupDeleteEventParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteEventParameter, GroupDeleteEventResponse>(parameter, cancellationToken);
        }
    }
}
