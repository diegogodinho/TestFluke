using Models;
using NUnit.Framework;
using RequestService;
using System.Collections.Generic;
using System.Configuration;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string urlBase = "https://eonet.sci.gsfc.nasa.gov/api/v2.1/";//ConfigurationManager.AppSettings["api-url-base"];
            Event test = new HttpRequests(urlBase).Get<Event>("events");




            Assert.Pass();
        }
    }
}