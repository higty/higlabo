using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete-members?view=graph-rest-1.0
    /// </summary>
    public partial class EducationclassDeleteMembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }
            public string? UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_Members_UserId_ref: return $"/education/classes/{Id}/members/{UserId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Id_Members_UserId_ref,
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
    public partial class EducationclassDeleteMembersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete-members?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassDeleteMembersResponse> EducationclassDeleteMembersAsync()
        {
            var p = new EducationclassDeleteMembersParameter();
            return await this.SendAsync<EducationclassDeleteMembersParameter, EducationclassDeleteMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassDeleteMembersResponse> EducationclassDeleteMembersAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassDeleteMembersParameter();
            return await this.SendAsync<EducationclassDeleteMembersParameter, EducationclassDeleteMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassDeleteMembersResponse> EducationclassDeleteMembersAsync(EducationclassDeleteMembersParameter parameter)
        {
            return await this.SendAsync<EducationclassDeleteMembersParameter, EducationclassDeleteMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/educationclass-delete-members?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EducationclassDeleteMembersResponse> EducationclassDeleteMembersAsync(EducationclassDeleteMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassDeleteMembersParameter, EducationclassDeleteMembersResponse>(parameter, cancellationToken);
        }
    }
}
