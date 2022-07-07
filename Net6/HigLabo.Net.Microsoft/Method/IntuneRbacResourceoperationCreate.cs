using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacResourceoperationCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_ResourceOperations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ResourceOperations: return $"/deviceManagement/resourceOperations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? ResourceName { get; set; }
        public string? ActionName { get; set; }
        public string? Description { get; set; }
    }
    public partial class IntuneRbacResourceoperationCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? ResourceName { get; set; }
        public string? ActionName { get; set; }
        public string? Description { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationCreateResponse> IntuneRbacResourceoperationCreateAsync()
        {
            var p = new IntuneRbacResourceoperationCreateParameter();
            return await this.SendAsync<IntuneRbacResourceoperationCreateParameter, IntuneRbacResourceoperationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationCreateResponse> IntuneRbacResourceoperationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacResourceoperationCreateParameter();
            return await this.SendAsync<IntuneRbacResourceoperationCreateParameter, IntuneRbacResourceoperationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationCreateResponse> IntuneRbacResourceoperationCreateAsync(IntuneRbacResourceoperationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneRbacResourceoperationCreateParameter, IntuneRbacResourceoperationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationCreateResponse> IntuneRbacResourceoperationCreateAsync(IntuneRbacResourceoperationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacResourceoperationCreateParameter, IntuneRbacResourceoperationCreateResponse>(parameter, cancellationToken);
        }
    }
}
