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
    public class XListResult
    {
        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyCollection<XListLineResult> Lines { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lines"></param>
        public XListResult(List<XListLineResult> lines)
        {
            this.Lines = new ReadOnlyCollection<XListLineResult>(lines);
        }
    }
}
