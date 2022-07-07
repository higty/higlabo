using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacDeviceandappmanagementroleassignmentCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_RoleAssignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_RoleAssignments: return $"/deviceManagement/roleAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public String[]? ResourceScopes { get; set; }
        public String[]? Members { get; set; }
    }
    public partial class IntuneRbacDeviceandappmanagementroleassignmentCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public String[]? ResourceScopes { get; set; }
        public String[]? Members { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentCreateResponse> IntuneRbacDeviceandappmanagementroleassignmentCreateAsync()
        {
            var p = new IntuneRbacDeviceandappmanagementroleassignmentCreateParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentCreateParameter, IntuneRbacDeviceandappmanagementroleassignmentCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentCreateResponse> IntuneRbacDeviceandappmanagementroleassignmentCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacDeviceandappmanagementroleassignmentCreateParameter();
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentCreateParameter, IntuneRbacDeviceandappmanagementroleassignmentCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentCreateResponse> IntuneRbacDeviceandappmanagementroleassignmentCreateAsync(IntuneRbacDeviceandappmanagementroleassignmentCreateParameter parameter)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentCreateParameter, IntuneRbacDeviceandappmanagementroleassignmentCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-deviceandappmanagementroleassignment-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDeviceandappmanagementroleassignmentCreateResponse> IntuneRbacDeviceandappmanagementroleassignmentCreateAsync(IntuneRbacDeviceandappmanagementroleassignmentCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacDeviceandappmanagementroleassignmentCreateParameter, IntuneRbacDeviceandappmanagementroleassignmentCreateResponse>(parameter, cancellationToken);
        }
    }
}
