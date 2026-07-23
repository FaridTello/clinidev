using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoEspecialidad
    {
        AccesoDatos ds = new AccesoDatos();

        /*getTablaMedicosxEspecialidad
        Obtiene los médicos pertenecientes a la especialidad indicada
        y devuelve el resultado en un DataTable.*/
        public DataTable getTablaMedicosxEspecialidad(Medico med)
        {
            string sql = "SELECT Legajo_M, (Nombre_M + ' ' + Apellido_M) AS NombreCompleto " +
                         "FROM Medicos WHERE Id_Especialidad_M = " + med.getId_Especialidad_M() +
                         " AND Activo_M = 1";

            return ds.ObtenerTabla("Medicos", sql);
        }

        /*getTablaEspecialidades
        Obtiene todas las especialidades registradas en la base de datos
        y devuelve el resultado en un DataTable.*/
        public DataTable getTablaEspecialidades()
        {
            string sql = "SELECT Id_Especialidad_E, Nombre_E FROM Especialidades";
            return ds.ObtenerTabla("Especialidades", sql);
        }
    }
}