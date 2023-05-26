using HigLabo.Mime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Smtp
{
    public class MailAddressCreateCondition
    {
        public MailAddress Sender { get; set; }
        public Boolean ExcludeSender { get; set; }

        public Boolean UseFrom { get; set; }
        public Boolean UseSender { get; set; }
        public Boolean UseTo { get; set; }
        public Boolean UseReplyTo { get; set; }
        public Boolean UseCc { get; set; }
        public Boolean UseBcc { get; set; }

        public MailAddressCreateCondition(MailAddress sender)
            : this(sender, false, false, false, false)
        {
        }
        public MailAddressCreateCondition(MailAddress sender, Boolean useFrom, Boolean useSender, Boolean useTo, Boolean useCc)
        {
            this.Sender = sender;
            this.ExcludeSender = false;
            this.UseFrom = useFrom;
            this.UseSender = useSender;
            this.UseTo = useTo;
            this.UseReplyTo = false;
            this.UseCc = useCc;
            this.UseBcc = false;
        }
    }
}
