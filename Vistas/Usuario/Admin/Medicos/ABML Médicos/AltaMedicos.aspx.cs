using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Medicos
{
    public partial class AltaMedicos : System.Web.UI.Page
    {
        NegocioMedico negMedico = new NegocioMedico();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();

            if (!IsPostBack)
            {
                NegocioEspecialidad negEsp = new NegocioEspecialidad();
                ddlEspecialidad.DataSource = negEsp.getTabla();
                ddlEspecialidad.DataTextField = "Nombre_E";
                ddlEspecialidad.DataValueField = "Id_Especialidad_E";
                ddlEspecialidad.DataBind();

                NegocioProvincia negProv = new NegocioProvincia();
                ddlProvincia.DataSource = negProv.getTabla();
                ddlProvincia.DataTextField = "Nombre_P";
                ddlProvincia.DataValueField = "Id_Provincia_P";
                ddlProvincia.DataBind();
                ddlProvincia.AutoPostBack = true;

                ddlSexo.Items.Add(new ListItem("Masculino", "0"));
                ddlSexo.Items.Add(new ListItem("Femenino", "1"));

                ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
                ddlProvincia.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
                ddlSexo.Items.Insert(0, new ListItem("-- Seleccionar --", "-1"));
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            if (txtContraseña.Text != txtConfirmarContra.Text)
            {
                lblMensaje.Text = "Las contraseñas no coinciden.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!DateTime.TryParse(txtFechaNacimiento.Text, out DateTime fechaNacimiento))
            {
                lblMensaje.Text = "La fecha de nacimiento ingresada no es válida.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string nombreUsuario = txtNombre.Text.Trim() + "." + txtApellido.Text.Trim();
            bool sexo = ddlSexo.SelectedValue == "1";
            int idLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            bool estado = negMedico.agregarMedico(txtDni.Text, txtNombre.Text, txtApellido.Text, sexo, txtNacionalidad.Text, fechaNacimiento, txtDireccion.Text, txtCorreoElectro.Text, txtTelefono.Text, idEspecialidad, idLocalidad, nombreUsuario, txtContraseña.Text);
            mostrarMensaje(estado);
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlLocalidad.Items.Clear();

            NegocioLocalidad negLoc = new NegocioLocalidad();
            ddlLocalidad.DataSource = negLoc.getLocalidadesPorProvincia(Convert.ToInt32(ddlProvincia.SelectedValue));
            ddlLocalidad.DataTextField = "Nombre_L";
            ddlLocalidad.DataValueField = "Id_Localidad_L";
            ddlLocalidad.DataBind();

            ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
        }

        private void limpiarCampos()
        {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            ddlEspecialidad.SelectedIndex = 0;
            ddlProvincia.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlSexo.SelectedIndex = 0;
            txtNacionalidad.Text = "";
            txtFechaNacimiento.Text = "";
            txtDireccion.Text = "";
            txtCorreoElectro.Text = "";
            txtTelefono.Text = "";
            txtContraseña.Text = "";
        }
        private void mostrarMensaje(bool estado)
        {
            if (estado == true)
            {
                lblMensaje.Text = "Operación realizada exitosamente";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                limpiarCampos();
            }
            else
            {
                lblMensaje.Text = "No se pudo realizar la operación";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}