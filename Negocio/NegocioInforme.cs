using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioInforme
    {
        /*getAusentismo
        Genera un informe de ausentismo para el rango de fechas recibido.
        Devuelve un DataTable con los pacientes que no asistieron a sus turnos.*/
        public DataTable getAusentismo(DateTime fechaDesde, DateTime fechaHasta)
        {
            DaoInforme dao = new DaoInforme();
            return dao.getAusentismo(fechaDesde, fechaHasta);
        }

        /*getPacientesPorMedicoYFecha
        Genera un informe de pacientes atendidos por médico en el rango de fechas recibido.
        Devuelve un DataTable con la cantidad de pacientes por médico.*/
        public DataTable getPacientesPorMedicoYFecha(DateTime fechaDesde, DateTime fechaHasta)
        {
            DaoInforme dao = new DaoInforme();
            return dao.getPacientesPorMedicoYFecha(fechaDesde, fechaHasta);
        }

        /*getDemandaPorLocalidad
        Genera un informe de demanda de turnos por localidad en el rango de fechas recibido.
        Devuelve un DataTable con la cantidad de turnos por localidad.*/
        public DataTable getDemandaPorLocalidad(DateTime fechaDesde, DateTime fechaHasta)
        {
            DaoInforme dao = new DaoInforme();
            return dao.getDemandaPorLocalidad(fechaDesde, fechaHasta);
        }
    }
}