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
    public partial class BajaLogicaTurno : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión,
        muestra su nombre y en la primera carga oculta los botones y el GridView de turnos.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();

            if (!IsPostBack)
            {
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                gvTurnos.Visible = false;
            }
        }

        /*btnBuscar_Click
        Se ejecuta al hacer clic en el botón Buscar. Valida que el ID ingresado
        sea un número válido y mayor a cero, luego busca el turno activo correspondiente.
        Si existe, muestra sus datos en el GridView y habilita los botones de confirmación.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int IdHorario;
            bool legajoValido = int.TryParse(txtIdTurno.Text, out IdHorario);

            if (!legajoValido || IdHorario <= 0)
            {
                lblMensaje.Text = "Ingrese un Id Turno válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                gvTurnos.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            NegocioTurno neg = new NegocioTurno();
            DataTable tabla = neg.getTurnosActivosPorId(IdHorario);

            if (tabla.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontraron turnos activos para ese Id Turno.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                gvTurnos.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
            }
            else
            {
                lblMensaje.Text = "";
                gvTurnos.Visible = true;
                btnConfirmar.Visible = true;
                btnCancelar.Visible = true;
            }

            gvTurnos.DataSource = tabla;
            gvTurnos.DataBind();
        }

        /*gvTurnos_RowCommand
        Se ejecuta al hacer clic en el botón Baja dentro del GridView.
        Da de baja el turno seleccionado y actualiza el GridView con los datos actualizados.*/
        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Baja")
            {
                int idTurno = Convert.ToInt32(e.CommandArgument);

                NegocioTurno neg = new NegocioTurno();
                bool resultado = neg.darBajaTurno(idTurno);

                lblMensaje.Text = resultado ? "Turno dado de baja correctamente." : "No se pudo dar de baja el turno.";
                lblMensaje.ForeColor = resultado ? System.Drawing.Color.Green : System.Drawing.Color.Red;

                int idTurnoBuscar = Convert.ToInt32(txtIdTurno.Text);
                gvTurnos.DataSource = neg.getTurnosActivosPorId(idTurnoBuscar);
                gvTurnos.DataBind();
            }
        }

        /*btnConfirmar_Click
        Se ejecuta al hacer clic en el botón Confirmar. Da de baja el turno
        y muestra el resultado de la operación. Si es exitoso, oculta los controles.*/
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int idTurno;
            if (!int.TryParse(txtIdTurno.Text, out idTurno))
            {
                lblMensaje.Text = "Ingresá un ID de turno válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (gvTurnos.Rows.Count == 0)
            {
                lblMensaje.Text = "Buscá un turno antes de dar click en confirmar.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            NegocioTurno negocio = new NegocioTurno();

            if (negocio.darBajaTurno(idTurno))
            {
                lblMensaje.Text = "El turno fue dado de baja correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                gvTurnos.DataSource = null;
                gvTurnos.DataBind();
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
            }
            else
            {
                lblMensaje.Text = "No se pudo dar de baja el turno.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        /*btnCancelar_Click
        Se ejecuta al hacer clic en el botón Cancelar. Limpia los campos,
        oculta los controles y restablece el GridView.*/
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtIdTurno.Text = "";
            gvTurnos.DataSource = null;
            gvTurnos.DataBind();
            lblMensaje.Text = "";
        }
    }
}