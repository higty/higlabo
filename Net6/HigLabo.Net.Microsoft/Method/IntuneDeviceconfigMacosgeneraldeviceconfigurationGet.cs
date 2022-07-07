using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacosgeneraldeviceconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations_DeviceConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations_DeviceConfigurationId: return $"/deviceManagement/deviceConfigurations/{DeviceConfigurationId}";
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
    public partial class IntuneDeviceconfigMacosgeneraldeviceconfigurationGetResponse : RestApiResponse
    {
        public enum MacOSGeneralDeviceConfigurationAppListType
        {
            None,
            AppsInListCompliant,
            AppsNotInListCompliant,
        }
        public enum MacOSGeneralDeviceConfigurationRequiredPasswordType
        {
            DeviceDefault,
            Alphanumeric,
            Numeric,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public AppListItem[]? CompliantAppsList { get; set; }
        public AppListType? CompliantAppListType { get; set; }
        public String[]? EmailInDomainSuffixes { get; set; }
        public bool? PasswordBlockSimple { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinimumCharacterSetCount { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public RequiredPasswordType? PasswordRequiredType { get; set; }
        public bool? PasswordRequired { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationGetResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationGetAsync()
        {
            var p = new IntuneDeviceconfigMacosgeneraldeviceconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationGetParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationGetResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacosgeneraldeviceconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationGetParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationGetResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationGetAsync(IntuneDeviceconfigMacosgeneraldeviceconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationGetParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationGetResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationGetAsync(IntuneDeviceconfigMacosgeneraldeviceconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationGetParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
