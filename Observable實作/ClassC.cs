using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable實作
{
    internal class ClassC
    {
        public void SayHi(string value)
        {
            CustomEventHandler<string>.Notify(value);
        }
    }
}
