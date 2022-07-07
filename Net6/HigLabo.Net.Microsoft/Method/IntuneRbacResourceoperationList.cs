using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacResourceoperationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class IntuneRbacResourceoperationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-rbac-resourceoperation?view=graph-rest-1.0
        /// </summary>
        public partial class ResourceOperation
        {
            public string? Id { get; set; }
            public string? ResourceName { get; set; }
            public string? ActionName { get; set; }
            public string? Description { get; set; }
        }

        public ResourceOperation[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationListResponse> IntuneRbacResourceoperationListAsync()
        {
            var p = new IntuneRbacResourceoperationListParameter();
            return await this.SendAsync<IntuneRbacResourceoperationListParameter, IntuneRbacResourceoperationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationListResponse> IntuneRbacResourceoperationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacResourceoperationListParameter();
            return await this.SendAsync<IntuneRbacResourceoperationListParameter, IntuneRbacResourceoperationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationListResponse> IntuneRbacResourceoperationListAsync(IntuneRbacResourceoperationListParameter parameter)
        {
            return await this.SendAsync<IntuneRbacResourceoperationListParameter, IntuneRbacResourceoperationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-resourceoperation-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacResourceoperationListResponse> IntuneRbacResourceoperationListAsync(IntuneRbacResourceoperationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacResourceoperationListParameter, IntuneRbacResourceoperationListResponse>(parameter, cancellationToken);
        }
    }
}
