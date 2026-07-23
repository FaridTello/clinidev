using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoUsuario
    {
        AccesoDatos ds = new AccesoDatos();

        /*getTablaUsuarios
        Obtiene todos los usuarios registrados en la base de datos.
        Devuelve un DataTable con la información de todos los usuarios.*/
        public DataTable getTablaUsuarios()
        {
            DataTable tabla = ds.ObtenerTabla(
                "Usuarios",
                "Select * from Usuarios"
            );

            return tabla;
        }

        /*getUsuarioPorId
        Obtiene los datos de un usuario específico a partir de su Id.
        Devuelve un DataTable con la información del usuario.*/
        public DataTable getUsuarioPorId(int idUsuario)
        {
            DataTable tabla = ds.ObtenerTabla(
                "Usuarios",
                "Select * from Usuarios where Id_Usuario_U = " + idUsuario
            );

            return tabla;
        }

        /*getUsuarioPorNombre
        Obtiene los datos de un usuario específico a partir de su nombre de usuario.
        Devuelve un DataTable con la información del usuario.*/
        public DataTable getUsuarioPorNombre(string nombre)
        {
            DataTable tabla = ds.ObtenerTabla(
                "Usuarios",
                "Select * from Usuarios where Nombre_U = '" + nombre + "'"
            );

            return tabla;
        }

        /*getUsuario
        Valida las credenciales de un usuario (nombre y contraseña).
        Si existe, completa el objeto Usuario con su Id y tipo de usuario.
        Retorna el objeto Usuario completo si las credenciales son válidas,
        o null en caso contrario.*/
        public Usuario getUsuario(Usuario usu)
        {
            DataTable tabla = ds.ObtenerTabla("Usuarios", "SELECT * FROM Usuarios WHERE Nombre_U = '" + usu.getNombre_U() + "' AND Contraseña_U = '" + usu.getContraseña_U() + "'");
            if (tabla.Rows.Count > 0)
            {
                usu.setId_Usuario_U(Convert.ToInt32(tabla.Rows[0][0].ToString()));
                usu.setTipo_Usuario_U(Convert.ToBoolean(tabla.Rows[0][3]));
                return usu;
            }
            return null;
        }
    }
}