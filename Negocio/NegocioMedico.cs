using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioMedico
    {
        /*agregarMedico
        Agrega un nuevo médico y su usuario asociado.
        Valida que no exista un médico con el mismo DNI.
        Retorna true si se agregó correctamente, false en caso contrario.*/
        public bool agregarMedico(string dni, string nombre, string apellido, bool sexo, string nacionalidad, DateTime fechaNacimiento, string direccion, string correo, string telefono, int idEspecialidad, int idLocalidad, string nombreUsuario, string contrasena)
        {
            int cantFilas = 0;

            DaoMedico dao = new DaoMedico();
            Medico med = new Medico();
            med.setDni_M(dni);
            med.setNombre_M(nombre);
            med.setApellido_M(apellido);
            med.setSexo_M(sexo);
            med.setNacionalidad_M(nacionalidad);
            med.setFecha_Nacimiento_M(fechaNacimiento);
            med.setDireccion_M(direccion);
            med.setCorreo_Electronico_M(correo);
            med.setTelefono_M(telefono);
            med.setId_Especialidad_M(idEspecialidad);
            med.setId_Localidad_M(idLocalidad);

            Usuario usu = new Usuario();
            usu.setNombre_U(nombreUsuario);
            usu.setContraseña_U(contrasena);

            if (dao.ExisteMedicoxDNI(med) == false)
            {
                cantFilas = dao.agregarMedico(med, usu);
            }

            if (cantFilas >= 1)
                return true;
            else
                return false;
        }

        /*eliminarMedico
        Elimina (baja lógica) un médico a partir de su legajo.
        Retorna true si se eliminó correctamente, false en caso contrario.*/
        public bool eliminarMedico(int legajo)
        {
            int cantFilas = 0;

            DaoMedico dao = new DaoMedico();
            Medico med = new Medico();
            med.setLegajo_M(legajo);

            if (dao.ExisteMedicoxLegajo(med) == true)
            {
                cantFilas = dao.eliminarMedico(med);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        /*modificarMedico
        Modifica los datos de un médico existente a partir de su legajo.
        Retorna true si se modificó correctamente, false en caso contrario.*/
        public bool modificarMedico(int legajo, string dni, string nombre, string apellido, bool sexo, string nacionalidad, DateTime fechaNacimiento, string direccion, string correo, string telefono, int idEspecialidad, int idLocalidad, bool activo)
        {
            int cantFilas = 0;
            DaoMedico dao = new DaoMedico();
            Medico med = new Medico();
            med.setLegajo_M(legajo);
            med.setDni_M(dni);
            med.setNombre_M(nombre);
            med.setApellido_M(apellido);
            med.setSexo_M(sexo);
            med.setNacionalidad_M(nacionalidad);
            med.setFecha_Nacimiento_M(fechaNacimiento);
            med.setDireccion_M(direccion);
            med.setCorreo_Electronico_M(correo);
            med.setTelefono_M(telefono);
            med.setId_Especialidad_M(idEspecialidad);
            med.setId_Localidad_M(idLocalidad);
            med.setActivo_M(activo);

            if (dao.ExisteMedicoxLegajo(med) == true)
            {
                cantFilas = dao.modificarMedico(med);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        /*getTabla
        Obtiene todos los médicos activos registrados en la base de datos.
        Devuelve un DataTable con la información de los médicos.*/
        public DataTable getTabla()
        {
            DaoMedico dao = new DaoMedico();
            return dao.getTablaMedicos();
        }

        /*getTablaxLegajo
        Obtiene los datos de un médico activo a partir de su legajo.
        Devuelve un DataTable con la información del médico.*/
        public DataTable getTablaxLegajo(int legajo)
        {
            DaoMedico dao = new DaoMedico();
            Medico med = new Medico();
            med.setLegajo_M(legajo);
            return dao.getTablaMedicosxLegajo(med);
        }

        /*getTablaxLegajoMod
        Obtiene los datos de un médico (activo o inactivo) a partir de su legajo,
        pensado para precargar el formulario de modificación.
        Devuelve un DataTable con la información del médico.*/
        public DataTable getTablaxLegajoMod(int legajo)
        {
            DaoMedico dao = new DaoMedico();
            Medico med = new Medico();
            med.setLegajo_M(legajo);
            return dao.getTablaMedicosxLegajoMod(med);
        }

        /*getTablaMedicosxLegajoBaja
        Obtiene los datos de un médico activo a partir de su legajo,
        pensado para precargar el formulario de baja.
        Devuelve un DataTable con la información del médico.*/
        public DataTable getTablaMedicosxLegajoBaja(Medico med)
        {
            DaoMedico dao = new DaoMedico();
            return dao.getTablaMedicosxLegajoBaja(med);
        }

        /*getTablaInactivosxLegajo
        Obtiene los datos de un médico inactivo a partir de su legajo.
        Devuelve un DataTable con la información del médico.*/
        public DataTable getTablaInactivosxLegajo(int legajo)
        {
            DaoMedico dao = new DaoMedico();
            Medico med = new Medico();
            med.setLegajo_M(legajo);
            return dao.getTablaMedicosInactivosxLegajo(med);
        }

        /*getTablaxNombre
        Busca médicos activos cuyo nombre o apellido coincidan parcialmente con el filtro.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTablaxNombre(string nombre)
        {
            DaoMedico dao = new DaoMedico();
            Medico med = new Medico();
            med.setNombre_M(nombre);
            return dao.getTablaMedicosxNombre(med);
        }

        /*getTablaInactivos
        Obtiene todos los médicos inactivos registrados en la base de datos.
        Devuelve un DataTable con la información de los médicos inactivos.*/
        public DataTable getTablaInactivos()
        {
            DaoMedico dao = new DaoMedico();
            return dao.getTablaMedicosInactivos();
        }

        /*reactivarMedico
        Reactiva un médico previamente dado de baja a partir de su legajo.
        Retorna true si se reactivó correctamente, false en caso contrario.*/
        public bool reactivarMedico(int legajo)
        {
            int cantFilas = 0;

            DaoMedico dao = new DaoMedico();
            Medico med = new Medico();
            med.setLegajo_M(legajo);

            if (dao.ExisteMedicoInactivo(med) == true)
            {
                cantFilas = dao.reactivarMedico(med);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        /*getTablaxEspecialidad
        Obtiene los médicos activos que pertenecen a la especialidad recibida.
        Devuelve un DataTable con la información de los médicos.*/
        public DataTable getTablaxEspecialidad(int idEspecialidad)
        {
            DaoMedico dao = new DaoMedico();
            Medico med = new Medico();
            med.setId_Especialidad_M(idEspecialidad);
            return dao.getTablaMedicosxEspecialidad(med);
        }

        /*getTablaxProvincia
        Obtiene los médicos activos que pertenecen a la provincia recibida.
        Devuelve un DataTable con la información de los médicos.*/
        public DataTable getTablaxProvincia(int idProvincia)
        {
            DaoMedico dao = new DaoMedico();
            return dao.getTablaMedicosxProvincia(idProvincia);
        }

        /*getTablaMedicosxNombreProvincia
        Busca médicos activos filtrando por nombre/apellido y por provincia simultáneamente.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTablaMedicosxNombreProvincia(string nombre, int provincia)
        {
            DaoMedico dao = new DaoMedico();
            return dao.getTablaMedicosxNombreProvincia(nombre, provincia);
        }

        /*getLegajoPorIdUsuario
        Obtiene el legajo del médico asociado al Id de usuario recibido.
        Devuelve el legajo si existe, o 0 en caso contrario.*/
        public int getLegajoPorIdUsuario(int idUsuario)
        {
            DaoMedico dao = new DaoMedico();
            return dao.getLegajoPorIdUsuario(idUsuario);
        }

        /*getTablaxNombreyLegajo
        Busca un médico activo filtrando por nombre/apellido y por legajo simultáneamente.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTablaxNombreyLegajo(string nombre, int legajo)
        {
            DaoMedico dao = new DaoMedico();
            Medico med = new Medico();

            med.setNombre_M(nombre);
            med.setLegajo_M(legajo);

            return dao.getTablaMedicosxNombreyLegajo(med);
        }
    }
}