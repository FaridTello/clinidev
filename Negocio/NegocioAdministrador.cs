using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioAdministrador
    {
        /*getTabla
        Obtiene todos los administradores registrados en la base de datos.
        Devuelve un DataTable con la información de los administradores.*/
        public DataTable getTabla()
        {
            DaoAdministrador dao = new DaoAdministrador();
            return dao.getTablaAdministradores();
        }

        /*getPorUsuario
        Obtiene los datos del administrador asociado al Id de usuario recibido.
        Devuelve un DataTable con la información del administrador.*/
        public DataTable getPorUsuario(int idUsuario)
        {
            DaoAdministrador dao = new DaoAdministrador();
            return dao.getAdministradorPorUsuario(idUsuario);
        }
    }
}