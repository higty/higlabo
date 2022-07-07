using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationcategoryDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Education_Classes_EducationClassId_AssignmentCategories_Delta,
            Education_Classes_EducationClassId_Assignments_EducationAssignmentId_Categories_Delta,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_EducationClassId_AssignmentCategories_Delta: return $"/education/classes/{EducationClassId}/assignmentCategories/delta";
                    case ApiPath.Education_Classes_EducationClassId_Assignments_EducationAssignmentId_Categories_Delta: return $"/education/classes/{EducationClassId}/assignments/{EducationAssignmentId}/categories/delta";
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
        public string EducationClassId { get; set; }
        public string EducationAssignmentId { get; set; }
    }
    public partial class EducationcategoryDeltaResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/educationcategory?view=graph-rest-1.0
        /// </summary>
        public partial class EducationCategory
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
        }

        public EducationCategory[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeltaResponse> EducationcategoryDeltaAsync()
        {
            var p = new EducationcategoryDeltaParameter();
            return await this.SendAsync<EducationcategoryDeltaParameter, EducationcategoryDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeltaResponse> EducationcategoryDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new EducationcategoryDeltaParameter();
            return await this.SendAsync<EducationcategoryDeltaParameter, EducationcategoryDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeltaResponse> EducationcategoryDeltaAsync(EducationcategoryDeltaParameter parameter)
        {
            return await this.SendAsync<EducationcategoryDeltaParameter, EducationcategoryDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeltaResponse> EducationcategoryDeltaAsync(EducationcategoryDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationcategoryDeltaParameter, EducationcategoryDeltaResponse>(parameter, cancellationToken);
        }
    }
}
