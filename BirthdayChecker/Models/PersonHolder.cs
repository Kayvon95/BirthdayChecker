using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayChecker.Models
{
    public static class PersonHolder
    {
        private static List<Person> persons = new List<Person>();

        public static IEnumerable<Person> Persons
        {
            get
            {
                return persons;
            }
        }

        public static void AddPerson(Person person)
        {
            persons.Add(person);
        }
    }
}
