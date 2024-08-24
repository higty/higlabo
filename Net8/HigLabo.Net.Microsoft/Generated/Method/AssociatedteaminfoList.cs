using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/associatedteaminfo-list?view=graph-rest-1.0
    /// </summary>
    public partial class AssociatedteaminfoListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_UserId_Teamwork_AssociatedTeams: return $"/users/{UserId}/teamwork/associatedTeams";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_UserId_Teamwork_AssociatedTeams,
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
    public partial class AssociatedteaminfoListResponse : RestApiResponse<AssociatedTeamInfo>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/associatedteaminfo-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/associatedteaminfo-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AssociatedteaminfoListResponse> AssociatedteaminfoListAsync()
        {
            var p = new AssociatedteaminfoListParameter();
            return await this.SendAsync<AssociatedteaminfoListParameter, AssociatedteaminfoListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/associatedteaminfo-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AssociatedteaminfoListResponse> AssociatedteaminfoListAsync(CancellationToken cancellationToken)
        {
            var p = new AssociatedteaminfoListParameter();
            return await this.SendAsync<AssociatedteaminfoListParameter, AssociatedteaminfoListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/associatedteaminfo-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AssociatedteaminfoListResponse> AssociatedteaminfoListAsync(AssociatedteaminfoListParameter parameter)
        {
            return await this.SendAsync<AssociatedteaminfoListParameter, AssociatedteaminfoListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/associatedteaminfo-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AssociatedteaminfoListResponse> AssociatedteaminfoListAsync(AssociatedteaminfoListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AssociatedteaminfoListParameter, AssociatedteaminfoListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/associatedteaminfo-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AssociatedTeamInfo> AssociatedteaminfoListEnumerateAsync(AssociatedteaminfoListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AssociatedteaminfoListParameter, AssociatedteaminfoListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AssociatedTeamInfo>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
