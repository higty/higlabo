using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameterAppListType
        {
            None,
            AppsInListCompliant,
            AppsNotInListCompliant,
        }
        public enum IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameterRequiredPasswordType
        {
            DeviceDefault,
            Alphanumeric,
            Numeric,
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
        public AppListItem[]? CompliantAppsList { get; set; }
        public IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameterAppListType CompliantAppListType { get; set; }
        public String[]? EmailInDomainSuffixes { get; set; }
        public bool? PasswordBlockSimple { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinimumCharacterSetCount { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeLock { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameterRequiredPasswordType PasswordRequiredType { get; set; }
        public bool? PasswordRequired { get; set; }
    }
    public partial class IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateAsync(IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-macosgeneraldeviceconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateResponse> IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateAsync(IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateParameter, IntuneDeviceconfigMacosgeneraldeviceconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
