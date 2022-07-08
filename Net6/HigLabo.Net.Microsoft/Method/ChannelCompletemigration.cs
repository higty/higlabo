using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ChannelCompletemigrationParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string TeamId { get; set; }
            public string ChannelId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_CompleteMigration: return $"/teams/{TeamId}/channels/{ChannelId}/completeMigration";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_CompleteMigration,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class ChannelCompletemigrationResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-completemigration?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelCompletemigrationResponse> ChannelCompletemigrationAsync()
        {
            var p = new ChannelCompletemigrationParameter();
            return await this.SendAsync<ChannelCompletemigrationParameter, ChannelCompletemigrationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-completemigration?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelCompletemigrationResponse> ChannelCompletemigrationAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelCompletemigrationParameter();
            return await this.SendAsync<ChannelCompletemigrationParameter, ChannelCompletemigrationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-completemigration?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelCompletemigrationResponse> ChannelCompletemigrationAsync(ChannelCompletemigrationParameter parameter)
        {
            return await this.SendAsync<ChannelCompletemigrationParameter, ChannelCompletemigrationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/channel-completemigration?view=graph-rest-1.0
        /// </summary>
        public async Task<ChannelCompletemigrationResponse> ChannelCompletemigrationAsync(ChannelCompletemigrationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelCompletemigrationParameter, ChannelCompletemigrationResponse>(parameter, cancellationToken);
        }
    }
}
