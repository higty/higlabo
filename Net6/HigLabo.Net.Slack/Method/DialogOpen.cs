
namespace HigLabo.Net.Slack
{
    public class DialogOpenParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "dialog.open";
        public string HttpMethod { get; private set; } = "POST";
        public string Dialog { get; set; } = "";
        public string Trigger_Id { get; set; } = "";
    }
    public partial class DialogOpenResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<DialogOpenResponse> DialogOpenAsync(string dialog, string trigger_Id)
        {
            var p = new DialogOpenParameter();
            p.Dialog = dialog;
            p.Trigger_Id = trigger_Id;
            return await this.SendAsync<DialogOpenParameter, DialogOpenResponse>(p, CancellationToken.None);
        }
        public async Task<DialogOpenResponse> DialogOpenAsync(string dialog, string trigger_Id, CancellationToken cancellationToken)
        {
            var p = new DialogOpenParameter();
            p.Dialog = dialog;
            p.Trigger_Id = trigger_Id;
            return await this.SendAsync<DialogOpenParameter, DialogOpenResponse>(p, cancellationToken);
        }
        public async Task<DialogOpenResponse> DialogOpenAsync(DialogOpenParameter parameter)
        {
            return await this.SendAsync<DialogOpenParameter, DialogOpenResponse>(parameter, CancellationToken.None);
        }
        public async Task<DialogOpenResponse> DialogOpenAsync(DialogOpenParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DialogOpenParameter, DialogOpenResponse>(parameter, cancellationToken);
        }
    }
}
