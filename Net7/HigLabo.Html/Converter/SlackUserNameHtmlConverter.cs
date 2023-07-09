using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HigLabo.Html
{
    public class SlackUserNameHtmlConverter : RegexHtmlConverter
    {
        public class SlackUserRecord
        {
            public String ID { get; set; } = "";
            public String Name { get; set; } = "";
        }
        public static class RegexList
        {
            public static Regex UserName = new Regex("<@(?<UserID>[^>]*)>", RegexOptions.IgnoreCase);
        }
        public List<SlackUserRecord> SlackUserList = new();

        protected override IEnumerable<Regex> GetRegexList()
        {
            yield return RegexList.UserName;
        }
        protected override String Convert(Match match)
        {
            var m = match;
            var userID = m.Groups["UserID"].Value;
            var userName = this.SlackUserList.Find(el => el.ID == userID)?.Name ?? userID;

            return $"<span class=\"slack-user-name\">@{userName}</span>";
        }

    }
}
