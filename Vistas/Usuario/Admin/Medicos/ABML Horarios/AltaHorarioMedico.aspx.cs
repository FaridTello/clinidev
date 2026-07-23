using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Vistas.Usuario.Admin.Medicos.Horarios
{
    public partial class AltaHorarioMedico : System.Web.UI.Page
    {
        /*Page_Load
        Se ejecuta al cargar la página. Obtiene el usuario logueado desde la sesión,
        muestra su nombre, carga las especialidades en el combo y deshabilita el combo
        de médicos hasta que se seleccione una especialidad.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Entidades.Usuario usu = (Entidades.Usuario)Session["UsuarioLogueado"];
            lblUsuario.Text = usu.getNombre_U();

            if (!IsPostBack)
            {
                cargarEspecialidades();
                ddlMedico.Enabled = false;
            }
        }

        /*cargarEspecialidades
        Carga el combo de especialidades con todas las especialidades registradas
        en la base de datos.*/
        private void cargarEspecialidades()
        {
            NegocioEspecialidad neg = new NegocioEspecialidad();
            DataTable tabla = neg.getTabla();

            ddlEspecialidad.DataSource = tabla;
            ddlEspecialidad.DataTextField = "Nombre_E";
            ddlEspecialidad.DataValueField = "Id_Especialidad_E";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
        }

        /*gvAsignados_SelectedIndexChanged
        Se ejecuta al cambiar la selección en el GridView de horarios asignados.
        Verifica que haya una especialidad seleccionada y habilita o deshabilita
        el combo de médicos según corresponda.*/
        protected void gvAsignados_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);

            if (idEspecialidad == 0)
            {
                ddlMedico.Items.Clear();
                ddlMedico.Enabled = false;
                return;
            }
        }

        /*cargarGrid
        Carga el GridView con los horarios asignados al médico cuyo legajo se recibe.*/
        private void cargarGrid(int legajo)
        {
            NegocioHorarioMedico neg = new NegocioHorarioMedico();
            gvAsignados.DataSource = neg.getTablaxLegajo(legajo);
            gvAsignados.DataBind();
        }

        /*btnGuardar_Click
        Se ejecuta al hacer clic en el botón Guardar. Valida que se haya seleccionado
        al menos un día, que los horarios sean válidos y que estén en punto.
        Luego asigna los horarios al médico seleccionado y muestra el resultado.*/
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int legajo = Convert.ToInt32(ddlMedico.SelectedValue);
            List<string> dias = new List<string>();

            foreach (ListItem item in cblDias.Items)
            {
                if (item.Selected)
                    dias.Add(item.Value);
            }

            if (dias.Count == 0)
            {
                lblMensaje.Text = "Debe seleccionar al menos un día.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }


            TimeSpan inicio, fin;
            bool okInicio = TimeSpan.TryParse(txtHorarioInicio.Text, out inicio);
            bool okFin = TimeSpan.TryParse(txtHorarioFin.Text, out fin);

            if (!okInicio || !okFin)
            {
                lblMensaje.Text = "Ingrese horarios válidos.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (inicio.Minutes != 0 || fin.Minutes != 0)
            {
                lblMensaje.Text = "Los horarios deben ser en punto (ej: 10:00).";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            NegocioHorarioMedico neg = new NegocioHorarioMedico();
            bool resultado = neg.agregarHorarios(legajo, dias, inicio, fin);

            if (resultado)
            {
                lblMensaje.Text = "Horario asignado correctamente.";
                lblMensaje.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblMensaje.Text = "Algún día ya tiene un horario que se superpone; revise el grid.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            cargarGrid(legajo);
        }

        /*ddlEspecialidad_SelectedIndexChanged
        Se ejecuta al cambiar la selección en el combo de especialidades.
        Carga los médicos activos de la especialidad seleccionada en el combo de médicos.*/
        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMedico.Items.Clear();

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

        /*ddlMedico_SelectedIndexChanged
        Se ejecuta al cambiar la selección en el combo de médicos.
        Carga el GridView con los horarios asignados al médico seleccionado.*/
        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            int legajo = Convert.ToInt32(ddlMedico.SelectedValue);

            if (legajo == 0)
            {
                return;
            }

            cargarGrid(legajo);
        }

    }
}