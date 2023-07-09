using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-doesuserhaveaccess?view=graph-rest-1.0
    /// </summary>
    public partial class ChannelDoesUserhaveAccessParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? ChannelId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Channels_ChannelId_DoesUserHaveAccess: return $"/teams/{TeamId}/channels/{ChannelId}/doesUserHaveAccess";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Channels_ChannelId_DoesUserHaveAccess,
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
    public partial class ChannelDoesUserhaveAccessResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-doesuserhaveaccess?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-doesuserhaveaccess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelDoesUserhaveAccessResponse> ChannelDoesUserhaveAccessAsync()
        {
            var p = new ChannelDoesUserhaveAccessParameter();
            return await this.SendAsync<ChannelDoesUserhaveAccessParameter, ChannelDoesUserhaveAccessResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-doesuserhaveaccess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelDoesUserhaveAccessResponse> ChannelDoesUserhaveAccessAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelDoesUserhaveAccessParameter();
            return await this.SendAsync<ChannelDoesUserhaveAccessParameter, ChannelDoesUserhaveAccessResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-doesuserhaveaccess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelDoesUserhaveAccessResponse> ChannelDoesUserhaveAccessAsync(ChannelDoesUserhaveAccessParameter parameter)
        {
            return await this.SendAsync<ChannelDoesUserhaveAccessParameter, ChannelDoesUserhaveAccessResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-doesuserhaveaccess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelDoesUserhaveAccessResponse> ChannelDoesUserhaveAccessAsync(ChannelDoesUserhaveAccessParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelDoesUserhaveAccessParameter, ChannelDoesUserhaveAccessResponse>(parameter, cancellationToken);
        }
    }
}
