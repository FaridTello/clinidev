using Negocio;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Medicos
{
    public partial class ModificacionMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();
        }

        private void RecargarGrid()
        {
            int legajo;

            if (int.TryParse(txtLegajoMedico.Text, out legajo))
            {
                NegocioMedico negocio = new NegocioMedico();

                GvMedicos.DataSource = negocio.getTablaxLegajo(legajo);
                GvMedicos.DataBind();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            GvMedicos.EditIndex = -1;
            RecargarGrid();
        }

        protected void GvMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvMedicos.EditIndex = e.NewEditIndex;
            RecargarGrid();

            GridViewRow fila = GvMedicos.Rows[e.NewEditIndex];

            int legajo = int.Parse(((Label)fila.FindControl("lbl_eit_Legajo")).Text);
            NegocioMedico negMedico = new NegocioMedico();
            DataTable dt = negMedico.getTablaxLegajo(legajo);
            int idEspecialidad = int.Parse(dt.Rows[0]["IdEspecialidad"].ToString());
            int idLocalidad = int.Parse(dt.Rows[0]["IdLocalidad"].ToString());
            int idProvincia = int.Parse(dt.Rows[0]["IdProvincia"].ToString());

            DropDownList ddlProvincia = (DropDownList)fila.FindControl("ddl_eit_Provincia");
            NegocioProvincia negProvincia = new NegocioProvincia();
            ddlProvincia.DataSource = negProvincia.getTabla();
            ddlProvincia.DataTextField = "Nombre_P";
            ddlProvincia.DataValueField = "Id_Provincia_P";
            ddlProvincia.DataBind();
            ddlProvincia.SelectedValue = idProvincia.ToString();

            DropDownList ddlLocalidad = (DropDownList)fila.FindControl("ddl_eit_Localidad");
            NegocioLocalidad negLocalidad = new NegocioLocalidad();
            ddlLocalidad.DataSource = negLocalidad.getLocalidadesPorProvincia(idProvincia);
            ddlLocalidad.DataTextField = "Nombre_L";
            ddlLocalidad.DataValueField = "Id_Localidad_L";
            ddlLocalidad.DataBind();
            ddlLocalidad.SelectedValue = idLocalidad.ToString();

            DropDownList ddlEspecialidad = (DropDownList)fila.FindControl("ddl_eit_Especialidad");
            NegocioEspecialidad negEspecialidad = new NegocioEspecialidad();
            ddlEspecialidad.DataSource = negEspecialidad.getTabla();
            ddlEspecialidad.DataTextField = "Nombre_E";
            ddlEspecialidad.DataValueField = "Id_Especialidad_E";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.SelectedValue = idEspecialidad.ToString();

            
        }

        protected void GvMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvMedicos.EditIndex = -1;
            RecargarGrid();
        }

        protected void GvMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = GvMedicos.Rows[e.RowIndex];

            int legajo = int.Parse(((Label)fila.FindControl("lbl_eit_Legajo")).Text);
            string dni = ((Label)fila.FindControl("lbl_eit_Dni")).Text;
            string nombre = ((TextBox)fila.FindControl("txt_eit_Nombre")).Text;
            string apellido = ((TextBox)fila.FindControl("txt_eit_Apellido")).Text;
            string fechaStr = ((TextBox)fila.FindControl("txt_eit_FechaNacimiento")).Text;
            string nac = ((TextBox)fila.FindControl("txt_eit_Nacionalidad")).Text;
            string dir = ((TextBox)fila.FindControl("txt_eit_Direccion")).Text;
            string correo = ((TextBox)fila.FindControl("txt_eit_CorreoElectronico")).Text;
            string tel = ((TextBox)fila.FindControl("txt_eit_Telefono")).Text;
            string activoStr = ((Label)fila.FindControl("lbl_eit_Estado")).Text;

            int idEspecialidad = int.Parse(((DropDownList)fila.FindControl("ddl_eit_Especialidad")).SelectedValue);
            int idLocalidad = int.Parse(((DropDownList)fila.FindControl("ddl_eit_Localidad")).SelectedValue);

            DropDownList ddlSexo = (DropDownList)fila.FindControl("ddl_eit_Sexo");
            bool sexo = ddlSexo.SelectedValue == "Masculino";

            bool activo = activoStr.Trim().ToLower() == "activo";

            if (!DateTime.TryParse(fechaStr, out DateTime fechaNacimiento))
            {
                lbl_Mensaje.Text = "La fecha de nacimiento ingresada no es válida.";
                lbl_Mensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int edad = DateTime.Today.Year - fechaNacimiento.Year;
            if (fechaNacimiento.Date > DateTime.Today.AddYears(-edad)) edad--;

            if (edad < 18)
            {
                lbl_Mensaje.Text = "El médico debe ser mayor de 18 años.";
                lbl_Mensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            NegocioMedico negocio = new NegocioMedico();
            bool resultado = negocio.modificarMedico(legajo, dni, nombre, apellido, sexo, nac, fechaNacimiento, dir, correo, tel, idEspecialidad, idLocalidad, activo);

            if (resultado)
            {
                GvMedicos.EditIndex = -1;
                RecargarGrid();
                lbl_Mensaje.Text = "Médico actualizado con éxito.";
                lbl_Mensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lbl_Mensaje.Text = "No se pudo actualizar el médico.";
                lbl_Mensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ddl_eit_Provincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;
            GridViewRow fila = (GridViewRow)ddlProvincia.NamingContainer;
            DropDownList ddlLocalidad = (DropDownList)fila.FindControl("ddl_eit_Localidad");

            NegocioLocalidad negLocalidad = new NegocioLocalidad();
            ddlLocalidad.DataSource = negLocalidad.getLocalidadesPorProvincia(int.Parse(ddlProvincia.SelectedValue));
            ddlLocalidad.DataTextField = "Nombre_L";
            ddlLocalidad.DataValueField = "Id_Localidad_L";
            ddlLocalidad.DataBind();
        }


    }
}