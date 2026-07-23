using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoAdministrador
    {
        AccesoDatos ds = new AccesoDatos();

        /*getTablaAdministradores
        Obtiene todos los registros de la tabla Administrador y
        devuelve el resultado en un DataTable.*/
        public DataTable getTablaAdministradores()
        {
            DataTable tabla = ds.ObtenerTabla(
                "Administrador",
                "SELECT * FROM Administrador"
            );
            return tabla;
        }

        /*getAdministradorPorUsuario
        Obtiene el administrador asociado al identificador del usuario
        recibido como parámetro y devuelve el resultado en un DataTable.*/
        public DataTable getAdministradorPorUsuario(int idUsuario)
        {
            DataTable tabla = ds.ObtenerTabla(
                "Administrador",
                "SELECT * FROM Administrador WHERE Id_Usuario_A = " + idUsuario
            );
            return tabla;
        }
    }
}