using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsMacosofficesuiteappCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsMacosofficesuiteappCreateParameterMobileAppPublishingState
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
        public IntuneAppsMacosofficesuiteappCreateParameterMobileAppPublishingState PublishingState { get; set; }
    }
    public partial class IntuneAppsMacosofficesuiteappCreateResponse : RestApiResponse
    {
        public enum MacOSOfficeSuiteAppMobileAppPublishingState
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
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-macosofficesuiteapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMacosofficesuiteappCreateResponse> IntuneAppsMacosofficesuiteappCreateAsync()
        {
            var p = new IntuneAppsMacosofficesuiteappCreateParameter();
            return await this.SendAsync<IntuneAppsMacosofficesuiteappCreateParameter, IntuneAppsMacosofficesuiteappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-macosofficesuiteapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMacosofficesuiteappCreateResponse> IntuneAppsMacosofficesuiteappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsMacosofficesuiteappCreateParameter();
            return await this.SendAsync<IntuneAppsMacosofficesuiteappCreateParameter, IntuneAppsMacosofficesuiteappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-macosofficesuiteapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMacosofficesuiteappCreateResponse> IntuneAppsMacosofficesuiteappCreateAsync(IntuneAppsMacosofficesuiteappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsMacosofficesuiteappCreateParameter, IntuneAppsMacosofficesuiteappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-macosofficesuiteapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsMacosofficesuiteappCreateResponse> IntuneAppsMacosofficesuiteappCreateAsync(IntuneAppsMacosofficesuiteappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsMacosofficesuiteappCreateParameter, IntuneAppsMacosofficesuiteappCreateResponse>(parameter, cancellationToken);
        }
    }
}
