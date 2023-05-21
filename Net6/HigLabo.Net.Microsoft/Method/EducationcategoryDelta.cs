using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
    /// </summary>
    public partial class EducationcategoryDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EducationClassId { get; set; }
            public string? EducationAssignmentId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_EducationClassId_AssignmentCategories_Delta: return $"/education/classes/{EducationClassId}/assignmentCategories/delta";
                    case ApiPath.Education_Classes_EducationClassId_Assignments_EducationAssignmentId_Categories_Delta: return $"/education/classes/{EducationClassId}/assignments/{EducationAssignmentId}/categories/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
        }
        public enum ApiPath
        {
            Education_Classes_EducationClassId_AssignmentCategories_Delta,
            Education_Classes_EducationClassId_Assignments_EducationAssignmentId_Categories_Delta,
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
    public partial class EducationcategoryDeltaResponse : RestApiResponse
    {
        public EducationCategory[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeltaResponse> EducationcategoryDeltaAsync()
        {
            var p = new EducationcategoryDeltaParameter();
            return await this.SendAsync<EducationcategoryDeltaParameter, EducationcategoryDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeltaResponse> EducationcategoryDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new EducationcategoryDeltaParameter();
            return await this.SendAsync<EducationcategoryDeltaParameter, EducationcategoryDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeltaResponse> EducationcategoryDeltaAsync(EducationcategoryDeltaParameter parameter)
        {
            return await this.SendAsync<EducationcategoryDeltaParameter, EducationcategoryDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationcategory-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationcategoryDeltaResponse> EducationcategoryDeltaAsync(EducationcategoryDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationcategoryDeltaParameter, EducationcategoryDeltaResponse>(parameter, cancellationToken);
        }
    }
}
