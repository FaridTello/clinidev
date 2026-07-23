using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioEspecialidad
    {
        /*getTabla
        Obtiene todas las especialidades registradas en la base de datos.
        Devuelve un DataTable con la información de las especialidades.*/
        public DataTable getTabla()
        {
            DaoEspecialidad dao = new DaoEspecialidad();
            return dao.getTablaEspecialidades();
        }
    }
}