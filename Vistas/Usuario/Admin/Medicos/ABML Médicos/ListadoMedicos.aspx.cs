using Negocio;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Medicos
{
    public partial class ListadoMedicos : System.Web.UI.Page
    {
        NegocioMedico negMedico = new NegocioMedico();
        NegocioProvincia negProvincia = new NegocioProvincia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = negMedico.getTabla();
                gvMedicos.DataSource = dt;
                gvMedicos.DataBind();

                if (Session["UsuarioLogueado"] != null)
                {
                    Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
                    lblUsuarioLogueado.Text = usu.getNombre_U();
                }
                else
                {
                    Response.Redirect("~/Usuario/Login.aspx");
                }

                CargarProvincias();
            }
        }
        private void CargarProvincias()
        {
            DataTable dtProvincias = negProvincia.getTabla();
            ddlProvincia.DataSource = dtProvincias;
            ddlProvincia.DataTextField = "Nombre_P";
            ddlProvincia.DataValueField = "Id_Provincia_P";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccionar Provincia --", "0"));
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtBuscarNombre.Text.Trim();
            int provincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            DataTable dt;

            if (!string.IsNullOrEmpty(nombre) && provincia != 0)
                dt = negMedico.getTablaMedicosxNombreProvincia(nombre, provincia);
            else if (!string.IsNullOrEmpty(nombre))
                dt = negMedico.getTablaxNombre(nombre);
            else if (provincia != 0)
                dt = negMedico.getTablaxProvincia(provincia);
            else
                dt = negMedico.getTabla();

            if (dt.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontraron médicos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                gvMedicos.DataSource = null;
            }
            else
            {
                lblMensaje.Text = "";
                gvMedicos.DataSource = dt;
            }

            gvMedicos.DataBind();
        }

        protected void gvMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMedicos.PageIndex = e.NewPageIndex;
            btnBuscar_Click(null, null);
        }

        private void limpiarCampos()
        {
            txtBuscarNombre.Text = string.Empty;
            ddlProvincia.SelectedIndex = 0;
        }


        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            gvMedicos.DataSource = negMedico.getTabla();
            gvMedicos.DataBind();
            limpiarCampos();
        }
    }
}