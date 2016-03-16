using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HigLabo.Core
{
    public static class TaskExtensions
    {
        public static event EventHandler<ExceptionThrownEventArgs> Error;

        public static void FireAndForget(this Task task)
        {
            task.ContinueWith(result =>
            {
                OnError(new ExceptionThrownEventArgs(result.Exception));
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
        private static void OnError(ExceptionThrownEventArgs e)
        {
            var eh = Error;
            if (eh != null)
            {
                eh(null, e);
            }
        }
    }
}
