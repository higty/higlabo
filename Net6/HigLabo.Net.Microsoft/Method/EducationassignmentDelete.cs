using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ClassesId { get; set; }
        public string AssignmentsId { get; set; }
    }
    public partial class EducationassignmentDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeleteResponse> EducationassignmentDeleteAsync()
        {
            var p = new EducationassignmentDeleteParameter();
            return await this.SendAsync<EducationassignmentDeleteParameter, EducationassignmentDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeleteResponse> EducationassignmentDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentDeleteParameter();
            return await this.SendAsync<EducationassignmentDeleteParameter, EducationassignmentDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeleteResponse> EducationassignmentDeleteAsync(EducationassignmentDeleteParameter parameter)
        {
            return await this.SendAsync<EducationassignmentDeleteParameter, EducationassignmentDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentDeleteResponse> EducationassignmentDeleteAsync(EducationassignmentDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentDeleteParameter, EducationassignmentDeleteResponse>(parameter, cancellationToken);
        }
    }
}
