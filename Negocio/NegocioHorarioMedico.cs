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
    public class NegocioHorarioMedico
    {

        /*getTablaHorariosMedico
        Obtiene todos los horarios médicos registrados en la base de datos.
        Devuelve un DataTable con la información de los horarios.*/
        public DataTable getTablaHorariosMedico()
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();
            return dao.getTablaHorariosMedicos();
        }

        /*agregarHorarios
        Agrega múltiples horarios para un médico en los días seleccionados.
        Valida que la hora de inicio sea menor a la hora de fin y que no existan
        horarios duplicados para el médico y día.
        Retorna true si todos los horarios se agregaron correctamente.*/
        public bool agregarHorarios(int legajo, List<string> dias, TimeSpan inicio, TimeSpan fin)
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();

            if (inicio >= fin)
                return false;

            List<HorarioMedico> horariosAValidar = new List<HorarioMedico>();

            foreach (string dia in dias)
            {
                HorarioMedico hor = new HorarioMedico();
                hor.setLegajo_HM(legajo);
                hor.setDia_HM(dia);
                hor.setHorario_Inicio_HM(inicio);
                hor.setHorario_Fin_HM(fin);

                horariosAValidar.Add(hor);
            }

            foreach (HorarioMedico hor in horariosAValidar)
            {
                if (dao.ExisteDiaOcupado(hor))
                    return false;
            }

            foreach (HorarioMedico hor in horariosAValidar)
            {
                int filas = dao.agregarHorario(hor);
                if (filas != 1)
                    return false;
            }

            return true;
        }

        /*getTablaxLegajo
        Obtiene los horarios de un médico específico a partir de su legajo.
        Devuelve un DataTable con la información de los horarios.*/
        public DataTable getTablaxLegajo(int legajo)
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();
            HorarioMedico hor = new HorarioMedico();
            hor.setLegajo_HM(legajo);
            return dao.getTablaHorariosxLegajo(hor);
        }

        /*getTablaHorarioActivoPorId
        Obtiene un horario activo a partir de su Id.
        Devuelve un DataTable con la información del horario.*/
        public DataTable getTablaHorarioActivoPorId(int idHorario)
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();
            return dao.getTablaHorarioActivoPorId(idHorario);
        }

        /*getTablaHorarioInactivoPorId
        Obtiene un horario inactivo a partir de su Id.
        Devuelve un DataTable con la información del horario.*/
        public DataTable getTablaHorarioInactivoPorId(int idHorario)
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();
            return dao.getTablaHorarioInactivoPorId(idHorario);
        }

        /*getTablaHorarioPorId
        Obtiene un horario (activo o inactivo) a partir de su Id.
        Devuelve un DataTable con la información del horario.*/
        public DataTable getTablaHorarioPorId(int idHorario)
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();
            return dao.getTablaHorarioPorId(idHorario);
        }

        /*eliminarHorarioMedico
        Elimina (baja lógica) un horario médico a partir de su Id.
        Retorna true si se eliminó correctamente, false en caso contrario.*/
        public bool eliminarHorarioMedico(int idHorario)
        {
            int cantFilas = 0;

            DaoHorarioMedico dao = new DaoHorarioMedico();
            HorarioMedico hm = new HorarioMedico();
            hm.setId_Horario_HM(idHorario);

            if (dao.ExisteHorarioxId(hm) == true)
            {
                cantFilas = dao.eliminarHorarioMedico(hm);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        /*getTablaHorariosPorLegajo
        Obtiene los horarios activos de un médico específico a partir de su legajo.
        Devuelve un DataTable con la información de los horarios.*/
        public DataTable getTablaHorariosPorLegajo(int legajo)
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();
            return dao.getTablaHorariosPorLegajo(legajo);
        }

        /*getTablaHorariosPorNombreApellido
        Busca horarios médicos cuyo médico coincida parcialmente con el nombre o apellido recibido.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTablaHorariosPorNombreApellido(string nombreApellido)
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();
            return dao.getTablaHorariosPorNombreApellido(nombreApellido);
        }

        /*modificarHorarioMedico
        Modifica un horario médico existente con los nuevos datos.
        Valida que no exista conflicto de día y horario para el médico.
        Retorna true si se modificó correctamente, false en caso contrario.*/
        public bool modificarHorarioMedico(int idHorario, int legajo, string dia, TimeSpan horarioInicio, TimeSpan horarioFin)
        {
            int cantFilas = 0;

            DaoHorarioMedico dao = new DaoHorarioMedico();
            HorarioMedico hm = new HorarioMedico();
            hm.setId_Horario_HM(idHorario);
            hm.setLegajo_HM(legajo);
            hm.setDia_HM(dia);
            hm.setHorario_Inicio_HM(horarioInicio);
            hm.setHorario_Fin_HM(horarioFin);

            if (dao.ExisteHorarioxId(hm) == true && dao.ExisteDiaOcupado(hm) == false)
            {
                cantFilas = dao.modificarHorarioMedico(hm);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        /*getTablaHorariosInactivosPorLegajo
        Obtiene los horarios inactivos de un médico específico a partir de su legajo.
        Devuelve un DataTable con la información de los horarios.*/
        public DataTable getTablaHorariosInactivosPorLegajo(int legajo)
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();
            return dao.getTablaHorariosInactivosPorLegajo(legajo);
        }

        /*reactivarHorarioMedico
        Reactiva un horario médico previamente dado de baja.
        Valida que no exista un horario activo para el mismo médico y día.
        Retorna true si se reactivó correctamente, false en caso contrario.*/
        public bool reactivarHorarioMedico(int idHorario)
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();

            DataTable tabla = dao.getTablaHorarioInactivoPorId(idHorario);

            if (tabla.Rows.Count == 0)
                return false;

            DataRow fila = tabla.Rows[0];

            HorarioMedico hm = new HorarioMedico();
            hm.setId_Horario_HM(idHorario);
            hm.setLegajo_HM(Convert.ToInt32(fila["Legajo"]));
            hm.setDia_HM(fila["Dia"].ToString());

            if (dao.ExisteDiaOcupado(hm))
                return false;

            if (dao.reactivarHorarioMedico(hm) == 1)
                return true;
            else
                return false;
        }

        /*getTablaHorariosPorDia
        Obtiene los horarios activos filtrados por el día de la semana recibido.
        Devuelve un DataTable con la información de los horarios.*/
        public DataTable getTablaHorariosPorDia(string dia)
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();
            return dao.getTablaHorariosPorDia(dia);
        }

        /*getTablaHorariosPorNombreYDia
        Busca horarios médicos filtrando por nombre/apellido del médico y por día de la semana.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTablaHorariosPorNombreYDia(string nombreApellido, string dia)
        {
            DaoHorarioMedico dao = new DaoHorarioMedico();
            return dao.getTablaHorariosPorNombreYDia(nombreApellido, dia);
        }

    }
}