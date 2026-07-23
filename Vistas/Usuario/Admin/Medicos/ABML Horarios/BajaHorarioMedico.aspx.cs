using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Medicos.Horarios
{
    public partial class BajaHorarioMedico : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión,
        muestra su nombre y en la primera carga oculta los botones y el GridView
        de horarios.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();

            if (!IsPostBack)
            {
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                gvHorarios.Visible = false;
                lblMensaje.Visible = false;
            }
        }

        /*cargarGrid
        Carga el GridView con los datos del horario activo cuyo ID se recibe.
        Si no se encuentra el horario, muestra un mensaje de error y oculta los controles.*/
        private void cargarGrid(int IdHorarioMedico)
        {
            NegocioHorarioMedico neg = new NegocioHorarioMedico();
            DataTable dt = neg.getTablaHorarioActivoPorId(IdHorarioMedico);

            gvHorarios.DataSource = dt;
            gvHorarios.DataBind();

            lblMensaje.Visible = true;

            if (dt.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontró un horario activo con ese ID.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                gvHorarios.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
            }
            else
            {
                lblMensaje.Text = "";
                gvHorarios.Visible = true;
                btnConfirmar.Visible = true;
                btnCancelar.Visible = true;
            }
        }

        /*btnConfirmar_Click
        Se ejecuta al hacer clic en el botón Confirmar. Da de baja el horario
        almacenado en sesión y oculta los controles después de mostrar el resultado.*/
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int idHorario = Convert.ToInt32(Session["IdHorarioMedico"]);

            NegocioHorarioMedico neg = new NegocioHorarioMedico();
            bool estado = neg.eliminarHorarioMedico(idHorario);

            if (estado)
            {
                lblMensaje.Text = "El horario se ha dado de baja con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo realizar la operación.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            gvHorarios.Visible = false;
            lblMensaje.Visible = true;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;

            Session["IdHorarioMedico"] = null;
        }

        /*btnCancelar_Click
        Se ejecuta al hacer clic en el botón Cancelar. Oculta los controles,
        limpia el mensaje y elimina el Id de horario de la sesión.*/
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            gvHorarios.Visible = false;
            lblMensaje.Visible = false;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;
            lblMensaje.Text = "";
            Session["IdHorarioMedico"] = null;
        }

        /*btnBuscar_Click
        Se ejecuta al hacer clic en el botón Buscar. Valida que el ID ingresado
        sea un número válido y carga el GridView con el horario activo correspondiente.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int idHorario;
            bool esNumeroValido = int.TryParse(txtHorarioMedico.Text, out idHorario);

            if (!esNumeroValido)
            {
                lblMensaje.Text = "Por favor, ingrese un ID de horario médico válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                gvHorarios.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            Session["IdHorarioMedico"] = idHorario;
            cargarGrid(idHorario);
        }
    }
}