using System;
using System.Linq;
using Lanit3.Model;
using Newtonsoft.Json;

namespace Lanit3.Models
{
    public class Car
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("horsepower")]
        public int HorsePower { get; set; }

        [JsonProperty("ownerId")]
        public long OwnerId { get; set; }

        public bool IsValid()
        {
            var person = DataBase.ModelContainer.personSet.First(x => x.Id == Id);
            return HorsePower > 0 && !DataBase.ModelContainer.carSet.Select(x => x.Id).Contains(Id) && person != null && person.birthdate <= DateTime.Today.AddYears(-18);
        }

        public car ParseToDb()
        {
            var car = new car();
            car.Id = Id;
            return car;
        }
    }
}