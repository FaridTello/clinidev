using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Pacientes
{
    public partial class ModificacionPaciente : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Verifica que el usuario esté logueado,
        si no lo está redirige al login. Si está logueado, muestra su nombre
        en la etiqueta correspondiente.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] != null)
            {
                Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
                lblUsuarioLogueado.Text = usu.getNombre_U();
            }
            else
            {
                Response.Redirect("~/Usuario/Login.aspx");
            }
        }

        /*RecargarGrid
        Recarga el GridView con los datos del paciente cuyo ID está ingresado en el campo de texto.
        Si no se encuentra el paciente, muestra un mensaje de error.*/
        private void RecargarGrid()
        {
            string strID = txtIDPaciente.Text;
            int idBusqueda;

            bool esNumeroValido = int.TryParse(strID, out idBusqueda) && idBusqueda > 0;

            if (esNumeroValido)
            {
                NegocioPaciente negocio = new NegocioPaciente();
                DataTable tabla = negocio.getTablaxID(idBusqueda);

                gvPacientes.DataSource = tabla;
                gvPacientes.DataBind();

                if (tabla == null || tabla.Rows.Count == 0)
                {
                    lblMensaje.Text = "No se encontró ningún paciente con el ID proporcionado. Por favor, ingrese un ID válido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        /*btnBuscar_Click
        Se ejecuta al hacer clic en el botón Buscar. Cancela cualquier edición en curso
        y recarga el GridView con el paciente correspondiente al ID ingresado.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvPacientes.EditIndex = -1;
            RecargarGrid();
        }

        /*ddl_eit_Provincia_SelectedIndexChanged
        Se ejecuta al cambiar la selección en el combo de provincia dentro del GridView en modo edición.
        Carga las localidades correspondientes a la provincia seleccionada.*/
        protected void ddl_eit_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;
            GridViewRow fila = (GridViewRow)ddlProvincia.NamingContainer;
            DropDownList ddlLocalidad = (DropDownList)fila.FindControl("ddl_eit_Localidad");

            NegocioLocalidad negLocalidad = new NegocioLocalidad();
            ddlLocalidad.DataSource = negLocalidad.getLocalidadesPorProvincia(int.Parse(ddlProvincia.SelectedValue));
            ddlLocalidad.DataTextField = "Nombre_L";
            ddlLocalidad.DataValueField = "Id_Localidad_L";
            ddlLocalidad.DataBind();
        }

        /*gvPacientes_RowEditing
        Se ejecuta al hacer clic en el botón Editar del GridView. Activa el modo de edición
        para la fila seleccionada y carga los combos de provincia y localidad con los valores actuales.*/
        protected void gvPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPacientes.EditIndex = e.NewEditIndex;
            RecargarGrid();

            GridViewRow fila = gvPacientes.Rows[e.NewEditIndex];

            int idBusqueda = int.Parse(txtIDPaciente.Text);

            NegocioPaciente negPaciente = new NegocioPaciente();

            DataTable dt = negPaciente.getTablaxID(idBusqueda);

            int idLocalidad = int.Parse(dt.Rows[0]["Id_Localidad_Pa"].ToString());
            int idProvincia = int.Parse(dt.Rows[0]["IdProvincia"].ToString());

            DropDownList ddlProvincia = (DropDownList)fila.FindControl("ddl_eit_Provincia");
            NegocioProvincia negProvincia = new NegocioProvincia();
            ddlProvincia.DataSource = negProvincia.getTabla();
            ddlProvincia.DataTextField = "Nombre_P";
            ddlProvincia.DataValueField = "Id_Provincia_P";
            ddlProvincia.DataBind();
            ddlProvincia.SelectedValue = idProvincia.ToString();

            DropDownList ddlLocalidad = (DropDownList)fila.FindControl("ddl_eit_Localidad");
            NegocioLocalidad negLocalidad = new NegocioLocalidad();
            ddlLocalidad.DataSource = negLocalidad.getLocalidadesPorProvincia(idProvincia);
            ddlLocalidad.DataTextField = "Nombre_L";
            ddlLocalidad.DataValueField = "Id_Localidad_L";
            ddlLocalidad.DataBind();
            ddlLocalidad.SelectedValue = idLocalidad.ToString();

        }

        /*gvPacientes_RowCancelingEdit
        Se ejecuta al hacer clic en el botón Cancelar durante la edición.
        Cancela el modo de edición y recarga el GridView.*/
        protected void gvPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPacientes.EditIndex = -1;
            RecargarGrid();
        }

        /*gvPacientes_RowUpdating
        Se ejecuta al hacer clic en el botón Actualizar durante la edición.
        Obtiene los valores modificados del paciente, valida la fecha de nacimiento
        y actualiza el paciente en la base de datos, mostrando el resultado en la etiqueta de mensaje.*/
        protected void gvPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = gvPacientes.Rows[e.RowIndex];
            string dni = ((Label)fila.FindControl("lbl_eit_Dni")).Text;
            string nombre = ((TextBox)fila.FindControl("txt_eit_Nombre")).Text;
            string apellido = ((TextBox)fila.FindControl("txt_eit_Apellido")).Text;
            string fechaStr = ((TextBox)fila.FindControl("txt_eit_FechaNacimiento")).Text;
            string nac = ((TextBox)fila.FindControl("txt_eit_Nacionalidad")).Text;
            string dir = ((TextBox)fila.FindControl("txt_eit_Direccion")).Text;
            string correo = ((TextBox)fila.FindControl("txt_eit_CorreoElectronico")).Text;
            string tel = ((TextBox)fila.FindControl("txt_eit_Telefono")).Text;
            int idLocalidad = int.Parse(((DropDownList)fila.FindControl("ddl_eit_Localidad")).SelectedValue);
            DropDownList ddlSexo = (DropDownList)fila.FindControl("ddl_eit_Sexo");
            bool sexo = ddlSexo.SelectedValue.Trim().ToLower() == "masculino";
            if (!DateTime.TryParse(fechaStr, out DateTime fechaNacimiento))
            {
                lblMensaje.Text = "La fecha de nacimiento ingresada no es válida.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }
            int idPaciente = int.Parse(txtIDPaciente.Text);
            NegocioPaciente negocio = new NegocioPaciente();
            bool resultado = negocio.modificarPaciente(idPaciente, dni, nombre, apellido, sexo, nac, fechaNacimiento, dir, correo, tel, idLocalidad);
            if (resultado)
            {
                gvPacientes.EditIndex = -1;
                RecargarGrid();
                lblMensaje.Text = "Paciente actualizado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo actualizar el paciente.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}