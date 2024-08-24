using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
    /// </summary>
    public partial class B2xidentityUserflowListUserAttributeAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_B2xUserFlows_Id_UserAttributeAssignments: return $"/identity/b2xUserFlows/{Id}/userAttributeAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id_UserAttributeAssignments,
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
    public partial class B2xidentityUserflowListUserAttributeAssignmentsResponse : RestApiResponse<IdentityUserFlowAttributeAssignment>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListUserAttributeAssignmentsResponse> B2xidentityUserflowListUserAttributeAssignmentsAsync()
        {
            var p = new B2xidentityUserflowListUserAttributeAssignmentsParameter();
            return await this.SendAsync<B2xidentityUserflowListUserAttributeAssignmentsParameter, B2xidentityUserflowListUserAttributeAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListUserAttributeAssignmentsResponse> B2xidentityUserflowListUserAttributeAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityUserflowListUserAttributeAssignmentsParameter();
            return await this.SendAsync<B2xidentityUserflowListUserAttributeAssignmentsParameter, B2xidentityUserflowListUserAttributeAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListUserAttributeAssignmentsResponse> B2xidentityUserflowListUserAttributeAssignmentsAsync(B2xidentityUserflowListUserAttributeAssignmentsParameter parameter)
        {
            return await this.SendAsync<B2xidentityUserflowListUserAttributeAssignmentsParameter, B2xidentityUserflowListUserAttributeAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<B2xidentityUserflowListUserAttributeAssignmentsResponse> B2xidentityUserflowListUserAttributeAssignmentsAsync(B2xidentityUserflowListUserAttributeAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityUserflowListUserAttributeAssignmentsParameter, B2xidentityUserflowListUserAttributeAssignmentsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/b2xidentityuserflow-list-userattributeassignments?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<IdentityUserFlowAttributeAssignment> B2xidentityUserflowListUserAttributeAssignmentsEnumerateAsync(B2xidentityUserflowListUserAttributeAssignmentsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<B2xidentityUserflowListUserAttributeAssignmentsParameter, B2xidentityUserflowListUserAttributeAssignmentsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<IdentityUserFlowAttributeAssignment>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
