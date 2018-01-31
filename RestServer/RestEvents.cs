using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShapeData;

namespace ShapeRestServer
{
    public class RestEvents
    {
        public delegate void AddCircleEvent(object source, CircleEventArgs e);

        public class CircleEventArgs : EventArgs
        {
            private string uuid;
            private List<Circle> circle;
            public CircleEventArgs(string uuid, List<Circle> circle)
            {
                this.uuid = uuid;
                this.circle = circle;
            }
            public string GetUuid()
            {
                return this.uuid;
            }
            public List<Circle> GetCircle()
            {
                return this.circle;
            }
        }
    }
}