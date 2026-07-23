using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        private int Legajo_M;
        private int Id_Especialidad_M;
        private int Id_Usuario_M;
        private int Id_Localidad_M;
        private string Dni_M;
        private string Nombre_M;
        private string Apellido_M;
        private bool Sexo_M;
        private string Nacionalidad_M;
        private DateTime Fecha_Nacimiento_M;
        private string Direccion_M;
        private string Correo_Electronico_M;
        private string Telefono_M;
        private bool Activo_M;

        public Medico() { }

        /*getLegajo_M
        Devuelve el legajo del médico.*/
        public int getLegajo_M() { return Legajo_M; }

        /*setLegajo_M
        Asigna el legajo del médico.*/
        public void setLegajo_M(int legajo) { Legajo_M = legajo; }

        /*getId_Especialidad_M
        Devuelve el Id de la especialidad del médico.*/
        public int getId_Especialidad_M() { return Id_Especialidad_M; }

        /*setId_Especialidad_M
        Asigna el Id de la especialidad del médico.*/
        public void setId_Especialidad_M(int id) { Id_Especialidad_M = id; }

        /*getId_Usuario_M
        Devuelve el Id de usuario asociado al médico.*/
        public int getId_Usuario_M() { return Id_Usuario_M; }

        /*setId_Usuario_M
        Asigna el Id de usuario asociado al médico.*/
        public void setId_Usuario_M(int id) { Id_Usuario_M = id; }

        /*getId_Localidad_M
        Devuelve el Id de la localidad del médico.*/
        public int getId_Localidad_M() { return Id_Localidad_M; }

        /*setId_Localidad_M
        Asigna el Id de la localidad del médico.*/
        public void setId_Localidad_M(int id) { Id_Localidad_M = id; }

        /*getDni_M
        Devuelve el DNI del médico.*/
        public string getDni_M() { return Dni_M; }

        /*setDni_M
        Asigna el DNI del médico.*/
        public void setDni_M(string dni) { Dni_M = dni; }

        /*getNombre_M
        Devuelve el nombre del médico.*/
        public string getNombre_M() { return Nombre_M; }

        /*setNombre_M
        Asigna el nombre del médico.*/
        public void setNombre_M(string nombre) { Nombre_M = nombre; }

        /*getApellido_M
        Devuelve el apellido del médico.*/
        public string getApellido_M() { return Apellido_M; }

        /*setApellido_M
        Asigna el apellido del médico.*/
        public void setApellido_M(string apellido) { Apellido_M = apellido; }

        /*getSexo_M
        Devuelve el sexo del médico (true = Masculino, false = Femenino).*/
        public bool getSexo_M() { return Sexo_M; }

        /*setSexo_M
        Asigna el sexo del médico (true = Masculino, false = Femenino).*/
        public void setSexo_M(bool sexo) { Sexo_M = sexo; }

        /*getNacionalidad_M
        Devuelve la nacionalidad del médico.*/
        public string getNacionalidad_M() { return Nacionalidad_M; }

        /*setNacionalidad_M
        Asigna la nacionalidad del médico.*/
        public void setNacionalidad_M(string nacionalidad) { Nacionalidad_M = nacionalidad; }

        /*getFecha_Nacimiento_M
        Devuelve la fecha de nacimiento del médico.*/
        public DateTime getFecha_Nacimiento_M() { return Fecha_Nacimiento_M; }

        /*setFecha_Nacimiento_M
        Asigna la fecha de nacimiento del médico.*/
        public void setFecha_Nacimiento_M(DateTime fecha) { Fecha_Nacimiento_M = fecha; }

        /*getDireccion_M
        Devuelve la dirección del médico.*/
        public string getDireccion_M() { return Direccion_M; }

        /*setDireccion_M
        Asigna la dirección del médico.*/
        public void setDireccion_M(string direccion) { Direccion_M = direccion; }

        /*getCorreo_Electronico_M
        Devuelve el correo electrónico del médico.*/
        public string getCorreo_Electronico_M() { return Correo_Electronico_M; }

        /*setCorreo_Electronico_M
        Asigna el correo electrónico del médico.*/
        public void setCorreo_Electronico_M(string correo) { Correo_Electronico_M = correo; }

        /*getTelefono_M
        Devuelve el teléfono del médico.*/
        public string getTelefono_M() { return Telefono_M; }

        /*setTelefono_M
        Asigna el teléfono del médico.*/
        public void setTelefono_M(string telefono) { Telefono_M = telefono; }

        /*getActivo_M
        Devuelve el estado del médico (true = Activo, false = Inactivo).*/
        public bool getActivo_M() { return Activo_M; }

        /*setActivo_M
        Asigna el estado del médico (true = Activo, false = Inactivo).*/
        public void setActivo_M(bool activo) { Activo_M = activo; }

    }
}