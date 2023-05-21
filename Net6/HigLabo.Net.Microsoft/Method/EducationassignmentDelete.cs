using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentDeleteParameter : IRestApiParameter
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
                    case ApiPath.Education_Classes_Id_Assignments_Id: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class EducationAssignmentDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentDeleteResponse> EducationAssignmentDeleteAsync()
        {
            var p = new EducationAssignmentDeleteParameter();
            return await this.SendAsync<EducationAssignmentDeleteParameter, EducationAssignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentDeleteResponse> EducationAssignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentDeleteParameter();
            return await this.SendAsync<EducationAssignmentDeleteParameter, EducationAssignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentDeleteResponse> EducationAssignmentDeleteAsync(EducationAssignmentDeleteParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentDeleteParameter, EducationAssignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentDeleteResponse> EducationAssignmentDeleteAsync(EducationAssignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentDeleteParameter, EducationAssignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
