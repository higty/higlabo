using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Imap
{
    /// <summary>
    /// 
    /// </summary>
    public class XListLineResult
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
        public String XName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="noSelect"></param>
        /// <param name="hasChildren"></param>
        /// <param name="xName"></param>
        public XListLineResult(String folderName, Boolean noSelect, Boolean hasChildren, string xName)
        {
            this.Name = folderName;
            this.NoSelect = noSelect;
            this.HasChildren = hasChildren;
            this.XName = xName;
        }
    }
}
