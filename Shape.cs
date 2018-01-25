<<<<<<< HEAD
﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WindowsFormsApplication3
{
    abstract class Shape
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ShapeAndJson
{

    [ServiceContract()]
    public abstract class Shape
>>>>>>> Adding Rest Service
    {
        public abstract double CalculateArea();
        [Newtonsoft.Json.JsonProperty("Id")]
        public int Id { get; set; }
    }
}
