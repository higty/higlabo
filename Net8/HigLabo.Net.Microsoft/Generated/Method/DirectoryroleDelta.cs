using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delta?view=graph-rest-1.0
    /// </summary>
    public partial class DirectoryroleDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.DirectoryRoles_Delta: return $"/directoryRoles/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            DirectoryRoles_Delta,
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
    public partial class DirectoryroleDeltaResponse : RestApiResponse<DirectoryRole>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryroleDeltaResponse> DirectoryroleDeltaAsync()
        {
            var p = new DirectoryroleDeltaParameter();
            return await this.SendAsync<DirectoryroleDeltaParameter, DirectoryroleDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryroleDeltaResponse> DirectoryroleDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new DirectoryroleDeltaParameter();
            return await this.SendAsync<DirectoryroleDeltaParameter, DirectoryroleDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryroleDeltaResponse> DirectoryroleDeltaAsync(DirectoryroleDeltaParameter parameter)
        {
            return await this.SendAsync<DirectoryroleDeltaParameter, DirectoryroleDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DirectoryroleDeltaResponse> DirectoryroleDeltaAsync(DirectoryroleDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DirectoryroleDeltaParameter, DirectoryroleDeltaResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/directoryrole-delta?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryRole> DirectoryroleDeltaEnumerateAsync(DirectoryroleDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<DirectoryroleDeltaParameter, DirectoryroleDeltaResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DirectoryRole>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
