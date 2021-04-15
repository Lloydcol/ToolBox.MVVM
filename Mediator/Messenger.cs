using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.MVVM.Mediator
{
    public static class Messenger<T>
    {
        private static Dictionary<string, Action<T>> _events = new Dictionary<string, Action<T>>();

        public static void Subscribe(string eventName, Action<T> action)
        {
            _events.Add(eventName, action);
        }

        public static void Publish(string eventName, T parameter)
        {
            Action<T> action = _events[eventName];
            action?.Invoke(parameter);
        }
    }
}
