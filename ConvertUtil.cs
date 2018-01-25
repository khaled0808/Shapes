using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeAndJson;
using System.IO;
using Newtonsoft.Json;

namespace ShapeAndJson
{
    public class ConvertUtil
    {

        public static string encodeToBase64(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string decodeFromBase64(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static List<Shape> getListShape(string input)
        {
            List<Shape> listobject = new List<Shape>();
            string text = input.ToUpper().Replace(" ", "");
            string[] value = System.Text.RegularExpressions.Regex.Split(text, @"\s\s+");
            int id = 0;
            foreach (string item in value)
            {
                string[] shapes = item.Split(':');
                Shape shape = null;
                switch (shapes[0])
                {
                    case "CIRCLE":
                        shape = new Circle(id++, Convert.ToUInt32(shapes[1]));
                        shape.CalculateArea();
                        break;
                    case "SQUARE":
                        shape = new Square(id++, Convert.ToUInt32(shapes[1]));
                        shape.CalculateArea();
                        break;
                    case "RECTANGLE":
                        string[] dimensions = shapes[1].Split(',');
                        shape = new Rectangle(id++, Convert.ToUInt32(dimensions[0]), Convert.ToUInt32(dimensions[1]));
                        shape.CalculateArea();
                        break;
                }
                if (shape != null)
                {
                    listobject.Add(shape);
                }
            }
            return listobject;
        }

        public static List<Type> getTypes( List<Shape> list)
        {
            List<Type> types = list.ConvertAll<Type>(c => c.GetType()).Distinct<Type>().ToList<Type>();
            return types;
        }

        public static string convertToJson(List<Shape> listobject)
        {
            using (StringWriter streamWriter = new StringWriter())
            {
                streamWriter.Write("[{");
                List<Type> types = getTypes(listobject);
                int counter = 0;
                foreach (Type type in types)
                {
                    List<Shape> shapes = listobject.Where(s => s.GetType() == type).ToList();
                    string shapesJson = JsonConvert.SerializeObject(shapes);
                    if (counter != 0)
                    {
                        streamWriter.Write(",");
                    }
                    counter++;
                    streamWriter.Write("\"");
                    streamWriter.Write(type.Name);
                    streamWriter.Write("\":");
                    streamWriter.Write(shapesJson);
                }
                streamWriter.Write("}]");
                return streamWriter.ToString();
            }
        }
    }
}

