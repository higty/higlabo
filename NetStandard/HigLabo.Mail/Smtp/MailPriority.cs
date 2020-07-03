using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    /// <summary>
    /// 重要度
    /// </summary>
    public enum MailPriority : byte
    {
        /// <summary>
        /// 最高重要度
        /// </summary>
        High = 1,
        /// <summary>
        /// 普通
        /// </summary>
        Normal = 3,
        /// <summary>
        /// 最低重要度
        /// </summary>
        Low = 5
    }
    public static class MailPriorityExtensions
    {
#if !NETFX_CORE
        public static MailPriority Cast(this System.Net.Mail.MailPriority priority)
        {
            switch (priority)
            {
                case System.Net.Mail.MailPriority.High: return MailPriority.High;
                case System.Net.Mail.MailPriority.Low: return MailPriority.Low;
                case System.Net.Mail.MailPriority.Normal: return MailPriority.Normal;
                default: throw new InvalidOperationException();
            }
        }
#endif
    }
}
