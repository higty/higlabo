using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using HigLabo.Net.Mail;

namespace HigLabo.Net.Imap
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchResult 
    {
        private static readonly List<String> _EmptyValueList = new List<String>();
        private static readonly List<Int64> _EmptyMailIndexList = new List<Int64>();
        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyCollection<String> Values { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyCollection<Int64> MailIndexList { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="text"></param>
        public SearchResult(String text)
        {
            String startText = "* Search";
            if (text.StartsWith(startText, StringComparison.OrdinalIgnoreCase) == false)
            { throw new MailClientException(text); }

            String line = "";
            using (StringReader sr = new StringReader(text))
            {
                line = sr.ReadLine();
            }
            Int32 startIndex = startText.Length + 1;
            if (line.Length < startIndex)
            {
                this.Values = new ReadOnlyCollection<String>(_EmptyValueList);
                this.MailIndexList = new ReadOnlyCollection<Int64>(_EmptyMailIndexList);
                return;
            }
            String ss = line.Substring(startIndex, line.Length - startIndex);
            List<String> values = new List<String>();
            List<Int64> indexList = new List<Int64>();
            Int64 index = 0;
            foreach (var el in ss.Split(' '))
            {
                values.Add(el);
                if (Int64.TryParse(el, out index) == true)
                {
                    indexList.Add(index);
                }
            }
            this.Values = new ReadOnlyCollection<String>(values);
            this.MailIndexList = new ReadOnlyCollection<Int64>(indexList);
        }
    }
}
