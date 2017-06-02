using App.Core;
using Stargramer.Core;
using Stargramer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stargramer.Line
{
    public static class LineBotClientExtensions
    {
        public static void SendElectedMessage(this LineBotClient client, OfferDataContext.Entry_Result_Edit_Record record, TextManager textManager)
        {
            var r = record;
            var cl = client;
            var tm = textManager;
            cl.SendMessage(r.LineID, tm.Text(TextKey.YourEntryElected));
            var url = String.Format("{0}/Offer/{1}/View", StargramerUrlInfo.WebSiteUrl, r.OfferCD);
            cl.SendMessage(r.LineID, tm.Text(TextKey.PleaseInputScheduleCandidate) + Environment.NewLine
                + url);
        }
    }
}
