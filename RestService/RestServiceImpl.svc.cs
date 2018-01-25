using System;
using System.Collections.Generic;
using System.ServiceModel.Description;
using System.Linq;
using Newtonsoft.Json;
using ShapeAndJson;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;
using System.Collections;

namespace RestService
{
    public class RestServiceImpl : IRestServiceImpl
    {
        public List<Circle> getCircle(string uuid)
        {
            Dictionary<string, List<Circle>> list = ServiceSinglton.Instance.getListCircle();
            var shapeList = (from shape in list
                             where shape.Key == uuid
                             select shape.Value);
            if (shapeList == null || shapeList.Count() == 0)
            {
                return null;
            }
            return shapeList.First();
        }

        public ResultData addCircle(Circle rData)
        {
            Guid guid = Guid.NewGuid();
            List<Circle> listCircle = new List<Circle>();
            listCircle.Add(rData);
            ServiceSinglton.Instance.addCircle(guid.ToString(), listCircle);
            ResultData resultData = new ResultData();
            resultData.Name = "Circle";
            resultData.UUId = guid.ToString();
            return resultData;
        }
        public ResultData addCircles(List<Circle> rData)
        {
            Guid guid = Guid.NewGuid();
            ServiceSinglton.Instance.addCircle(guid.ToString(), rData);
            ResultData resultData = new ResultData();
            resultData.Name = "Circle";
            resultData.UUId = guid.ToString();
            return resultData;
        }

        public ResultData postCircle()
        {
            Dictionary<string, List<Circle>> list = ServiceSinglton.Instance.getListCircle();
            var shapeList = (from shape in list select shape.Value);
            var jsonString = JsonConvert.SerializeObject(list, Formatting.Indented);
            return null;
        }
        public ResultData deleteCircle(string uuid)
        {
            ServiceSinglton.Instance.deleteCircle(uuid);
            ResultData resultData = new ResultData();
            resultData.Name = "Circle";
            resultData.UUId = uuid;
            return resultData;
        }
        public ResultData deleteshape(string uuid)
        {
            ServiceSinglton.Instance.deleteShape(uuid);
            ResultData resultData = new ResultData();
            resultData.Name = "Shape";
            resultData.UUId = uuid;
            return resultData;
        }

        public ResultData addShapes(TextInput input)
        {
            Guid guid = Guid.NewGuid();
            string text = input.textFile;
            string encode = ConvertUtil.decodeFromBase64(text);
            List<Shape> list = ConvertUtil.getListShape(encode);
            ServiceSinglton.Instance.addShape(guid.ToString(), list);
            ResultData resultData = new ResultData();
            resultData.Name = "Shape";
            resultData.UUId = guid.ToString();
            return resultData;
        }

        public ResultData addShape(Shape rData)
        {
            Guid guid = Guid.NewGuid();
            List<Shape> listSquare = new List<Shape>();
            listSquare.Add(rData);
            ResultData resultData = new ResultData();
            resultData.Name = "Shape";
            resultData.UUId = guid.ToString();
            return resultData;
        }

        public string calculateShapes(string uuid)
        {
            Dictionary<string, object> list = ServiceSinglton.Instance.getListShape();
            var shapeList = (from shape in list
                             where shape.Key == uuid
                             select shape.Value).First();
            if (shapeList is List<Shape>)
            {
                return ConvertUtil.convertToJson(shapeList as List<Shape>);
            }
            return "";
        }
        public ClassResult getShapes(string uuid)
        {
            Dictionary<string, object> list = ServiceSinglton.Instance.getListShape();
            var shapeList = (from shape in list
                             where shape.Key == uuid
                             select shape.Value).First();

            ClassResult cr = new ClassResult();
            List<Circle> circles = new List<Circle>();
            List<Square> squares = new List<Square>();
            List<Rectangle> rectangles = new List<Rectangle>();

            //sortieren 
            ((List<Shape>)shapeList).Sort((o1, o2) =>
            {
                return o1.GetType().ToString().CompareTo(o2.GetType().ToString());
            });

            //sortieren
            IEnumerator<Shape> iterate = ((List<Shape>)shapeList).GetEnumerator();
            while (iterate.MoveNext())
            {
                Shape shape = iterate.Current;
                if (shape is Circle)
                {
                    //cr.circle.Add(shape as Circle);
                    circles.Add(shape as Circle);
                }
                else if (shape is Square)
                {
                    //cr.square.Add(shape as Square);
                    squares.Add(shape as Square);
                }
                else if (shape is Rectangle)
                {
                    //cr.regtangle.Add(shape as Rectangle);
                    rectangles.Add(shape as Rectangle);
                }
            }
            cr.circle = circles;
            cr.square = squares;
            cr.regtangle = rectangles;
            return cr;
        }

        public List<ResultData> getAllShapes()
        {
            Dictionary<string, object> list = ServiceSinglton.Instance.getListShape();
            List<ResultData> resultObject = new List<ResultData>();
            foreach (var item in list)
            {
                var shapeList = item.Value;
                string UUID = item.Key;
                List<string> name = new List<string>();
                List<Type> types = ConvertUtil.getTypes(shapeList as List<Shape>).ToList();
                foreach (var typeName in types)
                {
                    name.Add(typeName.Name);
                }
                string stringname = string.Join(", ", name.ToArray());
                ResultData resultData = new ResultData();
                resultData.Name = "Shapes :" + stringname;
                resultData.UUId = UUID;
                resultObject.Add(resultData);
            }
            return resultObject;
        }
    }
}
