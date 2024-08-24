using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentAdditionalAccessParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Assignments_AdditionalAccess: return $"/identityGovernance/entitlementManagement/assignments/additionalAccess";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Assignments_AdditionalAccess,
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
    public partial class AccessPackageAssignmentAdditionalAccessResponse : RestApiResponse<AccessPackageAssignment>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentAdditionalAccessResponse> AccessPackageAssignmentAdditionalAccessAsync()
        {
            var p = new AccessPackageAssignmentAdditionalAccessParameter();
            return await this.SendAsync<AccessPackageAssignmentAdditionalAccessParameter, AccessPackageAssignmentAdditionalAccessResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentAdditionalAccessResponse> AccessPackageAssignmentAdditionalAccessAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageAssignmentAdditionalAccessParameter();
            return await this.SendAsync<AccessPackageAssignmentAdditionalAccessParameter, AccessPackageAssignmentAdditionalAccessResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentAdditionalAccessResponse> AccessPackageAssignmentAdditionalAccessAsync(AccessPackageAssignmentAdditionalAccessParameter parameter)
        {
            return await this.SendAsync<AccessPackageAssignmentAdditionalAccessParameter, AccessPackageAssignmentAdditionalAccessResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageAssignmentAdditionalAccessResponse> AccessPackageAssignmentAdditionalAccessAsync(AccessPackageAssignmentAdditionalAccessParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageAssignmentAdditionalAccessParameter, AccessPackageAssignmentAdditionalAccessResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessPackageAssignment> AccessPackageAssignmentAdditionalAccessEnumerateAsync(AccessPackageAssignmentAdditionalAccessParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AccessPackageAssignmentAdditionalAccessParameter, AccessPackageAssignmentAdditionalAccessResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AccessPackageAssignment>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
