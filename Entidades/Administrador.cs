using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Administrador
    {
        private int Id_Administrador_A;
        private int Id_Usuario_A;
        private string Dni_A;
        private string Nombre_A;
        private string Apellido_A;

        public Administrador() { }

        /*getId_Administrador_A
        Devuelve el Id del administrador.*/
        public int getId_Administrador_A()
        {
            return Id_Administrador_A;

        }

        /*setId_Administrador_A
        Asigna el Id del administrador.*/
        public void setId_Administrador_A(int id)
        {
            Id_Administrador_A = id;
        }

        /*getId_Usuario_A
        Devuelve el Id de usuario asociado al administrador.*/
        public int getId_Usuario_A()
        {
            return Id_Usuario_A;
        }

        /*setId_Usuario_A
        Asigna el Id de usuario asociado al administrador.*/
        public void setId_Usuario_A(int id)
        {
            Id_Usuario_A = id;
        }

        /*getDni_A
        Devuelve el DNI del administrador.*/
        public string getDni_A()
        {
            return Dni_A;
        }

        /*setDni_A
        Asigna el DNI del administrador.*/
        public void setDni_A(string dni)
        {
            Dni_A = dni;
        }

        /*getNombre_A
        Devuelve el nombre del administrador.*/
        public string getNombre_A()
        {
            return Nombre_A;
        }

        /*setNombre_A
        Asigna el nombre del administrador.*/
        public void setNombre_A(string nombre)
        {
            Nombre_A = nombre;
        }

        /*getApellido_A
        Devuelve el apellido del administrador.*/
        public string getApellido_A()
        {
            return Apellido_A;
        }

        /*setApellido_A
        Asigna el apellido del administrador.*/
        public void setApellido_A(string apellido)
        {
            Apellido_A = apellido;
        }
    }
}