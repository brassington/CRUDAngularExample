using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AngularJS_WebApi_EF.Controllers;
using AngularJS_WebApi_EF.Adapters;
using PracticeAngular.DataModels;
using System.Collections.Generic;
using System.Web.Http.Hosting;
using System.Web.Http;
using System.Net;
using AngularJS_WebApi_EF;
using System.Web.Http.Routing;
using System.Net.Http;

namespace PracticeAngular.Test
{
    [TestClass]
    public class PersonControllerTest
    {
        private PersonController _controller;


        [TestMethod]
        public void TestGetPeople()
        {
            //Arrange
            _controller = new PersonController(new PersonMockAdapter())
            {
                Request = new System.Net.Http.HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            //Act
            var people = _controller.GetPeople();

            //Assert
            Assert.AreEqual(3, people.Count);
            Assert.AreEqual("Bob", people[0].Name);
            Assert.AreEqual("Frank", people[1].Name);

        }

        [TestMethod]
        public void TestGetPerson()
        {
            //Arrange
            _controller = new PersonController(new PersonMockAdapter())
            {
                Request = new System.Net.Http.HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            //Act
            var person = _controller.GetPerson(3);

            //Assert
            Assert.AreEqual("Charlie", person.Name);
        }

        [TestMethod]
        public void TestPutPerson()
        {
            //Arrange
            _controller = new PersonController(new PersonMockAdapter())
            {
                Request = new System.Net.Http.HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };

            Person mockPerson = new Person()
            {
                Id = 3,
                Name = "Victor"
            };

            //Act
            var result = _controller.PutPerson(mockPerson.Id, mockPerson);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void TestPostPerson()
        {
            //Arrange
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            var httpRouteData = new HttpRouteData(httpConfiguration.Routes["DefaultApi"],
                new HttpRouteValueDictionary { { "controller", "Books" } });
            
            _controller = new PersonController(new PersonMockAdapter())
            {
                Request = new System.Net.Http.HttpRequestMessage(HttpMethod.Post, "/api/Person")
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, httpConfiguration },
                    { HttpPropertyKeys.HttpRouteDataKey, httpRouteData }}
                }
            };

            Person mockPerson = new Person()
            {
                Id = 3,
                Name = "Victor"
            };

            //Act
            var result = _controller.PostPerson(mockPerson);

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
            
        }

        [TestMethod]
        public void TestDeletePerson()
        {
            //Arrange
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            var httpRouteData = new HttpRouteData(httpConfiguration.Routes["DefaultApi"],
                new HttpRouteValueDictionary { { "controller", "Books" } });

            _controller = new PersonController(new PersonMockAdapter())
            {
                Request = new System.Net.Http.HttpRequestMessage(HttpMethod.Post, "/api/Person")
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, httpConfiguration },
                    { HttpPropertyKeys.HttpRouteDataKey, httpRouteData }}
                }
            };


            //Act
            var result = _controller.DeletePerson(3);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

        }
    }
}
