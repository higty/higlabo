using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
    /// </summary>
    public partial class EducationsubmissionSetupResourcesFolderParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? ClassesId { get; set; }
            public string? AssignmentsId { get; set; }
            public string? SubmissionsId { get; set; }

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
    public partial class EducationsubmissionSetupResourcesFolderResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationsubmissionSetupResourcesFolderResponse> EducationsubmissionSetupResourcesFolderAsync()
        {
            var p = new EducationsubmissionSetupResourcesFolderParameter();
            return await this.SendAsync<EducationsubmissionSetupResourcesFolderParameter, EducationsubmissionSetupResourcesFolderResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationsubmissionSetupResourcesFolderResponse> EducationsubmissionSetupResourcesFolderAsync(CancellationToken cancellationToken)
        {
            var p = new EducationsubmissionSetupResourcesFolderParameter();
            return await this.SendAsync<EducationsubmissionSetupResourcesFolderParameter, EducationsubmissionSetupResourcesFolderResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationsubmissionSetupResourcesFolderResponse> EducationsubmissionSetupResourcesFolderAsync(EducationsubmissionSetupResourcesFolderParameter parameter)
        {
            return await this.SendAsync<EducationsubmissionSetupResourcesFolderParameter, EducationsubmissionSetupResourcesFolderResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationsubmission-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationsubmissionSetupResourcesFolderResponse> EducationsubmissionSetupResourcesFolderAsync(EducationsubmissionSetupResourcesFolderParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationsubmissionSetupResourcesFolderParameter, EducationsubmissionSetupResourcesFolderResponse>(parameter, cancellationToken);
        }
    }
}
