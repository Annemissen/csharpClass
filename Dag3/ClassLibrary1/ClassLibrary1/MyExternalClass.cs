using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class MyExternalClass : IMyExternalClass
    {
        public MyExternalClass(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public string GetMeAsText()
        {
            return this.Name;
        }
    }
}
