using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core;

public class InvalidTimeStampException : Exception
{
    public Byte[] TimeStamp { get; private set; }
    public InvalidTimeStampException(Byte[] timeStamp)
    {
        this.TimeStamp = timeStamp;
    }
    public InvalidTimeStampException(Byte[] timeStamp, String message)
        : base(message)
    {
        this.TimeStamp = timeStamp;
    }
}
