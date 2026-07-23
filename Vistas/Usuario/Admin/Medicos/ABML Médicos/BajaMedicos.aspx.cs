using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Medicos
{
    public partial class BajaMedicos : System.Web.UI.Page
    {
        NegocioMedico negocio = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (!IsPostBack)
            {
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                // Validación de seguridad para que muestre el usuario logueado
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int legajo;
            bool esNumeroValido = int.TryParse(txtLegajoMedico.Text, out legajo);

            if (!esNumeroValido)
            {
                lblMensaje.Text = "Por favor, ingrese un número de legajo válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                gvBajaMedicos.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            Entidades.Medico med = new Entidades.Medico();
            med.setLegajo_M(legajo);

            DataTable tabla = negocio.getTablaMedicosxLegajoBaja(med);

            if (tabla.Rows.Count == 0)
            {
                lblMensaje.Text = "No existe un médico activo con el legajo ingresado.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                gvBajaMedicos.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            Session["LegajoMedico"] = legajo;
            gvBajaMedicos.DataSource = tabla;
            gvBajaMedicos.DataBind();
            gvBajaMedicos.Visible = true;
            btnConfirmar.Visible = true;
            btnCancelar.Visible = true;
            lblMensaje.Visible = false;
            txtLegajoMedico.Text = "";
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["LegajoMedico"]);
            bool estado = negocio.eliminarMedico(id);

            if (estado)
            {
                lblMensaje.Text = "El médico se ha eliminado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo realizar la operación.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            gvBajaMedicos.Visible = false;
            lblMensaje.Visible = true;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;

            Session["LegajoMedico"] = null;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            gvBajaMedicos.Visible = false;
            lblMensaje.Visible = false;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;
            lblMensaje.Text = "";
            Session["LegajoMedico"] = null;
        }
    }
}