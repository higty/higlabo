using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigEditionupgradeconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigEditionupgradeconfigurationGetResponse : RestApiResponse
    {
        public enum EditionUpgradeConfigurationEditionUpgradeLicenseType
        {
            ProductKey,
            LicenseFile,
        }
        public enum EditionUpgradeConfigurationWindows10EditionType
        {
            Windows10Enterprise,
            Windows10EnterpriseN,
            Windows10Education,
            Windows10EducationN,
            Windows10MobileEnterprise,
            Windows10HolographicEnterprise,
            Windows10Professional,
            Windows10ProfessionalN,
            Windows10ProfessionalEducation,
            Windows10ProfessionalEducationN,
            Windows10ProfessionalWorkstation,
            Windows10ProfessionalWorkstationN,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public EditionUpgradeLicenseType? LicenseType { get; set; }
        public Windows10EditionType? TargetEdition { get; set; }
        public string? License { get; set; }
        public string? ProductKey { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationGetResponse> IntuneDeviceconfigEditionupgradeconfigurationGetAsync()
        {
            var p = new IntuneDeviceconfigEditionupgradeconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationGetParameter, IntuneDeviceconfigEditionupgradeconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationGetResponse> IntuneDeviceconfigEditionupgradeconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigEditionupgradeconfigurationGetParameter();
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationGetParameter, IntuneDeviceconfigEditionupgradeconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationGetResponse> IntuneDeviceconfigEditionupgradeconfigurationGetAsync(IntuneDeviceconfigEditionupgradeconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationGetParameter, IntuneDeviceconfigEditionupgradeconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationGetResponse> IntuneDeviceconfigEditionupgradeconfigurationGetAsync(IntuneDeviceconfigEditionupgradeconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationGetParameter, IntuneDeviceconfigEditionupgradeconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
