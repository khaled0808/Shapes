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
using ShapeData;
using RestService;

namespace ShapeAndJson
{
    public partial class ShapeDialoge : Form
    {
        List<Shape> listobject;

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
            string strFilePath = fInfo.FullName;
            textBoxPath.Text = (strFilePath);
            var fileStream = fDialog.FileName;
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                text = streamReader.ReadToEnd().ToUpper().Replace(" ", "");

                listobject = ConvertUtil.getListShape(text);
                List<Type> types = ConvertUtil.getTypes(listobject);
                comboBoxShape.Items.Clear();
                foreach (var typeName in types)
                {
                    comboBoxShape.Items.Add(typeName.Name);
                }
                textBoxShape.Text = JsonConvert.SerializeObject(listobject, Formatting.Indented);
            }
        }

        private void buttonSaveFileDialog_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.FileName = "";
            savefile.Filter = "(*.json)|*.json";
            if (listobject != null)
            {
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(savefile.FileName, false))
                    {
                        sw.Write(ConvertUtil.convertToJson(listobject));
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
            textBoxShape.Text = string.Join(Environment.NewLine, ConvertUtil.filterShape(listobject, comboBoxShape.SelectedItem.ToString()));
        }

    }
}