using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DaoTurno
    {
        AccesoDatos ds = new AccesoDatos();

        /*agregarTurno
        Agrega un nuevo turno ejecutando el procedimiento almacenado spAgregarTurno
        con los parámetros del objeto Turno recibido.*/
        public int agregarTurno(Turno t)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@Id_Paciente_T", t.getId_Paciente_T());
            comando.Parameters.AddWithValue("@Id_Horario_T", t.getId_Horario_T());
            comando.Parameters.AddWithValue("@Horario_Turno_T", t.getHorario_Turno_T());
            comando.Parameters.AddWithValue("@Fecha_Turno_T", t.getFecha_Turno_T());
            comando.Parameters.AddWithValue("@Estado_T", t.getEstado_T());

            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarTurno");
        }

        /*getHorarioMedicoxDia
        Obtiene los horarios activos de un médico para un día específico.
        Devuelve un DataTable con los horarios disponibles.*/
        public DataTable getHorarioMedicoxDia(int legajo, string dia)
        {
            string sql = "SELECT Id_Horario_HM, Horario_Inicio_HM, Horario_Fin_HM " +
                         "FROM Horarios_Medicos WHERE Legajo_HM = " + legajo +
                         " AND Dia_HM = '" + dia + "'" +
                         " AND Estado_HM = 1";

            return ds.ObtenerTabla("Horarios_Medicos", sql);
        }

        /*getHorasOcupadas
        Obtiene las horas que ya están ocupadas para un médico en una fecha específica.
        Devuelve un DataTable con los horarios ocupados.*/
        public DataTable getHorasOcupadas(int legajo, DateTime fecha)
        {
            string sql = "SELECT T.Horario_Turno_T FROM Turnos T " +
                         "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                         "WHERE HM.Legajo_HM = " + legajo +
                         " AND T.Fecha_Turno_T = '" + fecha.ToString("yyyy-MM-dd") + "'" +
                         " AND T.Estado_T = 1";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getTurnosActivosxLegajo
        Obtiene todos los turnos activos de un médico específico, incluyendo
        especialidad, nombre del médico, paciente y horario.*/
        public DataTable getTurnosActivosxLegajo(int legajo)
        {
            string sql = "SELECT " +
                         "T.Id_Turno_T AS IdTurno, " +
                         "T.Id_Paciente_T, " +
                         "M.Id_Especialidad_M, " +
                         "HM.Legajo_HM, " +
                         "T.Fecha_Turno_T, " +
                         "T.Horario_Turno_T, " +
                         "T.Horario_Turno_T AS HorarioInicio, " +
                         "E.Nombre_E AS Especialidad, " +
                         "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico, " +
                         "(P.Nombre_Pa + ' ' + P.Apellido_Pa) AS Paciente " +
                         "FROM Turnos T " +
                         "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                         "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
                         "INNER JOIN Especialidades E ON M.Id_Especialidad_M = E.Id_Especialidad_E " +
                         "INNER JOIN Pacientes P ON T.Id_Paciente_T = P.Id_Paciente_Pa " +
                         "WHERE HM.Legajo_HM = " + legajo + " AND T.Estado_T = 1";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getTurnosActivosPorId
        Obtiene los detalles de un turno activo específico por su ID,
        incluyendo especialidad, médico y paciente.*/
        public DataTable getTurnosActivosPorId(int idTurno)
        {
            string sql = "SELECT E.Nombre_E AS Especialidad, " +
                         "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico, " +
                         "(P.Nombre_Pa + ' ' + P.Apellido_Pa) AS Paciente, " +
                         "T.Horario_Turno_T AS HorarioInicio, T.Id_Turno_T " +
                         "FROM Turnos T " +
                         "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                         "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
                         "INNER JOIN Especialidades E ON M.Id_Especialidad_M = E.Id_Especialidad_E " +
                         "INNER JOIN Pacientes P ON T.Id_Paciente_T = P.Id_Paciente_Pa " +
                         "WHERE T.Id_Turno_T = " + idTurno + " AND T.Estado_T = 1";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*darBajaTurno
        Da de baja lógica un turno ejecutando el procedimiento almacenado spDarBajaTurno.
        Retorna el número de filas afectadas.*/
        public int darBajaTurno(int idTurno)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@Id_Turno_T", idTurno);

            return ds.EjecutarProcedimientoAlmacenado(comando, "spDarBajaTurno");
        }

        /*existeTurnoActivo
        Verifica si existe un turno activo para un horario, fecha y hora específicos.
        Retorna true si existe al menos un registro.*/
        public bool existeTurnoActivo(int idHorarioHM, DateTime fecha, TimeSpan hora)
        {
            string sql = "SELECT * FROM Turnos WHERE Id_Horario_T = " + idHorarioHM +
                         " AND Fecha_Turno_T = '" + fecha.ToString("yyyy-MM-dd") + "'" +
                         " AND Horario_Turno_T = '" + hora.ToString(@"hh\:mm\:ss") + "'" +
                         " AND Estado_T = 1";

            DataTable tabla = ds.ObtenerTabla("Turnos", sql);
            return tabla.Rows.Count > 0;
        }

        /*existeTurnoInactivo
        Verifica si existe un turno inactivo con el ID recibido.
        Retorna true si existe al menos un registro.*/
        public bool existeTurnoInactivo(int idTurno)
        {
            DataTable tabla = ds.ObtenerTabla("Turnos",
                "SELECT Id_Turno_T FROM Turnos WHERE Id_Turno_T = " + idTurno + " AND Estado_T = 0");
            return tabla.Rows.Count > 0;
        }

        /*existeHorarioActivo
        Verifica si existe un horario activo con el ID recibido.
        Retorna true si existe al menos un registro.*/
        public bool existeHorarioActivo(int idHorario)
        {
            DataTable tabla = ds.ObtenerTabla("Horarios_Medicos",
                "SELECT Id_Horario_HM FROM Horarios_Medicos WHERE Id_Horario_HM = " + idHorario + " AND Estado_HM = 1");
            return tabla.Rows.Count > 0;
        }

        /*getTurnosInactivosxLegajo
        Obtiene todos los turnos inactivos de un médico específico,
        incluyendo paciente, fecha, horario, especialidad y médico.*/
        public DataTable getTurnosInactivosxLegajo(int legajo)
        {
            string sql = "SELECT T.Id_Turno_T, " +
                         "P.Nombre_Pa + ' ' + P.Apellido_Pa AS Paciente, " +
                         "T.Fecha_Turno_T, T.Horario_Turno_T, " +
                         "E.Nombre_E AS Especialidad, " +
                         "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico " +
                         "FROM Turnos T " +
                         "INNER JOIN Pacientes P ON T.Id_Paciente_T = P.Id_Paciente_Pa " +
                         "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                         "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
                         "INNER JOIN Especialidades E ON M.Id_Especialidad_M = E.Id_Especialidad_E " +
                         "WHERE HM.Legajo_HM = " + legajo + " AND T.Estado_T = 0";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getTurnoInactivoxId
        Obtiene los detalles de un turno inactivo específico por su ID,
        incluyendo paciente, fecha, horario, especialidad y médico.*/
        public DataTable getTurnoInactivoxId(int idTurno)
        {
            string sql = "SELECT T.Id_Turno_T, " +
                         "P.Nombre_Pa + ' ' + P.Apellido_Pa AS Paciente, " +
                         "T.Fecha_Turno_T, T.Horario_Turno_T, " +
                         "E.Nombre_E AS Especialidad, " +
                         "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico " +
                         "FROM Turnos T " +
                         "INNER JOIN Pacientes P ON T.Id_Paciente_T = P.Id_Paciente_Pa " +
                         "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                         "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
                         "INNER JOIN Especialidades E ON M.Id_Especialidad_M = E.Id_Especialidad_E " +
                         "WHERE T.Id_Turno_T = " + idTurno + " AND T.Estado_T = 0";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getTurnoPorId
        Obtiene el horario y fecha de un turno específico por su ID.
        Devuelve un DataTable con la información del turno.*/
        public DataTable getTurnoPorId(int idTurno)
        {
            return ds.ObtenerTabla("Turnos",
                "SELECT Id_Horario_T, Fecha_Turno_T, Horario_Turno_T FROM Turnos WHERE Id_Turno_T = " + idTurno);
        }

        /*darAltaTurno
        Reactiva un turno previamente dado de baja ejecutando el procedimiento
        almacenado spDarAltaTurno. Retorna el número de filas afectadas.*/
        public int darAltaTurno(int idTurno)
        {
            SqlCommand comando = new SqlCommand();
            Turno turno = new Turno();
            turno.setId_Turno_T(idTurno);
            ArmarParametrosTurnoReactivar(ref comando, turno);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spDarAltaTurno");
        }

        /*ArmarParametrosTurnoReactivar
        Arma el parámetro necesario (Id_Turno_T) para el procedimiento
        almacenado que reactiva un turno.*/
        private void ArmarParametrosTurnoReactivar(ref SqlCommand comando, Turno turno)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Turno_T", SqlDbType.Int);
            param.Value = turno.getId_Turno_T();
        }

        /*getTablaTurnosPorNombreApellidoMedico
        Busca turnos cuyo médico coincida parcialmente con el nombre o apellido recibido.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTablaTurnosPorNombreApellidoMedico(string busqueda)
        {
            AccesoDatos datos = new AccesoDatos();

            string sql = "SELECT " +
             "T.Id_Turno_T AS IdTurno, " +
             "(P.Nombre_Pa + ' ' + P.Apellido_Pa) AS Paciente, " +
             "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico, " +
             "E.Nombre_E AS Especialidad, " +
             "CONVERT(VARCHAR(5), T.Horario_Turno_T, 108) AS HorarioInicio, " +
             "CONVERT(VARCHAR(5), DATEADD(HOUR, 1, CAST(T.Horario_Turno_T AS DATETIME)), 108) AS HorarioFin, " +
             "T.Fecha_Turno_T AS FechaTurno, " +
             "CASE WHEN T.Estado_T = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado " +
             "FROM Turnos T " +
             "INNER JOIN Pacientes P ON T.Id_Paciente_T = P.Id_Paciente_Pa " +
             "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
             "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
             "INNER JOIN Especialidades E ON M.Id_Especialidad_M = E.Id_Especialidad_E " +
             "WHERE (M.Nombre_M + ' ' + M.Apellido_M) LIKE '%" + busqueda + "%' " +
             "ORDER BY T.Fecha_Turno_T DESC, T.Horario_Turno_T";

            return datos.ObtenerTabla("Turnos", sql);
        }

        /*getTablaTurnos
        Obtiene todos los turnos registrados con todos sus detalles
        incluyendo médico, especialidad, paciente, horario y estado.*/
        public DataTable getTablaTurnos()
        {
            string sql = "SELECT " +
                 "T.Id_Turno_T AS IdTurno, " +
                 "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico, " +
                 "E.Nombre_E AS Especialidad, " +
                 "(P.Nombre_Pa + ' ' + P.Apellido_Pa) AS Paciente, " +
                 "CONVERT(VARCHAR(5), T.Horario_Turno_T, 108) AS HorarioInicio, " +
                 "CONVERT(VARCHAR(5), DATEADD(HOUR, 1, CAST(T.Horario_Turno_T AS DATETIME)), 108) AS HorarioFin, " +
                 "T.Fecha_Turno_T AS FechaTurno, " +
                 "CASE WHEN T.Estado_T = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado " +
                 "FROM Turnos T " +
                 "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                 "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
                 "INNER JOIN Especialidades E ON M.Id_Especialidad_M = E.Id_Especialidad_E " +
                 "INNER JOIN Pacientes P ON T.Id_Paciente_T = P.Id_Paciente_Pa";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*modificarTurno
        Modifica los datos de un turno existente ejecutando el procedimiento
        almacenado spModificarTurno. Retorna el número de filas afectadas.*/
        public int modificarTurno(Turno tur)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@Id_Turno_T", tur.getId_Turno_T());
            comando.Parameters.AddWithValue("@Id_Paciente_T", tur.getId_Paciente_T());
            comando.Parameters.AddWithValue("@Id_Horario_T", tur.getId_Horario_T());
            comando.Parameters.AddWithValue("@Horario_Turno_T", tur.getHorario_Turno_T());
            comando.Parameters.AddWithValue("@Fecha_Turno_T", tur.getFecha_Turno_T());

            return ds.EjecutarProcedimientoAlmacenado(comando, "spModificarTurno");
        }

        /*getTurnoxId
        Obtiene los detalles completos de un turno activo específico por su ID,
        incluyendo paciente, médico y especialidad.*/
        public DataTable getTurnoxId(int idTurno)
        {
            string sql = "SELECT T.Id_Turno_T AS IdTurno, " +
                         "T.Id_Paciente_T, " +
                         "M.Id_Especialidad_M, " +
                         "HM.Legajo_HM, " +
                         "T.Horario_Turno_T, " +
                         "T.Horario_Turno_T AS HorarioInicio, " +
                         "T.Fecha_Turno_T, " +
                         "(P.Nombre_Pa + ' ' + P.Apellido_Pa) AS Paciente, " +
                         "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico, " +
                         "E.Nombre_E AS Especialidad " +
                         "FROM Turnos T " +
                         "INNER JOIN Pacientes P ON T.Id_Paciente_T = P.Id_Paciente_Pa " +
                         "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                         "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
                         "INNER JOIN Especialidades E ON M.Id_Especialidad_M = E.Id_Especialidad_E " +
                         "WHERE T.Id_Turno_T = " + idTurno + " AND T.Estado_T = 1";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getTurnosPorLegajo
        Obtiene todos los turnos activos de un médico específico para el login,
        incluyendo paciente, DNI, horario, presentismo y observación.*/
        public DataTable getTurnosPorLegajo(int legajo)
        {
            string sql = "SELECT T.Id_Turno_T AS IdTurno, " +
                         "T.Fecha_Turno_T AS Fecha, " +
                         "T.Horario_Turno_T AS HoraInicio, " +
                         "DATEADD(hour, 1, T.Horario_Turno_T) AS HoraFin, " +
                         "Pa.Dni_Pa AS DNI, " +
                         "Pa.Nombre_Pa + ' ' + Pa.Apellido_Pa AS Paciente, " +
                         "T.Presentismo_T AS Presentismo, " +
                         "T.Observacion_T AS Observacion " +
                         "FROM Turnos T " +
                         "INNER JOIN Pacientes Pa ON Pa.Id_Paciente_Pa = T.Id_Paciente_T " +
                         "INNER JOIN Horarios_Medicos HM ON HM.Id_Horario_HM = T.Id_Horario_T " +
                         "WHERE HM.Legajo_HM = " + legajo + " AND T.Estado_T = 1";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*marcarPresentismo
        Marca el presentismo de un turno ejecutando el procedimiento
        almacenado spMarcarPresentismo. Retorna el número de filas afectadas.*/
        public int marcarPresentismo(Turno t)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurnoMarcarPresentismo(ref comando, t);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spMarcarPresentismo");
        }

        /*ArmarParametrosTurnoMarcarPresentismo
        Arma los parámetros necesarios (Id_Turno_T, Presentismo_T y Observacion_T)
        para el procedimiento almacenado que marca el presentismo de un turno.*/
        private void ArmarParametrosTurnoMarcarPresentismo(ref SqlCommand comando, Turno t)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Turno_T", SqlDbType.Int);
            param.Value = t.getId_Turno_T();
            param = comando.Parameters.Add("@Presentismo_T", SqlDbType.Bit);
            param.Value = t.getPresentismo_T();
            param = comando.Parameters.Add("@Observacion_T", SqlDbType.Text);
            param.Value = string.IsNullOrEmpty(t.getObservacion_T()) ? (object)DBNull.Value : t.getObservacion_T();
        }

        /*getTurnosPorNombreApellido
        Busca turnos activos de un médico específico cuyo paciente coincida
        parcialmente con el nombre o apellido recibido.*/
        public DataTable getTurnosPorNombreApellido(int legajo, string nombreApellido)
        {
            string sql = "SELECT T.Id_Turno_T AS IdTurno, " +
                         "T.Fecha_Turno_T AS Fecha, " +
                         "T.Horario_Turno_T AS HoraInicio, " +
                         "DATEADD(hour, 1, T.Horario_Turno_T) AS HoraFin, " +
                         "Pa.Dni_Pa AS DNI, " +
                         "Pa.Nombre_Pa + ' ' + Pa.Apellido_Pa AS Paciente, " +
                         "T.Presentismo_T AS Presentismo, " +
                         "T.Observacion_T AS Observacion " +
                         "FROM Turnos T " +
                         "INNER JOIN Pacientes Pa ON Pa.Id_Paciente_Pa = T.Id_Paciente_T " +
                         "INNER JOIN Horarios_Medicos HM ON HM.Id_Horario_HM = T.Id_Horario_T " +
                         "WHERE HM.Legajo_HM = " + legajo +
                         " AND T.Estado_T = 1" +
                         " AND (Pa.Nombre_Pa + ' ' + Pa.Apellido_Pa) LIKE '%" + nombreApellido + "%'";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getTurnosPorFecha
        Obtiene los turnos activos de un médico específico para una fecha determinada.*/
        public DataTable getTurnosPorFecha(int legajo, DateTime fecha)
        {
            string sql = "SELECT T.Id_Turno_T AS IdTurno, " +
                         "T.Fecha_Turno_T AS Fecha, " +
                         "T.Horario_Turno_T AS HoraInicio, " +
                         "DATEADD(hour, 1, T.Horario_Turno_T) AS HoraFin, " +
                         "Pa.Dni_Pa AS DNI, " +
                         "Pa.Nombre_Pa + ' ' + Pa.Apellido_Pa AS Paciente, " +
                         "T.Presentismo_T AS Presentismo, " +
                         "T.Observacion_T AS Observacion " +
                         "FROM Turnos T " +
                         "INNER JOIN Pacientes Pa ON Pa.Id_Paciente_Pa = T.Id_Paciente_T " +
                         "INNER JOIN Horarios_Medicos HM ON HM.Id_Horario_HM = T.Id_Horario_T " +
                         "WHERE HM.Legajo_HM = " + legajo +
                         " AND T.Estado_T = 1" +
                         " AND T.Fecha_Turno_T = '" + fecha.ToString("yyyy-MM-dd") + "'";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getTurnosPorNombreApellidoYFecha
        Busca turnos activos de un médico específico filtrando por nombre/apellido
        del paciente y por fecha simultáneamente.*/
        public DataTable getTurnosPorNombreApellidoYFecha(int legajo, string nombreApellido, DateTime fecha)
        {
            string sql = "SELECT T.Id_Turno_T AS IdTurno, " +
                         "T.Fecha_Turno_T AS Fecha, " +
                         "T.Horario_Turno_T AS HoraInicio, " +
                         "DATEADD(hour, 1, T.Horario_Turno_T) AS HoraFin, " +
                         "Pa.Dni_Pa AS DNI, " +
                         "Pa.Nombre_Pa + ' ' + Pa.Apellido_Pa AS Paciente, " +
                         "T.Presentismo_T AS Presentismo, " +
                         "T.Observacion_T AS Observacion " +
                         "FROM Turnos T " +
                         "INNER JOIN Pacientes Pa ON Pa.Id_Paciente_Pa = T.Id_Paciente_T " +
                         "INNER JOIN Horarios_Medicos HM ON HM.Id_Horario_HM = T.Id_Horario_T " +
                         "WHERE HM.Legajo_HM = " + legajo +
                         " AND T.Estado_T = 1" +
                         " AND (Pa.Nombre_Pa + ' ' + Pa.Apellido_Pa) LIKE '%" + nombreApellido + "%'" +
                         " AND T.Fecha_Turno_T = '" + fecha.ToString("yyyy-MM-dd") + "'";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getTurnosPorNombreYPresentismo
        Busca turnos filtrando por nombre/apellido del médico y por estado de presentismo.*/
        public DataTable getTurnosPorNombreYPresentismo(string busqueda, int presentismo)
        {
            string sql = "SELECT " +
                         "T.Id_Turno_T AS IdTurno, " +
                         "(P.Nombre_Pa + ' ' + P.Apellido_Pa) AS Paciente, " +
                         "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico, " +
                         "E.Nombre_E AS Especialidad, " +
                         "CONVERT(VARCHAR(5), T.Horario_Turno_T, 108) AS HorarioInicio, " +
                         "CONVERT(VARCHAR(5), DATEADD(HOUR, 1, CAST(T.Horario_Turno_T AS DATETIME)), 108) AS HorarioFin, " +
                         "T.Fecha_Turno_T AS FechaTurno, " +
                         "CASE WHEN T.Estado_T = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado " +
                         "FROM Turnos T " +
                         "INNER JOIN Pacientes P ON T.Id_Paciente_T = P.Id_Paciente_Pa " +
                         "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                         "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
                         "INNER JOIN Especialidades E ON M.Id_Especialidad_M = E.Id_Especialidad_E " +
                         "WHERE (M.Nombre_M + ' ' + M.Apellido_M) LIKE '%" + busqueda + "%' " +
                         "AND T.Presentismo_T = " + presentismo +
                         " ORDER BY T.Fecha_Turno_T DESC, T.Horario_Turno_T";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getTurnosPorPresentismo
        Obtiene todos los turnos filtrados por estado de presentismo.*/
        public DataTable getTurnosPorPresentismo(int presentismo)
        {
            string sql = "SELECT " +
                         "T.Id_Turno_T AS IdTurno, " +
                         "(P.Nombre_Pa + ' ' + P.Apellido_Pa) AS Paciente, " +
                         "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico, " +
                         "E.Nombre_E AS Especialidad, " +
                         "CONVERT(VARCHAR(5), T.Horario_Turno_T, 108) AS HorarioInicio, " +
                         "CONVERT(VARCHAR(5), DATEADD(HOUR, 1, CAST(T.Horario_Turno_T AS DATETIME)), 108) AS HorarioFin, " +
                         "T.Fecha_Turno_T AS FechaTurno, " +
                         "CASE WHEN T.Estado_T = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado " +
                         "FROM Turnos T " +
                         "INNER JOIN Pacientes P ON T.Id_Paciente_T = P.Id_Paciente_Pa " +
                         "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                         "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
                         "INNER JOIN Especialidades E ON M.Id_Especialidad_M = E.Id_Especialidad_E " +
                         "WHERE T.Presentismo_T = " + presentismo;

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getInformeEspecialidadPorDemanda
        Genera un informe con la cantidad de turnos por especialidad
        para todos los turnos activos, ordenado de mayor a menor demanda.*/
        public DataTable getInformeEspecialidadPorDemanda()
        {
            string sql = "SELECT E.Nombre_E AS Especialidad, COUNT(T.Id_Turno_T) AS CantidadTurnos " +
                         "FROM Turnos T " +
                         "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                         "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
                         "INNER JOIN Especialidades E ON M.Id_Especialidad_M = E.Id_Especialidad_E " +
                         "WHERE T.Estado_T = 1 " +
                         "GROUP BY E.Nombre_E " +
                         "ORDER BY CantidadTurnos DESC";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getInformeEspecialidadPorDemanda
        Genera un informe con la cantidad de turnos por especialidad
        para un rango de fechas específico, ordenado de mayor a menor demanda.*/
        public DataTable getInformeEspecialidadPorDemanda(DateTime fechaDesde, DateTime fechaHasta)
        {
            string sql = "SELECT E.Nombre_E AS Especialidad, COUNT(T.Id_Turno_T) AS CantidadTurnos " +
                         "FROM Turnos T " +
                         "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                         "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
                         "INNER JOIN Especialidades E ON M.Id_Especialidad_M = E.Id_Especialidad_E " +
                         "WHERE T.Estado_T = 1 " +
                         "AND T.Fecha_Turno_T >= '" + fechaDesde.ToString("yyyy-MM-dd") + "' " +
                         "AND T.Fecha_Turno_T <= '" + fechaHasta.ToString("yyyy-MM-dd") + "' " +
                         "GROUP BY E.Nombre_E " +
                         "ORDER BY CantidadTurnos DESC";

            return ds.ObtenerTabla("Turnos", sql);
        }
    }
}