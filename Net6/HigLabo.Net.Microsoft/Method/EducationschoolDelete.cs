using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationschoolDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Schools_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Schools_Id: return $"/education/schools/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class EducationschoolDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteResponse> EducationschoolDeleteAsync()
        {
            var p = new EducationschoolDeleteParameter();
            return await this.SendAsync<EducationschoolDeleteParameter, EducationschoolDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteResponse> EducationschoolDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationschoolDeleteParameter();
            return await this.SendAsync<EducationschoolDeleteParameter, EducationschoolDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteResponse> EducationschoolDeleteAsync(EducationschoolDeleteParameter parameter)
        {
            return await this.SendAsync<EducationschoolDeleteParameter, EducationschoolDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationschoolDeleteResponse> EducationschoolDeleteAsync(EducationschoolDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationschoolDeleteParameter, EducationschoolDeleteResponse>(parameter, cancellationToken);
        }
    }
}
