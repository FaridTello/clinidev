using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Pacientes
{
    public partial class HomeABMLPacientes : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Verifica que el usuario esté logueado,
        si no lo está redirige al login. Si está logueado, muestra su nombre
        en la etiqueta correspondiente.*/
        protected void Page_Load(object sender, EventArgs e)
        {
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
}