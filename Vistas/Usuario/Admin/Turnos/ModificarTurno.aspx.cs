using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Turnos
{
    public partial class ModificarTurno : System.Web.UI.Page
    {
        NegocioTurno negTurno = new NegocioTurno();

        /*Page_Load
        Se ejecuta al cargar la página. Verifica que el usuario esté logueado,
        si no lo está redirige al login. Si está logueado, muestra su nombre
        en la etiqueta correspondiente.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

        /*RecargarGrid
        Recarga el GridView con los datos del turno cuyo ID está ingresado en el campo de texto.
        Si no se encuentra el turno activo, muestra un mensaje de error.*/
        private void RecargarGrid()
        {
            int idTurno;
            if (int.TryParse(txtIdTurno.Text, out idTurno))
            {
                DataTable tabla = negTurno.getTurnoxId(idTurno);

                if (tabla.Rows.Count == 0)
                {
                    lblMensaje.Text = "No se encontró un turno activo con ese ID.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    GvTurnos.DataSource = null;
                    GvTurnos.DataBind();
                    return;
                }

                GvTurnos.DataSource = tabla;
                GvTurnos.DataBind();
                lblMensaje.Text = "";
            }
            else
            {
                lblMensaje.Text = "Ingrese un ID de turno válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        /*btnBuscar_Click
        Se ejecuta al hacer clic en el botón Buscar. Recarga el GridView con el turno
        correspondiente al ID ingresado.*/
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            RecargarGrid();
        }

        /*GvTurnos_RowEditing
        Se ejecuta al hacer clic en el botón Editar del GridView. Activa el modo de edición
        para la fila seleccionada y carga los combos de paciente, especialidad, médico
        y horarios con los valores actuales del turno.*/
        protected void GvTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvTurnos.EditIndex = e.NewEditIndex;
            RecargarGrid();

            GridViewRow fila = GvTurnos.Rows[e.NewEditIndex];

            int idTurno = int.Parse(txtIdTurno.Text);
            DataTable dt = negTurno.getTurnoxId(idTurno);

            if (dt.Rows.Count > 0)
            {
                int idPaciente = int.Parse(dt.Rows[0]["Id_Paciente_T"].ToString());
                int idEspecialidad = int.Parse(dt.Rows[0]["Id_Especialidad_M"].ToString());
                int legajoMedico = int.Parse(dt.Rows[0]["Legajo_HM"].ToString());
                string horaTurno = dt.Rows[0]["Horario_Turno_T"].ToString();

                DropDownList ddlPaciente = (DropDownList)fila.FindControl("ddl_eit_Paciente");
                NegocioPaciente negPaciente = new NegocioPaciente();
                ddlPaciente.DataSource = negPaciente.getTablaActivos();
                ddlPaciente.DataTextField = "NombreCompleto";
                ddlPaciente.DataValueField = "Id_Paciente_Pa";
                ddlPaciente.DataBind();
                ddlPaciente.SelectedValue = idPaciente.ToString();

                DropDownList ddlEspecialidad = (DropDownList)fila.FindControl("ddl_eit_Especialidad");
                NegocioEspecialidad negEspecialidad = new NegocioEspecialidad();
                ddlEspecialidad.DataSource = negEspecialidad.getTabla();
                ddlEspecialidad.DataTextField = "Nombre_E";
                ddlEspecialidad.DataValueField = "Id_Especialidad_E";
                ddlEspecialidad.DataBind();
                ddlEspecialidad.SelectedValue = idEspecialidad.ToString();

                DropDownList ddlMedico = (DropDownList)fila.FindControl("ddl_eit_Medico");
                NegocioMedico negMedico = new NegocioMedico();
                ddlMedico.DataSource = negMedico.getTablaxEspecialidad(idEspecialidad);
                ddlMedico.DataTextField = "NombreCompleto";
                ddlMedico.DataValueField = "Legajo_M";
                ddlMedico.DataBind();
                ddlMedico.SelectedValue = legajoMedico.ToString();

                CargarHorariosEnFila(fila, legajoMedico, horaTurno);
            }
        }

        /*GvTurnos_RowCancelingEdit
        Se ejecuta al hacer clic en el botón Cancelar durante la edición.
        Cancela el modo de edición y recarga el GridView.*/
        protected void GvTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvTurnos.EditIndex = -1;
            RecargarGrid();
        }

        /*GvTurnos_RowUpdating
        Se ejecuta al hacer clic en el botón Actualizar durante la edición.
        Obtiene los valores modificados del turno, valida la fecha y actualiza
        el turno en la base de datos, mostrando el resultado en la etiqueta de mensaje.*/
        protected void GvTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = GvTurnos.Rows[e.RowIndex];

            int idTurno = int.Parse(((Label)fila.FindControl("lbl_eit_IdTurno")).Text);
            int idPaciente = int.Parse(((DropDownList)fila.FindControl("ddl_eit_Paciente")).SelectedValue);
            DateTime fechaTurno = DateTime.Parse(((TextBox)fila.FindControl("txt_eit_Fecha")).Text);

            if (fechaTurno.Date < DateTime.Today)
            {
                lblMensaje.Text = "La fecha del turno no puede ser anterior a hoy.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            DropDownList ddlHorario = (DropDownList)fila.FindControl("ddl_eit_Horario");

            if (ddlHorario.Items.Count == 0 || ddlHorario.SelectedValue == "0" || string.IsNullOrEmpty(ddlHorario.SelectedValue))
            {
                lblMensaje.Text = "El médico no atiende ese día o no hay horarios disponibles.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int idHorarioHM = Convert.ToInt32(ViewState["IdHorarioHM_Edit"]);
            TimeSpan horaExacta = TimeSpan.Parse(ddlHorario.SelectedValue);

            bool resultado = negTurno.modificarTurno(idTurno, idPaciente, idHorarioHM, horaExacta, fechaTurno);

            if (resultado)
            {
                GvTurnos.EditIndex = -1;
                RecargarGrid();
                lblMensaje.Text = "Turno actualizado con éxito.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "No se pudo actualizar el turno.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        /*ddl_eit_Especialidad_SelectedIndexChanged
        Se ejecuta al cambiar la selección en el combo de especialidad dentro del GridView en modo edición.
        Carga los médicos correspondientes a la especialidad seleccionada.*/
        protected void ddl_eit_Especialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlEspecialidad = (DropDownList)sender;
            GridViewRow fila = (GridViewRow)ddlEspecialidad.NamingContainer;
            DropDownList ddlMedico = (DropDownList)fila.FindControl("ddl_eit_Medico");
            DropDownList ddlHorario = (DropDownList)fila.FindControl("ddl_eit_Horario");

            NegocioMedico negMedico = new NegocioMedico();
            ddlMedico.DataSource = negMedico.getTablaxEspecialidad(int.Parse(ddlEspecialidad.SelectedValue));
            ddlMedico.DataTextField = "NombreCompleto";
            ddlMedico.DataValueField = "Legajo_M";
            ddlMedico.DataBind();
            ddlMedico.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            ddlHorario.Items.Clear();
        }

        /*ddl_eit_Medico_SelectedIndexChanged
        Se ejecuta al cambiar la selección en el combo de médico dentro del GridView en modo edición.
        Carga los horarios disponibles para el médico seleccionado en la fecha indicada.*/
        protected void ddl_eit_Medico_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlMedico = (DropDownList)sender;
            GridViewRow fila = (GridViewRow)ddlMedico.NamingContainer;
            CargarHorariosEnFila(fila, int.Parse(ddlMedico.SelectedValue), "");
        }

        /*txt_eit_Fecha_TextChanged
        Se ejecuta al cambiar el texto en el campo de fecha dentro del GridView en modo edición.
        Carga los horarios disponibles para la fecha ingresada.*/
        protected void txt_eit_Fecha_TextChanged(object sender, EventArgs e)
        {
            TextBox txtFecha = (TextBox)sender;
            GridViewRow fila = (GridViewRow)txtFecha.NamingContainer;
            DropDownList ddlMedico = (DropDownList)fila.FindControl("ddl_eit_Medico");
            CargarHorariosEnFila(fila, int.Parse(ddlMedico.SelectedValue), "");
        }

        /*CargarHorariosEnFila
        Carga los horarios disponibles para el médico y fecha indicados en la fila del GridView.
        Si se proporciona una hora preseleccionada, la selecciona en el combo.*/
        private void CargarHorariosEnFila(GridViewRow fila, int legajo, string horaPreseleccionada)
        {
            DropDownList ddlHorario = (DropDownList)fila.FindControl("ddl_eit_Horario");
            TextBox txtFecha = (TextBox)fila.FindControl("txt_eit_Fecha");

            ddlHorario.Items.Clear();
            DateTime fecha;

            if (legajo == 0 || !DateTime.TryParse(txtFecha.Text, out fecha)) return;

            int idHorarioHM;

            List<string> horas = negTurno.getHorasDisponibles(legajo, fecha, out idHorarioHM);

            ddlHorario.DataSource = horas;
            ddlHorario.DataBind();

            ViewState["IdHorarioHM_Edit"] = idHorarioHM;

            if (!string.IsNullOrEmpty(horaPreseleccionada))
            {
                TimeSpan horaBD;
                if (TimeSpan.TryParse(horaPreseleccionada, out horaBD))
                {
                    string horaCorta = horaBD.ToString(@"hh\:mm");
                    if (ddlHorario.Items.FindByText(horaCorta) == null)
                    {
                        ddlHorario.Items.Insert(0, new ListItem(horaCorta, horaCorta));
                    }
                    ddlHorario.SelectedValue = horaCorta;
                }
            }
        }
    }
}