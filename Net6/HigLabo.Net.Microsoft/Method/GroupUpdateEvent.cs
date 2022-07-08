using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupUpdateEventParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string GroupsId { get; set; }
            public string EventsId { get; set; }

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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
    }
    public partial class GroupUpdateEventResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-update-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUpdateEventResponse> GroupUpdateEventAsync()
        {
            var p = new GroupUpdateEventParameter();
            return await this.SendAsync<GroupUpdateEventParameter, GroupUpdateEventResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-update-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUpdateEventResponse> GroupUpdateEventAsync(CancellationToken cancellationToken)
        {
            var p = new GroupUpdateEventParameter();
            return await this.SendAsync<GroupUpdateEventParameter, GroupUpdateEventResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-update-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUpdateEventResponse> GroupUpdateEventAsync(GroupUpdateEventParameter parameter)
        {
            return await this.SendAsync<GroupUpdateEventParameter, GroupUpdateEventResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-update-event?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUpdateEventResponse> GroupUpdateEventAsync(GroupUpdateEventParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupUpdateEventParameter, GroupUpdateEventResponse>(parameter, cancellationToken);
        }
    }
}
