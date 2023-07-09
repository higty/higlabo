using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalListCreatedobjectsParameter : IRestApiParameter, IQueryParameterProperty
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
            DeletedDateTime,
            Id,
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
    public partial class ServiceprincipalListCreatedobjectsResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListCreatedobjectsResponse> ServiceprincipalListCreatedobjectsAsync()
        {
            var p = new ServiceprincipalListCreatedobjectsParameter();
            return await this.SendAsync<ServiceprincipalListCreatedobjectsParameter, ServiceprincipalListCreatedobjectsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListCreatedobjectsResponse> ServiceprincipalListCreatedobjectsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListCreatedobjectsParameter();
            return await this.SendAsync<ServiceprincipalListCreatedobjectsParameter, ServiceprincipalListCreatedobjectsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListCreatedobjectsResponse> ServiceprincipalListCreatedobjectsAsync(ServiceprincipalListCreatedobjectsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListCreatedobjectsParameter, ServiceprincipalListCreatedobjectsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-createdobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListCreatedobjectsResponse> ServiceprincipalListCreatedobjectsAsync(ServiceprincipalListCreatedobjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListCreatedobjectsParameter, ServiceprincipalListCreatedobjectsResponse>(parameter, cancellationToken);
        }
    }
}
