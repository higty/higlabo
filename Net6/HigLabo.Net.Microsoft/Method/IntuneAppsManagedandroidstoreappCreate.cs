using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsManagedandroidstoreappCreateParameter : IRestApiParameter
    {
        public enum IntuneAppsManagedandroidstoreappCreateParameterMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum IntuneAppsManagedandroidstoreappCreateParameterManagedAppAvailability
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
        public IntuneAppsManagedandroidstoreappCreateParameterMobileAppPublishingState PublishingState { get; set; }
        public IntuneAppsManagedandroidstoreappCreateParameterManagedAppAvailability AppAvailability { get; set; }
        public string? Version { get; set; }
        public string? PackageId { get; set; }
        public string? AppStoreUrl { get; set; }
        public AndroidMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
    }
    public partial class IntuneAppsManagedandroidstoreappCreateResponse : RestApiResponse
    {
        public enum ManagedAndroidStoreAppMobileAppPublishingState
        {
            NotPublished,
            Processing,
            Published,
        }
        public enum ManagedAndroidStoreAppManagedAppAvailability
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
        public string? PackageId { get; set; }
        public string? AppStoreUrl { get; set; }
        public AndroidMinimumOperatingSystem? MinimumSupportedOperatingSystem { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappCreateResponse> IntuneAppsManagedandroidstoreappCreateAsync()
        {
            var p = new IntuneAppsManagedandroidstoreappCreateParameter();
            return await this.SendAsync<IntuneAppsManagedandroidstoreappCreateParameter, IntuneAppsManagedandroidstoreappCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappCreateResponse> IntuneAppsManagedandroidstoreappCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsManagedandroidstoreappCreateParameter();
            return await this.SendAsync<IntuneAppsManagedandroidstoreappCreateParameter, IntuneAppsManagedandroidstoreappCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappCreateResponse> IntuneAppsManagedandroidstoreappCreateAsync(IntuneAppsManagedandroidstoreappCreateParameter parameter)
        {
            return await this.SendAsync<IntuneAppsManagedandroidstoreappCreateParameter, IntuneAppsManagedandroidstoreappCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-managedandroidstoreapp-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsManagedandroidstoreappCreateResponse> IntuneAppsManagedandroidstoreappCreateAsync(IntuneAppsManagedandroidstoreappCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsManagedandroidstoreappCreateParameter, IntuneAppsManagedandroidstoreappCreateResponse>(parameter, cancellationToken);
        }
    }
}
