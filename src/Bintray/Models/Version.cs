using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Labels = System.Collections.Generic.List<string>;
using Attributes = System.Collections.Generic.List<string>;
using Newtonsoft.Json;

namespace Bintray.Models {
    public class Version {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("desc")]
        public string Description { get; set; }

        [JsonProperty("package")]
        public string Package { get; set; }

        [JsonProperty("repo")]
        public string Repository { get; set; }

        [JsonProperty("owner")]
        public string Owner { get; set; }

        [JsonProperty("labels")]
        public Labels Labels { get; set; }

        [JsonProperty("attributes")]
        public Attributes Attributes { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }

        [JsonProperty("released")]
        public DateTimeOffset Released { get; set; }

        [JsonProperty("ordinal")]
        public int Ordinal { get; set; }
    }
}
