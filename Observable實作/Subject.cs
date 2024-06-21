using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable實作
{
    internal class Subject<T>
    {
        private Action<Observer<T>> _subscribe;
        private List<Observer<T>> _observers = new List<Observer<T>>();

        public Subject()
        {
            
        }
        public Subject(Action<Observer<T>> subscribe) 
        {
            _subscribe = subscribe;
        }


        public void Subscribe(Observer<T> observer)
        {
            _observers.Add(observer);
            foreach (Observer<T> ob in _observers)
            {
                _subscribe.Invoke(ob);
            }
        }

        public void Subscribe(Action<T> action)
        {
            _observers.Add(new Observer<T>(action));
            foreach (Observer<T> ob in _observers)
            {
                _subscribe.Invoke(ob);
            }
        }

        public void Unsubscribe(Observer<T> observer)
        {
            _observers.Remove(observer);
        }

        

        public void Next(T value) 
        {
            Action<Observer<T>> action = (observer) =>
            {
                observer.Next(value);
            };
            foreach (Observer<T> observer in _observers)
            {
                action.Invoke(observer);
            }

        }
    }
}
