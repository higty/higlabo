using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-accessassignments?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadminrelationshipListAccessAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DelegatedAdminRelationshipId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_AccessAssignments: return $"/tenantRelationships/delegatedAdminRelationships/{DelegatedAdminRelationshipId}/accessAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            TenantRelationships_DelegatedAdminRelationships_DelegatedAdminRelationshipId_AccessAssignments,
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
    public partial class DelegatedadminrelationshipListAccessAssignmentsResponse : RestApiResponse<DelegatedAdminAccessAssignment>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-accessassignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-accessassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminrelationshipListAccessAssignmentsResponse> DelegatedadminrelationshipListAccessAssignmentsAsync()
        {
            var p = new DelegatedadminrelationshipListAccessAssignmentsParameter();
            return await this.SendAsync<DelegatedadminrelationshipListAccessAssignmentsParameter, DelegatedadminrelationshipListAccessAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-accessassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminrelationshipListAccessAssignmentsResponse> DelegatedadminrelationshipListAccessAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadminrelationshipListAccessAssignmentsParameter();
            return await this.SendAsync<DelegatedadminrelationshipListAccessAssignmentsParameter, DelegatedadminrelationshipListAccessAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-accessassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminrelationshipListAccessAssignmentsResponse> DelegatedadminrelationshipListAccessAssignmentsAsync(DelegatedadminrelationshipListAccessAssignmentsParameter parameter)
        {
            return await this.SendAsync<DelegatedadminrelationshipListAccessAssignmentsParameter, DelegatedadminrelationshipListAccessAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-accessassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminrelationshipListAccessAssignmentsResponse> DelegatedadminrelationshipListAccessAssignmentsAsync(DelegatedadminrelationshipListAccessAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadminrelationshipListAccessAssignmentsParameter, DelegatedadminrelationshipListAccessAssignmentsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadminrelationship-list-accessassignments?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DelegatedAdminAccessAssignment> DelegatedadminrelationshipListAccessAssignmentsEnumerateAsync(DelegatedadminrelationshipListAccessAssignmentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<DelegatedadminrelationshipListAccessAssignmentsParameter, DelegatedadminrelationshipListAccessAssignmentsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DelegatedAdminAccessAssignment>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
