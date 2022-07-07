using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacResourceoperationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_ResourceOperations_ResourceOperationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ResourceOperations_ResourceOperationId: return $"/deviceManagement/resourceOperations/{ResourceOperationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ResourceOperationId { get; set; }
    }
    public partial class IntuneRbacResourceoperationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationDeleteResponse> IntuneRbacResourceoperationDeleteAsync()
        {
            var p = new IntuneRbacResourceoperationDeleteParameter();
            return await this.SendAsync<IntuneRbacResourceoperationDeleteParameter, IntuneRbacResourceoperationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationDeleteResponse> IntuneRbacResourceoperationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacResourceoperationDeleteParameter();
            return await this.SendAsync<IntuneRbacResourceoperationDeleteParameter, IntuneRbacResourceoperationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationDeleteResponse> IntuneRbacResourceoperationDeleteAsync(IntuneRbacResourceoperationDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneRbacResourceoperationDeleteParameter, IntuneRbacResourceoperationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationDeleteResponse> IntuneRbacResourceoperationDeleteAsync(IntuneRbacResourceoperationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacResourceoperationDeleteParameter, IntuneRbacResourceoperationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
