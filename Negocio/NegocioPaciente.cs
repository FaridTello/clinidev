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
    public class NegocioPaciente
    {
        /*agregarPaciente
        Agrega un nuevo paciente a la base de datos.
        Valida que no exista un paciente con el mismo DNI.
        Retorna true si se agregó correctamente, false en caso contrario.*/
        public bool agregarPaciente(string dni, string nombre, string apellido, bool sexo, string nacionalidad, DateTime fechaNacimiento, string direccion, string correo, string telefono, int idLocalidad)
        {
            int cantFilas = 0;

            DaoPaciente dao = new DaoPaciente();
            Paciente pac = new Paciente();
            pac.setDni_Pa(dni);
            pac.setNombre_Pa(nombre);
            pac.setApellido_Pa(apellido);
            pac.setSexo_Pa(sexo);
            pac.setNacionalidad_Pa(nacionalidad);
            pac.setFecha_Nacimiento_Pa(fechaNacimiento);
            pac.setDireccion_Pa(direccion);
            pac.setCorreo_Electronico_Pa(correo);
            pac.setTelefono_Pa(telefono);
            pac.setId_Localidad_Pa(idLocalidad);

            if (dao.ExistePacientexDNI(pac) == false)
            {
                cantFilas = dao.agregarPaciente(pac);
            }

            if (cantFilas >= 1)
                return true;
            else
                return false;
        }

        /*getTabla
        Obtiene todos los pacientes activos registrados en la base de datos.
        Devuelve un DataTable con la información de los pacientes.*/
        public DataTable getTabla()
        {
            DaoPaciente dao = new DaoPaciente();
            return dao.getTablaPacientes();
        }

        /*getTablaxNombre
        Busca pacientes activos cuyo nombre o apellido coincidan parcialmente con el filtro.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTablaxNombre(string nombre)
        {
            DaoPaciente dao = new DaoPaciente();
            Paciente pac = new Paciente();
            pac.setNombre_Pa(nombre);
            return dao.getTablaPacientesxNombre(pac);
        }

        /*getTablaxDNI
        Busca pacientes activos cuyo DNI coincida parcialmente con el filtro.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTablaxDNI(string dni)
        {
            DaoPaciente dao = new DaoPaciente();
            Paciente pac = new Paciente();
            pac.setDni_Pa(dni);
            return dao.getTablaPacientesxDNI(pac);
        }

        /*getTablaxID
        Obtiene los datos completos de un paciente activo a partir de su ID.
        Devuelve un DataTable con la información del paciente.*/
        public DataTable getTablaxID(int id)
        {
            DaoPaciente dao = new DaoPaciente();
            Paciente pac = new Paciente();
            pac.setId_Paciente_Pa(id);

            return dao.getTablaPacientesxID(pac);
        }

        /*getTablaPacientesxIDBaja
        Obtiene los datos de un paciente activo por su ID, pensado para precargar el formulario de baja.
        Devuelve un DataTable con la información del paciente.*/
        public DataTable getTablaPacientesxIDBaja(int id)
        {
            DaoPaciente dao = new DaoPaciente();
            return dao.getTablaPacientesxIDBaja(id);
        }

        /*getTablaPacientesxIDMod
        Obtiene los datos de un paciente activo por su ID, pensado para precargar el formulario de modificación.
        Devuelve un DataTable con la información del paciente.*/
        public DataTable getTablaPacientesxIDMod(int id)
        {
            DaoPaciente dao = new DaoPaciente();
            return dao.getTablaPacientesxIDMod(id);
        }

        /*getTablaxProvincia
        Obtiene los pacientes activos que pertenecen a la provincia recibida.
        Devuelve un DataTable con la información de los pacientes.*/
        public DataTable getTablaxProvincia(int idProvincia)
        {
            DaoPaciente dao = new DaoPaciente();
            Paciente pac = new Paciente();
            pac.setId_Localidad_Pa(idProvincia);
            return dao.getTablaPacientesxProvincia(pac);
        }

        /*getTablaInactivosxLegajo
        Obtiene los datos de un paciente inactivo a partir de su ID.
        Devuelve un DataTable con la información del paciente.*/
        public DataTable getTablaInactivosxLegajo(int idPaciente)
        {
            DaoPaciente dao = new DaoPaciente();
            Paciente pac = new Paciente();
            pac.setId_Paciente_Pa(idPaciente);
            return dao.getTablaPacientesInactivosxLegajo(pac);
        }

        /*reactivarPaciente
        Reactiva un paciente previamente dado de baja a partir de su ID.
        Retorna true si se reactivó correctamente, false en caso contrario.*/
        public bool reactivarPaciente(int idPaciente)
        {
            int cantFilas = 0;

            DaoPaciente dao = new DaoPaciente();
            Paciente pac = new Paciente();
            pac.setId_Paciente_Pa(idPaciente);

            if (dao.ExistePacienteInactivo(pac) == true)
            {
                cantFilas = dao.reactivarPaciente(pac);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        /*eliminarPaciente
        Elimina (baja lógica) un paciente a partir de su ID.
        Retorna true si se eliminó correctamente, false en caso contrario.*/
        public bool eliminarPaciente(int idPaciente)
        {
            int cantFilas = 0;

            DaoPaciente dao = new DaoPaciente();
            Paciente pac = new Paciente();
            pac.setId_Paciente_Pa(idPaciente);

            if (dao.ExistePacientexID(pac) == true)
            {
                cantFilas = dao.eliminarPaciente(pac);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        /*modificarPaciente
        Modifica los datos de un paciente existente a partir de su ID.
        Retorna true si se modificó correctamente, false en caso contrario.*/
        public bool modificarPaciente(int idPaciente, string dni, string nombre, string apellido, bool sexo, string nacionalidad, DateTime fechaNacimiento, string direccion, string correo, string telefono, int idLocalidad)
        {
            int cantFilas = 0;

            DaoPaciente dao = new DaoPaciente();
            Paciente pac = new Paciente();
            pac.setId_Paciente_Pa(idPaciente);
            pac.setDni_Pa(dni);
            pac.setNombre_Pa(nombre);
            pac.setApellido_Pa(apellido);
            pac.setSexo_Pa(sexo);
            pac.setNacionalidad_Pa(nacionalidad);
            pac.setFecha_Nacimiento_Pa(fechaNacimiento);
            pac.setDireccion_Pa(direccion);
            pac.setCorreo_Electronico_Pa(correo);
            pac.setTelefono_Pa(telefono);
            pac.setId_Localidad_Pa(idLocalidad);

            if (dao.ExistePacientexID(pac) == true)
            {
                cantFilas = dao.modificarPaciente(pac);
            }

            if (cantFilas == 1)
                return true;
            else
                return false;
        }

        /*getTablaActivos
        Obtiene el ID y nombre completo de todos los pacientes activos, útil para listados o combos.
        Devuelve un DataTable con la información de los pacientes.*/
        public DataTable getTablaActivos()
        {
            DaoPaciente dao = new DaoPaciente();
            return dao.getTablaPacientesActivos();
        }

        /*getTablaxNombreyID
        Busca un paciente activo filtrando por nombre/apellido y por ID simultáneamente.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTablaxNombreyID(string nombre, int id)
        {
            DaoPaciente dao = new DaoPaciente();
            Paciente pac = new Paciente();

            pac.setNombre_Pa(nombre);
            pac.setId_Paciente_Pa(id);

            return dao.getTablaPacientesxNombreyID(pac);
        }

        /*getTablaPacientesxNombreProvincia
        Busca pacientes activos filtrando por nombre/apellido y por provincia simultáneamente.
        Devuelve un DataTable con los resultados de la búsqueda.*/
        public DataTable getTablaPacientesxNombreProvincia(string nombre, int provincia)
        {
            DaoPaciente dao = new DaoPaciente();
            return dao.getTablaPacientesxNombreProvincia(nombre, provincia);
        }

    }
}