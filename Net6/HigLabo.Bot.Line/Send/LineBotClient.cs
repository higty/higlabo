using System.Net.Http;
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
using System.IO;

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
        public Task<HttpResponseMessage> SendMessageAsync(String to, String text)
        {
            var mg = new PushMessage();
            mg.To = to;
            var m = new TextMessage();
            m.Text = text;
            mg.Messages.Add(m);
            return SendMessageAsync(mg);
        }
        public Task<HttpResponseMessage> SendImageAsync(String to, String url)
        {
            var mg = new PushMessage();
            mg.To = to;
            var m = new ImageMessage();
            m.OriginalContentUrl = url;
            m.PreviewImageUrl = url;
            mg.Messages.Add(m);
            return this.SendMessageAsync(mg);
        }
        public Task<HttpResponseMessage> SendVideoAsync(String to, String url)
        {
            var mg = new PushMessage();
            mg.To = to;
            var m = new VideoMessage();
            m.OriginalContentUrl = url;
            m.PreviewImageUrl = url;
            mg.Messages.Add(m);
            return this.SendMessageAsync(mg);
        }
        public Task<HttpResponseMessage> SendMessageAsync<T>(T message)
            where T : PushMessage
        {
            var url = "https://api.line.me/v2/bot/message/push";
            return this.SendMessageAsync(message, url);
        }
        public Task<HttpResponseMessage> SendReplyMessageAsync<T>(T message)
            where T : ReplyMessage
        {
            var url = "https://api.line.me/v2/bot/message/reply";
            return this.SendMessageAsync(message, url);
        }
        private Task<HttpResponseMessage> SendMessageAsync<T>(T message, String url)
            where T : ISendMessage
        {
            var cl = this;
            var mg = new HttpRequestMessage(HttpMethod.Post, url);
            mg.Headers.Add("Authorization", "Bearer " + this.GetAccessToken());

            var json = message.CreateJson();
            var streamContent = new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes(json)));
            streamContent.Headers.Add("Content-Type", "application/json");
            mg.Content = streamContent;

            return cl.SendAsync(mg);
        }
    }
}
