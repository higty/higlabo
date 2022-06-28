
namespace HigLabo.Net.Slack
{
    public class CallsAddParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "calls.add";
        public string HttpMethod { get; private set; } = "POST";
        public string External_Unique_Id { get; set; } = "";
        public string Join_Url { get; set; } = "";
        public string Created_By { get; set; } = "";
        public int? Date_Start { get; set; }
        public string Desktop_App_Join_Url { get; set; } = "";
        public string External_Display_Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string Users { get; set; } = "";
    }
    public partial class CallsAddResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<CallsAddResponse> CallsAddAsync(string external_Unique_Id, string join_Url)
        {
            var p = new CallsAddParameter();
            p.External_Unique_Id = external_Unique_Id;
            p.Join_Url = join_Url;
            return await this.SendAsync<CallsAddParameter, CallsAddResponse>(p, CancellationToken.None);
        }
        public async Task<CallsAddResponse> CallsAddAsync(string external_Unique_Id, string join_Url, CancellationToken cancellationToken)
        {
            var p = new CallsAddParameter();
            p.External_Unique_Id = external_Unique_Id;
            p.Join_Url = join_Url;
            return await this.SendAsync<CallsAddParameter, CallsAddResponse>(p, cancellationToken);
        }
        public async Task<CallsAddResponse> CallsAddAsync(CallsAddParameter parameter)
        {
            return await this.SendAsync<CallsAddParameter, CallsAddResponse>(parameter, CancellationToken.None);
        }
        public async Task<CallsAddResponse> CallsAddAsync(CallsAddParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<CallsAddParameter, CallsAddResponse>(parameter, cancellationToken);
        }
    }
}
