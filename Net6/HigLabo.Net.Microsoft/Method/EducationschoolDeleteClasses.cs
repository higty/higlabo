using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationschoolDeleteClassesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Schools_Id_Classes_ClassId_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Schools_Id_Classes_ClassId_ref: return $"/education/schools/{Id}/classes/{ClassId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
        public string ClassId { get; set; }
    }
    public partial class EducationschoolDeleteClassesResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteClassesResponse> EducationschoolDeleteClassesAsync()
        {
            var p = new EducationschoolDeleteClassesParameter();
            return await this.SendAsync<EducationschoolDeleteClassesParameter, EducationschoolDeleteClassesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteClassesResponse> EducationschoolDeleteClassesAsync(CancellationToken cancellationToken)
        {
            var p = new EducationschoolDeleteClassesParameter();
            return await this.SendAsync<EducationschoolDeleteClassesParameter, EducationschoolDeleteClassesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteClassesResponse> EducationschoolDeleteClassesAsync(EducationschoolDeleteClassesParameter parameter)
        {
            return await this.SendAsync<EducationschoolDeleteClassesParameter, EducationschoolDeleteClassesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete-classes?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteClassesResponse> EducationschoolDeleteClassesAsync(EducationschoolDeleteClassesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationschoolDeleteClassesParameter, EducationschoolDeleteClassesResponse>(parameter, cancellationToken);
        }
    }
}
