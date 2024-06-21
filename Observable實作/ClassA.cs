using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Observable實作
{
    internal class ClassA
    {
        public void SayHi(string value)
        {
            ClassB b = new ClassB();
            b.SayHi(value);
        }
    }
}
