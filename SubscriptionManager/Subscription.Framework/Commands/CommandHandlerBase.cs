using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Framework.Commands
{
    public class CommandHandlerBase
    {
        internal Dictionary<string, Func<object, Task>> Handlers { get; } 
            = new Dictionary<string, Func<object, Task>>();

        protected void Register<T>(Func<T, Task> handler)
        {
            Handlers.Add(typeof(T).Name, c => handler((T)c));
        }
    }
}
