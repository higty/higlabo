using System;
using System.Collections.Generic;
using System.Text;
using HigLabo.Net.Mail;
using HigLabo.Mime;

namespace HigLabo.Net.Smtp;

public class SendMailResult
{
    private List<MailAddress> _InvalidMailAddressList = new List<MailAddress>();
    public Boolean SendSuccessful
    {
        get { return this.State == SendMailResultState.Success; }
    }
    public SendMailResultState State { get; private set; }
    public List<MailAddress> InvalidMailAddressList
    {
        get { return this._InvalidMailAddressList; }
    }
    public SendMailCommand Command { get; private set; }
    public String Message { get; private set; }
    public SendMailResult(SendMailResultState state, SendMailCommand command)
    {
        this.Command = command;
        this.State = state;
        this.Message = "";
    }
    public SendMailResult(SendMailResultState state, SendMailCommand command, String message, IEnumerable<MailAddress> invalidMailAddressList)
    {
        this.Command = command;
        this.State = state;
        this.Message = message;
        this.InvalidMailAddressList.AddRange(invalidMailAddressList);
    }
    public override string ToString()
    {
        return String.Format("Success={0}, State={1}, InvalidMailAddressCount={2}"
            , this.SendSuccessful, this.State, this.InvalidMailAddressList.Count);
    }
}
