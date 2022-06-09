using FormPersona.Models.Request;
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
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FormPersona
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string url = "https://localhost:44383/api/Persona";

            PersonaRequest persona = new PersonaRequest();
            persona.Nombre = txtNombre.Text;
            persona.Edad = int.Parse(txtEdad.Text);

            string resultado=Send<PersonaRequest>(url, persona, "POST");



        }

        public string Send<T> (string url, T objectRequest, string method= "POST")
        {
            string cadena = "";
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(objectRequest);

                WebRequest request = WebRequest.Create(url);
                request.Method = method;
                request.PreAuthenticate = true;
                request.ContentType = "application/json;charset=utf-8'";
                request.Timeout = 1000;

                using (StreamWriter sw= new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(json);
                    sw.Flush();
                }
                var httpResponse = (HttpWebResponse)request.GetResponse();
                using (StreamReader sr = new StreamReader(httpResponse.GetResponseStream()))
                {
                    cadena = sr.ReadToEnd();
                }
            }catch(Exception e)
            {
                cadena = e.Message;
            }
            return cadena;
        }
    }
}
