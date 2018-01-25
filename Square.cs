using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD

namespace WindowsFormsApplication3
{
    [Newtonsoft.Json.JsonObject("Square")]
    class Square : Shape
    {
        [Newtonsoft.Json.JsonProperty("width")]
        public double width { get; set; }
        [Newtonsoft.Json.JsonProperty("area")]
        public double area;
  
=======
using ShapeAndJson;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ShapeAndJson
{

    [Newtonsoft.Json.JsonObject("Square")]
    public class Square : Shape
    {

        [Newtonsoft.Json.JsonProperty("width")]
        public double width { get; set; }

        [Newtonsoft.Json.JsonProperty("area")]
        public double area;
        public Square()
        {
        }
>>>>>>> Adding Rest Service
        public Square(int id, double width)
        {
            this.width = width;
            Id = id;
        }
        public override double CalculateArea()
        {
<<<<<<< HEAD
           area= this.width * this.width;
           return area;
=======
            area = this.width * this.width;
            return area;
>>>>>>> Adding Rest Service
        }
    }
}
