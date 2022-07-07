using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupPostAcceptedsendersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_AcceptedSenders_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_AcceptedSenders_ref: return $"/groups/{Id}/acceptedSenders/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class GroupPostAcceptedsendersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostAcceptedsendersResponse> GroupPostAcceptedsendersAsync()
        {
            var p = new GroupPostAcceptedsendersParameter();
            return await this.SendAsync<GroupPostAcceptedsendersParameter, GroupPostAcceptedsendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostAcceptedsendersResponse> GroupPostAcceptedsendersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupPostAcceptedsendersParameter();
            return await this.SendAsync<GroupPostAcceptedsendersParameter, GroupPostAcceptedsendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostAcceptedsendersResponse> GroupPostAcceptedsendersAsync(GroupPostAcceptedsendersParameter parameter)
        {
            return await this.SendAsync<GroupPostAcceptedsendersParameter, GroupPostAcceptedsendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-post-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupPostAcceptedsendersResponse> GroupPostAcceptedsendersAsync(GroupPostAcceptedsendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupPostAcceptedsendersParameter, GroupPostAcceptedsendersResponse>(parameter, cancellationToken);
        }
    }
}
