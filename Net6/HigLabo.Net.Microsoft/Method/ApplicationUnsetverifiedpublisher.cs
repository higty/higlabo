using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationUnsetverifiedpublisherParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_Id_UnsetVerifiedPublisher: return $"/applications/{Id}/unsetVerifiedPublisher";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_Id_UnsetVerifiedPublisher,
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
    }
    public partial class ApplicationUnsetverifiedpublisherResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-unsetverifiedpublisher?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationUnsetverifiedpublisherResponse> ApplicationUnsetverifiedpublisherAsync()
        {
            var p = new ApplicationUnsetverifiedpublisherParameter();
            return await this.SendAsync<ApplicationUnsetverifiedpublisherParameter, ApplicationUnsetverifiedpublisherResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-unsetverifiedpublisher?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationUnsetverifiedpublisherResponse> ApplicationUnsetverifiedpublisherAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationUnsetverifiedpublisherParameter();
            return await this.SendAsync<ApplicationUnsetverifiedpublisherParameter, ApplicationUnsetverifiedpublisherResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-unsetverifiedpublisher?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationUnsetverifiedpublisherResponse> ApplicationUnsetverifiedpublisherAsync(ApplicationUnsetverifiedpublisherParameter parameter)
        {
            return await this.SendAsync<ApplicationUnsetverifiedpublisherParameter, ApplicationUnsetverifiedpublisherResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-unsetverifiedpublisher?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationUnsetverifiedpublisherResponse> ApplicationUnsetverifiedpublisherAsync(ApplicationUnsetverifiedpublisherParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationUnsetverifiedpublisherParameter, ApplicationUnsetverifiedpublisherResponse>(parameter, cancellationToken);
        }
    }
}
