using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Lanit3.Models;

namespace Lanit3.Controllers
{
    public class HakatonController : ApiController
    {
        [HttpPost]
        [Route("person")]
        public HttpResponseMessage Person([FromBody] Person person)
        {
            if (!person.IsValid())
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            try
            {
                DataBase.ModelContainer.personSet.Add(person.ParseToDb());
                DataBase.ModelContainer.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch(Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
        }

        [HttpPost]
        [Route("car")]
        public HttpResponseMessage Car([FromBody] Car car)
        {
            if (!car.IsValid())
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            try
            {
                DataBase.ModelContainer.carSet.Add(car.ParseToDb());
                DataBase.ModelContainer.SaveChanges();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
        }

        [HttpGet]
        [Route("personwithcars")]
        [ResponseType(typeof(Person))]
        public HttpResponseMessage PersonWithCars(HttpRequestMessage request, long personId)
        {
            // return person if exists
            if (personId <= 0)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            try
            {
                var pers = DataBase.ModelContainer.personSet.First(x => x.Id == personId);
                Person person = new Person(pers);
                return request.CreateResponse(HttpStatusCode.OK,person);
            }
            catch (Exception e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
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
            DataBase.ModelContainer.carSet.RemoveRange(DataBase.ModelContainer.carSet);
            DataBase.ModelContainer.personSet.RemoveRange(DataBase.ModelContainer.personSet);
            DataBase.ModelContainer.SaveChanges();
        }
    }
}
