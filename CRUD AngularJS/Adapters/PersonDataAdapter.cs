using PracticeAngular.Database;
using PracticeAngular.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJS_WebApi_EF.Adapters
{
    public class PersonDataAdapter : IPersonAdapter
    {
        public List<Person> GetListPeople()
        {
            PersonContext db = new PersonContext();
            return db.People.ToList();
        }


        public Person GetSinglePerson(int id)
        {
            PersonContext db = new PersonContext();
            Person person = db.People.Find(id);
            return person;
        }


        public Person PutSinglePerson(int id, Person newPerson)
        {
            PersonContext db = new PersonContext();
            Person oldPerson = db.People.Find(id);
            oldPerson.Name = newPerson.Name;
            db.SaveChanges();

            return oldPerson;
        }


        public Person PostSinglePerson(Person person)
        {
            PersonContext db = new PersonContext();
            db.People.Add(person);
            db.SaveChanges();

            return person;
        }

        public void DeleteSinglePerson(int id)
        {
            PersonContext db = new PersonContext();
            Person person = db.People.Find(id);
            db.People.Remove(person);
            db.SaveChanges();
        }
    }
}