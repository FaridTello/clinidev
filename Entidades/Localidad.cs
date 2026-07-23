using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localidad
    {
        private int Id_Localidad_L;
        private int Id_Provincia_L;
        private string Nombre_L;

        public Localidad() { }

        /*getId_Localidad_L
        Devuelve el Id de la localidad.*/
        public int getId_Localidad_L()
        {
            return Id_Localidad_L;
        }

        /*setId_Localidad_L
        Asigna el Id de la localidad.*/
        public void setId_Localidad_L(int id)
        {
            Id_Localidad_L = id;
        }

        /*getId_Provincia_L
        Devuelve el Id de la provincia a la que pertenece la localidad.*/
        public int getId_Provincia_L()
        {
            return Id_Provincia_L;
        }

        /*setId_Provincia_L
        Asigna el Id de la provincia a la que pertenece la localidad.*/
        public void setId_Provincia_L(int id)
        {
            Id_Provincia_L = id;
        }

        /*getNombre_L
        Devuelve el nombre de la localidad.*/
        public string getNombre_L()
        {
            return Nombre_L;
        }

        /*setNombre_L
        Asigna el nombre de la localidad.*/
        public void setNombre_L(string nombre)
        {
            Nombre_L = nombre;
        }
    }
}