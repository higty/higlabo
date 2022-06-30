﻿
namespace HigLabo.Net.Slack
{
    public partial class CallsUpdateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "calls.update";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Id { get; set; }
        public string Desktop_App_Join_Url { get; set; }
        public string Join_Url { get; set; }
        public string Title { get; set; }
    }
    public partial class CallsUpdateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<CallsUpdateResponse> CallsUpdateAsync(string id)
        {
            var p = new CallsUpdateParameter();
            p.Id = id;
            return await this.SendAsync<CallsUpdateParameter, CallsUpdateResponse>(p, CancellationToken.None);
        }
        public async Task<CallsUpdateResponse> CallsUpdateAsync(string id, CancellationToken cancellationToken)
        {
            var p = new CallsUpdateParameter();
            p.Id = id;
            return await this.SendAsync<CallsUpdateParameter, CallsUpdateResponse>(p, cancellationToken);
        }
        public async Task<CallsUpdateResponse> CallsUpdateAsync(CallsUpdateParameter parameter)
        {
            return await this.SendAsync<CallsUpdateParameter, CallsUpdateResponse>(parameter, CancellationToken.None);
        }
        public async Task<CallsUpdateResponse> CallsUpdateAsync(CallsUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallsUpdateParameter, CallsUpdateResponse>(parameter, cancellationToken);
        }
    }
}