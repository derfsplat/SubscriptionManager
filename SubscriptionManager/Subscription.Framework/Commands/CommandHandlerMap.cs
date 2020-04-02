using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscription.Framework.Commands
{
    public class CommandHandlerMap
    {
        private readonly Dictionary<string, Func<object, Task>> _handlers = new Dictionary<string, Func<object, Task>>();

        public CommandHandlerMap(params CommandHandlerBase[] commandHandlers)
        {
            foreach (var handler in commandHandlers.SelectMany(h => h.Handlers))
            {
                _handlers.Add(handler.Key, handler.Value);
            }
        }

        public Func<object, Task> Get(object command)
        {
            return _handlers[command.GetType().Name];
        }
    }
}
