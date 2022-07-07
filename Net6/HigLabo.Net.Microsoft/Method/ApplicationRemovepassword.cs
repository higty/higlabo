using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationRemovepasswordParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Applications_Id_RemovePassword,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Applications_Id_RemovePassword: return $"/applications/{Id}/removePassword";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public Guid? KeyId { get; set; }
        public string Id { get; set; }
    }
    public partial class ApplicationRemovepasswordResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovepasswordResponse> ApplicationRemovepasswordAsync()
        {
            var p = new ApplicationRemovepasswordParameter();
            return await this.SendAsync<ApplicationRemovepasswordParameter, ApplicationRemovepasswordResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovepasswordResponse> ApplicationRemovepasswordAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationRemovepasswordParameter();
            return await this.SendAsync<ApplicationRemovepasswordParameter, ApplicationRemovepasswordResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovepasswordResponse> ApplicationRemovepasswordAsync(ApplicationRemovepasswordParameter parameter)
        {
            return await this.SendAsync<ApplicationRemovepasswordParameter, ApplicationRemovepasswordResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-removepassword?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationRemovepasswordResponse> ApplicationRemovepasswordAsync(ApplicationRemovepasswordParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationRemovepasswordParameter, ApplicationRemovepasswordResponse>(parameter, cancellationToken);
        }
    }
}
