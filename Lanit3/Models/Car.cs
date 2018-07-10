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
    }
}