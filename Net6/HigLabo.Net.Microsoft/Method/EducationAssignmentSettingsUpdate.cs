using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationAssignmentSettingsUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_AssignmentSettings: return $"/education/classes/acdefc6b-2dc6-4e71-b1e9-6d9810ab1793/assignmentSettings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Acdefc6b2dc64e71B1e96d9810ab1793_AssignmentSettings,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public bool? SubmissionAnimationDisabled { get; set; }
    }
    public partial class EducationAssignmentSettingsUpdateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public bool? SubmissionAnimationDisabled { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentSettingsUpdateResponse> EducationAssignmentSettingsUpdateAsync()
        {
            var p = new EducationAssignmentSettingsUpdateParameter();
            return await this.SendAsync<EducationAssignmentSettingsUpdateParameter, EducationAssignmentSettingsUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentSettingsUpdateResponse> EducationAssignmentSettingsUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new EducationAssignmentSettingsUpdateParameter();
            return await this.SendAsync<EducationAssignmentSettingsUpdateParameter, EducationAssignmentSettingsUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentSettingsUpdateResponse> EducationAssignmentSettingsUpdateAsync(EducationAssignmentSettingsUpdateParameter parameter)
        {
            return await this.SendAsync<EducationAssignmentSettingsUpdateParameter, EducationAssignmentSettingsUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationassignmentsettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationAssignmentSettingsUpdateResponse> EducationAssignmentSettingsUpdateAsync(EducationAssignmentSettingsUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationAssignmentSettingsUpdateParameter, EducationAssignmentSettingsUpdateResponse>(parameter, cancellationToken);
        }
    }
}
