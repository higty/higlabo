using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationassignmentSetupresourcesfolderParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_Id_Assignments_Id_SetUpResourcesFolder,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Assignments_Id_SetUpResourcesFolder: return $"/education/classes/{ClassesId}/assignments/{AssignmentsId}/setUpResourcesFolder";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string ClassesId { get; set; }
        public string AssignmentsId { get; set; }
    }
    public partial class EducationassignmentSetupresourcesfolderResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentSetupresourcesfolderResponse> EducationassignmentSetupresourcesfolderAsync()
        {
            var p = new EducationassignmentSetupresourcesfolderParameter();
            return await this.SendAsync<EducationassignmentSetupresourcesfolderParameter, EducationassignmentSetupresourcesfolderResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentSetupresourcesfolderResponse> EducationassignmentSetupresourcesfolderAsync(CancellationToken cancellationToken)
        {
            var p = new EducationassignmentSetupresourcesfolderParameter();
            return await this.SendAsync<EducationassignmentSetupresourcesfolderParameter, EducationassignmentSetupresourcesfolderResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentSetupresourcesfolderResponse> EducationassignmentSetupresourcesfolderAsync(EducationassignmentSetupresourcesfolderParameter parameter)
        {
            return await this.SendAsync<EducationassignmentSetupresourcesfolderParameter, EducationassignmentSetupresourcesfolderResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignment-setupresourcesfolder?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationassignmentSetupresourcesfolderResponse> EducationassignmentSetupresourcesfolderAsync(EducationassignmentSetupresourcesfolderParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationassignmentSetupresourcesfolderParameter, EducationassignmentSetupresourcesfolderResponse>(parameter, cancellationToken);
        }
    }
}
