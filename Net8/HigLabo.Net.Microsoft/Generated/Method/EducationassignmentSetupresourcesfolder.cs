using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-setupresourcesfolder?view=graph-rest-1.0
    /// </summary>
    public partial class EducationAssignmentSetupResourcesFolderParameter : IRestApiParameter
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
                    case ApiPath.Education_Classes_Id_Assignments_Id_SetUpResourcesFolder: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/setUpResourcesFolder";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_SetUpResourcesFolder,
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
    public partial class EducationAssignmentSetupResourcesFolderResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationassignment-setupresourcesfolder?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentSetupResourcesFolderResponse> EducationAssignmentSetupResourcesFolderAsync()
        {
            var p = new EducationAssignmentSetupResourcesFolderParameter();
            return await this.SendAsync<EducationAssignmentSetupResourcesFolderParameter, EducationAssignmentSetupResourcesFolderResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentSetupResourcesFolderResponse> EducationAssignmentSetupResourcesFolderAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentSetupResourcesFolderParameter();
            return await this.SendAsync<EducationAssignmentSetupResourcesFolderParameter, EducationAssignmentSetupResourcesFolderResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentSetupResourcesFolderResponse> EducationAssignmentSetupResourcesFolderAsync(EducationAssignmentSetupResourcesFolderParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentSetupResourcesFolderParameter, EducationAssignmentSetupResourcesFolderResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationassignment-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationAssignmentSetupResourcesFolderResponse> EducationAssignmentSetupResourcesFolderAsync(EducationAssignmentSetupResourcesFolderParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentSetupResourcesFolderParameter, EducationAssignmentSetupResourcesFolderResponse>(parameter, cancellationToken);
        }
    }
}
