using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-delta?view=graph-rest-1.0
    /// </summary>
    public partial class EducationSchoolDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Schools_Delta: return $"/education/schools/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Schools_Delta,
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
    public partial class EducationSchoolDeltaResponse : RestApiResponse<EducationSchool>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationschool-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeltaResponse> EducationSchoolDeltaAsync()
        {
            var p = new EducationSchoolDeltaParameter();
            return await this.SendAsync<EducationSchoolDeltaParameter, EducationSchoolDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeltaResponse> EducationSchoolDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new EducationSchoolDeltaParameter();
            return await this.SendAsync<EducationSchoolDeltaParameter, EducationSchoolDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeltaResponse> EducationSchoolDeltaAsync(EducationSchoolDeltaParameter parameter)
        {
            return await this.SendAsync<EducationSchoolDeltaParameter, EducationSchoolDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationSchoolDeltaResponse> EducationSchoolDeltaAsync(EducationSchoolDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationSchoolDeltaParameter, EducationSchoolDeltaResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationschool-delta?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EducationSchool> EducationSchoolDeltaEnumerateAsync(EducationSchoolDeltaParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<EducationSchoolDeltaParameter, EducationSchoolDeltaResponse>(parameter, cancellationToken);
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
