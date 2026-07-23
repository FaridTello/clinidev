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
    public partial class AltaLogicaHorarioMedico : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Verifica que el usuario esté logueado,
        si no lo está redirige al login. En la primera carga oculta los botones
        y el GridView de horarios inactivos.*/
        protected void Page_Load(object sender, EventArgs e)
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

            if (!IsPostBack)
            {
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                gvHorariosInactivos.Visible = false;
                lblMensaje.Visible = false;
            }
        }

        /*cargarGrid
        Carga el GridView con los datos del horario inactivo cuyo ID se recibe.
        Si no se encuentra el horario, muestra un mensaje de error y oculta los controles.*/
        private void cargarGrid(int IdHorarioMedico)
        {
            NegocioHorarioMedico neg = new NegocioHorarioMedico();
            DataTable dt = neg.getTablaHorarioInactivoPorId(IdHorarioMedico);

            gvHorariosInactivos.DataSource = dt;
            gvHorariosInactivos.DataBind();

            lblMensaje.Visible = true;

            if (dt.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontró un horario inactivo con ese ID.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                gvHorariosInactivos.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
            }
            else
            {
                lblMensaje.Text = "";
                gvHorariosInactivos.Visible = true;
                btnConfirmar.Visible = true;
                btnCancelar.Visible = true;
            }
        }

        /*gvHorariosInactivos_RowCommand
        Se ejecuta al hacer clic en el botón Reactivar dentro del GridView.
        Reactiva el horario seleccionado y actualiza el GridView.*/
        protected void gvHorariosInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Reactivar")
            {
                int idHorario = Convert.ToInt32(e.CommandArgument);

                NegocioHorarioMedico neg = new NegocioHorarioMedico();
                bool resultado = neg.reactivarHorarioMedico(idHorario);

                int IdHorarioMedico = Convert.ToInt32(txtIdHorarioMedico.Text);
                cargarGrid(IdHorarioMedico);

                if (resultado)
                {
                    lblMensaje.Text = "Horario reactivado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "No se pudo reactivar el horario. ";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        /*btnCancelar_Click
        Se ejecuta al hacer clic en el botón Cancelar. Oculta los controles,
        limpia el mensaje y elimina el Id de horario de la sesión.*/
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            gvHorariosInactivos.Visible = false;
            lblMensaje.Visible = false;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;
            lblMensaje.Text = "";
            Session["IdHorarioMedico"] = null;
        }

        /*btnBuscar_Click
        Se ejecuta al hacer clic en el botón Buscar. Valida que el ID ingresado
        sea un número válido y carga el GridView con el horario inactivo correspondiente.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int idHorario;
            bool esNumeroValido = int.TryParse(txtIdHorarioMedico.Text, out idHorario);

            if (!esNumeroValido)
            {
                lblMensaje.Text = "Por favor, ingrese un ID de horario médico válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                gvHorariosInactivos.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            Session["IdHorarioMedico"] = idHorario;
            cargarGrid(idHorario);
        }

        /*btnConfirmar_Click
        Se ejecuta al hacer clic en el botón Confirmar. Reactiva el horario
        almacenado en sesión y oculta los controles después de mostrar el resultado.*/
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int idHorario = Convert.ToInt32(Session["IdHorarioMedico"]);
            NegocioHorarioMedico neg = new NegocioHorarioMedico();
            bool estado = neg.reactivarHorarioMedico(idHorario);

            if (estado)
            {
                lblMensaje.Text = "El horario se ha reactivado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo realizar la operación, corrobore que no se superponga con otro horario.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            gvHorariosInactivos.Visible = false;
            lblMensaje.Visible = true;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;
            Session["IdHorarioMedico"] = null;
        }
    }
}