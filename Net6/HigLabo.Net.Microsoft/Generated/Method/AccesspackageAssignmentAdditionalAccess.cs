using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackageAssignmentAdditionalAccessParameter : IRestApiParameter, IQueryParameterProperty
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
            ExpiredDateTime,
            Id,
            Schedule,
            State,
            Status,
            AccessPackage,
            Target,
            AssignmentPolicy,
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
    public partial class AccesspackageAssignmentAdditionalAccessResponse : RestApiResponse
    {
        public AccessPackageAssignment[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentAdditionalAccessResponse> AccesspackageAssignmentAdditionalAccessAsync()
        {
            var p = new AccesspackageAssignmentAdditionalAccessParameter();
            return await this.SendAsync<AccesspackageAssignmentAdditionalAccessParameter, AccesspackageAssignmentAdditionalAccessResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentAdditionalAccessResponse> AccesspackageAssignmentAdditionalAccessAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageAssignmentAdditionalAccessParameter();
            return await this.SendAsync<AccesspackageAssignmentAdditionalAccessParameter, AccesspackageAssignmentAdditionalAccessResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentAdditionalAccessResponse> AccesspackageAssignmentAdditionalAccessAsync(AccesspackageAssignmentAdditionalAccessParameter parameter)
        {
            return await this.SendAsync<AccesspackageAssignmentAdditionalAccessParameter, AccesspackageAssignmentAdditionalAccessResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-additionalaccess?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentAdditionalAccessResponse> AccesspackageAssignmentAdditionalAccessAsync(AccesspackageAssignmentAdditionalAccessParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageAssignmentAdditionalAccessParameter, AccesspackageAssignmentAdditionalAccessResponse>(parameter, cancellationToken);
        }
    }
}
