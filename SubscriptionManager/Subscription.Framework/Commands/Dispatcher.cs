using System.Threading.Tasks;

namespace Subscription.Framework.Commands
{
    //TODO: investigate usage of MediatR https://github.com/jbogard/MediatR
    public class Dispatcher
    {
        private readonly CommandHandlerMap _map;

        public Dispatcher(CommandHandlerMap map)
        {
            _map = map;
        }

        public Task Dispatch(object command)
        {
            var handler = _map.Get(command);
            if (handler == null)
                return Task.CompletedTask;

            return handler(command);
        }
    }
}
