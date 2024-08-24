using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityRetentioneventTypeListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_TriggerTypes_RetentionEventTypes: return $"/security/triggerTypes/retentionEventTypes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Security_TriggerTypes_RetentionEventTypes,
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
    public partial class SecurityRetentioneventTypeListResponse : RestApiResponse<RetentionEventType>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeListResponse> SecurityRetentioneventTypeListAsync()
        {
            var p = new SecurityRetentioneventTypeListParameter();
            return await this.SendAsync<SecurityRetentioneventTypeListParameter, SecurityRetentioneventTypeListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeListResponse> SecurityRetentioneventTypeListAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityRetentioneventTypeListParameter();
            return await this.SendAsync<SecurityRetentioneventTypeListParameter, SecurityRetentioneventTypeListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeListResponse> SecurityRetentioneventTypeListAsync(SecurityRetentioneventTypeListParameter parameter)
        {
            return await this.SendAsync<SecurityRetentioneventTypeListParameter, SecurityRetentioneventTypeListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityRetentioneventTypeListResponse> SecurityRetentioneventTypeListAsync(SecurityRetentioneventTypeListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityRetentioneventTypeListParameter, SecurityRetentioneventTypeListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-retentioneventtype-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<RetentionEventType> SecurityRetentioneventTypeListEnumerateAsync(SecurityRetentioneventTypeListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityRetentioneventTypeListParameter, SecurityRetentioneventTypeListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<RetentionEventType>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
