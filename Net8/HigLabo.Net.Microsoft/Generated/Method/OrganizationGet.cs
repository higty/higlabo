using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
    /// </summary>
    public partial class OrganizationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Organization: return $"/organization";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Organization,
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
    public partial class OrganizationGetResponse : RestApiResponse<Organization>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationGetResponse> OrganizationGetAsync()
        {
            var p = new OrganizationGetParameter();
            return await this.SendAsync<OrganizationGetParameter, OrganizationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationGetResponse> OrganizationGetAsync(CancellationToken cancellationToken)
        {
            var p = new OrganizationGetParameter();
            return await this.SendAsync<OrganizationGetParameter, OrganizationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationGetResponse> OrganizationGetAsync(OrganizationGetParameter parameter)
        {
            return await this.SendAsync<OrganizationGetParameter, OrganizationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<OrganizationGetResponse> OrganizationGetAsync(OrganizationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<OrganizationGetParameter, OrganizationGetResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/organization-get?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Organization> OrganizationGetEnumerateAsync(OrganizationGetParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<OrganizationGetParameter, OrganizationGetResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Organization>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
