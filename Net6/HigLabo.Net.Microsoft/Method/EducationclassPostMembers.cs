using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationclassPostMembersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_Id_Members_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id_Members_ref: return $"/education/classes/{Id}/members/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class EducationclassPostMembersResponse : RestApiResponse
    {
        public enum EducationClassEducationExternalSource
        {
            Sis,
            Manual,
        }

        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? MailNickname { get; set; }
        public string? Description { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string? ClassCode { get; set; }
        public string? ExternalName { get; set; }
        public string? ExternalId { get; set; }
        public EducationClassEducationExternalSource ExternalSource { get; set; }
        public string? ExternalSourceDetail { get; set; }
        public string? Grade { get; set; }
        public EducationTerm? Term { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostMembersResponse> EducationclassPostMembersAsync()
        {
            var p = new EducationclassPostMembersParameter();
            return await this.SendAsync<EducationclassPostMembersParameter, EducationclassPostMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostMembersResponse> EducationclassPostMembersAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassPostMembersParameter();
            return await this.SendAsync<EducationclassPostMembersParameter, EducationclassPostMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostMembersResponse> EducationclassPostMembersAsync(EducationclassPostMembersParameter parameter)
        {
            return await this.SendAsync<EducationclassPostMembersParameter, EducationclassPostMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-post-members?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassPostMembersResponse> EducationclassPostMembersAsync(EducationclassPostMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassPostMembersParameter, EducationclassPostMembersResponse>(parameter, cancellationToken);
        }
    }
}
