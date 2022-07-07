using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDeviceconfigurationassignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId_Assignments_DeviceConfigurationAssignmentId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId_Assignments_DeviceConfigurationAssignmentId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}/assignments/{DeviceConfigurationAssignmentId}";
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
        public string DeviceConfigurationAssignmentId { get; set; }
    }
    public partial class IntuneDeviceconfigDeviceconfigurationassignmentGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentGetResponse> IntuneDeviceconfigDeviceconfigurationassignmentGetAsync()
        {
            var p = new IntuneDeviceconfigDeviceconfigurationassignmentGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentGetParameter, IntuneDeviceconfigDeviceconfigurationassignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentGetResponse> IntuneDeviceconfigDeviceconfigurationassignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDeviceconfigurationassignmentGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentGetParameter, IntuneDeviceconfigDeviceconfigurationassignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentGetResponse> IntuneDeviceconfigDeviceconfigurationassignmentGetAsync(IntuneDeviceconfigDeviceconfigurationassignmentGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentGetParameter, IntuneDeviceconfigDeviceconfigurationassignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-deviceconfigurationassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDeviceconfigurationassignmentGetResponse> IntuneDeviceconfigDeviceconfigurationassignmentGetAsync(IntuneDeviceconfigDeviceconfigurationassignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDeviceconfigurationassignmentGetParameter, IntuneDeviceconfigDeviceconfigurationassignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
