using ShapeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestService
{
    [DataContract]
    public class ClassResult
    {
        [DataMember]
        public List<Circle> circle { get; set; }
        [DataMember]
        public List<Square> square { get; set; }
        [DataMember]
        public List<Rectangle> regtangle { get; set; }
    }
}



