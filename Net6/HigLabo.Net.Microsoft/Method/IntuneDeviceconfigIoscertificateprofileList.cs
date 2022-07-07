using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIoscertificateprofileListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations: return $"/deviceManagement/deviceConfigurations";
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
    public partial class IntuneDeviceconfigIoscertificateprofileListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-ioscertificateprofile?view=graph-rest-1.0
        /// </summary>
        public partial class IosCertificateProfile
        {
            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
        }

        public IosCertificateProfile[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscertificateprofile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscertificateprofileListResponse> IntuneDeviceconfigIoscertificateprofileListAsync()
        {
            var p = new IntuneDeviceconfigIoscertificateprofileListParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscertificateprofileListParameter, IntuneDeviceconfigIoscertificateprofileListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscertificateprofile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscertificateprofileListResponse> IntuneDeviceconfigIoscertificateprofileListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIoscertificateprofileListParameter();
            return await this.SendAsync<IntuneDeviceconfigIoscertificateprofileListParameter, IntuneDeviceconfigIoscertificateprofileListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscertificateprofile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscertificateprofileListResponse> IntuneDeviceconfigIoscertificateprofileListAsync(IntuneDeviceconfigIoscertificateprofileListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscertificateprofileListParameter, IntuneDeviceconfigIoscertificateprofileListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-ioscertificateprofile-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIoscertificateprofileListResponse> IntuneDeviceconfigIoscertificateprofileListAsync(IntuneDeviceconfigIoscertificateprofileListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIoscertificateprofileListParameter, IntuneDeviceconfigIoscertificateprofileListResponse>(parameter, cancellationToken);
        }
    }
}
