using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackageListAccesspackagesincompatiblewithParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_Id_AccessPackagesIncompatibleWith: return $"/identityGovernance/entitlementManagement/accessPackages/{Id}/accessPackagesIncompatibleWith";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            Description,
            DisplayName,
            Id,
            IsHidden,
            ModifiedDateTime,
            AccessPackagesIncompatibleWith,
            AssignmentPolicies,
            Catalog,
            IncompatibleAccessPackages,
            IncompatibleGroups,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages_Id_AccessPackagesIncompatibleWith,
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
    public partial class AccesspackageListAccesspackagesincompatiblewithResponse : RestApiResponse
    {
        public AccessPackage[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageListAccesspackagesincompatiblewithResponse> AccesspackageListAccesspackagesincompatiblewithAsync()
        {
            var p = new AccesspackageListAccesspackagesincompatiblewithParameter();
            return await this.SendAsync<AccesspackageListAccesspackagesincompatiblewithParameter, AccesspackageListAccesspackagesincompatiblewithResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageListAccesspackagesincompatiblewithResponse> AccesspackageListAccesspackagesincompatiblewithAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageListAccesspackagesincompatiblewithParameter();
            return await this.SendAsync<AccesspackageListAccesspackagesincompatiblewithParameter, AccesspackageListAccesspackagesincompatiblewithResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageListAccesspackagesincompatiblewithResponse> AccesspackageListAccesspackagesincompatiblewithAsync(AccesspackageListAccesspackagesincompatiblewithParameter parameter)
        {
            return await this.SendAsync<AccesspackageListAccesspackagesincompatiblewithParameter, AccesspackageListAccesspackagesincompatiblewithResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageListAccesspackagesincompatiblewithResponse> AccesspackageListAccesspackagesincompatiblewithAsync(AccesspackageListAccesspackagesincompatiblewithParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageListAccesspackagesincompatiblewithParameter, AccesspackageListAccesspackagesincompatiblewithResponse>(parameter, cancellationToken);
        }
    }
}
