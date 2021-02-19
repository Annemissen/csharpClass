using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPersonData
{
    class People
    {

        private Dictionary<string, Person> personMap;

        public People()
        {
            personMap = new Dictionary<string, Person>();
        }

        public Dictionary<string, Person> PersonMap { get; }

        /**
         * Inserts an element k into the collection.The function must fail if the key is already occupied by some other element.
         */
        public bool AddPerson(string key, Person p)
        {
            return personMap.TryAdd(key, p);
        }

        /**
         * Retrieves an element identified by the Key k.If not found then the function returns null.
         */
        public Person GetPerson(string key)
        {
            Person value;
            personMap.TryGetValue(key, out value);
            return value;
        }

        public int Size()
        {
            return personMap.Count;
        }

    }
}
