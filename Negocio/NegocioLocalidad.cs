using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioLocalidad
    {
        /*getTabla
        Obtiene todas las localidades registradas en la base de datos.
        Devuelve un DataTable con la información de todas las localidades.*/
        public DataTable getTabla()
        {
            DaoLocalidad dao = new DaoLocalidad();
            return dao.getTablaLocalidades();
        }

        /*getLocalidadesPorProvincia
        Obtiene las localidades que pertenecen a la provincia recibida por Id.
        Devuelve un DataTable con la información de las localidades.*/
        public DataTable getLocalidadesPorProvincia(int idProvincia)
        {
            DaoLocalidad dao = new DaoLocalidad();
            return dao.getLocalidadesPorProvincia(idProvincia);
        }
    }
}