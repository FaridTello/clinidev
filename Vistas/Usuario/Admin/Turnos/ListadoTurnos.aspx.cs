using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Turnos
{
    public partial class ListadoTurnos : System.Web.UI.Page
    {
        NegocioTurno negocioTurno = new NegocioTurno();

        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión,
        muestra su nombre y en la primera carga carga la grilla con todos los turnos.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();
            if (!IsPostBack)
            {
                cargarGrilla();
            }
        }

        /*cargarGrilla
        Carga el GridView con todos los turnos registrados en la base de datos.*/
        private void cargarGrilla()
        {
            gvTurnos.DataSource = negocioTurno.getTablaTurnos();
            gvTurnos.DataBind();
        }

        /*gvTurnos_PageIndexChanging
        Se ejecuta al cambiar de página en el GridView. Actualiza el índice de página
        y recarga la grilla.*/
        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;
            cargarGrilla();
        }

        /*btnBuscar_Click
        Se ejecuta al hacer clic en el botón Buscar. Filtra los turnos por nombre/apellido
        del médico y/o estado de presentismo según los valores seleccionados.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            gvTurnos.PageIndex = 0;
            string busqueda = txtBuscarMedico.Text.Trim();
            int presentismo = Convert.ToInt32(ddlPresentismo.SelectedValue);

            bool tieneBusqueda = !string.IsNullOrEmpty(busqueda);
            bool tienePresentismo = presentismo != -1;

            DataTable dt;

            if (!tieneBusqueda && !tienePresentismo)
                dt = negocioTurno.getTablaTurnos();
            else if (tieneBusqueda && !tienePresentismo)
                dt = negocioTurno.getTablaTurnosPorMedico(busqueda);
            else if (!tieneBusqueda && tienePresentismo)
                dt = negocioTurno.getTurnosPorPresentismo(presentismo);
            else
                dt = negocioTurno.getTurnosPorNombreYPresentismo(busqueda, presentismo);

            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }

        /*btnLimpiar_Click
        Se ejecuta al hacer clic en el botón Limpiar. Restablece los campos de búsqueda
        y recarga la grilla con todos los turnos.*/
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarMedico.Text = "";
            ddlPresentismo.SelectedIndex = 0;
            lblMensaje.Text = "";
            gvTurnos.PageIndex = 0;
            cargarGrilla();
        }
    }
}