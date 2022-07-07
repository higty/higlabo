using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TermstoreGroupDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Ites_SiteId_TermStore_Groups_GroupId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Ites_SiteId_TermStore_Groups_GroupId: return $"/ites/{SiteId}/termStore/groups/{GroupId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string SiteId { get; set; }
        public string GroupId { get; set; }
    }
    public partial class TermstoreGroupDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupDeleteResponse> TermstoreGroupDeleteAsync()
        {
            var p = new TermstoreGroupDeleteParameter();
            return await this.SendAsync<TermstoreGroupDeleteParameter, TermstoreGroupDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupDeleteResponse> TermstoreGroupDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TermstoreGroupDeleteParameter();
            return await this.SendAsync<TermstoreGroupDeleteParameter, TermstoreGroupDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupDeleteResponse> TermstoreGroupDeleteAsync(TermstoreGroupDeleteParameter parameter)
        {
            return await this.SendAsync<TermstoreGroupDeleteParameter, TermstoreGroupDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/termstore-group-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<TermstoreGroupDeleteResponse> TermstoreGroupDeleteAsync(TermstoreGroupDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermstoreGroupDeleteParameter, TermstoreGroupDeleteResponse>(parameter, cancellationToken);
        }
    }
}
