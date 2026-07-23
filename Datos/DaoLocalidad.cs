using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoLocalidad
    {
        AccesoDatos ds = new AccesoDatos();

        /*getTablaLocalidades
        Obtiene todas las localidades registradas en la base de datos
        y devuelve el resultado en un DataTable.*/
        public DataTable getTablaLocalidades()
        {
            DataTable tabla = ds.ObtenerTabla(
                "Localidades",
                "Select * from Localidades"
            );

            return tabla;
        }

        /*getLocalidadesPorProvincia
        Obtiene las localidades correspondientes a la provincia
        indicada y devuelve el resultado en un DataTable.*/
        public DataTable getLocalidadesPorProvincia(int idProvincia)
        {
            DataTable tabla = ds.ObtenerTabla(
                "Localidades",
                "Select * from Localidades where Id_Provincia_L = " + idProvincia
            );

            return tabla;
        }
    }
}