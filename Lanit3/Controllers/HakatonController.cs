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
            if (!car.IsValid())
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            try
            {
                DataBase.ModelContainer.carSet.Add(car.ParseToDb());
                DataBase.ModelContainer.SaveChanges();
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

        [HttpGet]
        [Route("personwithcars")]
        public Person PersonWithCars(long personId)
        {
            // return person if exists
            if (personId <= 0)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            try
            {
                var pers = DataBase.ModelContainer.personSet.First(x => x.Id == personId);
                Person person = new Person(pers);
                return person;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
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
            // clear database
            throw new NotImplementedException();
        }
    }
}
