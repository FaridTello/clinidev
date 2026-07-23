using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Medicos.ABML_Horarios
{
    public partial class ListadoHorarioMedico : System.Web.UI.Page
    {
        NegocioHorarioMedico negHorario = new NegocioHorarioMedico();

        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión,
        muestra su nombre y en la primera carga carga la grilla con todos los horarios.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();
            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }

        /*CargarGrilla
        Carga el GridView con todos los horarios médicos registrados en la base de datos.*/
        private void CargarGrilla()
        {
            gvHorarios.DataSource = negHorario.getTablaHorariosMedico();
            gvHorarios.DataBind();
        }

        /*btnBuscar_Click
        Se ejecuta al hacer clic en el botón Buscar. Filtra los horarios por nombre/apellido
        del médico y/o día de la semana según los valores seleccionados.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreyApellido.Text.Trim();
            string dia = ddlDia.SelectedValue;

            NegocioHorarioMedico neg = new NegocioHorarioMedico();
            DataTable dt;

            bool tieneNombre = !string.IsNullOrEmpty(nombre);
            bool tieneDia = dia != "-1";

            if (!tieneNombre && !tieneDia)
                dt = neg.getTablaHorariosPorNombreApellido("");
            else if (tieneNombre && !tieneDia)
                dt = neg.getTablaHorariosPorNombreApellido(nombre);
            else if (!tieneNombre && tieneDia)
                dt = neg.getTablaHorariosPorDia(dia);
            else
                dt = neg.getTablaHorariosPorNombreYDia(nombre, dia);

            if (dt.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontraron horarios.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                gvHorarios.DataSource = null;
            }
            else
            {
                lblMensaje.Text = "";
                gvHorarios.DataSource = dt;
            }

            gvHorarios.DataBind();
        }

        /*gvHorarios_SelectedIndexChanged
        Se ejecuta al cambiar la selección en el GridView. Actualmente no lo implementamos.*/
        protected void gvHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*gvHorarios_PageIndexChanging
        Se ejecuta al cambiar de página en el GridView. Actualiza el índice de página
        y recarga la grilla.*/
        protected void gvHorarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHorarios.PageIndex = e.NewPageIndex;
            CargarGrilla();
        }

        /*btnLimpiar_Click
        Se ejecuta al hacer clic en el botón Limpiar. Restablece los campos de búsqueda
        y recarga la grilla con todos los horarios.*/
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreyApellido.Text = "";
            ddlDia.SelectedIndex = 0;
            lblMensaje.Text = "";
            CargarGrilla();
        }
    }
}