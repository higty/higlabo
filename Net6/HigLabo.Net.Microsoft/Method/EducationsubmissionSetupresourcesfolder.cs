using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationsubmissionSetupResourcesfolderParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string ClassesId { get; set; }
            public string AssignmentsId { get; set; }
            public string SubmissionsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_Submissions_Id_SetUpResourcesFolder: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/submissions/{SubmissionsId}/setUpResourcesFolder";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_Submissions_Id_SetUpResourcesFolder,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class EducationsubmissionSetupResourcesfolderResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionSetupResourcesfolderResponse> EducationsubmissionSetupResourcesfolderAsync()
        {
            var p = new EducationsubmissionSetupResourcesfolderParameter();
            return await this.SendAsync<EducationsubmissionSetupResourcesfolderParameter, EducationsubmissionSetupResourcesfolderResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionSetupResourcesfolderResponse> EducationsubmissionSetupResourcesfolderAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionSetupResourcesfolderParameter();
            return await this.SendAsync<EducationsubmissionSetupResourcesfolderParameter, EducationsubmissionSetupResourcesfolderResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionSetupResourcesfolderResponse> EducationsubmissionSetupResourcesfolderAsync(EducationsubmissionSetupResourcesfolderParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionSetupResourcesfolderParameter, EducationsubmissionSetupResourcesfolderResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationsubmissionSetupResourcesfolderResponse> EducationsubmissionSetupResourcesfolderAsync(EducationsubmissionSetupResourcesfolderParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionSetupResourcesfolderParameter, EducationsubmissionSetupResourcesfolderResponse>(parameter, cancellationToken);
        }
    }
}
