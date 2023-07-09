using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalListMemberofParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_MemberOf: return $"/servicePrincipals/{Id}/memberOf";
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
            ServicePrincipals_Id_MemberOf,
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
    public partial class ServiceprincipalListMemberofResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListMemberofResponse> ServiceprincipalListMemberofAsync()
        {
            var p = new ServiceprincipalListMemberofParameter();
            return await this.SendAsync<ServiceprincipalListMemberofParameter, ServiceprincipalListMemberofResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListMemberofResponse> ServiceprincipalListMemberofAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListMemberofParameter();
            return await this.SendAsync<ServiceprincipalListMemberofParameter, ServiceprincipalListMemberofResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListMemberofResponse> ServiceprincipalListMemberofAsync(ServiceprincipalListMemberofParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListMemberofParameter, ServiceprincipalListMemberofResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-memberof?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListMemberofResponse> ServiceprincipalListMemberofAsync(ServiceprincipalListMemberofParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListMemberofParameter, ServiceprincipalListMemberofResponse>(parameter, cancellationToken);
        }
    }
}
