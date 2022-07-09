using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationSchoolDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Schools_Id: return $"/education/schools/{Id}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Schools_Id,
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
    public partial class EducationSchoolDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolDeleteResponse> EducationSchoolDeleteAsync()
        {
            var p = new EducationSchoolDeleteParameter();
            return await this.SendAsync<EducationSchoolDeleteParameter, EducationSchoolDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolDeleteResponse> EducationSchoolDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new EducationSchoolDeleteParameter();
            return await this.SendAsync<EducationSchoolDeleteParameter, EducationSchoolDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolDeleteResponse> EducationSchoolDeleteAsync(EducationSchoolDeleteParameter parameter)
        {
            return await this.SendAsync<EducationSchoolDeleteParameter, EducationSchoolDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolDeleteResponse> EducationSchoolDeleteAsync(EducationSchoolDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationSchoolDeleteParameter, EducationSchoolDeleteResponse>(parameter, cancellationToken);
        }
    }
}
