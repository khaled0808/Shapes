using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeData
{

    [Newtonsoft.Json.JsonObject("Circle")]
    public class Circle : Shape
    {
        [Newtonsoft.Json.JsonProperty("radius")]
        public double radius { get; set; }

        [Newtonsoft.Json.JsonProperty("area")]
        public double area;

        public Circle()
        {
        }

        public Circle(int id, double radius)
        {
            this.radius = radius;
            Id = id;
        }
        public override double CalculateArea()
        {
            area = this.radius * this.radius * 3.14;
            return area;
        }
    }

}