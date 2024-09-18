using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Messaging
{
    public interface IEventBus
    {
        void Publish<T>(string queueName, T eventMessage);
        void Subscribe<T>(string queueName, Action<T> eventHandler);
    }
}
