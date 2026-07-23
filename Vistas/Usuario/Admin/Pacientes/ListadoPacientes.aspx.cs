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
    public partial class ListadoPacientes : System.Web.UI.Page
    {
        NegocioPaciente negPaciente = new NegocioPaciente();
        NegocioProvincia negProvincia = new NegocioProvincia();

        /*Page_Load
        Se ejecuta al cargar la página. Verifica que el usuario esté logueado,
        si no lo está redirige al login. En la primera carga carga las provincias
        y la grilla con todos los pacientes activos.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                CargarProvincias();
                CargarGrilla();
            }
        }

        /*CargarGrilla
        Carga el GridView con todos los pacientes activos registrados en la base de datos.*/
        private void CargarGrilla()
        {
            gvPacientes.DataSource = negPaciente.getTabla();
            gvPacientes.DataBind();
        }

        /*CargarProvincias
        Carga el DropDownList con las provincias registradas en la base de datos.*/
        private void CargarProvincias()
        {
            DataTable dtProvincias = negProvincia.getTabla();
            ddlProvincias.DataSource = dtProvincias;
            ddlProvincias.DataTextField = "Nombre_P";
            ddlProvincias.DataValueField = "Id_Provincia_P";
            ddlProvincias.DataBind();
            ddlProvincias.Items.Insert(0, new ListItem("-- Seleccionar Provincia --", "0"));
        }

        /*btnBuscar_Click
        Se ejecuta al hacer clic en el botón Buscar. Filtra los pacientes por nombre
        y/o provincia según los valores ingresados y muestra los resultados en el GridView.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarNombre.Text.Trim();
            int provincia = Convert.ToInt32(ddlProvincias.SelectedValue);
            DataTable dt;

            if (!string.IsNullOrEmpty(nombre) && provincia != 0)
                dt = negPaciente.getTablaPacientesxNombreProvincia(nombre, provincia);
            else if (!string.IsNullOrEmpty(nombre))
                dt = negPaciente.getTablaxNombre(nombre);
            else if (provincia != 0)
                dt = negPaciente.getTablaxProvincia(provincia);
            else
                dt = negPaciente.getTabla();

            if (dt.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontró al paciente.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                gvPacientes.DataSource = null;
            }
            else
            {
                lblMensaje.Text = "";
                gvPacientes.DataSource = dt;
            }

            gvPacientes.DataBind();
        }

        /*gvPacientes_PageIndexChanging
        Se ejecuta al cambiar de página en el GridView. Actualiza el índice de página
        y vuelve a ejecutar la búsqueda para mantener los filtros aplicados.*/
        protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPacientes.PageIndex = e.NewPageIndex;
            btnBuscar_Click(null, null);
        }

        /*gvPacientes_RowEditing
        Se ejecuta al hacer clic en el botón Editar del GridView.
        Redirige a la página de modificación del paciente con su ID en la URL.*/
        protected void gvPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
            int idPaciente = Convert.ToInt32(gvPacientes.DataKeys[e.NewEditIndex].Value);
            Response.Redirect("~/Usuario/Admin/Pacientes/ModificacionPaciente.aspx?id=" + idPaciente);
        }

        /*gvPacientes_RowDeleting
        Se ejecuta al hacer clic en el botón Eliminar del GridView.
        Redirige a la página de baja del paciente con su ID en la URL.*/
        protected void gvPacientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true;
            int idPaciente = Convert.ToInt32(gvPacientes.DataKeys[e.RowIndex].Value);
            Response.Redirect("~/Usuario/Admin/Pacientes/BajaPacientes.aspx?id=" + idPaciente);
        }

        /*limpiarCampos
        Limpia los campos de búsqueda y restablece el combo de provincias a su valor por defecto.*/
        private void limpiarCampos()
        {
            txtBuscarNombre.Text = "";
            ddlProvincias.SelectedIndex = 0;
        }

        /*btnLimpiarFiltros_Click
        Se ejecuta al hacer clic en el botón Limpiar Filtros.
        Limpia los campos de búsqueda y recarga la grilla con todos los pacientes activos.*/
        protected void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            CargarGrilla();
        }
    }
}