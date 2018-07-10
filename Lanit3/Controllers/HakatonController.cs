using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lanit3.Models;

namespace Lanit3.Controllers
{
    public class HakatonController : ApiController
    {
        [HttpPost]
        [Route("person")]
        public void Person([FromBody] Person person)
        {
            // save person
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("car")]
        public void Car([FromBody] Car car)
        {
            // save car
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("personwithcars")]
        public Person PersonWithCars(long personId)
        {
            // return person if exists
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("statistics")]
        public Statistics Statistics()
        {
            // return statistics
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("clear")]
        public void Clear()
        {
            // clear database
            throw new NotImplementedException();
        }
    }
}
