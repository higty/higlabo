using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Text;
using HigLabo.Net.Mail;

namespace HigLabo.Net.Imap
{
    /// <summary>
    /// 
    /// </summary>
    public class CapabilityResult : ImapCommandResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyCollection<String> Features { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="text"></param>
        public CapabilityResult(String tag, String text)
            : base(tag, text)
        {
            String s = "* Capability ";
            if (text.StartsWith(s, StringComparison.OrdinalIgnoreCase) == false)
            { throw new MailClientException(text); }

            String line = "";
            using (StringReader sr = new StringReader(text))
            {
                line = sr.ReadLine();
            }
            Int32 index = s.Length;
            String ss = line.Substring(index, line.Length - index);
            List<String> l = new List<string>();
            foreach (var el in ss.Split(' '))
            {
                if (String.IsNullOrEmpty(el) == true) { continue; }
                l.Add(el);
            }
            this.Features = new ReadOnlyCollection<string>(l);
        }
    }
}
