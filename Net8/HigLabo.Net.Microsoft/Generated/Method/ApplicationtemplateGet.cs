using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-get?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationTemplateGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

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
    public partial class ApplicationTemplateGetResponse : RestApiResponse
    {
        public String[]? Categories { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? HomePageUrl { get; set; }
        public string? Id { get; set; }
        public string? LogoUrl { get; set; }
        public string? Publisher { get; set; }
        public String[]? SupportedProvisioningTypes { get; set; }
        public String[]? SupportedSingleSignOnModes { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationTemplateGetResponse> ApplicationTemplateGetAsync()
        {
            var p = new ApplicationTemplateGetParameter();
            return await this.SendAsync<ApplicationTemplateGetParameter, ApplicationTemplateGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationTemplateGetResponse> ApplicationTemplateGetAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationTemplateGetParameter();
            return await this.SendAsync<ApplicationTemplateGetParameter, ApplicationTemplateGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationTemplateGetResponse> ApplicationTemplateGetAsync(ApplicationTemplateGetParameter parameter)
        {
            return await this.SendAsync<ApplicationTemplateGetParameter, ApplicationTemplateGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationTemplateGetResponse> ApplicationTemplateGetAsync(ApplicationTemplateGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationTemplateGetParameter, ApplicationTemplateGetResponse>(parameter, cancellationToken);
        }
    }
}
