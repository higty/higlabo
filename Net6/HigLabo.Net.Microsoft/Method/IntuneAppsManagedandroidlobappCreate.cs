using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagedandroidlobappCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsManagedandroidlobappCreateParameterMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum IntuneAppsManagedandroidlobappCreateParameterManagedAppAvailability
        {
            Global,
            LineOfBusiness,
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
        public IntuneAppsManagedandroidlobappCreateParameterMobileAppPublishingState PublishingState { get; set; }
        public IntuneAppsManagedandroidlobappCreateParameterManagedAppAvailability AppAvailability { get; set; }
        public string? Version { get; set; }
        public string? CommittedContentVersion { get; set; }
        public string? FileName { get; set; }
        public Int64? Size { get; set; }
        public string? PackageId { get; set; }
        public AndroidMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
        public string? VersionName { get; set; }
        public string? VersionCode { get; set; }
    }
    public partial class IntuneAppsManagedandroidlobappCreateResponse : RestApiResponse
    {
        public enum ManagedAndroidLobAppMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum ManagedAndroidLobAppManagedAppAvailability
        {
            Global,
            LineOfBusiness,
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
        public ManagedAppAvailability? AppAvailability { get; set; }
        public string? Version { get; set; }
        public string? CommittedContentVersion { get; set; }
        public string? FileName { get; set; }
        public Int64? Size { get; set; }
        public string? PackageId { get; set; }
        public AndroidMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
        public string? VersionName { get; set; }
        public string? VersionCode { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidlobapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidlobappCreateResponse> IntuneAppsManagedandroidlobappCreateAsync()
        {
            var p = new IntuneAppsManagedandroidlobappCreateParameter();
            return await this.SendAsync<IntuneAppsManagedandroidlobappCreateParameter, IntuneAppsManagedandroidlobappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidlobapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidlobappCreateResponse> IntuneAppsManagedandroidlobappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagedandroidlobappCreateParameter();
            return await this.SendAsync<IntuneAppsManagedandroidlobappCreateParameter, IntuneAppsManagedandroidlobappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidlobapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidlobappCreateResponse> IntuneAppsManagedandroidlobappCreateAsync(IntuneAppsManagedandroidlobappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagedandroidlobappCreateParameter, IntuneAppsManagedandroidlobappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidlobapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidlobappCreateResponse> IntuneAppsManagedandroidlobappCreateAsync(IntuneAppsManagedandroidlobappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagedandroidlobappCreateParameter, IntuneAppsManagedandroidlobappCreateResponse>(parameter, cancellationToken);
        }
    }
}
