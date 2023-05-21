using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-acceptedsenders?view=graph-rest-1.0
    /// </summary>
    public partial class GroupPostAcceptedsendersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_AcceptedSenders_ref: return $"/groups/{Id}/acceptedSenders/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Groups_Id_AcceptedSenders_ref,
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
    public partial class GroupPostAcceptedsendersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-post-acceptedsenders?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-post-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostAcceptedsendersResponse> GroupPostAcceptedsendersAsync()
        {
            var p = new GroupPostAcceptedsendersParameter();
            return await this.SendAsync<GroupPostAcceptedsendersParameter, GroupPostAcceptedsendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-post-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostAcceptedsendersResponse> GroupPostAcceptedsendersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupPostAcceptedsendersParameter();
            return await this.SendAsync<GroupPostAcceptedsendersParameter, GroupPostAcceptedsendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-post-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostAcceptedsendersResponse> GroupPostAcceptedsendersAsync(GroupPostAcceptedsendersParameter parameter)
        {
            return await this.SendAsync<GroupPostAcceptedsendersParameter, GroupPostAcceptedsendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-post-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostAcceptedsendersResponse> GroupPostAcceptedsendersAsync(GroupPostAcceptedsendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupPostAcceptedsendersParameter, GroupPostAcceptedsendersResponse>(parameter, cancellationToken);
        }
    }
}
