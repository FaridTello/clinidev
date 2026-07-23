using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vistas.Usuario.Admin.Medicos;

namespace Vistas.Usuario.Admin.Pacientes
{
    public partial class AltaLogicaPaciente : System.Web.UI.Page
    {
        NegocioPaciente negPaciente = new NegocioPaciente();

        /*Page_Load
        Se ejecuta al cargar la página. Verifica que el usuario esté logueado,
        si no lo está redirige al login. En la primera carga oculta los botones
        y el GridView de pacientes.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                if (Session["UsuarioLogueado"] != null)
                {
                    Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
                    lblUsuarioLogueado.Text = usu.getNombre_U();
                }
                else
                {
                    Response.Redirect("~/Usuario/Login.aspx");
                }
            }
        }

        /*btnBuscar_Click
        Se ejecuta al hacer clic en el botón Buscar. Valida que el legajo ingresado
        sea un número válido y busca el paciente inactivo correspondiente.
        Si existe, muestra sus datos en el GridView y habilita los botones de confirmación.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int Legajo;
            bool esNumeroValido = int.TryParse(txtLegajoMedico.Text, out Legajo);

            if (!esNumeroValido)
            {
                lblMensaje.Text = "Por favor, ingrese un número de legajo válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                gvAltaPacientes.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            DataTable tabla = negPaciente.getTablaInactivosxLegajo(Legajo);

            if (tabla.Rows.Count == 0)
            {
                lblMensaje.Text = "No existe un paciente inactivo con el legajo ingresado.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                gvAltaPacientes.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            Session["LegajoMedico"] = Legajo;
            gvAltaPacientes.DataSource = tabla;
            gvAltaPacientes.DataBind();
            gvAltaPacientes.Visible = true;
            btnConfirmar.Visible = true;
            btnCancelar.Visible = true;
            lblMensaje.Visible = false;
            txtLegajoMedico.Text = "";
        }

        /*btnConfirmar_Click
        Se ejecuta al hacer clic en el botón Confirmar. Reactiva al paciente
        almacenado en sesión y oculta los controles después de mostrar el resultado.*/
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["LegajoMedico"]);
            bool estado = negPaciente.reactivarPaciente(id);

            if (estado)
            {
                lblMensaje.Text = "El paciente se ha reactivado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo realizar la operación.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            gvAltaPacientes.Visible = false;
            lblMensaje.Visible = true;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;

            Session["LegajoMedico"] = null;
        }

        /*btnCancelar_Click
        Se ejecuta al hacer clic en el botón Cancelar. Oculta los controles,
        limpia el mensaje y elimina el legajo de la sesión.*/
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            gvAltaPacientes.Visible = false;
            lblMensaje.Visible = false;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;
            lblMensaje.Text = "";
            Session["LegajoMedico"] = null;
        }
    }
}