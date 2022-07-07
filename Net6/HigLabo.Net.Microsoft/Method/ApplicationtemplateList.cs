using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationtemplateListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            ApplicationTemplates,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.ApplicationTemplates: return $"/applicationTemplates";
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
    public partial class ApplicationtemplateListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/applicationtemplate?view=graph-rest-1.0
        /// </summary>
        public partial class ApplicationTemplate
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

        public ApplicationTemplate[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateListResponse> ApplicationtemplateListAsync()
        {
            var p = new ApplicationtemplateListParameter();
            return await this.SendAsync<ApplicationtemplateListParameter, ApplicationtemplateListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateListResponse> ApplicationtemplateListAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationtemplateListParameter();
            return await this.SendAsync<ApplicationtemplateListParameter, ApplicationtemplateListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateListResponse> ApplicationtemplateListAsync(ApplicationtemplateListParameter parameter)
        {
            return await this.SendAsync<ApplicationtemplateListParameter, ApplicationtemplateListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/applicationtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ApplicationtemplateListResponse> ApplicationtemplateListAsync(ApplicationtemplateListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationtemplateListParameter, ApplicationtemplateListResponse>(parameter, cancellationToken);
        }
    }
}
