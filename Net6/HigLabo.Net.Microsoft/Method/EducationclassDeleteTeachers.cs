using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationclassDeleteTeachersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }
            public string UserId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Classes_Id_Teachers_UserId_ref: return $"/education/classes/{Id}/teachers/{UserId}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Education_Classes_Id_Teachers_UserId_ref,
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
    public partial class EducationclassDeleteTeachersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete-teachers?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteTeachersResponse> EducationclassDeleteTeachersAsync()
        {
            var p = new EducationclassDeleteTeachersParameter();
            return await this.SendAsync<EducationclassDeleteTeachersParameter, EducationclassDeleteTeachersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete-teachers?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteTeachersResponse> EducationclassDeleteTeachersAsync(CancellationToken cancellationToken)
        {
            var p = new EducationclassDeleteTeachersParameter();
            return await this.SendAsync<EducationclassDeleteTeachersParameter, EducationclassDeleteTeachersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete-teachers?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteTeachersResponse> EducationclassDeleteTeachersAsync(EducationclassDeleteTeachersParameter parameter)
        {
            return await this.SendAsync<EducationclassDeleteTeachersParameter, EducationclassDeleteTeachersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationclass-delete-teachers?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationclassDeleteTeachersResponse> EducationclassDeleteTeachersAsync(EducationclassDeleteTeachersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationclassDeleteTeachersParameter, EducationclassDeleteTeachersResponse>(parameter, cancellationToken);
        }
    }
}
