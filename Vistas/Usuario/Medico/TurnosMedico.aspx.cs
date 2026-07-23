using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Medico
{
    public partial class TurnosMedico : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión,
        muestra su nombre y en la primera carga obtiene el legajo del médico
        para mostrar sus turnos asignados.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();

            if (!IsPostBack)
            {
                NegocioMedico negocioMedico = new NegocioMedico();
                int legajo = negocioMedico.getLegajoPorIdUsuario(usu.getId_Usuario_U());

                NegocioTurno negocioTurno = new NegocioTurno();
                gvTurnos.DataSource = negocioTurno.getTurnosPorLegajo(legajo);
                gvTurnos.DataBind();
            }
        }

        /*btnBuscar_Click
        Se ejecuta al hacer clic en el botón Buscar. Filtra los turnos del médico
        por nombre/apellido del paciente y/o fecha según los valores ingresados.
        Valida el formato de la fecha si se proporciona.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            NegocioMedico negocioMedico = new NegocioMedico();
            int legajo = negocioMedico.getLegajoPorIdUsuario(usu.getId_Usuario_U());

            string nombreApellido = txtNombreApellido.Text.Trim();
            string fechaTexto = txtFecha.Text.Trim();

            NegocioTurno negocioTurno = new NegocioTurno();
            DataTable dt;

            bool tieneNombre = !string.IsNullOrEmpty(nombreApellido);
            bool tieneFecha = !string.IsNullOrEmpty(fechaTexto);

            if (!tieneNombre && !tieneFecha)
            {
                dt = negocioTurno.getTurnosPorLegajo(legajo);
            }
            else if (tieneNombre && !tieneFecha)
            {
                dt = negocioTurno.getTurnosPorNombreApellido(legajo, nombreApellido);
            }
            else if (!tieneNombre && tieneFecha)
            {
                DateTime fecha;
                if (!DateTime.TryParse(fechaTexto, out fecha))
                {
                    lblMensaje.Text = "Fecha inválida.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                dt = negocioTurno.getTurnosPorFecha(legajo, fecha);
            }
            else
            {
                DateTime fecha;
                if (!DateTime.TryParse(fechaTexto, out fecha))
                {
                    lblMensaje.Text = "Fecha inválida.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                dt = negocioTurno.getTurnosPorNombreApellidoYFecha(legajo, nombreApellido, fecha);
            }

            gvTurnos.EditIndex = -1;
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
            txtNombreApellido.Text = "";
            txtFecha.Text = "";

            if (dt.Rows.Count == 0)
            {
                lblMensaje.Text = "No se encontraron turnos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblMensaje.Text = "";
            }
        }

        /*gvTurnos_RowEditing
        Se ejecuta al hacer clic en el botón Editar del GridView.
        Activa el modo de edición para la fila seleccionada y recarga los turnos del médico.*/
        protected void gvTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTurnos.EditIndex = e.NewEditIndex;
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            NegocioMedico negocioMedico = new NegocioMedico();
            int legajo = negocioMedico.getLegajoPorIdUsuario(usu.getId_Usuario_U());
            NegocioTurno negocioTurno = new NegocioTurno();
            gvTurnos.DataSource = negocioTurno.getTurnosPorLegajo(legajo);
            gvTurnos.DataBind();
        }

        /*gvTurnos_RowUpdating
        Se ejecuta al hacer clic en el botón Actualizar durante la edición.
        Obtiene los valores de presentismo y observación, valida que se haya seleccionado
        un estado y actualiza el turno en la base de datos. Muestra el resultado.*/
        protected void gvTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idTurno = Convert.ToInt32(gvTurnos.DataKeys[e.RowIndex].Value);

            DropDownList ddlPresentismo = (DropDownList)gvTurnos.Rows[e.RowIndex].FindControl("ddlPresentismo");
            TextBox txtObservacion = (TextBox)gvTurnos.Rows[e.RowIndex].FindControl("txtObservacion");

            if (ddlPresentismo.SelectedValue == "-1")
            {
                lblMensaje.Text = "Debe seleccionar Presente o Ausente.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            bool presentismo = Convert.ToBoolean(Convert.ToInt32(ddlPresentismo.SelectedValue));
            string observacion = txtObservacion.Text.Trim();

            NegocioTurno negocio = new NegocioTurno();
            bool resultado = negocio.marcarPresentismo(idTurno, presentismo, observacion);

            if (resultado)
            {
                lblMensaje.Text = "Turno actualizado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo actualizar el turno.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            gvTurnos.EditIndex = -1;
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            NegocioMedico negocioMedico = new NegocioMedico();
            int legajo = negocioMedico.getLegajoPorIdUsuario(usu.getId_Usuario_U());
            gvTurnos.DataSource = new NegocioTurno().getTurnosPorLegajo(legajo);
            gvTurnos.DataBind();
        }

        /*gvTurnos_RowCancelingEdit
        Se ejecuta al hacer clic en el botón Cancelar durante la edición.
        Cancela el modo de edición y recarga los turnos del médico.*/
        protected void gvTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTurnos.EditIndex = -1;
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            NegocioMedico negocioMedico = new NegocioMedico();
            int legajo = negocioMedico.getLegajoPorIdUsuario(usu.getId_Usuario_U());
            NegocioTurno negocioTurno = new NegocioTurno();
            gvTurnos.DataSource = negocioTurno.getTurnosPorLegajo(legajo);
            gvTurnos.DataBind();
        }

        /*gvTurnos_RowCommand
        Se ejecuta al hacer clic en un botón dentro del GridView.
        Actualmente no tiene implementación.*/
        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}