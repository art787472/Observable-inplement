using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observable實作
{
    internal class ClassB
    {
        public void SayHi(string value)
        {
            ClassC c = new ClassC();
            c.SayHi(value);
        }
    }
}
