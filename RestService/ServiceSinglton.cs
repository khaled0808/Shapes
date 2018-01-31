using ShapeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestService
{
    public class ServiceSinglton
    {

        Dictionary<string, object> listShape = new Dictionary<string, object>();

        Dictionary<string, List<Circle>> listCircle = new Dictionary<string, List<Circle>>();

        private static readonly ServiceSinglton _instance = new ServiceSinglton();

        public static ServiceSinglton Instance
        {
            get
            {
                return _instance;
            }
        }

        public Dictionary<string, object> getListShape()
        {
            return listShape;
        }

        public Dictionary<string, List<Circle>> getListCircle()
        {
            return listCircle;
        }

        public void addCircle(string guid, List<Circle> circle)
        {
            listCircle.Add(guid, circle);
        }

        public void addShape<T>(string guid, List<T> shape) where T : Shape
        {
            listShape.Add(guid, shape);
        }

        public void deleteCircle(string guid)
        {
            listCircle.Remove(guid);
        }

        public void deleteShape(string guid)
        {
            listShape.Remove(guid);
        }
    }
}