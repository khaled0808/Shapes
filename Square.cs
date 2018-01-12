using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    [Newtonsoft.Json.JsonObject("Square")]
    class Square : Shape
    {
        [Newtonsoft.Json.JsonProperty("width")]
        public double width { get; set; }
        [Newtonsoft.Json.JsonProperty("area")]
        public double area;
  
        public Square(int id, double width)
        {
            this.width = width;
            Id = id;
        }
        public override double CalculateArea()
        {
           area= this.width * this.width;
           return area;
        }
    }
}
