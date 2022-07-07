using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacResourceoperationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string ResourceOperationId { get; set; }
    }
    public partial class IntuneRbacResourceoperationGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? ResourceName { get; set; }
        public string? ActionName { get; set; }
        public string? Description { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationGetResponse> IntuneRbacResourceoperationGetAsync()
        {
            var p = new IntuneRbacResourceoperationGetParameter();
            return await this.SendAsync<IntuneRbacResourceoperationGetParameter, IntuneRbacResourceoperationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationGetResponse> IntuneRbacResourceoperationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacResourceoperationGetParameter();
            return await this.SendAsync<IntuneRbacResourceoperationGetParameter, IntuneRbacResourceoperationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationGetResponse> IntuneRbacResourceoperationGetAsync(IntuneRbacResourceoperationGetParameter parameter)
        {
            return await this.SendAsync<IntuneRbacResourceoperationGetParameter, IntuneRbacResourceoperationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationGetResponse> IntuneRbacResourceoperationGetAsync(IntuneRbacResourceoperationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacResourceoperationGetParameter, IntuneRbacResourceoperationGetResponse>(parameter, cancellationToken);
        }
    }
}
