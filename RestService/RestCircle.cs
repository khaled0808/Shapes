using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestService
{
    [DataContract]
    public class RestCircle
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public double radius { get; set; }

        [DataMember]
        public double area { get; set; }
    }
}
