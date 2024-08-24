using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-submissions?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentListSubmissionsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ClassesId { get; set; }
            public string? AssignmentsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Submissions: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/submissions";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Submissions,
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
    public partial class EducationAssignmentListSubmissionsResponse : RestApiResponse<EducationSubmission>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-submissions?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-submissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentListSubmissionsResponse> EducationAssignmentListSubmissionsAsync()
        {
            var p = new EducationAssignmentListSubmissionsParameter();
            return await this.SendAsync<EducationAssignmentListSubmissionsParameter, EducationAssignmentListSubmissionsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-submissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentListSubmissionsResponse> EducationAssignmentListSubmissionsAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentListSubmissionsParameter();
            return await this.SendAsync<EducationAssignmentListSubmissionsParameter, EducationAssignmentListSubmissionsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-submissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentListSubmissionsResponse> EducationAssignmentListSubmissionsAsync(EducationAssignmentListSubmissionsParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentListSubmissionsParameter, EducationAssignmentListSubmissionsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-submissions?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentListSubmissionsResponse> EducationAssignmentListSubmissionsAsync(EducationAssignmentListSubmissionsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentListSubmissionsParameter, EducationAssignmentListSubmissionsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-list-submissions?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EducationSubmission> EducationAssignmentListSubmissionsEnumerateAsync(EducationAssignmentListSubmissionsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<EducationAssignmentListSubmissionsParameter, EducationAssignmentListSubmissionsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<EducationSubmission>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
