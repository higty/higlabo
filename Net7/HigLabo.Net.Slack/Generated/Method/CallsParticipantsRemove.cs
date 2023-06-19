using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class CallsParticipantsRemoveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "calls.participants.remove";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? Users { get; set; }
    }
    public partial class CallsParticipantsRemoveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/calls.participants.remove
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/calls.participants.remove
        /// </summary>
        public async ValueTask<CallsParticipantsRemoveResponse> CallsParticipantsRemoveAsync(string? id, string? users)
        {
            var p = new CallsParticipantsRemoveParameter();
            p.Id = id;
            p.Users = users;
            return await this.SendAsync<CallsParticipantsRemoveParameter, CallsParticipantsRemoveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.participants.remove
        /// </summary>
        public async ValueTask<CallsParticipantsRemoveResponse> CallsParticipantsRemoveAsync(string? id, string? users, CancellationToken cancellationToken)
        {
            var p = new CallsParticipantsRemoveParameter();
            p.Id = id;
            p.Users = users;
            return await this.SendAsync<CallsParticipantsRemoveParameter, CallsParticipantsRemoveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.participants.remove
        /// </summary>
        public async ValueTask<CallsParticipantsRemoveResponse> CallsParticipantsRemoveAsync(CallsParticipantsRemoveParameter parameter)
        {
            return await this.SendAsync<CallsParticipantsRemoveParameter, CallsParticipantsRemoveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.participants.remove
        /// </summary>
        public async ValueTask<CallsParticipantsRemoveResponse> CallsParticipantsRemoveAsync(CallsParticipantsRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallsParticipantsRemoveParameter, CallsParticipantsRemoveResponse>(parameter, cancellationToken);
        }
    }
}
