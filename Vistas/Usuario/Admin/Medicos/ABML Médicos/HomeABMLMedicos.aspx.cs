using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Medicos
{
    public partial class HomeABMLMedicos : System.Web.UI.Page
    {
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