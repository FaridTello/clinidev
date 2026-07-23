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
    public class NegocioUsuario
    {
        /*getTabla
        Obtiene todos los usuarios registrados en la base de datos.
        Devuelve un DataTable con la información de todos los usuarios.*/
        public DataTable getTabla()
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.getTablaUsuarios();
        }

        /*getPorId
        Obtiene los datos de un usuario específico a partir de su Id.
        Devuelve un DataTable con la información del usuario.*/
        public DataTable getPorId(int idUsuario)
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.getUsuarioPorId(idUsuario);
        }

        /*getPorNombre
        Obtiene los datos de un usuario específico a partir de su nombre de usuario.
        Devuelve un DataTable con la información del usuario.*/
        public DataTable getPorNombre(string nombre)
        {
            DaoUsuario dao = new DaoUsuario();
            return dao.getUsuarioPorNombre(nombre);
        }

        /*login
        Valida las credenciales de un usuario (nombre y contraseña) para el inicio de sesión.
        Retorna el objeto Usuario completo si las credenciales son válidas,
        o null en caso contrario.*/
        public Usuario login(string nombre, string contrasena)
        {
            DaoUsuario dao = new DaoUsuario();
            Usuario usu = new Usuario();
            usu.setNombre_U(nombre);
            usu.setContraseña_U(contrasena);
            return dao.getUsuario(usu);
        }
    }
}