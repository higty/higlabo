using HigLabo.Net;
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
        public HttpResponse SendMessage(String recipientID, String text)
        {
            var model = new TextMessage();
            model.RecipientID = recipientID;
            model.Text = text;
            return SendMessage(model);
        }
        public HttpResponse SendImage(String recipientID, String url)
        {
            var m = new AttachmentMessage();
            m.RecipientID = recipientID;
            m.AttachmentType = AttachmentType.Image;
            m.Url = url;
            m.IsReusable = true;
            return this.SendMessage(m);
        }
        public HttpResponse SendAttachment(String recipientID, String attachmentID)
        {
            var m = new AttachmentMessage();
            m.RecipientID = recipientID;
            m.AttachmentType = AttachmentType.Image;
            m.AttachmentID = attachmentID;
            return this.SendMessage(m);
        }
        public HttpResponse SendMessage<T>(T message)
            where T : PushMessage
        {
            var json = message.CreateJson();

            var cl = this;
            var url = "https://graph.facebook.com/v2.9/me/messages?access_token=" + this.GetAccessToken();
            var cm = new HttpRequestCommand(url);
            cm.MethodName = HttpMethodName.Post;
            cm.ContentType = "application/json";
            cm.SetBodyStream(Encoding.UTF8.GetBytes(json));
            var res = cl.GetResponse(cm);
            return res;
        }
    }
}
