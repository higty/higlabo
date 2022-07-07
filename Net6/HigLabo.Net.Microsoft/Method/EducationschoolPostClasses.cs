using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationschoolPostClassesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Schools_Id_Classes_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Schools_Id_Classes_ref: return $"/education/schools/{Id}/classes/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
    }
    public partial class EducationschoolPostClassesResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-post-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolPostClassesResponse> EducationschoolPostClassesAsync()
        {
            var p = new EducationschoolPostClassesParameter();
            return await this.SendAsync<EducationschoolPostClassesParameter, EducationschoolPostClassesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-post-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolPostClassesResponse> EducationschoolPostClassesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationschoolPostClassesParameter();
            return await this.SendAsync<EducationschoolPostClassesParameter, EducationschoolPostClassesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-post-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolPostClassesResponse> EducationschoolPostClassesAsync(EducationschoolPostClassesParameter parameter)
        {
            return await this.SendAsync<EducationschoolPostClassesParameter, EducationschoolPostClassesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-post-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolPostClassesResponse> EducationschoolPostClassesAsync(EducationschoolPostClassesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationschoolPostClassesParameter, EducationschoolPostClassesResponse>(parameter, cancellationToken);
        }
    }
}
