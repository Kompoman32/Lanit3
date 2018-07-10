using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Lanit3.Models
{
    public class Statistics
    {
        private static Statistics LanitStatistics { get; set; }
        private static HashSet<string> UniqueVendors { get; set; }

        [JsonProperty("personcount")]
        public long PersonCount { get; set; }

        [JsonProperty("carcount")]
        public long CarCount { get; set; }

        [JsonProperty("uniquevendorcount")]
        public long UniqueVendorCount { get; set; }

        public static void Init()
        {
            var stat = new Statistics();
            UniqueVendors = new HashSet<string>();
            var carCount = 0;
            foreach (var car in DataBase.ModelContainer.carSet)
            {
                var vendor = car.model.Split('-')[0].ToLower();
                if (!UniqueVendors.Contains(vendor)) UniqueVendors.Add(vendor);
                carCount++;
            }

            stat.CarCount = carCount;
            stat.PersonCount = DataBase.ModelContainer.personSet.Count();
            stat.UniqueVendorCount = UniqueVendors.Count;
            LanitStatistics = stat;
        }

        public static Statistics GetStatistics()
        {
            return LanitStatistics;
        }
    }
}