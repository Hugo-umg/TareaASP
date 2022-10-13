using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TareaASP
{
    public partial class Estudiantes : System.Web.UI.Page
    {
        private Modelo.Estudiante _estudiante;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _estudiante = new Modelo.Estudiante();

                _estudiante.DropTiposSangre(drpTipoSangre);
                _estudiante.GridEstudiantes(grdEstudiantes);
            }
        }

        protected void Crear_Click(object sender, EventArgs e)
        {
            _estudiante = new Modelo.Estudiante();

            var carnet = txtCarnet.Text;
            var nombres = txtNombres.Text;
            var apellidos = txtApellidos.Text;
            var direccion = txtDireccion.Text;
            var telefono = txtTelefono.Text;
            var email = txtCorreo.Text;
            var tipoSangre = Convert.ToInt32(drpTipoSangre.SelectedValue);
            var fechaNacimiento = txtFechaNac.Text;

            if(_estudiante.Crear(carnet, nombres, apellidos, direccion, telefono, email, tipoSangre, fechaNacimiento) > 0)
            {
                lblMensaje.Text = "Estudiante creado.";
                _estudiante.GridEstudiantes(grdEstudiantes);
            }
        }

        protected void Actualizar_Click(object sender, EventArgs e)
        {
            _estudiante = new Modelo.Estudiante();

            //var id = Convert.ToInt32(txtID.Text);
            var id = Convert.ToInt32(grdEstudiantes.SelectedValue);
            var carnet = txtCarnet.Text;
            var nombres = txtNombres.Text;
            var apellidos = txtApellidos.Text;
            var direccion = txtDireccion.Text;
            var telefono = txtTelefono.Text;
            var email = txtCorreo.Text;
            var tipoSangre = Convert.ToInt32(drpTipoSangre.SelectedValue);
            var fechaNacimiento = txtFechaNac.Text;

            if (_estudiante.Actualizar(id, carnet, nombres, apellidos, direccion, telefono, email, tipoSangre, fechaNacimiento) > 0)
            {
                lblMensaje.Text = "Modificación exitosa.";
                _estudiante.GridEstudiantes(grdEstudiantes);
            }
        }

        protected void GridEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fila = grdEstudiantes.SelectedRow;

            txtID.Text = fila.Cells[2].Text;
            txtCarnet.Text = fila.Cells[3].Text;
            txtNombres.Text = fila.Cells[4].Text;
            txtApellidos.Text = fila.Cells[5].Text;
            txtDireccion.Text = fila.Cells[6].Text;
            txtTelefono.Text = fila.Cells[7].Text;
            txtCorreo.Text = fila.Cells[8].Text;

            //fila.Cells[9].Text
            int indice = fila.RowIndex;
            drpTipoSangre.SelectedValue = grdEstudiantes.DataKeys[indice].Values["id_tipo_sangre"].ToString();
            
            DateTime fecha = Convert.ToDateTime(fila.Cells[10].Text);
            txtFechaNac.Text = fecha.ToString("yyyy-mm-dd");

            btnActualizar.Visible = true;
        }

        protected void GridEstudiantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (_estudiante.Borrar(Convert.ToInt32(e.Keys["id"])) > 0)
            {
                lblMensaje.Text = "Estudiante eliminado.";
                _estudiante.GridEstudiantes(grdEstudiantes);
            }
        }
    }
}