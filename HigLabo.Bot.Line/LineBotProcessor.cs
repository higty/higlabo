using App.Core;
using HigLabo.Core;
using Newtonsoft.Json;
using Stargramer.Core;
using Stargramer.Data;
using Stargramer.Line.Send;
using Stargramer.Line.Webhook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stargramer.Line
{
    public class LineBotProcessor
    {
        public static class CommandNames
        {
            public static readonly String ApplyCommand = "ApplyCommand";
            public static readonly String EntryScheduleAcceptCommand = "EntryScheduleAcceptCommand";
        }

        public void ReceiveMessage(WebhookMessage message)
        {
            UserActionMessage m = null;
            foreach (var item in message.Events)
            {
                switch (item.Type)
                {
                    case EventType.Message:
                        m = new UserActionMessage(item as MessageEvent);
                        break;
                    case EventType.Postback:
                        m = new UserActionMessage(item as PostbackEvent);
                        break;
                    case EventType.Follow:break;
                    case EventType.UnFollow:break;
                    case EventType.Join:break;
                    case EventType.Leave:break;
                    case EventType.Beacon:break;
                    default:throw new InvalidOperationException();
                }
            }
            if (m != null)
            {
                this.ReceiveMessage(m);
            }
        }
        private void ReceiveMessage(UserActionMessage message)
        {
            var mg = message;
            if (mg.ActionType == UserActionType.Postback)
            {
                var data = JsonConvert.DeserializeObject<ActionData>(mg.Postback.Data);

                if (data.Name == CommandNames.ApplyCommand)
                {
                    var rUser = WebApp.Current.DatabaseCache.User.SelectBy_LineID(mg.Source.ID);
                    var dc = new OfferDataContext(rUser.UserCD);
                    var gg = new List<Guid>();
                    gg.Add(Guid.Parse(data.Value));

                    var l = new List<OfferDataContext.Entry_Result_Edit_Record>();
                    if (data.Method == nameof(OfferEntryResult.Elected))
                    {
                        l = dc.Entry_Result_Edit(OfferEntryResult.Elected, gg.ToArray());
                    }
                    else if (data.Method == nameof(OfferEntryResult.Rejected))
                    {
                        l = dc.Entry_Result_Edit(OfferEntryResult.Rejected, gg.ToArray());
                    }
                    var cl = new LineBotClient();
                    foreach (var r in l)
                    {
                        cl.SendElectedMessage(r, WebApp.Current.TextManager.Copy(rUser.Language));
                    }
                }

                if (data.Name == CommandNames.EntryScheduleAcceptCommand)
                {
                    if (data.Method == "Accept")
                    {
                        var rUser = WebApp.Current.DatabaseCache.User.SelectBy_LineID(mg.Source.ID);
                        var scheduleCD = Guid.Parse(data.Value);
                        var dc = new OfferDataContext(rUser.UserCD);
                        dc.Entry_Schedule_Accept(scheduleCD);
                        var rOffer = dc.DOffer_SelectBy_ScheduleCD(scheduleCD);

                        var tm = WebApp.Current.TextManager;
                        var cl = new LineBotClient();
                        //Send to Instagramer
                        cl.SendMessage(mg.Source.ID, tm.Text(TextKey.ScheduleIsAccepted) + Environment.NewLine
                            + "https://www.stargramer.com/User/Offer/List");

                        //Send to shop person
                        var rShop = WebApp.Current.DatabaseCache.Shop.SelectByPrimaryKey(rOffer.ShopCD);
                        if (rShop.LineID.IsNullOrEmpty() == false)
                        {
                            cl.SendMessage(rShop.LineID, tm.Text(TextKey.ScheduleAcceptCompletedAndSendMessageToInstagramer));
                        }
                    }
                    else if (data.Method == "Deny")
                    {

                    }
                }
            }
        }
    }
}
