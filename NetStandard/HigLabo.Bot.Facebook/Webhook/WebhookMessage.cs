using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigLabo.Bot.Facebook.Webhook
{
    /// <summary>
    /// https://developers.facebook.com/docs/messenger-platform/webhook-reference/message-delivered
    /// </summary>
    public class WebhookMessage
    {
        public String Object { get; set; }
        public Entry[] Entry { get; set; }

        public Messaging GetMessaging()
        {
            if (this.Entry == null ||
                this.Entry.Length == 0 ||
                this.Entry[0].Messaging.Length == 0)
            { return null; }
            return this.Entry[0].Messaging[0];
        }
    }
    public class Entry
    {
        public String ID { get; set; }
        public Int64 Time { get; set; }
        public Messaging[] Messaging { get; set; }
    }
    public class Messaging
    {
        public ObjectID Sender { get; set; }
        public ObjectID Recipient { get; set; }
        public Int64 Timestamp { get; set; }

        public Message Message { get; set; }
        public Delivery Delivery { get; set; }
        public Read Read { get; set; }
        public PostBack Postback { get; set; }
        public Referral Referral { get; set; }

        public String GetText()
        {
            if (this.Message != null)
            {
                return this.Message.Text;
            }
            else if (this.Postback != null)
            {
                return this.Postback.Payload;
            }
            return "";
        }
    }
    public class ObjectID
    {
        public String ID { get; set; }
        public override string ToString()
        {
            return this.ID;
        }
    }
    public class Message
    {
        public String Mid { get; set; }
        public Int32 Seq { get; set; }
        public String Text { get; set; }
        public String Sticker_ID { get; set; }
        public ObjectPayload Quick_Reply { get; set; }
        public Attachment[] Attachments { get; set; }

        public override string ToString()
        {
            return this.Text;
        }
    }
    public class ObjectPayload
    {
        public String Payload { get; set; }
    }
    public class Attachment
    {
        public String Title { get; set; }
        public String Url { get; set; }
        public String Type { get; set; }
        public AttachmentPayload Payload { get; set; }
    }
    public class AttachmentPayload
    {
        public String Url { get; set; }
        public String Sticker_ID { get; set; }
        public Coordinates Coordinates { get; set; }
        public override string ToString()
        {
            return this.Url;
        }
    }
    public class Coordinates
    {
        public Double Lat { get; set; }
        public Double Long { get; set; }
    }

    public class Delivery
    {
        public String[] Mids { get; set; }
        public Int64 Watermark { get; set; }
        public Int32 Seq { get; set; }
    }
    public class Read
    {
        public Int64 Watermark { get; set; }
        public Int32 Seq { get; set; }
    }
    public class PostBack
    {
        public String Payload { get; set; }
        public override string ToString()
        {
            return this.Payload;
        }
    }
    public class Referral
    {
        public String Ref { get; set; }
        public String Ad_ID { get; set; }
        public String Source { get; set; }
        public String Type { get; set; }
    }
}
