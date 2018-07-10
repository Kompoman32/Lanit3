using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lanit3.Model;
using Newtonsoft.Json;

namespace Lanit3.Models
{
    public class Person
    {
        public Person(){}
        public Person(person p)
        {
            Id = p.Id;
            Name = p.name;
            BirthDate = p.birthdate.ToString("dd.MM.yyyy");
            Cars = p.car.Select(x=>new Car(x)).ToList();
        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthdate")]
        public string BirthDate { get; set; }

        [JsonProperty("cars")]
        public List<Car> Cars { get; set; }

        public bool IsValid()
        {
            return DateTime.TryParse(BirthDate, out var date) && date < DateTime.Today && !DataBase.ModelContainer.personSet.Select(x=>x.Id).Contains(Id);
        }

        public person ParseToDb()
        {
            var pers = new person();
            if (DateTime.TryParse(BirthDate, out var date)){
                pers.Id = Id;
                pers.birthdate = date;
                pers.name = Name;
                return pers;
            }
            throw new ArgumentException();
        }
    }
}