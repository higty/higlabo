using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// <summary>
    /// 
    /// </summary>
    public class SendMailListResult
    {
        private List<SendMailResult> _Results = new List<SendMailResult>();
        /// <summary>
        /// 
        /// </summary>
        public SendMailResultState State { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SendMailResult> Results
        {
            get { return _Results; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public SendMailListResult(SendMailResultState state)
        {
            this.State = state;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="results"></param>
        public SendMailListResult(SendMailResultState state, IEnumerable<SendMailResult> results)
        {
            this.State = state;
            this.Results.AddRange(results);
        }
    }
}
