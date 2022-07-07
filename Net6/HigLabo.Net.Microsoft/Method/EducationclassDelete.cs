using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationclassDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Education_Classes_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Education_Classes_Id: return $"/education/classes/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string Id { get; set; }
    }
    public partial class EducationclassDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteResponse> EducationclassDeleteAsync()
        {
            var p = new EducationclassDeleteParameter();
            return await this.SendAsync<EducationclassDeleteParameter, EducationclassDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteResponse> EducationclassDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassDeleteParameter();
            return await this.SendAsync<EducationclassDeleteParameter, EducationclassDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteResponse> EducationclassDeleteAsync(EducationclassDeleteParameter parameter)
        {
            return await this.SendAsync<EducationclassDeleteParameter, EducationclassDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteResponse> EducationclassDeleteAsync(EducationclassDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassDeleteParameter, EducationclassDeleteResponse>(parameter, cancellationToken);
        }
    }
}
