using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacRoledefinitionCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_RoleDefinitions,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RoleDefinitions: return $"/deviceManagement/roleDefinitions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public RolePermission[]? RolePermissions { get; set; }
        public bool? IsBuiltIn { get; set; }
    }
    public partial class IntuneRbacRoledefinitionCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public RolePermission[]? RolePermissions { get; set; }
        public bool? IsBuiltIn { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionCreateResponse> IntuneRbacRoledefinitionCreateAsync()
        {
            var p = new IntuneRbacRoledefinitionCreateParameter();
            return await this.SendAsync<IntuneRbacRoledefinitionCreateParameter, IntuneRbacRoledefinitionCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionCreateResponse> IntuneRbacRoledefinitionCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacRoledefinitionCreateParameter();
            return await this.SendAsync<IntuneRbacRoledefinitionCreateParameter, IntuneRbacRoledefinitionCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionCreateResponse> IntuneRbacRoledefinitionCreateAsync(IntuneRbacRoledefinitionCreateParameter parameter)
        {
            return await this.SendAsync<IntuneRbacRoledefinitionCreateParameter, IntuneRbacRoledefinitionCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-roledefinition-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacRoledefinitionCreateResponse> IntuneRbacRoledefinitionCreateAsync(IntuneRbacRoledefinitionCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacRoledefinitionCreateParameter, IntuneRbacRoledefinitionCreateResponse>(parameter, cancellationToken);
        }
    }
}
