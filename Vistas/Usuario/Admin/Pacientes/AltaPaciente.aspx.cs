using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin
{
    public partial class AltaPaciente : System.Web.UI.Page
    {
        NegocioPaciente negPaciente = new NegocioPaciente();

        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión,
        muestra su nombre y en la primera carga carga los combos de provincias y sexo.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();

            if (!IsPostBack)
            {
                NegocioProvincia negProv = new NegocioProvincia();
                ddlProvincia.DataSource = negProv.getTabla();
                ddlProvincia.DataTextField = "Nombre_P";
                ddlProvincia.DataValueField = "Id_Provincia_P";
                ddlProvincia.DataBind();
                ddlProvincia.AutoPostBack = true;

                ddlSexo.Items.Add(new ListItem("Masculino", "0"));
                ddlSexo.Items.Add(new ListItem("Femenino", "1"));

                ddlProvincia.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
                ddlSexo.Items.Insert(0, new ListItem("-- Seleccionar --", "-1"));
            }
        }

        /*ddlProvincia_SelectedIndexChanged
        Se ejecuta al cambiar la selección en el combo de provincias.
        Carga las localidades correspondientes a la provincia seleccionada en el combo de localidades.*/
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

        /*btnGuardar_Click
        Se ejecuta al hacer clic en el botón Guardar. Obtiene los datos del formulario,
        convierte el sexo a booleano y llama a la capa de negocio para agregar el paciente.
        Muestra el resultado de la operación.*/
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool sexo = ddlSexo.SelectedValue == "1";
            DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);
            int idLocalidad = Convert.ToInt32(ddlLocalidad.SelectedValue);

            Boolean estado = false;

            estado = negPaciente.agregarPaciente(txtDni.Text, txtNombre.Text, txtApellido.Text, sexo, txtNacionalidad.Text, fechaNacimiento, txtDireccion.Text, txtCorreo.Text, txtTelefono.Text, idLocalidad);
            if (estado == true)
            {
                mostrarMensaje(estado);
            }
            else
            {
                mostrarMensaje(estado);
            }
        }

        /*limpiarCampos
        Limpia todos los campos del formulario y restablece los combos a su valor por defecto.*/
        private void limpiarCampos()
        {
            txtDni.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            ddlProvincia.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            ddlSexo.SelectedIndex = 0;
            txtNacionalidad.Text = "";
            txtFechaNacimiento.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        /*mostrarMensaje
        Muestra un mensaje en la interfaz indicando el resultado de la operación.
        Si la operación fue exitosa, limpia los campos del formulario.*/
        private void mostrarMensaje(bool estado)
        {
            if (estado == true)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Operación realizada exitosamente";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                limpiarCampos();
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "No se pudo realizar la operación";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        /*btnLimpiar_Click
        Se ejecuta al hacer clic en el botón Limpiar. Limpia todos los campos del formulario.*/
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}