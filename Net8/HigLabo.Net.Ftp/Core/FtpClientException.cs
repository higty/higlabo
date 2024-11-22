using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Ftp;

[Serializable]
public class FtpClientException : Exception
{
    public FtpCommandResult? Result { get; private set; }

    public FtpClientException()
    {
    }
    public FtpClientException(FtpCommandResult result)
    {
        this.Result = result;
    }
    public FtpClientException(String message)
        : base(message)
    {
    }
    public FtpClientException(Exception exception)
        : base(exception.Message, exception)
    {
    }
}
