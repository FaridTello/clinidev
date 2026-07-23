using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia
    {
        private int Id_Provincia_P;
        private string Nombre_P;

        public Provincia() { }

        /*getId_Provincia_P
        Devuelve el Id de la provincia.*/
        public int getId_Provincia_P()
        {
            return Id_Provincia_P;
        }

        /*setId_Provincia_P
        Asigna el Id de la provincia.*/
        public void setId_Provincia_P(int id)
        {
            Id_Provincia_P = id;
        }

        /*getNombre_P
        Devuelve el nombre de la provincia.*/
        public string getNombre_P()
        {
            return Nombre_P;
        }

        /*setNombre_P
        Asigna el nombre de la provincia.*/
        public void setNombre_P(string nombre)
        {
            Nombre_P = nombre;
        }
    }
}