using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delta?view=graph-rest-1.0
    /// </summary>
    public partial class GroupDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Delta: return $"/groups/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Delta,
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
    public partial class GroupDeltaResponse : RestApiResponse<Group>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/group-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupDeltaResponse> GroupDeltaAsync()
        {
            var p = new GroupDeltaParameter();
            return await this.SendAsync<GroupDeltaParameter, GroupDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupDeltaResponse> GroupDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new GroupDeltaParameter();
            return await this.SendAsync<GroupDeltaParameter, GroupDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupDeltaResponse> GroupDeltaAsync(GroupDeltaParameter parameter)
        {
            return await this.SendAsync<GroupDeltaParameter, GroupDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<GroupDeltaResponse> GroupDeltaAsync(GroupDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupDeltaParameter, GroupDeltaResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/group-delta?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Group> GroupDeltaEnumerateAsync(GroupDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<GroupDeltaParameter, GroupDeltaResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Group>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
