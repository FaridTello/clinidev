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
    public partial class InformeDemandaLocalidad : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Verifica que el usuario esté logueado,
        si no lo está redirige al login. Si está logueado, muestra su nombre
        en la etiqueta correspondiente.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UsuarioLogueado"] != null)
                {
                    Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
                    lblUsuario.Text = usu.getNombre_U();
                }
                else
                {
                    Response.Redirect("~/Usuario/Login.aspx");
                }
            }
        }

        /*btnGenerar_Click
        Se ejecuta al hacer clic en el botón Generar. Valida que las fechas estén completas
        y sean correctas, luego genera el informe de demanda por localidad para el rango
        de fechas seleccionado y muestra los resultados en el GridView.*/
        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFechaDesde.Text) || string.IsNullOrEmpty(txtFechaHasta.Text))
            {
                lblMensaje.Text = "Ingrese ambas fechas para generar el mapa de demanda.";
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

            NegocioInforme neg = new NegocioInforme();
            DataTable tabla = neg.getDemandaPorLocalidad(fechaDesde, fechaHasta);

            if (tabla.Rows.Count == 0)
            {
                lblMensaje.Text = "No se registraron pacientes de ninguna localidad en esas fechas.";
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
        Se ejecuta al hacer clic en el botón Limpiar. Restablece los campos de fecha,
        limpia el mensaje y vacía el GridView.*/
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFechaDesde.Text = "";
            txtFechaHasta.Text = "";
            lblMensaje.Text = "";
            gvInforme.DataSource = null;
            gvInforme.DataBind();
        }
    }
}