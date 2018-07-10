using Newtonsoft.Json;

namespace Lanit3.Models
{
    public class Statistics
    {
        [JsonProperty("personcount")]
        public long PersonCount { get; set; }

        [JsonProperty("carcount")]
        public long CarCount { get; set; }

        [JsonProperty("uniquevendorcount")]
        public long UniqueVendorCount { get; set; }
    }
}