using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioTurno
    {
        private static readonly string[] dias = { "Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sabado" };

        /*getDiaSemana
        Devuelve el nombre del día de la semana correspondiente a la fecha recibida.*/
        public string getDiaSemana(DateTime fecha)
        {
            return dias[(int)fecha.DayOfWeek];
        }

        /*getHorasDisponibles
        Devuelve la lista de horas disponibles (ej: "09:00", "10:00") para un médico en una fecha específica.
        También devuelve el Id del horario del médico a través del parámetro de salida idHorarioHM.*/
        public List<string> getHorasDisponibles(int legajo, DateTime fecha, out int idHorarioHM)
        {
            idHorarioHM = 0;
            List<string> disponibles = new List<string>();

            DaoTurno dao = new DaoTurno();
            string dia = getDiaSemana(fecha);

            DataTable horario = dao.getHorarioMedicoxDia(legajo, dia);
            if (horario.Rows.Count == 0)
                return disponibles;

            TimeSpan inicio = (TimeSpan)horario.Rows[0]["Horario_Inicio_HM"];
            TimeSpan fin = (TimeSpan)horario.Rows[0]["Horario_Fin_HM"];
            idHorarioHM = Convert.ToInt32(horario.Rows[0]["Id_Horario_HM"]);

            DataTable ocupados = dao.getHorasOcupadas(legajo, fecha);
            List<TimeSpan> horasOcupadas = new List<TimeSpan>();
            foreach (DataRow fila in ocupados.Rows)
            {
                horasOcupadas.Add((TimeSpan)fila["Horario_Turno_T"]);
            }

            for (TimeSpan hora = inicio; hora < fin; hora = hora.Add(TimeSpan.FromHours(1)))
            {
                if (!horasOcupadas.Contains(hora))
                    disponibles.Add(hora.ToString(@"hh\:mm"));
            }

            return disponibles;
        }

        /*agregarTurno
        Agrega un nuevo turno para un paciente en un horario y fecha específicos.
        Valida que no exista un turno activo para ese horario y fecha.
        Retorna true si se agregó correctamente, false en caso contrario.*/
        public bool agregarTurno(int idPaciente, int idHorarioHM, TimeSpan hora, DateTime fecha)
        {
            int cantFilas = 0;

            DaoTurno dao = new DaoTurno();

            if (dao.existeTurnoActivo(idHorarioHM, fecha, hora) == false)
            {
                Turno t = new Turno();
                t.setId_Paciente_T(idPaciente);
                t.setId_Horario_T(idHorarioHM);
                t.setHorario_Turno_T(hora);
                t.setFecha_Turno_T(fecha);
                t.setEstado_T(true);

                cantFilas = dao.agregarTurno(t);
            }

            if (cantFilas >= 1)
                return true;
            else
                return false;
        }

        /*getTurnosActivosxLegajo
        Obtiene todos los turnos activos de un médico específico a partir de su legajo.
        Devuelve un DataTable con la información de los turnos.*/
        public DataTable getTurnosActivosxLegajo(int legajo)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTurnosActivosxLegajo(legajo);
        }

        /*getTurnosActivosPorId
        Obtiene los detalles de un turno activo específico a partir de su ID.
        Devuelve un DataTable con la información del turno.*/
        public DataTable getTurnosActivosPorId(int idTurno)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTurnosActivosPorId(idTurno);
        }

        /*darBajaTurno
        Da de baja lógica un turno a partir de su ID.
        Retorna true si se eliminó correctamente, false en caso contrario.*/
        public bool darBajaTurno(int idTurno)
        {
            int cantFilas = 0;
            DaoTurno dao = new DaoTurno();

            if (dao.getTurnosActivosPorId(idTurno).Rows.Count > 0)
                cantFilas = dao.darBajaTurno(idTurno);

            if (cantFilas >= 1)
                return true;
            else
                return false;
        }

        /*existeTurnoActivo
        Verifica si existe un turno activo para un horario, fecha y hora específicos.
        Retorna true si existe al menos un registro, false en caso contrario.*/
        public bool existeTurnoActivo(int idHorarioHM, DateTime fecha, TimeSpan hora)
        {
            DaoTurno dao = new DaoTurno();
            return dao.existeTurnoActivo(idHorarioHM, fecha, hora);
        }

        /*getTurnosInactivosxLegajo
        Obtiene todos los turnos inactivos de un médico específico a partir de su legajo.
        Devuelve un DataTable con la información de los turnos.*/
        public DataTable getTurnosInactivosxLegajo(int legajo)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTurnosInactivosxLegajo(legajo);
        }

        /*darAltaTurno
        Reactiva un turno previamente dado de baja a partir de su ID.
        Valida que no exista otro turno activo para el mismo horario y fecha,
        y que el horario del médico esté activo.
        Retorna true si se reactivó correctamente, false en caso contrario.*/
        public bool darAltaTurno(int idTurno)
        {
            int cantFilas = 0;
            DaoTurno dao = new DaoTurno();

            if (dao.existeTurnoInactivo(idTurno) == true)
            {
                DataTable turno = dao.getTurnoPorId(idTurno);

                if (turno.Rows.Count > 0)
                {
                    int idHorario = Convert.ToInt32(turno.Rows[0]["Id_Horario_T"]);
                    DateTime fecha = Convert.ToDateTime(turno.Rows[0]["Fecha_Turno_T"]);
                    TimeSpan hora = (TimeSpan)turno.Rows[0]["Horario_Turno_T"];

                    if (dao.existeTurnoActivo(idHorario, fecha, hora) == false && dao.existeHorarioActivo(idHorario) == true)
                        cantFilas = dao.darAltaTurno(idTurno);
                }
            }

            if (cantFilas >= 1)
                return true;
            else
                return false;
        }

        /*getTablaTurnosPorMedico
        Busca turnos cuyo médico coincida parcialmente con el nombre o apellido recibido.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTablaTurnosPorMedico(string busqueda)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTablaTurnosPorNombreApellidoMedico(busqueda);
        }

        /*getTurnoInactivoxId
        Obtiene los detalles de un turno inactivo específico a partir de su ID.
        Devuelve un DataTable con la información del turno.*/
        public DataTable getTurnoInactivoxId(int idTurno)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTurnoInactivoxId(idTurno);
        }

        /*getTablaTurnos
        Obtiene todos los turnos registrados con todos sus detalles.
        Devuelve un DataTable con la información de los turnos.*/
        public DataTable getTablaTurnos()
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTablaTurnos();
        }

        /*modificarTurno
        Modifica los datos de un turno existente a partir de su ID.
        Valida que el turno esté activo y que no exista conflicto de horario.
        Retorna true si se modificó correctamente, false en caso contrario.*/
        public bool modificarTurno(int idTurno, int idPaciente, int idHorarioHM, TimeSpan hora, DateTime fecha)
        {
            int cantFilas = 0;
            DaoTurno dao = new DaoTurno();

            if (dao.getTurnosActivosPorId(idTurno).Rows.Count > 0 && dao.existeTurnoActivo(idHorarioHM, fecha, hora) == false)
            {
                Turno t = new Turno();
                t.setId_Turno_T(idTurno);
                t.setId_Paciente_T(idPaciente);
                t.setId_Horario_T(idHorarioHM);
                t.setHorario_Turno_T(hora);
                t.setFecha_Turno_T(fecha);

                cantFilas = dao.modificarTurno(t);
            }

            if (cantFilas >= 1)
                return true;
            else
                return false;
        }

        /*getTurnoxId
        Obtiene los detalles completos de un turno activo específico a partir de su ID.
        Devuelve un DataTable con la información del turno.*/
        public DataTable getTurnoxId(int idTurno)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTurnoxId(idTurno);
        }

        /*getTurnosPorLegajo
        Obtiene todos los turnos activos de un médico específico para el login,
        incluyendo paciente, DNI, horario, presentismo y observación.
        Devuelve un DataTable con la información de los turnos.*/
        public DataTable getTurnosPorLegajo(int legajo)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTurnosPorLegajo(legajo);
        }

        /*marcarPresentismo
        Marca el presentismo de un turno con su observación correspondiente.
        Retorna true si se marcó correctamente, false en caso contrario.*/
        public bool marcarPresentismo(int idTurno, bool presentismo, string observacion)
        {
            int cantFilas = 0;

            DaoTurno dao = new DaoTurno();
            Turno t = new Turno();
            t.setId_Turno_T(idTurno);
            t.setPresentismo_T(presentismo);

            if (presentismo == false)
                t.setObservacion_T(null);
            else
                t.setObservacion_T(observacion);

            cantFilas = dao.marcarPresentismo(t);

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        /*getTurnosPorNombreApellido
        Busca turnos activos de un médico específico cuyo paciente coincida
        parcialmente con el nombre o apellido recibido.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTurnosPorNombreApellido(int legajo, string nombreApellido)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTurnosPorNombreApellido(legajo, nombreApellido);
        }

        /*getTurnosPorFecha
        Obtiene los turnos activos de un médico específico para una fecha determinada.
        Devuelve un DataTable con la información de los turnos.*/
        public DataTable getTurnosPorFecha(int legajo, DateTime fecha)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTurnosPorFecha(legajo, fecha);
        }

        /*getTurnosPorNombreApellidoYFecha
        Busca turnos activos de un médico específico filtrando por nombre/apellido
        del paciente y por fecha simultáneamente.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTurnosPorNombreApellidoYFecha(int legajo, string nombreApellido, DateTime fecha)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTurnosPorNombreApellidoYFecha(legajo, nombreApellido, fecha);
        }

        /*getTurnosPorNombreYPresentismo
        Busca turnos filtrando por nombre/apellido del médico y por estado de presentismo.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTurnosPorNombreYPresentismo(string busqueda, int presentismo)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTurnosPorNombreYPresentismo(busqueda, presentismo);
        }

        /*getTurnosPorPresentismo
        Obtiene todos los turnos filtrados por estado de presentismo.
        Devuelve un DataTable con la información de los turnos.*/
        public DataTable getTurnosPorPresentismo(int presentismo)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getTurnosPorPresentismo(presentismo);
        }

        /*getInformeEspecialidadPorDemanda
        Genera un informe con la cantidad de turnos por especialidad
        para todos los turnos activos, ordenado de mayor a menor demanda.
        Devuelve un DataTable con el informe.*/
        public DataTable getInformeEspecialidadPorDemanda()
        {
            DaoTurno dao = new DaoTurno();
            return dao.getInformeEspecialidadPorDemanda();
        }

        /*getInformeEspecialidadPorDemanda
        Genera un informe con la cantidad de turnos por especialidad
        para un rango de fechas específico, ordenado de mayor a menor demanda.
        Devuelve un DataTable con el informe.*/
        public DataTable getInformeEspecialidadPorDemanda(DateTime fechaDesde, DateTime fechaHasta)
        {
            DaoTurno dao = new DaoTurno();
            return dao.getInformeEspecialidadPorDemanda(fechaDesde, fechaHasta);
        }
    }
}