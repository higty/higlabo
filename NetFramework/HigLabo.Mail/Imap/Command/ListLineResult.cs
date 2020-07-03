using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Imap
{
    /// <summary>
    /// 
    /// </summary>
    public class ListLineResult
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
        /// <param name="folderName"></param>
        /// <param name="noSelect"></param>
        /// <param name="hasChildren"></param>
        public ListLineResult(String folderName, Boolean noSelect, Boolean hasChildren)
        {
            this.Name = folderName;
            this.NoSelect = noSelect;
            this.HasChildren = hasChildren;
        }
    }
}
