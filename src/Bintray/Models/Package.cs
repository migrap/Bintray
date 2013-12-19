using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attributes = System.Collections.Generic.List<string>;
using Versions = System.Collections.Generic.List<string>;
using Labels = System.Collections.Generic.List<string>;

namespace Bintray.Models {
    public class Package {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("repo")]
        public string Repository { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("labels")]
        public Labels Labels { get; set; }

        [JsonProperty("attributes_name")]
        public Attributes Attributes { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("rating_count")]
        public int Ratings { get; set; }

        [JsonProperty("followers_count")]
        public int Followers { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("versions")]
        public Versions Versions { get; set; }

        [JsonProperty("latest_version")]
        public string Version { get; set; }

        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }
    }
}
