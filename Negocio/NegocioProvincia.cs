using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NegocioProvincia
    {
        /*getTabla
        Obtiene todas las provincias registradas en la base de datos.
        Devuelve un DataTable con la información de todas las provincias.*/
        public DataTable getTabla()
        {
            DaoProvincia dao = new DaoProvincia();
            return dao.getTablaProvincias();
        }
    }
}