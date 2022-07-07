using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupDeleteAcceptedsendersParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class GroupDeleteAcceptedsendersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteAcceptedsendersResponse> GroupDeleteAcceptedsendersAsync()
        {
            var p = new GroupDeleteAcceptedsendersParameter();
            return await this.SendAsync<GroupDeleteAcceptedsendersParameter, GroupDeleteAcceptedsendersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteAcceptedsendersResponse> GroupDeleteAcceptedsendersAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeleteAcceptedsendersParameter();
            return await this.SendAsync<GroupDeleteAcceptedsendersParameter, GroupDeleteAcceptedsendersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteAcceptedsendersResponse> GroupDeleteAcceptedsendersAsync(GroupDeleteAcceptedsendersParameter parameter)
        {
            return await this.SendAsync<GroupDeleteAcceptedsendersParameter, GroupDeleteAcceptedsendersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-delete-acceptedsenders?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupDeleteAcceptedsendersResponse> GroupDeleteAcceptedsendersAsync(GroupDeleteAcceptedsendersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeleteAcceptedsendersParameter, GroupDeleteAcceptedsendersResponse>(parameter, cancellationToken);
        }
    }
}
