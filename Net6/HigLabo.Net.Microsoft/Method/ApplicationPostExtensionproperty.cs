using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationPostExtensionpropertyParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ApplicationObjectId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Applications_ApplicationObjectId_ExtensionProperties: return $"/applications/{ApplicationObjectId}/extensionProperties";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Applications_ApplicationObjectId_ExtensionProperties,
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
        public string? DataType { get; set; }
        public string? Name { get; set; }
        public String[]? TargetObjects { get; set; }
        public string? AppDisplayName { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public bool? IsSyncedFromOnPremises { get; set; }
    }
    public partial class ApplicationPostExtensionpropertyResponse : RestApiResponse
    {
        public string? AppDisplayName { get; set; }
        public string? DataType { get; set; }
        public DateTimeOffset? DeletedDateTime { get; set; }
        public bool? IsSyncedFromOnPremises { get; set; }
        public string? Name { get; set; }
        public String[]? TargetObjects { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-extensionproperty?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostExtensionpropertyResponse> ApplicationPostExtensionpropertyAsync()
        {
            var p = new ApplicationPostExtensionpropertyParameter();
            return await this.SendAsync<ApplicationPostExtensionpropertyParameter, ApplicationPostExtensionpropertyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-extensionproperty?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostExtensionpropertyResponse> ApplicationPostExtensionpropertyAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationPostExtensionpropertyParameter();
            return await this.SendAsync<ApplicationPostExtensionpropertyParameter, ApplicationPostExtensionpropertyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-extensionproperty?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostExtensionpropertyResponse> ApplicationPostExtensionpropertyAsync(ApplicationPostExtensionpropertyParameter parameter)
        {
            return await this.SendAsync<ApplicationPostExtensionpropertyParameter, ApplicationPostExtensionpropertyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/application-post-extensionproperty?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationPostExtensionpropertyResponse> ApplicationPostExtensionpropertyAsync(ApplicationPostExtensionpropertyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationPostExtensionpropertyParameter, ApplicationPostExtensionpropertyResponse>(parameter, cancellationToken);
        }
    }
}
