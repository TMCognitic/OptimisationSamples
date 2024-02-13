using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPatternMediator.MediatorPattern
{
    public class Mediator<TMessage>
        where TMessage : struct, IMessage
    {
        public static readonly Mediator<TMessage> Instance = new Mediator<TMessage>();

        public event Action<TMessage>? Publisher;

        private Mediator()
        {
            
        }

        public void Send(TMessage message)
        {
            Publisher?.Invoke(message);
        }
    }
}
