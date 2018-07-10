using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web;
using Lanit3.Models;


namespace Lanit3.Controllers
{
    public class HakatonController : ApiController
    {
        [HttpPost]
        [Route("person")]
        public void Person([FromBody] Person person)
        {
            if (!person.IsValid())
            throw new HttpResponseException(HttpStatusCode.BadRequest);
            try
            {
                DataBase.ModelContainer.personSet.Add(person.ParseToDb());
                DataBase.ModelContainer.SaveChanges();
            }
            catch(Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
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
        [ResponseType(typeof(Statistics))]
        public HttpResponseMessage Statistics(HttpRequestMessage request)
        {
            var stat = new Statistics() { CarCount = 4, PersonCount = 0, UniqueVendorCount = 4 };

            //return new HttpResponseMessage(HttpStatusCode.NotFound);
            
            return request.CreateResponse(HttpStatusCode.OK, stat);
            //var t  = Request.CreateErrorResponse(HttpStatusCode.BadRequest, new Exception());
            //throw new HttpResponseException(HttpStatusCode.BadRequest);


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
