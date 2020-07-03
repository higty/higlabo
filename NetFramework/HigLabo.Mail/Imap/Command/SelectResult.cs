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
    public class SelectResult
    {
        /// <summary>
        /// 
        /// </summary>
        public String FolderName { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32 Exists { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32 Recent { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyCollection<String> Flags { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="exists"></param>
        /// <param name="recent"></param>
        /// <param name="flags"></param>
        public SelectResult(String folderName, Int32 exists, Int32 recent, params String[] flags)
        {
            this.FolderName = folderName;
            this.Exists = exists;
            this.Recent = recent;
            this.Flags = new ReadOnlyCollection<string>(new List<string>(flags));
        }
    }
}
