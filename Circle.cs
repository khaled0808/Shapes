<<<<<<< HEAD
﻿using Newtonsoft.Json;
using System;
=======
﻿using System;
>>>>>>> Adding Rest Service
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< HEAD
namespace WindowsFormsApplication3
{
    [Newtonsoft.Json.JsonObject("Circle")]
    class Circle : Shape
=======
namespace ShapeAndJson
{

    [Newtonsoft.Json.JsonObject("Circle")]
    public class Circle : Shape
>>>>>>> Adding Rest Service
    {
        [Newtonsoft.Json.JsonProperty("radius")]
        public double radius { get; set; }

        [Newtonsoft.Json.JsonProperty("area")]
        public double area;
<<<<<<< HEAD
=======

        public Circle()
        {
        }
>>>>>>> Adding Rest Service
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
<<<<<<< HEAD
}
=======

}
>>>>>>> Adding Rest Service
