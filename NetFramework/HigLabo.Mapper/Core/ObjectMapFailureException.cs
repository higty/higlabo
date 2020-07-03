using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public class ObjectMapFailureException : Exception
    {
        public Object SourceObject { get; private set; }
        public Object TargetObject { get; private set; }

        public ObjectMapFailureException() { }
        public ObjectMapFailureException(String message, Object sourceObject, Object targetObject, Exception exception)
            : base(message, exception)
        {
            this.SourceObject = sourceObject;
            this.TargetObject = targetObject;
        }
    }
}
