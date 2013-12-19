using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bintray.Models {
    public class Packages : List<Packages.Package> {
        public class Package {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("linked")]
            public bool Linked { get; set; }
        }
    }
}
