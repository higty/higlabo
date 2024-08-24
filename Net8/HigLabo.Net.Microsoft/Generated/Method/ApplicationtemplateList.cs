using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-list?view=graph-rest-1.0
    /// </summary>
    public partial class ApplicationTemplateListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class ApplicationTemplateListResponse : RestApiResponse<ApplicationTemplate>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationTemplateListResponse> ApplicationTemplateListAsync()
        {
            var p = new ApplicationTemplateListParameter();
            return await this.SendAsync<ApplicationTemplateListParameter, ApplicationTemplateListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationTemplateListResponse> ApplicationTemplateListAsync(CancellationToken cancellationToken)
        {
            var p = new ApplicationTemplateListParameter();
            return await this.SendAsync<ApplicationTemplateListParameter, ApplicationTemplateListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationTemplateListResponse> ApplicationTemplateListAsync(ApplicationTemplateListParameter parameter)
        {
            return await this.SendAsync<ApplicationTemplateListParameter, ApplicationTemplateListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ApplicationTemplateListResponse> ApplicationTemplateListAsync(ApplicationTemplateListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ApplicationTemplateListParameter, ApplicationTemplateListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/applicationtemplate-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ApplicationTemplate> ApplicationTemplateListEnumerateAsync(ApplicationTemplateListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<ApplicationTemplateListParameter, ApplicationTemplateListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ApplicationTemplate>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
