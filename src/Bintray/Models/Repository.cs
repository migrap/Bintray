using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Labels = System.Collections.Generic.List<string>;

namespace Bintray.Models {
    public class Repository {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("labels")]
        public Labels Labels { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("package_count")]
        public int Packages { get; set; }
    }
}
