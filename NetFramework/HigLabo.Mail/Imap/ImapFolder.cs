using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Imap
{
    /// <summary>
    /// 
    /// </summary>
    public class ImapFolder
    {
        /// <summary>
        /// 
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Boolean HasChildren { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Boolean NoSelect { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32 MailCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32 RecentMailCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ImapFolder> Children { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyCollection<String> Flags { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public ImapFolder(SelectResult result)
        {
            this.Name = result.FolderName;
            this.MailCount = result.Exists;
            this.RecentMailCount = result.Recent;
            this.Flags = new ReadOnlyCollection<string>(new List<string>(result.Flags));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public ImapFolder(ListLineResult result)
        {
            this.Name = result.Name;
            this.NoSelect = result.NoSelect;
            this.HasChildren = result.HasChildren;
            this.MailCount = -1;
            this.RecentMailCount = -1;
            this.Flags = new ReadOnlyCollection<string>(new List<string>());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="noSelect"></param>
        /// <param name="hasChildren"></param>
        public ImapFolder(String folderName, Boolean noSelect, Boolean hasChildren)
        {
            this.Name = folderName;
            this.NoSelect = noSelect;
            this.HasChildren = hasChildren;
            this.MailCount = -1;
            this.RecentMailCount = -1;
            this.Flags = new ReadOnlyCollection<string>(new List<string>());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
