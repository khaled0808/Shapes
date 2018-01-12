using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace WindowsFormsApplication3
{
    public partial class ShapeDialoge : Form
    {
        List<Shape> listobject;
        string[] value;
        public ShapeDialoge()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void buttonOpenFileDialog_Click(object sender, EventArgs e)
        {
            string text;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Filter = "Text files (*.txt)|*.txt";
            if (fDialog.ShowDialog() != DialogResult.OK)
                return;
            System.IO.FileInfo fInfo = new System.IO.FileInfo(fDialog.FileName);
            string strFileName = fInfo.Name;
            string strFilePath = fInfo.FullName;
            textBoxPath.Text = (strFilePath);
            listobject = new List<Shape>();
            var fileStream = fDialog.FileName;
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd().ToUpper().Replace(" ", "");
            }
            value = System.Text.RegularExpressions.Regex.Split(text, @"\s\s+");
            textBoxShape.Text = string.Join(Environment.NewLine, value);
            int id = 0;
            foreach (string item in value)
            {
                string[] shapes = item.Split(':');
                Shape shape = null;
                switch (shapes[0])
                {
                    case "CIRCLE":
                        shape = new Circle(id++, Convert.ToUInt32(shapes[1]));
                        break;
                    case "SQUARE":
                        shape = new Square(id++, Convert.ToUInt32(shapes[1]));
                        break;
                    case "RECTANGLE":
                        string[] dimensions = shapes[1].Split(',');
                        shape = new Rectangle(id++, Convert.ToUInt32(dimensions[0]), Convert.ToUInt32(dimensions[1]));
                        break;
                }
                if (shape != null)
                {
                    shape.CalculateArea();
                    listobject.Add(shape);
                }
            }
            List<Type> types = getTypes(listobject);
            comboBoxShape.Items.Clear();
            foreach (var typeName in types)
            {
                comboBoxShape.Items.Add(typeName.Name);
            }
        }

        private List<Type> getTypes(List<Shape> list)
        {
            List<Type> types = list.ConvertAll<Type>(c => c.GetType()).Distinct<Type>().ToList<Type>();
            return types;
        }
        private void buttonSaveFileDialog_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "";
            savefile.Filter = "|*.json";
            if (listobject != null)
            {
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(savefile.FileName, false))
                    {
                        sw.Write("[{");
                        List<Type> types = getTypes(listobject);
                        int counter = 0;
                        foreach (Type type in types)
                        {
                            type.GetElementType();
                            List<Shape> shapes = listobject.Where(s => s.GetType() == type).ToList();
                            string shapesJson = JsonConvert.SerializeObject(shapes, Formatting.Indented);
                            if (counter != 0)
                            {
                                sw.Write(",");
                            }
                            counter++;
                            sw.Write("\"");
                            sw.Write(type.Name);
                            sw.Write("\":");
                            sw.Write(shapesJson);
                        }
                        sw.Write("}]");
                    }
                }
            }
            else
            {
                MessageBox.Show("insert your Data Please");
            }
        }

        private void comboBoxShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxShape.Text = string.Join(Environment.NewLine, filterShape(comboBoxShape.SelectedItem.ToString()));

        }
        public string[] filterShape(string name)
        {
            List<string> termsList = new List<string>();
            foreach (var item in value)
            {
                if (name == "Circle")
                {
                    if (item.StartsWith("C"))
                    {
                        termsList.Add(item);
                    }
                }
                else if (name == "Square")
                {
                    if (item.StartsWith("S"))
                    {
                        termsList.Add(item);
                    }
                }
                else if (name == "Rectangle")
                {
                    if (item.StartsWith("R"))
                    {
                        termsList.Add(item);
                    }
                }
            }
            return termsList.ToArray();
        }
    }
}



