using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas.Usuario
{
    public partial class Login : System.Web.UI.Page
    {
        private NegocioUsuario negUsuario = new NegocioUsuario();

        /*Page_Load
        Se ejecuta al cargar la página. En la primera carga limpia la sesión
        por seguridad al mostrar la pantalla de login.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["UsuarioLogueado"] = null;
            }
        }

        /*btnIngresar_Click
        Se ejecuta al hacer clic en el botón Ingresar. Valida que los campos
        estén completos, intenta autenticar al usuario con las credenciales
        proporcionadas y redirige según el tipo de usuario (Administrador o Médico).*/
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text.Trim();
            string contrasenia = txtContrasenia.Text.Trim();

            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(contrasenia))
            {
                lblMensaje.Text = "Por favor, complete todos los campos.";
                return;
            }

            Entidades.Usuario usuarioLogueado = negUsuario.login(nombreUsuario, contrasenia);

            if (usuarioLogueado != null)
            {
                Session["UsuarioLogueado"] = usuarioLogueado;

                if (usuarioLogueado.getTipo_Usuario_U() == false)
                {
                    Response.Redirect("~/Usuario/Admin/Home.aspx");
                }
                else
                {
                    Response.Redirect("~/Usuario/Medico/TurnosMedico.aspx");
                }
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}