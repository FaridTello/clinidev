using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Datos
{
    public class DaoHorarioMedico
    {
        AccesoDatos ds = new AccesoDatos();

        /*agregarHorario
        Arma los parámetros a partir de un objeto HorarioMedico y ejecuta el
        procedimiento almacenado que da de alta un nuevo horario para un médico.*/
        public int agregarHorario(HorarioMedico hor)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@Legajo_HM", hor.getLegajo_HM());
            comando.Parameters.AddWithValue("@Dia_HM", hor.getDia_HM());
            comando.Parameters.AddWithValue("@Horario_Inicio_HM", hor.getHorario_Inicio_HM());
            comando.Parameters.AddWithValue("@Horario_Fin_HM", hor.getHorario_Fin_HM());

            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarHorario");
        }

        /*getTablaHorariosMedicos
        Obtiene todos los horarios médicos junto con el nombre y apellido del médico
        asociado, mostrando el estado (Activo / No Activo) en formato legible.*/
        public DataTable getTablaHorariosMedicos()
        {
            return ds.ObtenerTabla("Horarios_Medicos",
                "SELECT HM.Id_Horario_HM AS IdHorario, HM.Legajo_HM AS Legajo, " +
                "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico, HM.Dia_HM AS Dia, " +
                "HM.Horario_Inicio_HM AS HorarioInicio, HM.Horario_Fin_HM AS HorarioFin, " +
                "CASE WHEN HM.Estado_HM = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado " +
                "FROM Horarios_Medicos HM " +
                "INNER JOIN Medicos M ON M.Legajo_M = HM.Legajo_HM");
        }

        /*ExisteDiaOcupado
        Verifica si el médico ya tiene un horario activo cargado en el mismo día,
        excluyendo el propio registro que se esté editando (Id_Horario_HM distinto).
        Devuelve true si encuentra un cruce de horario.*/
        public bool ExisteDiaOcupado(HorarioMedico hor)
        {
            string sql = "SELECT * FROM Horarios_Medicos WHERE Legajo_HM = " + hor.getLegajo_HM() +
                         " AND Dia_HM = '" + hor.getDia_HM() + "'" +
                         " AND Id_Horario_HM <> " + hor.getId_Horario_HM() +
                         " AND Estado_HM = 1";
            DataTable tabla = ds.ObtenerTabla("Horarios_Medicos", sql);
            return tabla.Rows.Count > 0;
        }

        /*getTablaHorariosxLegajo
        Obtiene todos los horarios (activos e inactivos) asociados a un legajo
        de médico en particular, mostrando el estado en formato legible.*/
        public DataTable getTablaHorariosxLegajo(HorarioMedico hor)
        {
            string sql = "SELECT Id_Horario_HM, Dia_HM, Horario_Inicio_HM, Horario_Fin_HM, " +
             "CASE WHEN Estado_HM = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado_HM " +
             "FROM Horarios_Medicos WHERE Legajo_HM = " + hor.getLegajo_HM();

            return ds.ObtenerTabla("Horarios_Medicos", sql);
        }

        /*eliminarHorarioMedico
        Da de baja (lógica) un horario médico existente, ejecutando el
        procedimiento almacenado correspondiente.*/
        public int eliminarHorarioMedico(HorarioMedico hm)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosHorarioMedicoEliminar(ref comando, hm);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spBajaHorarioMedico");
        }

        /*ArmarParametrosHorarioMedicoEliminar
        Arma el parámetro necesario (Id_Horario_HM) para el procedimiento
        almacenado que da de baja un horario médico.*/
        private void ArmarParametrosHorarioMedicoEliminar(ref SqlCommand comando, HorarioMedico hm)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Horario_HM", SqlDbType.Int);
            param.Value = hm.getId_Horario_HM();
        }

        /*ExisteHorarioxId
        Verifica si existe un horario médico con el Id recibido.
        Devuelve true si se encuentra al menos un registro.*/
        public bool ExisteHorarioxId(HorarioMedico hm)
        {
            DataTable dt = ds.ObtenerTabla("Horarios_Medicos",
                "SELECT Id_Horario_HM FROM Horarios_Medicos WHERE Id_Horario_HM = " + hm.getId_Horario_HM());
            return dt.Rows.Count > 0;
        }

        /*getTablaHorariosPorLegajo
        Obtiene los horarios activos correspondientes a un legajo de médico
        en particular.*/
        public DataTable getTablaHorariosPorLegajo(int legajo)
        {
            return ds.ObtenerTabla("Horarios_Medicos",
                "SELECT Id_Horario_HM AS IdHorario, Legajo_HM AS Legajo, Dia_HM AS Dia, " +
                "Horario_Inicio_HM AS HorarioInicio, Horario_Fin_HM AS HorarioFin " +
                "FROM Horarios_Medicos WHERE Legajo_HM = " + legajo + " AND Estado_HM = 1");
        }

        /*getTablaHorariosPorNombreApellido
        Obtiene los horarios activos de los médicos cuyo nombre y apellido
        coincidan (parcialmente) con el texto recibido como parámetro.*/
        public DataTable getTablaHorariosPorNombreApellido(string nombreApellido)
        {
            string sql = "SELECT HM.Id_Horario_HM AS IdHorario, HM.Legajo_HM AS Legajo, " +
                         "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico, HM.Dia_HM AS Dia, " +
                         "HM.Horario_Inicio_HM AS HorarioInicio, HM.Horario_Fin_HM AS HorarioFin, " +
                         "CASE WHEN HM.Estado_HM = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado " +
                         "FROM Horarios_Medicos HM " +
                         "INNER JOIN Medicos M ON M.Legajo_M = HM.Legajo_HM " +
                         "WHERE HM.Estado_HM = 1 " +
                         "AND (M.Nombre_M + ' ' + M.Apellido_M) LIKE '%" + nombreApellido + "%'";

            return ds.ObtenerTabla("Horarios_Medicos", sql);
        }

        /*modificarHorarioMedico
        Arma los parámetros a partir de un objeto HorarioMedico y ejecuta el
        procedimiento almacenado que actualiza un horario médico existente.*/
        public int modificarHorarioMedico(HorarioMedico hm)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosHorarioMedicoModificar(ref comando, hm);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spModificarHorarioMedico");
        }

        /*ArmarParametrosHorarioMedicoModificar
        Arma todos los parámetros necesarios (Id, Legajo, Día, Horario de inicio
        y de fin) para el procedimiento almacenado que modifica un horario médico.*/
        private void ArmarParametrosHorarioMedicoModificar(ref SqlCommand comando, HorarioMedico hm)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Horario_HM", SqlDbType.Int);
            param.Value = hm.getId_Horario_HM();
            param = comando.Parameters.Add("@Legajo_HM", SqlDbType.Int);
            param.Value = hm.getLegajo_HM();
            param = comando.Parameters.Add("@Dia_HM", SqlDbType.VarChar);
            param.Value = hm.getDia_HM();
            param = comando.Parameters.Add("@Horario_Inicio_HM", SqlDbType.Time);
            param.Value = hm.getHorario_Inicio_HM();
            param = comando.Parameters.Add("@Horario_Fin_HM", SqlDbType.Time);
            param.Value = hm.getHorario_Fin_HM();
        }

        /*getTablaHorariosInactivosPorLegajo
        Obtiene los horarios inactivos (dados de baja) correspondientes
        a un legajo de médico en particular.*/
        public DataTable getTablaHorariosInactivosPorLegajo(int legajo)
        {
            return ds.ObtenerTabla("Horarios_Medicos",
                "SELECT Id_Horario_HM AS IdHorario, Legajo_HM AS Legajo, Dia_HM AS Dia, " +
                "Horario_Inicio_HM AS HorarioInicio, Horario_Fin_HM AS HorarioFin " +
                "FROM Horarios_Medicos WHERE Legajo_HM = " + legajo + " AND Estado_HM = 0");
        }

        /*getTablaHorarioActivoPorId
        Obtiene el detalle (día, horario y médico) de un horario activo
        puntual, buscado por su Id.*/
        public DataTable getTablaHorarioActivoPorId(int idHorario)
        {
            string sql = "SELECT HM.Dia_HM AS Dia, HM.Horario_Inicio_HM AS Inicio, " +
                         "HM.Horario_Fin_HM AS Fin, (M.Nombre_M + ' ' + M.Apellido_M) AS Medico " +
                         "FROM Horarios_Medicos HM " +
                         "INNER JOIN Medicos M ON M.Legajo_M = HM.Legajo_HM " +
                         "WHERE HM.Id_Horario_HM = " + idHorario + " AND HM.Estado_HM = 1";

            return ds.ObtenerTabla("Horarios_Medicos", sql);
        }

        /*getTablaHorarioInactivoPorId
        Obtiene el detalle (día, horario y médico) de un horario inactivo
        puntual, buscado por su Id.*/
        public DataTable getTablaHorarioInactivoPorId(int idHorario)
        {
            string sql = "SELECT HM.Id_Horario_HM AS IdHorario, HM.Legajo_HM AS Legajo, HM.Dia_HM AS Dia, " +
                 "HM.Horario_Inicio_HM AS Inicio, HM.Horario_Fin_HM AS Fin, (M.Nombre_M + ' ' + M.Apellido_M) AS Medico " +
                 "FROM Horarios_Medicos HM " +
                 "INNER JOIN Medicos M ON M.Legajo_M = HM.Legajo_HM " +
                 "WHERE HM.Id_Horario_HM = " + idHorario + " AND HM.Estado_HM = 0";

            return ds.ObtenerTabla("Horarios_Medicos", sql);
        }

        /*getTablaHorarioPorId
        Obtiene el detalle completo de un horario médico (activo o inactivo),
        buscado por su Id, incluyendo el estado en formato legible.*/
        public DataTable getTablaHorarioPorId(int idHorario)
        {
            string sql = "SELECT HM.Id_Horario_HM AS IdHorario, HM.Legajo_HM AS Legajo, (M.Nombre_M + ' ' + M.Apellido_M) AS Medico, " +
                         "HM.Dia_HM AS Dia, HM.Horario_Inicio_HM AS Inicio, HM.Horario_Fin_HM AS Fin, " +
                         "CASE WHEN HM.Estado_HM = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado " +
                         "FROM Horarios_Medicos HM " +
                         "INNER JOIN Medicos M ON M.Legajo_M = HM.Legajo_HM " +
                         "WHERE HM.Id_Horario_HM = " + idHorario;

            return ds.ObtenerTabla("Horarios_Medicos", sql);
        }

        /*getTablaHorariosPorDia
        Obtiene los horarios activos que correspondan al día de la semana
        recibido como parámetro.*/
        public DataTable getTablaHorariosPorDia(string dia)
        {
            string sql = "SELECT HM.Id_Horario_HM AS IdHorario, HM.Legajo_HM AS Legajo, " +
                         "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico, HM.Dia_HM AS Dia, " +
                         "HM.Horario_Inicio_HM AS HorarioInicio, HM.Horario_Fin_HM AS HorarioFin, " +
                         "CASE WHEN HM.Estado_HM = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado " +
                         "FROM Horarios_Medicos HM " +
                         "INNER JOIN Medicos M ON M.Legajo_M = HM.Legajo_HM " +
                         "WHERE HM.Dia_HM = '" + dia + "' AND HM.Estado_HM = 1";

            return ds.ObtenerTabla("Horarios_Medicos", sql);
        }

        /*getTablaHorariosPorNombreYDia
        Obtiene los horarios activos filtrando simultáneamente por nombre/apellido
        del médico (coincidencia parcial) y por día de la semana.*/
        public DataTable getTablaHorariosPorNombreYDia(string nombreApellido, string dia)
        {
            string sql = "SELECT HM.Id_Horario_HM AS IdHorario, HM.Legajo_HM AS Legajo, " +
                         "(M.Nombre_M + ' ' + M.Apellido_M) AS Medico, HM.Dia_HM AS Dia, " +
                         "HM.Horario_Inicio_HM AS HorarioInicio, HM.Horario_Fin_HM AS HorarioFin, " +
                         "CASE WHEN HM.Estado_HM = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado " +
                         "FROM Horarios_Medicos HM " +
                         "INNER JOIN Medicos M ON M.Legajo_M = HM.Legajo_HM " +
                         "WHERE HM.Estado_HM = 1 " +
                         "AND (M.Nombre_M + ' ' + M.Apellido_M) LIKE '%" + nombreApellido + "%' " +
                         "AND HM.Dia_HM = '" + dia + "'";

            return ds.ObtenerTabla("Horarios_Medicos", sql);
        }

        /*reactivarHorarioMedico
        Reactiva un horario médico previamente dado de baja, ejecutando
        el procedimiento almacenado correspondiente.*/
        public int reactivarHorarioMedico(HorarioMedico hm)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@Id_Horario_HM", hm.getId_Horario_HM());
            return ds.EjecutarProcedimientoAlmacenado(comando, "spReactivarHorarioMedico");
        }
    }
}