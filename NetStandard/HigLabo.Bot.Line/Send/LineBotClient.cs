using HigLabo.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Bot.Line.Send;
using HigLabo.Core;

namespace HigLabo.Bot.Line
{
    public class LineBotClient : HttpClient
    {
        public static String DefaultAccessToken { get; set; }

        public String AccessToken { get; set; }

        public LineBotClient()
        {
        }
        public LineBotClient(String accessToken)
        {
            this.AccessToken = accessToken;
        }

        public String GetAccessToken()
        {
            if (this.AccessToken.IsNullOrEmpty())
            {
                return DefaultAccessToken;
            }
            return this.AccessToken;
        }
        public HttpResponse SendMessage(String to, String text)
        {
            var mg = new PushMessage();
            mg.To = to;
            var m = new TextMessage();
            m.Text = text;
            mg.Messages.Add(m);
            return SendMessage(mg);
        }
        public HttpResponse SendImage(String to, String url)
        {
            var mg = new PushMessage();
            mg.To = to;
            var m = new ImageMessage();
            m.OriginalContentUrl = url;
            m.PreviewImageUrl = url;
            mg.Messages.Add(m);
            return this.SendMessage(mg);
        }
        public HttpResponse SendVideo(String to, String url)
        {
            var mg = new PushMessage();
            mg.To = to;
            var m = new VideoMessage();
            m.OriginalContentUrl = url;
            m.PreviewImageUrl = url;
            mg.Messages.Add(m);
            return this.SendMessage(mg);
        }
        public HttpResponse SendMessage<T>(T message)
            where T : PushMessage
        {
            var json = message.CreateJson();

            var cl = this;
            var url = "https://api.line.me/v2/bot/message/push";
            var cm = new HttpRequestCommand(url);
            cm.Headers.Add("Authorization", "Bearer " + this.GetAccessToken());
            cm.MethodName = HttpMethodName.Post;
            cm.ContentType = "application/json";
            cm.SetBodyStream(Encoding.UTF8.GetBytes(json));
            var res = cl.GetResponse(cm);
            return res;
        }
        public HttpResponse SendReplyMessage<T>(T message)
            where T : ReplyMessage
        {
            var json = message.CreateJson();

            var cl = this;
            var url = "https://api.line.me/v2/bot/message/reply";
            var cm = new HttpRequestCommand(url);
            cm.Headers.Add("Authorization", "Bearer " + this.GetAccessToken());
            cm.MethodName = HttpMethodName.Post;
            cm.ContentType = "application/json";
            cm.SetBodyStream(Encoding.UTF8.GetBytes(json));
            var res = cl.GetResponse(cm);
            return res;
        }
    }
}
