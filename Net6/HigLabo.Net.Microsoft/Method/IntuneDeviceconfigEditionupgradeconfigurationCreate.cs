using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigEditionupgradeconfigurationCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigEditionupgradeconfigurationCreateParameterEditionUpgradeLicenseType
        {
            ProductKey,
            LicenseFile,
        }
        public enum IntuneDeviceconfigEditionupgradeconfigurationCreateParameterWindows10EditionType
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
        public IntuneDeviceconfigEditionupgradeconfigurationCreateParameterEditionUpgradeLicenseType LicenseType { get; set; }
        public IntuneDeviceconfigEditionupgradeconfigurationCreateParameterWindows10EditionType TargetEdition { get; set; }
        public string? License { get; set; }
        public string? ProductKey { get; set; }
    }
    public partial class IntuneDeviceconfigEditionupgradeconfigurationCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationCreateResponse> IntuneDeviceconfigEditionupgradeconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigEditionupgradeconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationCreateParameter, IntuneDeviceconfigEditionupgradeconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationCreateResponse> IntuneDeviceconfigEditionupgradeconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigEditionupgradeconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationCreateParameter, IntuneDeviceconfigEditionupgradeconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationCreateResponse> IntuneDeviceconfigEditionupgradeconfigurationCreateAsync(IntuneDeviceconfigEditionupgradeconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationCreateParameter, IntuneDeviceconfigEditionupgradeconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-editionupgradeconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigEditionupgradeconfigurationCreateResponse> IntuneDeviceconfigEditionupgradeconfigurationCreateAsync(IntuneDeviceconfigEditionupgradeconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigEditionupgradeconfigurationCreateParameter, IntuneDeviceconfigEditionupgradeconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
