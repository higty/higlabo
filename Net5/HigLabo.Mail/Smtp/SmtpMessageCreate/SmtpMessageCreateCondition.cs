using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HigLabo.Mime;

namespace HigLabo.Net.Smtp
{
    public class SmtpMessageCreateCondition
    {
        public MailAddress Sender { get; set; }

        public MailAddressCreateCondition To { get; set; }
        public MailAddressCreateCondition Cc { get; set; }
        public MailAddressCreateCondition Bcc { get; set; }

        public SmtpMessageReplyMode ReplyMode { get; set; }
        public Boolean CopyContents { get; set; }
        public Boolean CopyAlternateViews { get; set; }
        public Boolean CopyAttachments { get; set; }

        public ISmtpMessageSubjectFormatter SubjectFormatter { get; set; }
        public ISmtpMessageBodyFormatter BodyFormatter { get; set; }

        public SmtpMessageCreateCondition(MailAddress sender, SmtpMessageCreateMode mode, Boolean isBodyHtml)
        {
            this.Sender = sender;
            this.ReplyMode = SmtpMessageReplyMode.QuoteBodyText;

            switch (mode)
            {
                case SmtpMessageCreateMode.Copy: this.SubjectFormatter = new SmtpMessageSubjectCopyFormatter();break;
                case SmtpMessageCreateMode.Reply: this.SubjectFormatter = new SmtpMessageSubjectReplyFormatter(); break;
                case SmtpMessageCreateMode.ReplyAll: this.SubjectFormatter = new SmtpMessageSubjectReplyFormatter(); break;
                case SmtpMessageCreateMode.Transfer: this.SubjectFormatter = new SmtpMessageSubjectTransferFormatter(); break;
                default: throw new InvalidOperationException();
            }
            if (mode == SmtpMessageCreateMode.Copy)
            {
                this.BodyFormatter = new SmtpMessageBodyTextCopyFormatter();
            }
            else
            {
                if (isBodyHtml == true)
                {
                    this.BodyFormatter = new SmtpMessageBodyHtmlReplyFormatter();
                }
                else
                {
                    this.BodyFormatter = new SmtpMessageBodyTextReplyFormatter();
                }
            }

            this.To = new MailAddressCreateCondition(sender);
            this.Cc = new MailAddressCreateCondition(sender);
            this.Bcc = new MailAddressCreateCondition(sender);

            switch (mode)
            {
                case SmtpMessageCreateMode.Copy:
                    this.To.UseTo = true;
                    this.Cc.UseCc = true;
                    this.Bcc.UseBcc = true;
                    this.CopyAlternateViews = true;
                    this.CopyAttachments = true;
                    this.CopyContents = true;
                    break;
                case SmtpMessageCreateMode.Reply:
                    this.To.UseFrom = true;
                    this.To.UseSender = true;
                    this.CopyAlternateViews = false;
                    this.CopyAttachments = false;
                    this.CopyContents = false;
                    break;
                case SmtpMessageCreateMode.ReplyAll:
                    this.To.UseFrom = true;
                    this.To.UseSender = true;
                    this.Cc.UseTo = true;
                    this.Cc.UseCc = true;
                    this.CopyAlternateViews = false;
                    this.CopyAttachments = false;
                    this.CopyContents = false;
                    break;
                case SmtpMessageCreateMode.Transfer:
                    this.CopyAlternateViews = true;
                    this.CopyAttachments = true;
                    this.CopyContents = true;
                    break;
                default: throw new InvalidOperationException();
            }
            
        }
    }
}
