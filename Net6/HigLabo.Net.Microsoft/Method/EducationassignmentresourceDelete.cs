using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentresourceDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_ClassId_Assignments_AssignmentId_Resources_ResourceId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_ClassId_Assignments_AssignmentId_Resources_ResourceId: return $"/education/classes/{ClassId}/assignments/{AssignmentId}/resources/{ResourceId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ClassId { get; set; }
        public string AssignmentId { get; set; }
        public string ResourceId { get; set; }
    }
    public partial class EducationassignmentresourceDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentresourceDeleteResponse> EducationassignmentresourceDeleteAsync()
        {
            var p = new EducationassignmentresourceDeleteParameter();
            return await this.SendAsync<EducationassignmentresourceDeleteParameter, EducationassignmentresourceDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentresourceDeleteResponse> EducationassignmentresourceDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentresourceDeleteParameter();
            return await this.SendAsync<EducationassignmentresourceDeleteParameter, EducationassignmentresourceDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentresourceDeleteResponse> EducationassignmentresourceDeleteAsync(EducationassignmentresourceDeleteParameter parameter)
        {
            return await this.SendAsync<EducationassignmentresourceDeleteParameter, EducationassignmentresourceDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentresource-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentresourceDeleteResponse> EducationassignmentresourceDeleteAsync(EducationassignmentresourceDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentresourceDeleteParameter, EducationassignmentresourceDeleteResponse>(parameter, cancellationToken);
        }
    }
}
