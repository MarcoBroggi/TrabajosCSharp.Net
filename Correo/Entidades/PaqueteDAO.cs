using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PaqueteDAO
    {
        private static SqlConnection conexion;
        private static SqlCommand comando;

        /// <summary>
        /// Constructor
        /// </summary>
        static PaqueteDAO()
        {
            string connectionString = "Data Source=.\\SQLEXPRESS; Initial Catalog=correo-sp-2017; Integrated Security=True;";
            conexion = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Inserta un paquete en la base de datos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            comando = new SqlCommand();
            bool retorno = false;
            string alumno = "Alumno genérico";
            try
            {
                conexion.Open();
                string insertComando = String.Format("INSERT INTO Paquetes" +
                            "(DireccionEntrega,TrackingId,Alumno) VALUES " +
                            "('{0}','{1}','{2}')",
                            p.DireccionEntrega, p.TrackingID, alumno);
                comando = new SqlCommand(insertComando, conexion);
                comando.ExecuteNonQuery();
                retorno = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return retorno;
        }
    }
}
