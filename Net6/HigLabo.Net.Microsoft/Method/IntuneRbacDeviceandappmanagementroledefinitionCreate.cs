using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacDeviceandappmanagementroledefinitionCreateParameter : IRestApiParameter
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
    public partial class IntuneRbacDeviceandappmanagementroledefinitionCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionCreateResponse> IntuneRbacDeviceandappmanagementroledefinitionCreateAsync()
        {
            var p = new IntuneRbacDeviceandappmanagementroledefinitionCreateParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionCreateParameter, IntuneRbacDeviceandappmanagementroledefinitionCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionCreateResponse> IntuneRbacDeviceandappmanagementroledefinitionCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacDeviceandappmanagementroledefinitionCreateParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionCreateParameter, IntuneRbacDeviceandappmanagementroledefinitionCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionCreateResponse> IntuneRbacDeviceandappmanagementroledefinitionCreateAsync(IntuneRbacDeviceandappmanagementroledefinitionCreateParameter parameter)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionCreateParameter, IntuneRbacDeviceandappmanagementroledefinitionCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroledefinition-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroledefinitionCreateResponse> IntuneRbacDeviceandappmanagementroledefinitionCreateAsync(IntuneRbacDeviceandappmanagementroledefinitionCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroledefinitionCreateParameter, IntuneRbacDeviceandappmanagementroledefinitionCreateResponse>(parameter, cancellationToken);
        }
    }
}
