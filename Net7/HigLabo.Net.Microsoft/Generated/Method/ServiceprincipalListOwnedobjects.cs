﻿using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalListOwnedobjectsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Id_OwnedObjects: return $"/servicePrincipals/{Id}/ownedObjects";
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
            ServicePrincipals_Id_OwnedObjects,
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
    public partial class ServiceprincipalListOwnedobjectsResponse : RestApiResponse
    {
        public DirectoryObject[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListOwnedobjectsResponse> ServiceprincipalListOwnedobjectsAsync()
        {
            var p = new ServiceprincipalListOwnedobjectsParameter();
            return await this.SendAsync<ServiceprincipalListOwnedobjectsParameter, ServiceprincipalListOwnedobjectsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListOwnedobjectsResponse> ServiceprincipalListOwnedobjectsAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListOwnedobjectsParameter();
            return await this.SendAsync<ServiceprincipalListOwnedobjectsParameter, ServiceprincipalListOwnedobjectsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListOwnedobjectsResponse> ServiceprincipalListOwnedobjectsAsync(ServiceprincipalListOwnedobjectsParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListOwnedobjectsParameter, ServiceprincipalListOwnedobjectsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-list-ownedobjects?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalListOwnedobjectsResponse> ServiceprincipalListOwnedobjectsAsync(ServiceprincipalListOwnedobjectsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListOwnedobjectsParameter, ServiceprincipalListOwnedobjectsResponse>(parameter, cancellationToken);
        }
    }
}
