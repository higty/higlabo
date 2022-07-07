using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesApplepushnotificationcertificateGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_ApplePushNotificationCertificate,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ApplePushNotificationCertificate: return $"/deviceManagement/applePushNotificationCertificate";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneDevicesApplepushnotificationcertificateGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? AppleIdentifier { get; set; }
        public string? TopicIdentifier { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public string? CertificateSerialNumber { get; set; }
        public string? Certificate { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-applepushnotificationcertificate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesApplepushnotificationcertificateGetResponse> IntuneDevicesApplepushnotificationcertificateGetAsync()
        {
            var p = new IntuneDevicesApplepushnotificationcertificateGetParameter();
            return await this.SendAsync<IntuneDevicesApplepushnotificationcertificateGetParameter, IntuneDevicesApplepushnotificationcertificateGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-applepushnotificationcertificate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesApplepushnotificationcertificateGetResponse> IntuneDevicesApplepushnotificationcertificateGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesApplepushnotificationcertificateGetParameter();
            return await this.SendAsync<IntuneDevicesApplepushnotificationcertificateGetParameter, IntuneDevicesApplepushnotificationcertificateGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-applepushnotificationcertificate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesApplepushnotificationcertificateGetResponse> IntuneDevicesApplepushnotificationcertificateGetAsync(IntuneDevicesApplepushnotificationcertificateGetParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesApplepushnotificationcertificateGetParameter, IntuneDevicesApplepushnotificationcertificateGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-applepushnotificationcertificate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesApplepushnotificationcertificateGetResponse> IntuneDevicesApplepushnotificationcertificateGetAsync(IntuneDevicesApplepushnotificationcertificateGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesApplepushnotificationcertificateGetParameter, IntuneDevicesApplepushnotificationcertificateGetResponse>(parameter, cancellationToken);
        }
    }
}
