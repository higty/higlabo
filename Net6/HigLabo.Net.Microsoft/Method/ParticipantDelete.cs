using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-delete?view=graph-rest-1.0
    /// </summary>
    public partial class ParticipantDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? CallsId { get; set; }
            public string? ParticipantsId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Communications_Calls_Id_Participants_Id: return $"/communications/calls/{CallsId}/participants/{ParticipantsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Communications_Calls_Id_Participants_Id,
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
    public partial class ParticipantDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/participant-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantDeleteResponse> ParticipantDeleteAsync()
        {
            var p = new ParticipantDeleteParameter();
            return await this.SendAsync<ParticipantDeleteParameter, ParticipantDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantDeleteResponse> ParticipantDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ParticipantDeleteParameter();
            return await this.SendAsync<ParticipantDeleteParameter, ParticipantDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantDeleteResponse> ParticipantDeleteAsync(ParticipantDeleteParameter parameter)
        {
            return await this.SendAsync<ParticipantDeleteParameter, ParticipantDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/participant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantDeleteResponse> ParticipantDeleteAsync(ParticipantDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ParticipantDeleteParameter, ParticipantDeleteResponse>(parameter, cancellationToken);
        }
    }
}
