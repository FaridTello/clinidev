using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Datos
{
    public class DaoProvincia
    {
        AccesoDatos ds = new AccesoDatos();

        /*getTablaProvincias
        Obtiene todas las provincias registradas en la base de datos.
        Devuelve un DataTable con la información de todas las provincias.*/
        public DataTable getTablaProvincias()
        {
            DataTable tabla = ds.ObtenerTabla("Provincias", "Select * from Provincias");
            return tabla;
        }
    }
}