using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusTraning.EventBus
{
    public class EventBus
    {
        private readonly Dictionary<Type, List<Delegate>> eventHandlers = new Dictionary<Type, List<Delegate>>();
        public void Subscribe<T>(Action<T> eventHandler)
        {
            Type eventType = typeof(T);
            if (!eventHandlers.ContainsKey(eventType))
            {
                eventHandlers[eventType] = new List<Delegate>();
            }

            eventHandlers[eventType].Add(eventHandler);
        }
        public void Unsubscribe<T>(Action<T> eventHandler)
        {
            Type eventType = typeof(T);
            if (eventHandlers.ContainsKey(eventType))
            {
                eventHandlers[eventType].Remove(eventHandler);
            }
        }
        public void Publish<T>(T @event)
        {
            Type eventType = typeof(T);
            if (eventHandlers.ContainsKey(eventType))
            {
                foreach (var handler in eventHandlers[eventType])
                {
                    ((Action<T>)handler)(@event);
                }
            }
        }
    }
}
