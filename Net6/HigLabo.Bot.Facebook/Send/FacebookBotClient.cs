using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HigLabo.Bot.Facebook.Send;
using HigLabo.Core;
using System.IO;

namespace HigLabo.Bot.Facebook
{
    public class FacebookBotClient : HttpClient
    {
        public static String DefaultAccessToken { get; set; }

        public String AccessToken { get; set; }
        
        public FacebookBotClient(String accessToken)
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
        public Task<HttpResponseMessage> SendMessageAsync(String recipientID, String text)
        {
            var model = new TextMessage();
            model.RecipientID = recipientID;
            model.Text = text;
            return this.SendMessageAsync(model);
        }
        public Task<HttpResponseMessage> SendImageAsync(String recipientID, String url)
        {
            var m = new AttachmentMessage();
            m.RecipientID = recipientID;
            m.AttachmentType = AttachmentType.Image;
            m.Url = url;
            m.IsReusable = true;
            return this.SendMessageAsync(m);
        }
        public Task<HttpResponseMessage> SendAttachmentAsync(String recipientID, String attachmentID)
        {
            var m = new AttachmentMessage();
            m.RecipientID = recipientID;
            m.AttachmentType = AttachmentType.Image;
            m.AttachmentID = attachmentID;
            return this.SendMessageAsync(m);
        }
        public Task<HttpResponseMessage> SendMessageAsync<T>(T message)
            where T : PushMessage
        {
            var json = message.CreateJson();

            var cl = this;
            var url = "https://graph.facebook.com/v4.0/me/messages?access_token=" + this.GetAccessToken();
            var mg = new HttpRequestMessage(HttpMethod.Post, url);
            var streamContent = new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes(json)));
            streamContent.Headers.Add("Content-Type", "application/json");
            mg.Content = streamContent;
            return cl.SendAsync(mg);
        }
    }
}
