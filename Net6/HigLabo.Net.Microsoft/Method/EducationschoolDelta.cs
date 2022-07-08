using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EducationSchoolDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Education_Schools_Delta: return $"/education/schools/delta";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Address,
            CreatedBy,
            Description,
            DisplayName,
            ExternalId,
            ExternalPrincipalId,
            ExternalSource,
            ExternalSourceDetail,
            HighestGrade,
            Id,
            LowestGrade,
            Phone,
            PrincipalEmail,
            PrincipalName,
            SchoolNumber,
            AdministrativeUnit,
            Classes,
            Users,
        }
        public enum ApiPath
        {
            Education_Schools_Delta,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class EducationSchoolDeltaResponse : RestApiResponse
    {
        public EducationSchool[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolDeltaResponse> EducationSchoolDeltaAsync()
        {
            var p = new EducationSchoolDeltaParameter();
            return await this.SendAsync<EducationSchoolDeltaParameter, EducationSchoolDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolDeltaResponse> EducationSchoolDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new EducationSchoolDeltaParameter();
            return await this.SendAsync<EducationSchoolDeltaParameter, EducationSchoolDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolDeltaResponse> EducationSchoolDeltaAsync(EducationSchoolDeltaParameter parameter)
        {
            return await this.SendAsync<EducationSchoolDeltaParameter, EducationSchoolDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/educationschool-delta?view=graph-rest-1.0
        /// </summary>
        public async Task<EducationSchoolDeltaResponse> EducationSchoolDeltaAsync(EducationSchoolDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EducationSchoolDeltaParameter, EducationSchoolDeltaResponse>(parameter, cancellationToken);
        }
    }
}
