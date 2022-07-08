using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationtemplateInstantiateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ApplicationTemplateId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ApplicationTemplates_ApplicationTemplateId_Instantiate: return $"/applicationTemplates/{ApplicationTemplateId}/instantiate";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            ApplicationTemplates_ApplicationTemplateId_Instantiate,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public Application? Application { get; set; }
        public ServicePrincipal? ServicePrincipal { get; set; }
    }
    public partial class ApplicationtemplateInstantiateResponse : RestApiResponse
    {
        public Application? Application { get; set; }
        public ServicePrincipal? ServicePrincipal { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-instantiate?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateInstantiateResponse> ApplicationtemplateInstantiateAsync()
        {
            var p = new ApplicationtemplateInstantiateParameter();
            return await this.SendAsync<ApplicationtemplateInstantiateParameter, ApplicationtemplateInstantiateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-instantiate?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateInstantiateResponse> ApplicationtemplateInstantiateAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationtemplateInstantiateParameter();
            return await this.SendAsync<ApplicationtemplateInstantiateParameter, ApplicationtemplateInstantiateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-instantiate?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateInstantiateResponse> ApplicationtemplateInstantiateAsync(ApplicationtemplateInstantiateParameter parameter)
        {
            return await this.SendAsync<ApplicationtemplateInstantiateParameter, ApplicationtemplateInstantiateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-instantiate?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateInstantiateResponse> ApplicationtemplateInstantiateAsync(ApplicationtemplateInstantiateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationtemplateInstantiateParameter, ApplicationtemplateInstantiateResponse>(parameter, cancellationToken);
        }
    }
}
