using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Turnos
{
    public partial class AltaLogicaTurnos : System.Web.UI.Page
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
        sea un número válido y busca el turno inactivo correspondiente.
        Si existe, muestra sus datos en el GridView y habilita los botones de confirmación.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int idTurno;
            if (!int.TryParse(txtLegajo.Text, out idTurno))
            {
                lblMensaje.Text = "Ingresá un ID de turno válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                gvTurnos.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            NegocioTurno negocio = new NegocioTurno();
            DataTable tabla = negocio.getTurnoInactivoxId(idTurno);

            if (tabla.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontró ningún turno dado de baja con ese ID.";
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

        /*gvTurnos_SelectedIndexChanged
        Se ejecuta al cambiar la selección en el GridView. Actualmente no tiene implementación.*/
        protected void gvTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*btnConfirmar_Click
        Se ejecuta al hacer clic en el botón Confirmar. Reactiva el turno inactivo
        y muestra el resultado de la operación. Si es exitoso, oculta los controles.*/
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int idTurno;
            if (!int.TryParse(txtLegajo.Text, out idTurno))
            {
                lblMensaje.Text = "Ingresá un ID de turno válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (gvTurnos.Rows.Count == 0)
            {
                lblMensaje.Text = "Busca un turno antes de dar click en confirmar.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            NegocioTurno negocio = new NegocioTurno();

            if (negocio.darAltaTurno(idTurno))
            {
                lblMensaje.Text = "El turno fue dado de alta correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                gvTurnos.DataSource = null;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                gvTurnos.DataBind();
            }
            else
            {
                lblMensaje.Text = "No se pudo dar de alta el turno.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        /*btnCancelar_Click
        Se ejecuta al hacer clic en el botón Cancelar. Limpia los campos,
        oculta los controles y restablece el GridView.*/
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtLegajo.Text = "";
            gvTurnos.DataSource = null;
            gvTurnos.DataBind();
            gvTurnos.Visible = false;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;
            lblMensaje.Text = "";
        }
    }
}