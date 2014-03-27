using AngularJS_WebApi_EF.Adapters;
using PracticeAngular.Database;
using PracticeAngular.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AngularJS_WebApi_EF.Controllers
{
    public class PersonController : ApiController
    {
        private IPersonAdapter _personAdapter;

        public PersonController()
        {
            _personAdapter = new PersonDataAdapter();
        }

        public PersonController(IPersonAdapter adapter)
        {
            _personAdapter = adapter;
        }


        //private PersonContext db = new PersonContext();

        // GET api/Person
        public List<Person> GetPeople()
        {
            return _personAdapter.GetListPeople().ToList();
        }

        // GET api/Person/5
        public Person GetPerson(int id)
        {
            Person person = _personAdapter.GetSinglePerson(id);
            if (person == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return person;
        }

        // PUT api/Person/5
        public HttpResponseMessage PutPerson(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != person.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                person = _personAdapter.PutSinglePerson(id, person);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Person
        public HttpResponseMessage PostPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                person = _personAdapter.PostSinglePerson(person);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, person);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = person.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Person/5
        public HttpResponseMessage DeletePerson(int id)
        {
            Person person = _personAdapter.GetSinglePerson(id);
            if (person == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
                      

            try
            {
                _personAdapter.DeleteSinglePerson(id);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, person);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}