using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ConsoleAppPersonData
{
    class SortByWeight : IComparer<Person>
    {

        public int Compare([AllowNull] Person x, [AllowNull] Person y)
        {
            return x.Weight.CompareTo(y.Weight);
        }
    }
}