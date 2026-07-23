using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Medicos.ABML_Horarios
{
    public partial class ModificarHorarioMedico : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión
        y muestra su nombre en la etiqueta correspondiente.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();
        }

        /*gvHorarios_RowEditing
        Se ejecuta al hacer clic en el botón Editar del GridView. Activa el modo de edición
        para la fila seleccionada y guarda el legajo del médico en ViewState para usarlo
        durante la actualización.*/
        protected void gvHorarios_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHorarios.EditIndex = e.NewEditIndex;
            RecargarGrid();

            if (!string.IsNullOrWhiteSpace(txtIdHorarioMedico.Text))
            {
                int idHorario = int.Parse(txtIdHorarioMedico.Text);
                NegocioHorarioMedico negocio = new NegocioHorarioMedico();
                DataTable dt = negocio.getTablaHorarioPorId(idHorario);

                if (dt.Rows.Count > 0)
                {
                    ViewState["Legajo_Edit"] = Convert.ToInt32(dt.Rows[0]["Legajo"]);
                }
            }
        }

        /*gvHorarios_RowCancelingEdit
        Se ejecuta al hacer clic en el botón Cancelar durante la edición.
        Cancela el modo de edición y recarga el GridView.*/
        protected void gvHorarios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHorarios.EditIndex = -1;
            RecargarGrid();
        }

        /*RecargarGrid
        Recarga el GridView con los datos del horario cuyo ID está ingresado en el campo de texto.*/
        private void RecargarGrid()
        {
            if (!string.IsNullOrWhiteSpace(txtIdHorarioMedico.Text))
            {
                NegocioHorarioMedico negocio = new NegocioHorarioMedico();
                gvHorarios.DataSource = negocio.getTablaHorarioPorId(int.Parse(txtIdHorarioMedico.Text));
                gvHorarios.DataBind();
            }
        }

        /*gvHorarios_RowUpdating
        Se ejecuta al hacer clic en el botón Actualizar durante la edición.
        Obtiene los valores modificados del horario, valida y actualiza el horario
        en la base de datos, mostrando el resultado en la etiqueta de mensaje.*/
        protected void gvHorarios_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = gvHorarios.Rows[e.RowIndex];

            int idHorario = int.Parse(((Label)fila.FindControl("lbl_eit_IdHorario")).Text);
            int legajo = Convert.ToInt32(ViewState["Legajo_Edit"]);
            string dia = ((DropDownList)fila.FindControl("ddl_eit_dias")).SelectedValue;
            TimeSpan inicio = TimeSpan.Parse(((TextBox)fila.FindControl("txt_eit_Inicio")).Text);
            TimeSpan fin = TimeSpan.Parse(((TextBox)fila.FindControl("txt_eit_Fin")).Text);

            NegocioHorarioMedico negocio = new NegocioHorarioMedico();
            bool resultado = negocio.modificarHorarioMedico(idHorario, legajo, dia, inicio, fin);

            if (resultado)
            {
                lblMensaje.Text = "Horario modificado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo modificar. Verificá que el horario exista y el día no esté ocupado.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            gvHorarios.EditIndex = -1;
            RecargarGrid();
        }

        /*btnBuscar_Click
        Se ejecuta al hacer clic en el botón Buscar. Recarga el GridView con el horario
        correspondiente al ID ingresado.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RecargarGrid();
        }
    }
}