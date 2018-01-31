using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ShapeData
{

    [ServiceContract()]
    public abstract class Shape

    {
        public abstract double CalculateArea();
        [Newtonsoft.Json.JsonProperty("Id")]
        public int Id { get; set; }
    }
}
