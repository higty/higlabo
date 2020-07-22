using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HigLabo.Core
{
    public class ParalellExecutionContext
    {
        public List<Task> TaskList { get; private set; } = new List<Task>();

        public Exception Execute()
        {
            var tt = this.TaskList;
            foreach (var item in tt)
            {
                if (item.Status == TaskStatus.Created)
                {
                    item.Start();
                }
            }
            var allTask = Task.WhenAll(tt);
            try
            {
                allTask.Wait();
            }
            catch { }

            return allTask.Exception;
        }
        public List<T> GetResults<T>()
        {
            var l = new List<T>();
            foreach (var item in this.TaskList)
            {
                if (item.Exception != null) { continue; }

                if (item is Task<T> task)
                {
                    if (task.Result != null)
                    {
                        l.Add(task.Result);
                    }
                }
            }
            return l;
        }
    }
}
