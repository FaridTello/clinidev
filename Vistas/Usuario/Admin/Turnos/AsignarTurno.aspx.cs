using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas.Usuario.Admin.Turnos
{
    public partial class AsignarTurno : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión,
        muestra su nombre y en la primera carga carga las especialidades y pacientes,
        deshabilitando los combos de médico y horario hasta que se seleccione una especialidad.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();
            if (!IsPostBack)
            {
                cargarEspecialidades();
                cargarPacientes();
                ddlMedico.Enabled = false;
                ddlHorario.Enabled = false;
            }
        }

        /*btnGuardar_Click
        Se ejecuta al hacer clic en el botón Guardar. Valida que todos los campos
        estén completos y correctos, luego asigna el turno al paciente seleccionado
        en el horario y fecha elegidos. Muestra el resultado de la operación.*/
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idPaciente = Convert.ToInt32(ddlPaciente.SelectedValue);
            int idHorarioHM = ViewState["IdHorarioHM"] != null ? Convert.ToInt32(ViewState["IdHorarioHM"]) : 0;
            DateTime fecha;
            TimeSpan hora;

            if (idPaciente == 0 || idHorarioHM == 0 ||
                !DateTime.TryParse(txtFecha.Text, out fecha) ||
                ddlHorario.SelectedValue == "0" ||
                !TimeSpan.TryParse(ddlHorario.SelectedValue, out hora))
            {
                lblMensaje.Text = "Complete todos los campos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            NegocioTurno neg = new NegocioTurno();

            bool resultado = neg.agregarTurno(idPaciente, idHorarioHM, hora, fecha);

            if (resultado)
            {
                cargarHorariosDisponibles();
                lblMensaje.Text = "Turno asignado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                cargarHorariosDisponibles();
                lblMensaje.Text = "No se pudo asignar el turno.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        /*ddlEspecialidad_SelectedIndexChanged
        Se ejecuta al cambiar la selección en el combo de especialidades.
        Carga los médicos activos de la especialidad seleccionada en el combo de médicos.*/
        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMedico.Items.Clear();
            ddlHorario.Items.Clear();
            ddlHorario.Enabled = false;

            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
            if (idEspecialidad == 0)
            {
                ddlMedico.Enabled = false;
                return;
            }

            NegocioMedico neg = new NegocioMedico();
            ddlMedico.DataSource = neg.getTablaxEspecialidad(idEspecialidad);
            ddlMedico.DataTextField = "NombreCompleto";
            ddlMedico.DataValueField = "Legajo_M";
            ddlMedico.DataBind();
            ddlMedico.Items.Insert(0, new ListItem("-- Seleccionar --", "0"));
            ddlMedico.Enabled = true;
        }

        /*cargarHorariosDisponibles
        Carga los horarios disponibles para el médico seleccionado en la fecha indicada.
        Valida que la fecha no sea anterior a hoy y que el médico atienda ese día.
        Guarda el Id del horario del médico en ViewState para usarlo al asignar el turno.*/
        private void cargarHorariosDisponibles()
        {
            ddlHorario.Items.Clear();
            ddlHorario.Enabled = false;

            int legajo = Convert.ToInt32(ddlMedico.SelectedValue);
            DateTime fecha;
            bool fechaValida = DateTime.TryParse(txtFecha.Text, out fecha);

            if (legajo == 0 || !fechaValida)
                return;

            if (fecha.Date < DateTime.Today)
            {
                lblMensaje.Text = "La fecha no puede ser anterior a hoy.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            NegocioTurno neg = new NegocioTurno();
            int idHorarioHM;
            List<string> horas = neg.getHorasDisponibles(legajo, fecha, out idHorarioHM);

            if (horas.Count == 0)
            {
                lblMensaje.Text = "El médico no atiende ese día o no quedan horarios libres.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            ddlHorario.DataSource = horas;
            ddlHorario.DataBind();
            ddlHorario.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            ddlHorario.Enabled = true;
            lblMensaje.Text = "";

            ViewState["IdHorarioHM"] = idHorarioHM;
        }

        /*ddlMedico_SelectedIndexChanged
        Se ejecuta al cambiar la selección en el combo de médicos.
        Carga los horarios disponibles para el médico seleccionado.*/
        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarHorariosDisponibles();
        }

        /*txtFecha_TextChanged
        Se ejecuta al cambiar el texto en el campo de fecha.
        Carga los horarios disponibles para la fecha ingresada.*/
        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            cargarHorariosDisponibles();
        }

        /*cargarEspecialidades
        Carga el combo de especialidades con todas las especialidades registradas en la base de datos.*/
        private void cargarEspecialidades()
        {
            NegocioEspecialidad neg = new NegocioEspecialidad();
            ddlEspecialidad.DataSource = neg.getTabla();
            ddlEspecialidad.DataTextField = "Nombre_E";
            ddlEspecialidad.DataValueField = "Id_Especialidad_E";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        /*cargarPacientes
        Carga el combo de pacientes con todos los pacientes activos registrados en la base de datos.*/
        private void cargarPacientes()
        {
            NegocioPaciente neg = new NegocioPaciente();
            ddlPaciente.DataSource = neg.getTablaActivos();
            ddlPaciente.DataTextField = "NombreCompleto";
            ddlPaciente.DataValueField = "Id_Paciente_Pa";
            ddlPaciente.DataBind();
            ddlPaciente.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }
    }
}