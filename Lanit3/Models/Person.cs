﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Lanit3.Models
{
    public class Person
    {
        public Person()
        {

        }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthdate")]
        public string BirthDate { get; set; }

        [JsonProperty("cars")]
        public List<Car> Cars { get; set; }
    }
}