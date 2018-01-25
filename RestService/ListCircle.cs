using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace RestService
{
    [DataContract]
    public class ListCircle
    {
        [DataMember]
        public List<RestCircle> circle { get; set; }
      
    }
}