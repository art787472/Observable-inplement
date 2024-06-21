using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable實作
{
    internal class CustomEventHandler<T>
    {
        private static Subject<T> _subject = new Subject<T>((ob) => { });

        public CustomEventHandler()
        {

        }

        public static void Notify(T value)
        {
            _subject.Next(value);
        }

        public static CustomEventHandler<T> operator +(CustomEventHandler<T> eventHandler, Action<T> action)
        {
            _subject.Subscribe(action);
            return eventHandler;
        }
        
    }
}
