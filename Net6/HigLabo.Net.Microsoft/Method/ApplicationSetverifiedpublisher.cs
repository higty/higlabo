using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationSetverifiedpublisherParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_SetVerifiedPublisher: return $"/applications/{Id}/setVerifiedPublisher";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_SetVerifiedPublisher,
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
        public string? VerifiedPublisherId { get; set; }
    }
    public partial class ApplicationSetverifiedpublisherResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-setverifiedpublisher?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationSetverifiedpublisherResponse> ApplicationSetverifiedpublisherAsync()
        {
            var p = new ApplicationSetverifiedpublisherParameter();
            return await this.SendAsync<ApplicationSetverifiedpublisherParameter, ApplicationSetverifiedpublisherResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-setverifiedpublisher?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationSetverifiedpublisherResponse> ApplicationSetverifiedpublisherAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationSetverifiedpublisherParameter();
            return await this.SendAsync<ApplicationSetverifiedpublisherParameter, ApplicationSetverifiedpublisherResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-setverifiedpublisher?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationSetverifiedpublisherResponse> ApplicationSetverifiedpublisherAsync(ApplicationSetverifiedpublisherParameter parameter)
        {
            return await this.SendAsync<ApplicationSetverifiedpublisherParameter, ApplicationSetverifiedpublisherResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-setverifiedpublisher?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationSetverifiedpublisherResponse> ApplicationSetverifiedpublisherAsync(ApplicationSetverifiedpublisherParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationSetverifiedpublisherParameter, ApplicationSetverifiedpublisherResponse>(parameter, cancellationToken);
        }
    }
}
