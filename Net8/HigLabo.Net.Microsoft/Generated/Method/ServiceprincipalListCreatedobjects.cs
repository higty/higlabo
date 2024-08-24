using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
    /// </summary>
    public partial class ServicePrincipalListCreatedObjectsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_CreatedObjects: return $"/servicePrincipals/{Id}/createdObjects";
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            ServicePrincipals_Id_CreatedObjects,
            ServicePrincipals,
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
    public partial class ServicePrincipalListCreatedObjectsResponse : RestApiResponse<DirectoryObject>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListCreatedObjectsResponse> ServicePrincipalListCreatedObjectsAsync()
        {
            var p = new ServicePrincipalListCreatedObjectsParameter();
            return await this.SendAsync<ServicePrincipalListCreatedObjectsParameter, ServicePrincipalListCreatedObjectsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListCreatedObjectsResponse> ServicePrincipalListCreatedObjectsAsync(CancellationToken cancellationToken)
        {
            var p = new ServicePrincipalListCreatedObjectsParameter();
            return await this.SendAsync<ServicePrincipalListCreatedObjectsParameter, ServicePrincipalListCreatedObjectsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListCreatedObjectsResponse> ServicePrincipalListCreatedObjectsAsync(ServicePrincipalListCreatedObjectsParameter parameter)
        {
            return await this.SendAsync<ServicePrincipalListCreatedObjectsParameter, ServicePrincipalListCreatedObjectsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServicePrincipalListCreatedObjectsResponse> ServicePrincipalListCreatedObjectsAsync(ServicePrincipalListCreatedObjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServicePrincipalListCreatedObjectsParameter, ServicePrincipalListCreatedObjectsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DirectoryObject> ServicePrincipalListCreatedObjectsEnumerateAsync(ServicePrincipalListCreatedObjectsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ServicePrincipalListCreatedObjectsParameter, ServicePrincipalListCreatedObjectsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DirectoryObject>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
