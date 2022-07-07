using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigIosupdateconfigurationCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigIosupdateconfigurationCreateParameterDayOfWeek
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public TimeOnly? ActiveHoursStart { get; set; }
        public TimeOnly? ActiveHoursEnd { get; set; }
        public IntuneDeviceconfigIosupdateconfigurationCreateParameterDayOfWeek ScheduledInstallDays { get; set; }
        public Int32? UtcTimeOffsetInMinutes { get; set; }
    }
    public partial class IntuneDeviceconfigIosupdateconfigurationCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public TimeOnly? ActiveHoursStart { get; set; }
        public TimeOnly? ActiveHoursEnd { get; set; }
        public DayOfWeek[]? ScheduledInstallDays { get; set; }
        public Int32? UtcTimeOffsetInMinutes { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationCreateResponse> IntuneDeviceconfigIosupdateconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigIosupdateconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationCreateParameter, IntuneDeviceconfigIosupdateconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationCreateResponse> IntuneDeviceconfigIosupdateconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigIosupdateconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationCreateParameter, IntuneDeviceconfigIosupdateconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationCreateResponse> IntuneDeviceconfigIosupdateconfigurationCreateAsync(IntuneDeviceconfigIosupdateconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationCreateParameter, IntuneDeviceconfigIosupdateconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-iosupdateconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigIosupdateconfigurationCreateResponse> IntuneDeviceconfigIosupdateconfigurationCreateAsync(IntuneDeviceconfigIosupdateconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigIosupdateconfigurationCreateParameter, IntuneDeviceconfigIosupdateconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
