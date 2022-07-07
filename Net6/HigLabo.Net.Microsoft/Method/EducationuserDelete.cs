using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationuserDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Users_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Users_Id: return $"/education/users/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class EducationuserDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserDeleteResponse> EducationuserDeleteAsync()
        {
            var p = new EducationuserDeleteParameter();
            return await this.SendAsync<EducationuserDeleteParameter, EducationuserDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserDeleteResponse> EducationuserDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationuserDeleteParameter();
            return await this.SendAsync<EducationuserDeleteParameter, EducationuserDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserDeleteResponse> EducationuserDeleteAsync(EducationuserDeleteParameter parameter)
        {
            return await this.SendAsync<EducationuserDeleteParameter, EducationuserDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationuser-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationuserDeleteResponse> EducationuserDeleteAsync(EducationuserDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationuserDeleteParameter, EducationuserDeleteResponse>(parameter, cancellationToken);
        }
    }
}
