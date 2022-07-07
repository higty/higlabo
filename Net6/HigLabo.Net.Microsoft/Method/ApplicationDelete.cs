using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Applications_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id: return $"/applications/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class ApplicationDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteResponse> ApplicationDeleteAsync()
        {
            var p = new ApplicationDeleteParameter();
            return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteResponse> ApplicationDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationDeleteParameter();
            return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteResponse> ApplicationDeleteAsync(ApplicationDeleteParameter parameter)
        {
            return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationDeleteResponse> ApplicationDeleteAsync(ApplicationDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationDeleteParameter, ApplicationDeleteResponse>(parameter, cancellationToken);
        }
    }
}
