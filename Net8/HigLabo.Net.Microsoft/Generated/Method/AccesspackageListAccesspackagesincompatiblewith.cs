using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageListAccessPackagesincompatiblewithParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class AccessPackageListAccessPackagesincompatiblewithResponse : RestApiResponse<AccessPackage>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageListAccessPackagesincompatiblewithResponse> AccessPackageListAccessPackagesincompatiblewithAsync()
        {
            var p = new AccessPackageListAccessPackagesincompatiblewithParameter();
            return await this.SendAsync<AccessPackageListAccessPackagesincompatiblewithParameter, AccessPackageListAccessPackagesincompatiblewithResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageListAccessPackagesincompatiblewithResponse> AccessPackageListAccessPackagesincompatiblewithAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageListAccessPackagesincompatiblewithParameter();
            return await this.SendAsync<AccessPackageListAccessPackagesincompatiblewithParameter, AccessPackageListAccessPackagesincompatiblewithResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageListAccessPackagesincompatiblewithResponse> AccessPackageListAccessPackagesincompatiblewithAsync(AccessPackageListAccessPackagesincompatiblewithParameter parameter)
        {
            return await this.SendAsync<AccessPackageListAccessPackagesincompatiblewithParameter, AccessPackageListAccessPackagesincompatiblewithResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageListAccessPackagesincompatiblewithResponse> AccessPackageListAccessPackagesincompatiblewithAsync(AccessPackageListAccessPackagesincompatiblewithParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageListAccessPackagesincompatiblewithParameter, AccessPackageListAccessPackagesincompatiblewithResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-accesspackagesincompatiblewith?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<AccessPackage> AccessPackageListAccessPackagesincompatiblewithEnumerateAsync(AccessPackageListAccessPackagesincompatiblewithParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<AccessPackageListAccessPackagesincompatiblewithParameter, AccessPackageListAccessPackagesincompatiblewithResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<AccessPackage>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
