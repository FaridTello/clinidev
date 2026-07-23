using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Especialidad
    {
        private int Id_Especialidad_E;
        private string Nombre_E;

        public Especialidad() { }

        /*getId_Especialidad_E
        Devuelve el Id de la especialidad.*/
        public int getId_Especialidad_E()
        {
            return Id_Especialidad_E;
        }

        /*setId_Especialidad_E
        Asigna el Id de la especialidad.*/
        public void setId_Especialidad_E(int id)
        {
            Id_Especialidad_E = id;
        }

        /*getNombre_E
        Devuelve el nombre de la especialidad.*/
        public string getNombre_E()
        {
            return Nombre_E;
        }

        /*setNombre_E
        Asigna el nombre de la especialidad.*/
        public void setNombre_E(string nombre)
        {
            Nombre_E = nombre;
        }
    }
}