using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-list?view=graph-rest-1.0
    /// </summary>
    public partial class EducationSchoolListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Schools: return $"/education/schools";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Schools,
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
    public partial class EducationSchoolListResponse : RestApiResponse<EducationSchool>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolListResponse> EducationSchoolListAsync()
        {
            var p = new EducationSchoolListParameter();
            return await this.SendAsync<EducationSchoolListParameter, EducationSchoolListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolListResponse> EducationSchoolListAsync(CancellationToken cancellationToken)
        {
            var p = new EducationSchoolListParameter();
            return await this.SendAsync<EducationSchoolListParameter, EducationSchoolListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolListResponse> EducationSchoolListAsync(EducationSchoolListParameter parameter)
        {
            return await this.SendAsync<EducationSchoolListParameter, EducationSchoolListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolListResponse> EducationSchoolListAsync(EducationSchoolListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationSchoolListParameter, EducationSchoolListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EducationSchool> EducationSchoolListEnumerateAsync(EducationSchoolListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<EducationSchoolListParameter, EducationSchoolListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<EducationSchool>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
