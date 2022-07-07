using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityuserflowDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id: return $"/identity/b2xUserFlows/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class B2xidentityuserflowDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowDeleteResponse> B2xidentityuserflowDeleteAsync()
        {
            var p = new B2xidentityuserflowDeleteParameter();
            return await this.SendAsync<B2xidentityuserflowDeleteParameter, B2xidentityuserflowDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowDeleteResponse> B2xidentityuserflowDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityuserflowDeleteParameter();
            return await this.SendAsync<B2xidentityuserflowDeleteParameter, B2xidentityuserflowDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowDeleteResponse> B2xidentityuserflowDeleteAsync(B2xidentityuserflowDeleteParameter parameter)
        {
            return await this.SendAsync<B2xidentityuserflowDeleteParameter, B2xidentityuserflowDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowDeleteResponse> B2xidentityuserflowDeleteAsync(B2xidentityuserflowDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityuserflowDeleteParameter, B2xidentityuserflowDeleteResponse>(parameter, cancellationToken);
        }
    }
}
