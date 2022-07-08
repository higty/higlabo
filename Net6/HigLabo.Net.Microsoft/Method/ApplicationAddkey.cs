using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationAddkeyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_AddKey: return $"/applications/{Id}/addKey";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_AddKey,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public KeyCredential? KeyCredential { get; set; }
        public PasswordCredential? PasswordCredential { get; set; }
        public string? Proof { get; set; }
        public string? CustomKeyIdentifier { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Key { get; set; }
        public Guid? KeyId { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? Type { get; set; }
        public string? Usage { get; set; }
    }
    public partial class ApplicationAddkeyResponse : RestApiResponse
    {
        public string? CustomKeyIdentifier { get; set; }
        public string? DisplayName { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Key { get; set; }
        public Guid? KeyId { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public string? Type { get; set; }
        public string? Usage { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-addkey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationAddkeyResponse> ApplicationAddkeyAsync()
        {
            var p = new ApplicationAddkeyParameter();
            return await this.SendAsync<ApplicationAddkeyParameter, ApplicationAddkeyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-addkey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationAddkeyResponse> ApplicationAddkeyAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationAddkeyParameter();
            return await this.SendAsync<ApplicationAddkeyParameter, ApplicationAddkeyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-addkey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationAddkeyResponse> ApplicationAddkeyAsync(ApplicationAddkeyParameter parameter)
        {
            return await this.SendAsync<ApplicationAddkeyParameter, ApplicationAddkeyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-addkey?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationAddkeyResponse> ApplicationAddkeyAsync(ApplicationAddkeyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationAddkeyParameter, ApplicationAddkeyResponse>(parameter, cancellationToken);
        }
    }
}
