using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/calls.participants.add
    /// </summary>
    public partial class CallsParticipantsAddParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "calls.participants.add";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? Users { get; set; }
    }
    public partial class CallsParticipantsAddResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/calls.participants.add
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/calls.participants.add
        /// </summary>
        public async ValueTask<CallsParticipantsAddResponse> CallsParticipantsAddAsync(string? id, string? users)
        {
            var p = new CallsParticipantsAddParameter();
            p.Id = id;
            p.Users = users;
            return await this.SendAsync<CallsParticipantsAddParameter, CallsParticipantsAddResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.participants.add
        /// </summary>
        public async ValueTask<CallsParticipantsAddResponse> CallsParticipantsAddAsync(string? id, string? users, CancellationToken cancellationToken)
        {
            var p = new CallsParticipantsAddParameter();
            p.Id = id;
            p.Users = users;
            return await this.SendAsync<CallsParticipantsAddParameter, CallsParticipantsAddResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.participants.add
        /// </summary>
        public async ValueTask<CallsParticipantsAddResponse> CallsParticipantsAddAsync(CallsParticipantsAddParameter parameter)
        {
            return await this.SendAsync<CallsParticipantsAddParameter, CallsParticipantsAddResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/calls.participants.add
        /// </summary>
        public async ValueTask<CallsParticipantsAddResponse> CallsParticipantsAddAsync(CallsParticipantsAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallsParticipantsAddParameter, CallsParticipantsAddResponse>(parameter, cancellationToken);
        }
    }
}
