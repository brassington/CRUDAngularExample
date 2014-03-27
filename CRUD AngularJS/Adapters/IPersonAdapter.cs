using PracticeAngular.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJS_WebApi_EF.Adapters
{
    public interface IPersonAdapter
    {
        List<Person> GetListPeople();
        Person GetSinglePerson(int id);
        Person PutSinglePerson(int id, Person person);
        Person PostSinglePerson(Person person);
        void DeleteSinglePerson(int id);
    }
}
