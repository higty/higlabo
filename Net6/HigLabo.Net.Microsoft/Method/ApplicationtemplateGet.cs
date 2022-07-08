using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationtemplateGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ApplicationTemplates_Id: return $"/applicationTemplates/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            ApplicationTemplates_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class ApplicationtemplateGetResponse : RestApiResponse
    {
        public enum ApplicationTemplateString
        {
            Oidc,
            Password,
            Saml,
            NotSupported,
        }

        public String[]? Categories { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? HomePageUrl { get; set; }
        public string? Id { get; set; }
        public string? LogoUrl { get; set; }
        public string? Publisher { get; set; }
        public String[]? SupportedProvisioningTypes { get; set; }
        public ApplicationTemplateString SupportedSingleSignOnModes { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateGetResponse> ApplicationtemplateGetAsync()
        {
            var p = new ApplicationtemplateGetParameter();
            return await this.SendAsync<ApplicationtemplateGetParameter, ApplicationtemplateGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateGetResponse> ApplicationtemplateGetAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationtemplateGetParameter();
            return await this.SendAsync<ApplicationtemplateGetParameter, ApplicationtemplateGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateGetResponse> ApplicationtemplateGetAsync(ApplicationtemplateGetParameter parameter)
        {
            return await this.SendAsync<ApplicationtemplateGetParameter, ApplicationtemplateGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateGetResponse> ApplicationtemplateGetAsync(ApplicationtemplateGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationtemplateGetParameter, ApplicationtemplateGetResponse>(parameter, cancellationToken);
        }
    }
}
