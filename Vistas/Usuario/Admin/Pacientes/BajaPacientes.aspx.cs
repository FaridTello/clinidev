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
    public partial class BajaPacientes : System.Web.UI.Page
    {
        NegocioPaciente negocio = new NegocioPaciente();

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
        Se ejecuta al hacer clic en el botón Buscar. Valida que el ID ingresado
        sea un número válido y mayor a cero, luego busca el paciente activo correspondiente.
        Si existe, muestra sus datos en el GridView y habilita los botones de confirmación.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string strID = txtLegajoPaciente.Text;
            int idBusqueda;

            bool esNumeroValido = int.TryParse(strID, out idBusqueda);

            if (!esNumeroValido || idBusqueda <= 0)
            {
                lblMensaje.Text = "Por favor, ingrese un ID de paciente válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                gvBajaPaciente.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            DataTable tabla = negocio.getTablaPacientesxIDBaja(idBusqueda);

            if (tabla.Rows.Count == 0)
            {
                lblMensaje.Text = "No existe un paciente activo con el ID ingresado.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                gvBajaPaciente.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            int idPacienteReal = Convert.ToInt32(tabla.Rows[0]["ID"]);
            Session["IdPacienteABorrar"] = idPacienteReal;

            gvBajaPaciente.DataSource = tabla;
            gvBajaPaciente.DataBind();

            gvBajaPaciente.Visible = true;
            btnConfirmar.Visible = true;
            btnCancelar.Visible = true;
            lblMensaje.Visible = false;
            txtLegajoPaciente.Text = "";
        }

        /*btnConfirmar_Click
        Se ejecuta al hacer clic en el botón Confirmar. Elimina (baja lógica) al paciente
        almacenado en sesión y oculta los controles después de mostrar el resultado.*/
        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["IdPacienteABorrar"]);

            bool estado = negocio.eliminarPaciente(id);

            if (estado)
            {
                lblMensaje.Text = "El paciente se ha eliminado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo realizar la operación.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            gvBajaPaciente.Visible = false;
            lblMensaje.Visible = true;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;

            Session["IdPacienteABorrar"] = null;
        }

        /*btnCancelar_Click
        Se ejecuta al hacer clic en el botón Cancelar. Oculta los controles,
        limpia el mensaje y elimina el ID del paciente de la sesión.*/
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            gvBajaPaciente.Visible = false;
            lblMensaje.Visible = false;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;
            lblMensaje.Text = "";
            Session["IdPacienteABorrar"] = null;
        }
    }
}