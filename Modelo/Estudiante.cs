using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.UI.WebControls;

namespace Modelo
{
    public class Estudiante
    {
        private ConexionBD _conectar;

        private DataTable DropTipoSangre()
        {
            DataTable tiposSangre = new DataTable();

            _conectar = new ConexionBD();
            _conectar.AbrirConexion();

            var consulta = "Select id_tipo_sangre as id, sangre From tipos_sangre;";

            MySqlDataAdapter query = new MySqlDataAdapter(consulta, _conectar.Conectar);
            query.Fill(tiposSangre);

            _conectar.CerrarConexion();

            return tiposSangre;
        }

        private DataTable GridEstudiantes()
        {
            DataTable estudiantes = new DataTable();

            _conectar = new ConexionBD();
            _conectar.AbrirConexion();

            var consulta = "Select e.id_estudiante as id, e.carne, e.nombres, e.apellidos, e.direccion, e.telefono, e.correo_electronico, e.fecha_nacimiento, e.id_tipo_sangre, t.sangre ";
            consulta += "From estudiantes as e ";
            consulta += "Inner Join tipos_sangre as t On e.id_tipo_sangre = t.id_tipo_sangre;";

            MySqlDataAdapter query = new MySqlDataAdapter(consulta, _conectar.Conectar);
            query.Fill(estudiantes);

            _conectar.CerrarConexion();

            return estudiantes;
        }

        public void DropTiposSangre(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("--- Elige Tipo de Sangre ---");
            drop.Items[0].Value = "0";

            drop.DataSource = DropTipoSangre();
            drop.DataTextField = "sangre";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void GridEstudiantes(GridView grid)
        {
            grid.DataSource = GridEstudiantes();
            grid.DataBind();
        }

        public int Crear(string carnet, string nombres, string apellidos, string direccion, string telefono, string email, int tipoSangre, string fechaNacimiento)
        {
            int retorno;

            _conectar = new ConexionBD();
            _conectar.AbrirConexion();

            var query = string.Format("Insert Into Estudiantes (carne, nombres, apellidos, direccion, telefono, correo_electronico, id_tipo_sangre, fecha_nacimiento) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, '{7}');", carnet, nombres, apellidos, direccion, telefono, email, tipoSangre, fechaNacimiento);

            MySqlCommand comando = new MySqlCommand(query, _conectar.Conectar);

            retorno = comando.ExecuteNonQuery();

            _conectar.CerrarConexion();

            return retorno;
        }

        public int Actualizar(int id, string carnet, string nombres, string apellidos, string direccion, string telefono, string email, int tipoSangre, string fechaNacimiento)
        {
            int retorno;

            _conectar = new ConexionBD();
            _conectar.AbrirConexion();

            var query = string.Format("Update Estudiantes Set carne='{0}', nombres='{1}', apellidos='{2}', direccion='{3}', telefono='{4}', correo_electronico='{5}', id_tipo_sangre={6}, fecha_nacimiento='{7}' Where id_estudiante={8};", carnet, nombres, apellidos, direccion, telefono, email, tipoSangre, fechaNacimiento, id);

            MySqlCommand comando = new MySqlCommand(query, _conectar.Conectar);

            retorno = comando.ExecuteNonQuery();

            _conectar.CerrarConexion();

            return retorno;
        }

        public int Borrar(int id)
        {
            int retorno;

            _conectar = new ConexionBD();
            _conectar.AbrirConexion();

            var query = string.Format("Delete Estudiantes Where id_estudiante={0};", id);

            MySqlCommand comando = new MySqlCommand(query, _conectar.Conectar);

            retorno = comando.ExecuteNonQuery();

            _conectar.CerrarConexion();

            return retorno;
        }
    }
}
