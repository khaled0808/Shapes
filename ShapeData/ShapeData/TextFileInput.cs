using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShapeData
{
    [ServiceContract()]
    public class TextFileInput
    {
        [Newtonsoft.Json.JsonProperty("textFile")]
        public string textFile { get; set; }
    }
}
