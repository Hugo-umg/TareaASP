using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class ConexionBD
    {
        private string _cadena = "server=localhost; database=db_tareas; user=usr_tareas; password=Tareas123**";

        public MySqlConnection Conectar;

        public void AbrirConexion()
        {
            try
            {
                Conectar = new MySqlConnection
                {
                    ConnectionString = _cadena
                };
                Conectar.Open();

                //System.Diagnostics.Debug.WriteLine("Conexión exitosa.");
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine($"Conexión fallida. Error: {ex.Message}");
                Console.WriteLine($"Conexión fallida. Error: {ex.Message}");
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (Conectar != null && Conectar.State == ConnectionState.Open)
                {
                    Conectar.Close();
                    //System.Diagnostics.Debug.WriteLine("Conexión cerrada.");
                }
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine($"Conexión fallida. Error: {ex.Message}");
                Console.WriteLine($"Conexión fallida. Error: {ex.Message}");
            }
        }
    }
}
