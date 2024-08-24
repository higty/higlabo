using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-list-tabs?view=graph-rest-1.0
    /// </summary>
    public partial class ChannelListTabsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamsId { get; set; }
            public string? ChannelsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_Id_Channels_Id_Tabs: return $"/teams/{TeamsId}/channels/{ChannelsId}/tabs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_Id_Channels_Id_Tabs,
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
    public partial class ChannelListTabsResponse : RestApiResponse<TeamsTab>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/channel-list-tabs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelListTabsResponse> ChannelListTabsAsync()
        {
            var p = new ChannelListTabsParameter();
            return await this.SendAsync<ChannelListTabsParameter, ChannelListTabsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelListTabsResponse> ChannelListTabsAsync(CancellationToken cancellationToken)
        {
            var p = new ChannelListTabsParameter();
            return await this.SendAsync<ChannelListTabsParameter, ChannelListTabsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelListTabsResponse> ChannelListTabsAsync(ChannelListTabsParameter parameter)
        {
            return await this.SendAsync<ChannelListTabsParameter, ChannelListTabsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ChannelListTabsResponse> ChannelListTabsAsync(ChannelListTabsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChannelListTabsParameter, ChannelListTabsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/channel-list-tabs?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<TeamsTab> ChannelListTabsEnumerateAsync(ChannelListTabsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ChannelListTabsParameter, ChannelListTabsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<TeamsTab>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
