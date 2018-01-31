using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ShapeData
{
    [DataContract]
    public class ResultData
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string UUId { get; set; }
    }
}