using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleAppPersonData
{
    class SortByAge : IComparer<Person>
    {

        public int Compare([AllowNull] Person x, [AllowNull] Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
