using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Turnos
{
    public partial class HomeABMLTurnos : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión
        y muestra su nombre en la etiqueta correspondiente.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();
        }
    }
}