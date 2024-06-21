using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable實作
{
    internal class Observer<T>
    {
        private Action<T> _next;
        private Action _error;
        private Action _complete;
        private bool isStopped;
        public Observer(Action<T> next, Action error = null, Action complete = null) 
        {
            this._next = next;
            this._error = error;
            this._complete = complete;
        }

        private void Unsubscribe()
        {
            this.isStopped = true;
        }

        public void Next(T value) 
        {
            if(this._next == null)
                return;
            this._next.Invoke(value);
        }

        public void Complete()
        {
            if (this._complete == null)
                return;
            this._complete.Invoke();
        }
    }
}
