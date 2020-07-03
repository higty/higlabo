using HigLabo.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HigLabo.Bot.Line.Webhook
{
    public class WebhookMessage
    {
        public List<Event> Events { get; set; } = new List<Event>();

        public static WebhookMessage Create(String text)
        {
            var mg = new WebhookMessage();
            var dd = JsonConvert.DeserializeObject<Dictionary<String, Object>>(text);
            if (dd.ContainsKey("events") &&
                dd["events"] is JArray)
            {
                foreach (var item in dd["events"] as JArray)
                {
                    var tp = item["type"].ToString().ToEnum<EventType>().Value;
                    var json = item.ToString();
                    switch (tp)
                    {
                        case EventType.Message:
                            mg.Events.Add(JsonConvert.DeserializeObject<MessageEvent>(json));
                            break;
                        case EventType.Follow:
                            mg.Events.Add(JsonConvert.DeserializeObject<FollowEvent>(json));
                            break;
                        case EventType.UnFollow:
                            mg.Events.Add(JsonConvert.DeserializeObject<UnFollowEvent>(json));
                            break;
                        case EventType.Join:
                            mg.Events.Add(JsonConvert.DeserializeObject<JoinEvent>(json));
                            break;
                        case EventType.Leave:
                            mg.Events.Add(JsonConvert.DeserializeObject<LeaveEvent>(json));
                            break;
                        case EventType.Postback:
                            mg.Events.Add(JsonConvert.DeserializeObject<PostbackEvent>(json));
                            break;
                        case EventType.Beacon:
                            mg.Events.Add(JsonConvert.DeserializeObject<BeaconEvent>(json));
                            break;
                        default:throw new InvalidOperationException();
                    }
                }
            }
            return mg;
        }
    }
    public enum SourceType
    {
        User,
        Group,
        Room,
    }
    public class Source
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public SourceType Type { get; set; }
        public String ID
        {
            get
            {
                switch (this.Type)
                {
                    case SourceType.User: return this.UserID;
                    case SourceType.Group: return this.GroupID;
                    case SourceType.Room: return this.RoomID;
                    default: throw new InvalidOperationException();
                }
            }
        }
        public String UserID { get; set; }
        public String GroupID { get; set; }
        public String RoomID { get; set; }
    }
    public enum EventType
    {
        Message,
        Follow,
        UnFollow,
        Join,
        Leave,
        Postback,
        Beacon,
    }
    public abstract class Event
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract EventType Type { get; }
        public String Timestamp { get; set; }
        public Source Source { get; set; }
    }

    public enum MessageType
    {
        Text,
        Image,
        Video,
        Audio,
        File,
        Location,
        Sticker,
    }
    public class MessageEvent : Event
    {
        public override EventType Type => EventType.Message;
        public String ReplyToken { get; set; }
        public Message Message { get; set; }
    }
    public class Message
    {
        public String ID { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageType Type { get; set; }
        public String Text { get; set; }
        public String FileName { get; set; }
        public Int32 FileSize { get; set; }
    }

    public class FollowEvent : Event
    {
        public override EventType Type => EventType.Follow;
        public String ReplyToken { get; set; }
    }
    public class UnFollowEvent : Event
    {
        public override EventType Type => EventType.UnFollow;
    }
    public class JoinEvent : Event
    {
        public override EventType Type => EventType.Join;
        public String ReplyToken { get; set; }
    }
    public class LeaveEvent : Event
    {
        public override EventType Type => EventType.Leave;
    }
    public class PostbackEvent : Event
    {
        public override EventType Type => EventType.Postback;
        public String ReplyToken { get; set; }
        public PostBackData Postback { get; set; }
    }
    public class PostBackData
    {
        public String Data { get; set; }
    }
    public class BeaconEvent : Event
    {
        public override EventType Type => EventType.Beacon;
        public String ReplyToken { get; set; }
        public Beacon Beacon { get; set; }
    }
    public class Beacon
    {
        public String HwID { get; set; }
        public BeaconType Type { get; set; }
    }
    public enum BeaconType
    {
        Enter,
        Leave,
        Banner,
    }
}