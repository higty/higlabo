using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ParticipantDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Communications_Calls_Id_Participants_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Communications_Calls_Id_Participants_Id: return $"/communications/calls/{CallsId}/participants/{ParticipantsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string CallsId { get; set; }
        public string ParticipantsId { get; set; }
    }
    public partial class ParticipantDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantDeleteResponse> ParticipantDeleteAsync()
        {
            var p = new ParticipantDeleteParameter();
            return await this.SendAsync<ParticipantDeleteParameter, ParticipantDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantDeleteResponse> ParticipantDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new ParticipantDeleteParameter();
            return await this.SendAsync<ParticipantDeleteParameter, ParticipantDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantDeleteResponse> ParticipantDeleteAsync(ParticipantDeleteParameter parameter)
        {
            return await this.SendAsync<ParticipantDeleteParameter, ParticipantDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/participant-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<ParticipantDeleteResponse> ParticipantDeleteAsync(ParticipantDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ParticipantDeleteParameter, ParticipantDeleteResponse>(parameter, cancellationToken);
        }
    }
}
