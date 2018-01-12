using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    [Newtonsoft.Json.JsonObject("Rectangle")]
    class Rectangle : Shape
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
        public override double CalculateArea()
        {
            area = (this.width * this.height);
            return area;
        }
    }
}
