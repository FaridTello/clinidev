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
    public partial class AltaLogicaMedicos : System.Web.UI.Page
    {
        NegocioMedico negocio = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
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
            int Legajo;
            bool esNumeroValido = int.TryParse(txtLegajoMedico.Text, out Legajo);

            if (!esNumeroValido)
            {
                lblMensaje.Text = "Por favor, ingrese un número de legajo válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                gvAltaMedicos.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            DataTable tabla = negocio.getTablaInactivosxLegajo(Legajo);

            if (tabla.Rows.Count == 0)
            {
                lblMensaje.Text = "No existe un médico inactivo con el legajo ingresado.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Visible = true;
                gvAltaMedicos.Visible = false;
                btnConfirmar.Visible = false;
                btnCancelar.Visible = false;
                return;
            }

            Session["LegajoMedico"] = Legajo;
            gvAltaMedicos.DataSource = tabla;
            gvAltaMedicos.DataBind();
            gvAltaMedicos.Visible = true;
            btnConfirmar.Visible = true;
            btnCancelar.Visible = true;
            lblMensaje.Visible = false;
            txtLegajoMedico.Text = "";
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["LegajoMedico"]);
            bool estado = negocio.reactivarMedico(id);

            if (estado)
            {
                lblMensaje.Text = "El médico se ha reactivado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo realizar la operación.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            gvAltaMedicos.Visible = false;
            lblMensaje.Visible = true;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;

            Session["LegajoMedico"] = null;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            gvAltaMedicos.Visible = false;
            lblMensaje.Visible = false;
            btnConfirmar.Visible = false;
            btnCancelar.Visible = false;
            lblMensaje.Text = "";
            Session["LegajoMedico"] = null;
        }
    }
}