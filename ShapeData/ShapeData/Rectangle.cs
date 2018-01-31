using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeData
{
    public class Rectangle : Shape
    {
        [Newtonsoft.Json.JsonProperty("height")]
        public double height { get; set; }
        [Newtonsoft.Json.JsonProperty("width")]
        public double width { get; set; }
        [Newtonsoft.Json.JsonProperty("area")]
        public double area;

        public Rectangle(int id, double width, double height)
        {
            Id = id;
            this.width = width;
            this.height = height;
        }

        public Rectangle()
        {
            // TODO: Complete member initialization
        }

        public override double CalculateArea()
        {
            area = (this.width * this.height);
            return area;
        }
    }
}
