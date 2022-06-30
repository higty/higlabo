﻿
namespace HigLabo.Net.Slack
{
    public partial class CallsParticipantsAddParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "calls.participants.add";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string Users { get; set; }
    }
    public partial class CallsParticipantsAddResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<CallsParticipantsAddResponse> CallsParticipantsAddAsync(string id, string users)
        {
            var p = new CallsParticipantsAddParameter();
            p.Id = id;
            p.Users = users;
            return await this.SendAsync<CallsParticipantsAddParameter, CallsParticipantsAddResponse>(p, CancellationToken.None);
        }
        public async Task<CallsParticipantsAddResponse> CallsParticipantsAddAsync(string id, string users, CancellationToken cancellationToken)
        {
            var p = new CallsParticipantsAddParameter();
            p.Id = id;
            p.Users = users;
            return await this.SendAsync<CallsParticipantsAddParameter, CallsParticipantsAddResponse>(p, cancellationToken);
        }
        public async Task<CallsParticipantsAddResponse> CallsParticipantsAddAsync(CallsParticipantsAddParameter parameter)
        {
            return await this.SendAsync<CallsParticipantsAddParameter, CallsParticipantsAddResponse>(parameter, CancellationToken.None);
        }
        public async Task<CallsParticipantsAddResponse> CallsParticipantsAddAsync(CallsParticipantsAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallsParticipantsAddParameter, CallsParticipantsAddResponse>(parameter, cancellationToken);
        }
    }
}