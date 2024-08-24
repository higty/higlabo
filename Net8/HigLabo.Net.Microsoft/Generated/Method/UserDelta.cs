using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-delta?view=graph-rest-1.0
    /// </summary>
    public partial class UserDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_Delta: return $"/users/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_Delta,
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
    public partial class UserDeltaResponse : RestApiResponse<User>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/user-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserDeltaResponse> UserDeltaAsync()
        {
            var p = new UserDeltaParameter();
            return await this.SendAsync<UserDeltaParameter, UserDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserDeltaResponse> UserDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new UserDeltaParameter();
            return await this.SendAsync<UserDeltaParameter, UserDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserDeltaResponse> UserDeltaAsync(UserDeltaParameter parameter)
        {
            return await this.SendAsync<UserDeltaParameter, UserDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserDeltaResponse> UserDeltaAsync(UserDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserDeltaParameter, UserDeltaResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/user-delta?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<User> UserDeltaEnumerateAsync(UserDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<UserDeltaParameter, UserDeltaResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<User>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
