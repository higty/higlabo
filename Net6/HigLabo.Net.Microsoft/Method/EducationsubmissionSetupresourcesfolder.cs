using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionSetupresourcesfolderParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Submissions_Id_SetUpResourcesFolder,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Submissions_Id_SetUpResourcesFolder: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/submissions/{SubmissionsId}/setUpResourcesFolder";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string ClassesId { get; set; }
        public string AssignmentsId { get; set; }
        public string SubmissionsId { get; set; }
    }
    public partial class EducationsubmissionSetupresourcesfolderResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionSetupresourcesfolderResponse> EducationsubmissionSetupresourcesfolderAsync()
        {
            var p = new EducationsubmissionSetupresourcesfolderParameter();
            return await this.SendAsync<EducationsubmissionSetupresourcesfolderParameter, EducationsubmissionSetupresourcesfolderResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionSetupresourcesfolderResponse> EducationsubmissionSetupresourcesfolderAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionSetupresourcesfolderParameter();
            return await this.SendAsync<EducationsubmissionSetupresourcesfolderParameter, EducationsubmissionSetupresourcesfolderResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionSetupresourcesfolderResponse> EducationsubmissionSetupresourcesfolderAsync(EducationsubmissionSetupresourcesfolderParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionSetupresourcesfolderParameter, EducationsubmissionSetupresourcesfolderResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionSetupresourcesfolderResponse> EducationsubmissionSetupresourcesfolderAsync(EducationsubmissionSetupresourcesfolderParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionSetupresourcesfolderParameter, EducationsubmissionSetupresourcesfolderResponse>(parameter, cancellationToken);
        }
    }
}
