using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestService
{
    [ServiceContract()]
    public class TextInput
    {
        [Newtonsoft.Json.JsonProperty("textFile")]
        public string textFile { get; set; }
    }
}
