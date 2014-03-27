using PracticeAngular.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJS_WebApi_EF.Adapters
{
    public class PersonMockAdapter : IPersonAdapter
    {   
        List<Person> mockdb = new List<Person>(){
                new Person { Id = 1, Name = "Bob"},
                new Person { Id = 2, Name = "Frank"},
                new Person { Id = 3, Name = "Charlie"}
            };

        public List<Person> GetListPeople()
        {
            return mockdb;
        }

        public Person GetSinglePerson(int id)
        {
            Person person = mockdb.Where(p => p.Id == id).FirstOrDefault();
            return person;
        }

        public Person PutSinglePerson(int id, Person newPerson)
        {
            Person oldPerson = mockdb.Where(p => p.Id == id).FirstOrDefault();
            oldPerson.Name = newPerson.Name;
            return oldPerson;
        }

        public Person PostSinglePerson(Person person)
        {
            Person newPerson = new Person();
            newPerson.Id = person.Id;
            newPerson.Name = person.Name;

            mockdb.Add(newPerson);
            return newPerson;
        }

        public void DeleteSinglePerson(int id)
        {
            Person person = mockdb.Where(p => p.Id == id).FirstOrDefault();
            mockdb.Remove(person);
        }
    }
}