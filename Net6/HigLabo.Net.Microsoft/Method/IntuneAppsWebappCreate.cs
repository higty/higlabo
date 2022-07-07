using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsWebappCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsWebappCreateParameterMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum ApiPath
        {
            DeviceAppManagement_MobileApps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_MobileApps: return $"/deviceAppManagement/mobileApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public MimeContent? LargeIcon { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public bool? IsFeatured { get; set; }
        public string? PrivacyInformationUrl { get; set; }
        public string? InformationUrl { get; set; }
        public string? Owner { get; set; }
        public string? Developer { get; set; }
        public string? Notes { get; set; }
        public IntuneAppsWebappCreateParameterMobileAppPublishingState PublishingState { get; set; }
        public string? AppUrl { get; set; }
        public bool? UseManagedBrowser { get; set; }
    }
    public partial class IntuneAppsWebappCreateResponse : RestApiResponse
    {
        public enum WebAppMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }

        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public MimeContent? LargeIcon { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public bool? IsFeatured { get; set; }
        public string? PrivacyInformationUrl { get; set; }
        public string? InformationUrl { get; set; }
        public string? Owner { get; set; }
        public string? Developer { get; set; }
        public string? Notes { get; set; }
        public MobileAppPublishingState? PublishingState { get; set; }
        public string? AppUrl { get; set; }
        public bool? UseManagedBrowser { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappCreateResponse> IntuneAppsWebappCreateAsync()
        {
            var p = new IntuneAppsWebappCreateParameter();
            return await this.SendAsync<IntuneAppsWebappCreateParameter, IntuneAppsWebappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappCreateResponse> IntuneAppsWebappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsWebappCreateParameter();
            return await this.SendAsync<IntuneAppsWebappCreateParameter, IntuneAppsWebappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappCreateResponse> IntuneAppsWebappCreateAsync(IntuneAppsWebappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsWebappCreateParameter, IntuneAppsWebappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-webapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsWebappCreateResponse> IntuneAppsWebappCreateAsync(IntuneAppsWebappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsWebappCreateParameter, IntuneAppsWebappCreateResponse>(parameter, cancellationToken);
        }
    }
}
