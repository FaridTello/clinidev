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
    public partial class InformeAusentismo : System.Web.UI.Page
    {

        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión
        y muestra su nombre en la etiqueta correspondiente.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();
        }

        /*btnGenerar_Click
        Se ejecuta al hacer clic en el botón Generar. Valida que las fechas estén completas
        y sean correctas, luego genera el informe de ausentismo para el rango de fechas
        seleccionado y muestra los resultados en las etiquetas correspondientes.*/
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

            NegocioInforme neg = new NegocioInforme();
            DataTable tabla = neg.getAusentismo(fechaDesde, fechaHasta);

            if (tabla.Rows.Count == 0 || tabla.Rows[0]["TotalTurnos"].ToString() == "0")
            {
                lblMensaje.Text = "No hay turnos registrados en ese rango de fechas.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            DataRow fila = tabla.Rows[0];

            lblTotal.Text = fila["TotalTurnos"].ToString();
            lblPresentes.Text = fila["Presentes"].ToString();
            lblAusentes.Text = fila["Ausentes"].ToString();
            lblPorcentajePresentes.Text = fila["PorcentajePresentes"].ToString() + "%";
            lblPorcentajeAusentes.Text = fila["PorcentajeAusentes"].ToString() + "%";
            lblMensaje.Text = "";
        }

    }
}