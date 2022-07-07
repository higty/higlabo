using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationRemovekeyParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Applications_Id_RemoveKey,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id_RemoveKey: return $"/applications/{Id}/removeKey";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Guid? KeyId { get; set; }
        public string? Proof { get; set; }
        public string Id { get; set; }
    }
    public partial class ApplicationRemovekeyResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovekeyResponse> ApplicationRemovekeyAsync()
        {
            var p = new ApplicationRemovekeyParameter();
            return await this.SendAsync<ApplicationRemovekeyParameter, ApplicationRemovekeyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovekeyResponse> ApplicationRemovekeyAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationRemovekeyParameter();
            return await this.SendAsync<ApplicationRemovekeyParameter, ApplicationRemovekeyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovekeyResponse> ApplicationRemovekeyAsync(ApplicationRemovekeyParameter parameter)
        {
            return await this.SendAsync<ApplicationRemovekeyParameter, ApplicationRemovekeyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removekey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovekeyResponse> ApplicationRemovekeyAsync(ApplicationRemovekeyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationRemovekeyParameter, ApplicationRemovekeyResponse>(parameter, cancellationToken);
        }
    }
}
