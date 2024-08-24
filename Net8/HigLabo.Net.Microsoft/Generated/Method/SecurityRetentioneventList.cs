using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityRetentioneventListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Triggers_RetentionEvents: return $"/security/triggers/retentionEvents";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_Triggers_RetentionEvents,
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
    public partial class SecurityRetentioneventListResponse : RestApiResponse<RetentionEvent>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventListResponse> SecurityRetentioneventListAsync()
        {
            var p = new SecurityRetentioneventListParameter();
            return await this.SendAsync<SecurityRetentioneventListParameter, SecurityRetentioneventListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventListResponse> SecurityRetentioneventListAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityRetentioneventListParameter();
            return await this.SendAsync<SecurityRetentioneventListParameter, SecurityRetentioneventListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventListResponse> SecurityRetentioneventListAsync(SecurityRetentioneventListParameter parameter)
        {
            return await this.SendAsync<SecurityRetentioneventListParameter, SecurityRetentioneventListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventListResponse> SecurityRetentioneventListAsync(SecurityRetentioneventListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityRetentioneventListParameter, SecurityRetentioneventListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentionevent-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<RetentionEvent> SecurityRetentioneventListEnumerateAsync(SecurityRetentioneventListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityRetentioneventListParameter, SecurityRetentioneventListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<RetentionEvent>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
