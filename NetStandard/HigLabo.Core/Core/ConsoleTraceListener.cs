using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace App.Core
{
    public class ConsoleTraceListener : TextWriterTraceListener
    {

        public ConsoleTraceListener() : base(Console.Out)
        {
        }

        public ConsoleTraceListener(bool useErrorStream) : base(useErrorStream ? Console.Error : Console.Out)
        {
        }

        public override void Close()
        {
            // No resources to clean up.
        }
    }
}
