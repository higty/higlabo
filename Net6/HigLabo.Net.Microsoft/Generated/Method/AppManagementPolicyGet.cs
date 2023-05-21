using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class AppManagementPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_AppManagementPolicies_Id: return $"/policies/appManagementPolicies/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            DisplayName,
            Description,
            IsEnabled,
            Restrictions,
            AppliesTo,
        }
        public enum ApiPath
        {
            Policies_AppManagementPolicies_Id,
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
    public partial class AppManagementPolicyGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public bool? IsEnabled { get; set; }
        public AppManagementConfiguration? Restrictions { get; set; }
        public DirectoryObject? AppliesTo { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyGetResponse> AppManagementPolicyGetAsync()
        {
            var p = new AppManagementPolicyGetParameter();
            return await this.SendAsync<AppManagementPolicyGetParameter, AppManagementPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyGetResponse> AppManagementPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AppManagementPolicyGetParameter();
            return await this.SendAsync<AppManagementPolicyGetParameter, AppManagementPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyGetResponse> AppManagementPolicyGetAsync(AppManagementPolicyGetParameter parameter)
        {
            return await this.SendAsync<AppManagementPolicyGetParameter, AppManagementPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/appmanagementpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AppManagementPolicyGetResponse> AppManagementPolicyGetAsync(AppManagementPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppManagementPolicyGetParameter, AppManagementPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
