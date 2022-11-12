using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HigLabo.Html
{
    public class SlackEmojiHtmlConverter : RegexHtmlConverter
    {
        public class SlackEmojiRecord
        {
            public String Name { get; set; } = "";
            public String Text { get; set; } = "";
        }
        public static class RegexList
        {
            public static Regex Emoji = new Regex(":(?<Name>[^:]*):", RegexOptions.IgnoreCase);
        }

        public static List<SlackEmojiRecord> SlackEmojiList = new();

        static SlackEmojiHtmlConverter()
        {
            InitializeSlackEmojiList();
        }
        private static void InitializeSlackEmojiList()
        {
            var asm = typeof(SlackEmojiHtmlConverter).Assembly;
            var name = asm.GetManifestResourceNames().FirstOrDefault(el => el.EndsWith("SlackEmojiList.json"));
            if (name == null) { return; }
            using (var stream = asm.GetManifestResourceStream(name))
            {
                if (stream == null) { return; }
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    var d = System.Text.Json.JsonSerializer.Deserialize<Dictionary<String, String>>(json);
                    foreach (var kv in d)
                    {
                        var r = new SlackEmojiRecord();
                        r.Name = kv.Key;
                        r.Text = kv.Value;
                        SlackEmojiList.Add(r);
                    }
                }
            }
        }

        protected override IEnumerable<Regex> GetRegexList()
        {
            yield return RegexList.Emoji;
        }
        protected override String Convert(Match match)
        {
            var m = match;
            var name = m.Groups["Name"].Value;
            var rEmoji = SlackEmojiList.Find(el => el.Name == name);

            if (rEmoji == null)
            {
                return m.Value;
            }
            else
            {
                return $"<div class=\"slack-emoji\">{rEmoji.Text}</div>";
            }
        }

    }
}
