using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationPostOwnersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Applications_Id_Owners_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id_Owners_ref: return $"/applications/{Id}/owners/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class ApplicationPostOwnersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOwnersResponse> ApplicationPostOwnersAsync()
        {
            var p = new ApplicationPostOwnersParameter();
            return await this.SendAsync<ApplicationPostOwnersParameter, ApplicationPostOwnersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOwnersResponse> ApplicationPostOwnersAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostOwnersParameter();
            return await this.SendAsync<ApplicationPostOwnersParameter, ApplicationPostOwnersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOwnersResponse> ApplicationPostOwnersAsync(ApplicationPostOwnersParameter parameter)
        {
            return await this.SendAsync<ApplicationPostOwnersParameter, ApplicationPostOwnersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-owners?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostOwnersResponse> ApplicationPostOwnersAsync(ApplicationPostOwnersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostOwnersParameter, ApplicationPostOwnersResponse>(parameter, cancellationToken);
        }
    }
}
