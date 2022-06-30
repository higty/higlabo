
namespace HigLabo.Net.Slack
{
    public partial class CallsParticipantsRemoveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "calls.participants.remove";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string Users { get; set; }
    }
    public partial class CallsParticipantsRemoveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<CallsParticipantsRemoveResponse> CallsParticipantsRemoveAsync(string id, string users)
        {
            var p = new CallsParticipantsRemoveParameter();
            p.Id = id;
            p.Users = users;
            return await this.SendAsync<CallsParticipantsRemoveParameter, CallsParticipantsRemoveResponse>(p, CancellationToken.None);
        }
        public async Task<CallsParticipantsRemoveResponse> CallsParticipantsRemoveAsync(string id, string users, CancellationToken cancellationToken)
        {
            var p = new CallsParticipantsRemoveParameter();
            p.Id = id;
            p.Users = users;
            return await this.SendAsync<CallsParticipantsRemoveParameter, CallsParticipantsRemoveResponse>(p, cancellationToken);
        }
        public async Task<CallsParticipantsRemoveResponse> CallsParticipantsRemoveAsync(CallsParticipantsRemoveParameter parameter)
        {
            return await this.SendAsync<CallsParticipantsRemoveParameter, CallsParticipantsRemoveResponse>(parameter, CancellationToken.None);
        }
        public async Task<CallsParticipantsRemoveResponse> CallsParticipantsRemoveAsync(CallsParticipantsRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallsParticipantsRemoveParameter, CallsParticipantsRemoveResponse>(parameter, cancellationToken);
        }
    }
}
