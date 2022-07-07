using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupUnsubscribebymailParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Groups_Id_UnsubscribeByMail,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_UnsubscribeByMail: return $"/groups/{Id}/unsubscribeByMail";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class GroupUnsubscribebymailResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-unsubscribebymail?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUnsubscribebymailResponse> GroupUnsubscribebymailAsync()
        {
            var p = new GroupUnsubscribebymailParameter();
            return await this.SendAsync<GroupUnsubscribebymailParameter, GroupUnsubscribebymailResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-unsubscribebymail?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUnsubscribebymailResponse> GroupUnsubscribebymailAsync(CancellationToken cancellationToken)
        {
            var p = new GroupUnsubscribebymailParameter();
            return await this.SendAsync<GroupUnsubscribebymailParameter, GroupUnsubscribebymailResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-unsubscribebymail?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUnsubscribebymailResponse> GroupUnsubscribebymailAsync(GroupUnsubscribebymailParameter parameter)
        {
            return await this.SendAsync<GroupUnsubscribebymailParameter, GroupUnsubscribebymailResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-unsubscribebymail?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupUnsubscribebymailResponse> GroupUnsubscribebymailAsync(GroupUnsubscribebymailParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupUnsubscribebymailParameter, GroupUnsubscribebymailResponse>(parameter, cancellationToken);
        }
    }
}
