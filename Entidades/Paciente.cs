using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paciente
    {
        private int Id_Paciente_Pa;
        private int Id_Localidad_Pa;
        private string Dni_Pa;
        private string Nombre_Pa;
        private string Apellido_Pa;
        private bool Sexo_Pa;
        private string Nacionalidad_Pa;
        private DateTime Fecha_Nacimiento_Pa;
        private string Direccion_Pa;
        private string Correo_Electronico_Pa;
        private string Telefono_Pa;
        private bool Activo_Pa;

        public Paciente() { }

        /*getId_Paciente_Pa
        Devuelve el Id del paciente.*/
        public int getId_Paciente_Pa() { return Id_Paciente_Pa; }

        /*setId_Paciente_Pa
        Asigna el Id del paciente.*/
        public void setId_Paciente_Pa(int id) { Id_Paciente_Pa = id; }

        /*getId_Localidad_Pa
        Devuelve el Id de la localidad del paciente.*/
        public int getId_Localidad_Pa() { return Id_Localidad_Pa; }

        /*setId_Localidad_Pa
        Asigna el Id de la localidad del paciente.*/
        public void setId_Localidad_Pa(int id) { Id_Localidad_Pa = id; }

        /*getDni_Pa
        Devuelve el DNI del paciente.*/
        public string getDni_Pa() { return Dni_Pa; }

        /*setDni_Pa
        Asigna el DNI del paciente.*/
        public void setDni_Pa(string dni) { Dni_Pa = dni; }

        /*getNombre_Pa
        Devuelve el nombre del paciente.*/
        public string getNombre_Pa() { return Nombre_Pa; }

        /*setNombre_Pa
        Asigna el nombre del paciente.*/
        public void setNombre_Pa(string nombre) { Nombre_Pa = nombre; }

        /*getApellido_Pa
        Devuelve el apellido del paciente.*/
        public string getApellido_Pa() { return Apellido_Pa; }

        /*setApellido_Pa
        Asigna el apellido del paciente.*/
        public void setApellido_Pa(string apellido) { Apellido_Pa = apellido; }

        /*getSexo_Pa
        Devuelve el sexo del paciente (true = Masculino, false = Femenino).*/
        public bool getSexo_Pa() { return Sexo_Pa; }

        /*setSexo_Pa
        Asigna el sexo del paciente (true = Masculino, false = Femenino).*/
        public void setSexo_Pa(bool sexo) { Sexo_Pa = sexo; }

        /*getNacionalidad_Pa
        Devuelve la nacionalidad del paciente.*/
        public string getNacionalidad_Pa() { return Nacionalidad_Pa; }

        /*setNacionalidad_Pa
        Asigna la nacionalidad del paciente.*/
        public void setNacionalidad_Pa(string nacionalidad) { Nacionalidad_Pa = nacionalidad; }

        /*getFecha_Nacimiento_Pa
        Devuelve la fecha de nacimiento del paciente.*/
        public DateTime getFecha_Nacimiento_Pa() { return Fecha_Nacimiento_Pa; }

        /*setFecha_Nacimiento_Pa
        Asigna la fecha de nacimiento del paciente.*/
        public void setFecha_Nacimiento_Pa(DateTime fecha) { Fecha_Nacimiento_Pa = fecha; }

        /*getDireccion_Pa
        Devuelve la dirección del paciente.*/
        public string getDireccion_Pa() { return Direccion_Pa; }

        /*setDireccion_Pa
        Asigna la dirección del paciente.*/
        public void setDireccion_Pa(string direccion) { Direccion_Pa = direccion; }

        /*getCorreo_Electronico_Pa
        Devuelve el correo electrónico del paciente.*/
        public string getCorreo_Electronico_Pa() { return Correo_Electronico_Pa; }

        /*setCorreo_Electronico_Pa
        Asigna el correo electrónico del paciente.*/
        public void setCorreo_Electronico_Pa(string correo) { Correo_Electronico_Pa = correo; }

        /*getTelefono_Pa
        Devuelve el teléfono del paciente.*/
        public string getTelefono_Pa() { return Telefono_Pa; }

        /*setTelefono_Pa
        Asigna el teléfono del paciente.*/
        public void setTelefono_Pa(string telefono) { Telefono_Pa = telefono; }

        /*getActivo_Pa
        Devuelve el estado del paciente (true = Activo, false = Inactivo).*/
        public bool getActivo_Pa() { return Activo_Pa; }

        /*setActivo_Pa
        Asigna el estado del paciente (true = Activo, false = Inactivo).*/
        public void setActivo_Pa(bool activo) { Activo_Pa = activo; }
    }
}