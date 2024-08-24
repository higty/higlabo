using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityUserflowAttributeListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_UserFlowAttributes: return $"/identity/userFlowAttributes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_UserFlowAttributes,
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
    public partial class IdentityUserflowAttributeListResponse : RestApiResponse<IdentityUserFlowAttribute>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityUserflowAttributeListResponse> IdentityUserflowAttributeListAsync()
        {
            var p = new IdentityUserflowAttributeListParameter();
            return await this.SendAsync<IdentityUserflowAttributeListParameter, IdentityUserflowAttributeListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityUserflowAttributeListResponse> IdentityUserflowAttributeListAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityUserflowAttributeListParameter();
            return await this.SendAsync<IdentityUserflowAttributeListParameter, IdentityUserflowAttributeListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityUserflowAttributeListResponse> IdentityUserflowAttributeListAsync(IdentityUserflowAttributeListParameter parameter)
        {
            return await this.SendAsync<IdentityUserflowAttributeListParameter, IdentityUserflowAttributeListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityUserflowAttributeListResponse> IdentityUserflowAttributeListAsync(IdentityUserflowAttributeListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityUserflowAttributeListParameter, IdentityUserflowAttributeListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityuserflowattribute-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<IdentityUserFlowAttribute> IdentityUserflowAttributeListEnumerateAsync(IdentityUserflowAttributeListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<IdentityUserflowAttributeListParameter, IdentityUserflowAttributeListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<IdentityUserFlowAttribute>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
