using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int Id_Usuario_U;
        private string Nombre_U;
        private string Contraseña_U;
        private bool Tipo_Usuario_U;

        public Usuario() { }

        /*getId_Usuario_U
        Devuelve el Id del usuario.*/
        public int getId_Usuario_U()
        {
            return Id_Usuario_U;
        }

        /*setId_Usuario_U
        Asigna el Id del usuario.*/
        public void setId_Usuario_U(int id)
        {
            Id_Usuario_U = id;
        }

        /*getNombre_U
        Devuelve el nombre de usuario.*/
        public string getNombre_U()
        {
            return Nombre_U;
        }

        /*setNombre_U
        Asigna el nombre de usuario.*/
        public void setNombre_U(string nombre)
        {
            Nombre_U = nombre;
        }

        /*getContraseña_U
        Devuelve la contraseña del usuario.*/
        public string getContraseña_U()
        {
            return Contraseña_U;
        }

        /*setContraseña_U
        Asigna la contraseña del usuario.*/
        public void setContraseña_U(string contraseña)
        {
            Contraseña_U = contraseña;
        }

        /*getTipo_Usuario_U
        Devuelve el tipo de usuario (true = Administrador, false = Médico).*/
        public bool getTipo_Usuario_U()
        {
            return Tipo_Usuario_U;
        }

        /*setTipo_Usuario_U
        Asigna el tipo de usuario (true = Administrador, false = Médico).*/
        public void setTipo_Usuario_U(bool tipo)
        {
            Tipo_Usuario_U = tipo;
        }
    }
}