using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-delete-incomingchannels?view=graph-rest-1.0
    /// </summary>
    public partial class TeamDeleteIncomingchannelsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? IncomingChannelId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_IncomingChannels_IncomingChannelId_ref: return $"/teams/{TeamId}/incomingChannels/{IncomingChannelId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_IncomingChannels_IncomingChannelId_ref,
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
    public partial class TeamDeleteIncomingchannelsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-delete-incomingchannels?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-delete-incomingchannels?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamDeleteIncomingchannelsResponse> TeamDeleteIncomingchannelsAsync()
        {
            var p = new TeamDeleteIncomingchannelsParameter();
            return await this.SendAsync<TeamDeleteIncomingchannelsParameter, TeamDeleteIncomingchannelsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-delete-incomingchannels?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamDeleteIncomingchannelsResponse> TeamDeleteIncomingchannelsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamDeleteIncomingchannelsParameter();
            return await this.SendAsync<TeamDeleteIncomingchannelsParameter, TeamDeleteIncomingchannelsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-delete-incomingchannels?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamDeleteIncomingchannelsResponse> TeamDeleteIncomingchannelsAsync(TeamDeleteIncomingchannelsParameter parameter)
        {
            return await this.SendAsync<TeamDeleteIncomingchannelsParameter, TeamDeleteIncomingchannelsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-delete-incomingchannels?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamDeleteIncomingchannelsResponse> TeamDeleteIncomingchannelsAsync(TeamDeleteIncomingchannelsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamDeleteIncomingchannelsParameter, TeamDeleteIncomingchannelsResponse>(parameter, cancellationToken);
        }
    }
}
