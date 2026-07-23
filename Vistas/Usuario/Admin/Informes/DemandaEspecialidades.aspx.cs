using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Informes
{
    public partial class DemandaEspecialidades : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión,
        muestra su nombre y carga el informe de demanda por especialidades sin filtro.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();

            NegocioTurno negTurno = new NegocioTurno();
            negTurno.getInformeEspecialidadPorDemanda();
            gvInforme.DataSource = negTurno.getInformeEspecialidadPorDemanda();
            gvInforme.DataBind();


        }

        /*btnGenerar_Click
        Se ejecuta al hacer clic en el botón Generar. Valida que las fechas estén completas
        y sean correctas, luego genera el informe de demanda por especialidades
        para el rango de fechas seleccionado.*/
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (txtFechaDesde.Text == "" || txtFechaHasta.Text == "")
            {
                lblMensaje.Text = "Ingrese ambas fechas para generar el informe.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            DateTime fechaDesde = Convert.ToDateTime(txtFechaDesde.Text);
            DateTime fechaHasta = Convert.ToDateTime(txtFechaHasta.Text);

            if (fechaDesde > fechaHasta)
            {
                lblMensaje.Text = "La fecha desde no puede ser mayor a la fecha hasta.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            NegocioTurno neg = new NegocioTurno();
            DataTable tabla = neg.getInformeEspecialidadPorDemanda(fechaDesde, fechaHasta);

            if (tabla.Rows.Count == 0)
            {
                lblMensaje.Text = "No hay turnos registrados en ese rango de fechas.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                gvInforme.DataSource = null;
                gvInforme.DataBind();
                return;
            }

            lblMensaje.Text = "";
            gvInforme.DataSource = tabla;
            gvInforme.DataBind();
        }

        /*btnLimpiar_Click
        Se ejecuta al hacer clic en el botón Limpiar. Restablece el informe
        mostrando todos los datos sin filtro de fechas.*/
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            NegocioTurno negTurno = new NegocioTurno();
            negTurno.getInformeEspecialidadPorDemanda();
            gvInforme.DataSource = negTurno.getInformeEspecialidadPorDemanda();
            gvInforme.DataBind();
        }
    }
}