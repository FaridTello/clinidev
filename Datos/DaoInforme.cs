using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoInforme
    {
        AccesoDatos ds = new AccesoDatos();

        /*getAusentismo
        Obtiene un informe de presentismo y ausentismo de los turnos
        comprendidos entre las fechas indicadas.*/
        public DataTable getAusentismo(DateTime fechaDesde, DateTime fechaHasta)
        {
            string sql = "SELECT " +
                         "COUNT(*) AS TotalTurnos, " +
                         "SUM(CASE WHEN Estado_T = 1 THEN 1 ELSE 0 END) AS Presentes, " +
                         "SUM(CASE WHEN Estado_T = 0 THEN 1 ELSE 0 END) AS Ausentes, " +
                         "CAST(SUM(CASE WHEN Estado_T = 1 THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2)) AS PorcentajePresentes, " +
                         "CAST(SUM(CASE WHEN Estado_T = 0 THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2)) AS PorcentajeAusentes " +
                         "FROM Turnos " +
                         "WHERE Fecha_Turno_T BETWEEN '" + fechaDesde.ToString("yyyy-MM-dd") + "' AND '" + fechaHasta.ToString("yyyy-MM-dd") + "'";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getPacientesPorMedicoYFecha
        Obtiene la cantidad de pacientes atendidos por cada médico
        dentro del rango de fechas especificado.*/
        public DataTable getPacientesPorMedicoYFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            string sql = "SELECT (M.Nombre_M + ' ' + M.Apellido_M) AS Medico, " +
                         "CONVERT(varchar, T.Fecha_Turno_T, 103) AS Fecha, " +
                         "COUNT(T.Id_Paciente_T) AS CantidadPacientes " +
                         "FROM Turnos T " +
                         "INNER JOIN Horarios_Medicos HM ON T.Id_Horario_T = HM.Id_Horario_HM " +
                         "INNER JOIN Medicos M ON HM.Legajo_HM = M.Legajo_M " +
                         "WHERE T.Fecha_Turno_T BETWEEN '" + fechaDesde.ToString("yyyy-MM-dd") + "' AND '" + fechaHasta.ToString("yyyy-MM-dd") + "' " +
                         "AND T.Estado_T = 1 " + /*Solo turnos activos.*/
                         "GROUP BY M.Nombre_M, M.Apellido_M, T.Fecha_Turno_T " +
                         "ORDER BY T.Fecha_Turno_T DESC, Medico ASC";

            return ds.ObtenerTabla("Turnos", sql);
        }

        /*getDemandaPorLocalidad
        Obtiene un informe con la cantidad de turnos atendidos por
        localidad y el porcentaje de demanda correspondiente.*/
        public DataTable getDemandaPorLocalidad(DateTime fechaDesde, DateTime fechaHasta)
        {
            string sql = "SELECT L.Nombre_L AS Localidad, " +
                         "Pr.Nombre_P AS Provincia, " +
                         "COUNT(T.Id_Turno_T) AS TurnosAtendidos, " +
                         "CAST(CAST(COUNT(T.Id_Turno_T) * 100.0 / SUM(COUNT(T.Id_Turno_T)) OVER() AS decimal(10,2)) AS varchar) + '%' AS PorcentajeDemanda " +
                         "FROM Turnos T " +
                         "INNER JOIN Pacientes P ON T.Id_Paciente_T = P.Id_Paciente_Pa " +
                         "INNER JOIN Localidades L ON P.Id_Localidad_Pa = L.Id_Localidad_L " +
                         "INNER JOIN Provincias Pr ON L.Id_Provincia_L = Pr.Id_Provincia_P " +
                         "WHERE T.Fecha_Turno_T BETWEEN '" + fechaDesde.ToString("yyyy-MM-dd") + "' AND '" + fechaHasta.ToString("yyyy-MM-dd") + "' " +
                         "AND T.Estado_T = 1 AND T.Presentismo_T = 1 " + /*Solo turnos válidos y pacientes que asistieron.*/
                         "GROUP BY L.Nombre_L, Pr.Nombre_P " +
                         "ORDER BY TurnosAtendidos DESC";
            return ds.ObtenerTabla("Turnos", sql);
        }
    }
}