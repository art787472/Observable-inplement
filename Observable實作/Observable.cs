using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable實作
{
    internal class Observable<T>
    {
        private Action<Observer<T>> _subscribe;
        public Observable(Action<Observer<T>> subscribe) 
        {
            this._subscribe = subscribe;
        }
        
        public void Subscribe(Observer<T> observer)
        {
            this._subscribe.Invoke(observer);

        }
        
        public void Subscribe(Action<T> action)
        {
            Observer<T> observer = new Observer<T>(action);
            this._subscribe.Invoke(observer);

        }



        public static Observable<T> From(IEnumerable<T> enumerable) 
        {
            return new Observable<T>((ob) => 
            {
                foreach (T item in enumerable)
                {
                    ob.Next(item);
                    ob.Complete();
                }
            });
        }

        public static Observable<T> Of(params T[] enumerable) 
        {
            return new Observable<T>((ob) =>
            {
                foreach (T item in enumerable)
                {
                    ob.Next(item);
                    ob.Complete();
                }
            });
        }
    }
}
