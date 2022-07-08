using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ApplicationtemplateListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ApplicationTemplates: return $"/applicationTemplates";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Categories,
            Description,
            DisplayName,
            HomePageUrl,
            Id,
            LogoUrl,
            Publisher,
            SupportedProvisioningTypes,
            SupportedSingleSignOnModes,
        }
        public enum ApiPath
        {
            ApplicationTemplates,
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
    public partial class ApplicationtemplateListResponse : RestApiResponse
    {
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
