using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationuseroverviewGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_UserStatusOverview,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_UserStatusOverview: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/userStatusOverview";
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
        public string DeviceConfigurationId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationuseroverviewGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public Int32? PendingCount { get; set; }
        public Int32? NotApplicableCount { get; set; }
        public Int32? SuccessCount { get; set; }
        public Int32? ErrorCount { get; set; }
        public Int32? FailedCount { get; set; }
        public DateTimeOffset? LastUpdateDateTime { get; set; }
        public Int32? ConfigurationVersion { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuseroverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuseroverviewGetResponse> IntuneDeviceconfigDeviceconfigurationuseroverviewGetAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationuseroverviewGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuseroverviewGetParameter, IntuneDeviceconfigDeviceconfigurationuseroverviewGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuseroverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuseroverviewGetResponse> IntuneDeviceconfigDeviceconfigurationuseroverviewGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationuseroverviewGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuseroverviewGetParameter, IntuneDeviceconfigDeviceconfigurationuseroverviewGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuseroverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuseroverviewGetResponse> IntuneDeviceconfigDeviceconfigurationuseroverviewGetAsync(IntuneDeviceconfigDeviceconfigurationuseroverviewGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuseroverviewGetParameter, IntuneDeviceconfigDeviceconfigurationuseroverviewGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationuseroverview-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationuseroverviewGetResponse> IntuneDeviceconfigDeviceconfigurationuseroverviewGetAsync(IntuneDeviceconfigDeviceconfigurationuseroverviewGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationuseroverviewGetParameter, IntuneDeviceconfigDeviceconfigurationuseroverviewGetResponse>(parameter, cancellationToken);
        }
    }
}
