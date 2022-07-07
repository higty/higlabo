using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationclassDeleteMembersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_Id_Members_UserId_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Members_UserId_ref: return $"/education/classes/{Id}/members/{UserId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string UserId { get; set; }
    }
    public partial class EducationclassDeleteMembersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteMembersResponse> EducationclassDeleteMembersAsync()
        {
            var p = new EducationclassDeleteMembersParameter();
            return await this.SendAsync<EducationclassDeleteMembersParameter, EducationclassDeleteMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteMembersResponse> EducationclassDeleteMembersAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassDeleteMembersParameter();
            return await this.SendAsync<EducationclassDeleteMembersParameter, EducationclassDeleteMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteMembersResponse> EducationclassDeleteMembersAsync(EducationclassDeleteMembersParameter parameter)
        {
            return await this.SendAsync<EducationclassDeleteMembersParameter, EducationclassDeleteMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteMembersResponse> EducationclassDeleteMembersAsync(EducationclassDeleteMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassDeleteMembersParameter, EducationclassDeleteMembersResponse>(parameter, cancellationToken);
        }
    }
}
