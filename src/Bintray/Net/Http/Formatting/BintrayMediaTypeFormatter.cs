using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Bintray.Net.Http.Formatting {
    internal class BintrayMediaTypeFormatter : JsonMediaTypeFormatter {
        public BintrayMediaTypeFormatter() {
            //SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.IsoDateTimeConverter)
        }
    }
}
