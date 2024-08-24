using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list?view=graph-rest-1.0
    /// </summary>
    public partial class EducationClassListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes: return $"/education/classes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes,
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
    public partial class EducationClassListResponse : RestApiResponse<EducationClass>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationClassListResponse> EducationClassListAsync()
        {
            var p = new EducationClassListParameter();
            return await this.SendAsync<EducationClassListParameter, EducationClassListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationClassListResponse> EducationClassListAsync(CancellationToken cancellationToken)
        {
            var p = new EducationClassListParameter();
            return await this.SendAsync<EducationClassListParameter, EducationClassListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationClassListResponse> EducationClassListAsync(EducationClassListParameter parameter)
        {
            return await this.SendAsync<EducationClassListParameter, EducationClassListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationClassListResponse> EducationClassListAsync(EducationClassListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationClassListParameter, EducationClassListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EducationClass> EducationClassListEnumerateAsync(EducationClassListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<EducationClassListParameter, EducationClassListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<EducationClass>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
