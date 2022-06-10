using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string respuesta = GetHttp();
            List<ViewModels.PersonaViewModel> lista = JsonConvert.DeserializeObject<List<ViewModels.PersonaViewModel>>(respuesta);
            dataGridView1.DataSource = lista;
        }

        private string GetHttp()
        {
            WebRequest request = WebRequest.Create("https://localhost:44375/api/Persona");
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return  sr.ReadToEnd();
        }
    }
}
