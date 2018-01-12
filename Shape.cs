using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WindowsFormsApplication3
{
    abstract class Shape
    {
        public abstract double CalculateArea();
        [Newtonsoft.Json.JsonProperty("Id")]
        public int Id { get; set; }
    }
}
