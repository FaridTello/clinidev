using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DaoPaciente
    {
        AccesoDatos ds = new AccesoDatos();

        /*getTablaPacientes
        Obtiene todos los pacientes activos con sus datos principales,
        mostrando el sexo y el estado en formato legible.*/
        public DataTable getTablaPacientes()
        {
            return ds.ObtenerTabla("Pacientes", "SELECT Id_Paciente_Pa AS ID, Dni_Pa AS DNI, Nombre_Pa AS Nombre, Apellido_Pa AS Apellido, CASE WHEN Sexo_Pa = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, Nacionalidad_Pa AS Nacionalidad, Fecha_Nacimiento_Pa AS FechaNacimiento, Direccion_Pa AS Direccion, Correo_Electronico_Pa AS Correo, Telefono_Pa AS Telefono, CASE WHEN Activo_Pa = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado FROM Pacientes WHERE Activo_Pa = 1");
        }

        /*getTablaPacientesxNombre
        Busca pacientes activos cuyo nombre, apellido o nombre completo
        coincidan parcialmente con el filtro recibido.*/
        public DataTable getTablaPacientesxNombre(Paciente pac)
        {
            return ds.ObtenerTabla("Pacientes", "SELECT Id_Paciente_Pa AS ID, Dni_Pa AS DNI, Nombre_Pa AS Nombre, Apellido_Pa AS Apellido, CASE WHEN Sexo_Pa = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, Nacionalidad_Pa AS Nacionalidad, Fecha_Nacimiento_Pa AS FechaNacimiento, Direccion_Pa AS Direccion, Correo_Electronico_Pa AS Correo, Telefono_Pa AS Telefono, CASE WHEN Activo_Pa = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado FROM Pacientes WHERE Activo_Pa = 1 AND (Nombre_Pa LIKE '%" + pac.getNombre_Pa() + "%' OR Apellido_Pa LIKE '%" + pac.getNombre_Pa() + "%' OR (Nombre_Pa + ' ' + Apellido_Pa) LIKE '%" + pac.getNombre_Pa() + "%')");
        }

        /*getTablaPacientesxDNI
        Obtiene los datos completos de pacientes activos (incluyendo localidad
        y provincia) cuyo DNI coincida parcialmente con el filtro recibido.*/
        public DataTable getTablaPacientesxDNI(Paciente pac)
        {
            string consultaSQL = @"SELECT 
                Id_Paciente_Pa AS ID, 
                Dni_Pa AS DNI, 
                Nombre_Pa AS Nombre, 
                Apellido_Pa AS Apellido, 
                CASE WHEN Sexo_Pa = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, 
                Nacionalidad_Pa AS Nacionalidad, 
                Fecha_Nacimiento_Pa AS FechaNacimiento, 
                Direccion_Pa AS Direccion, 
                Correo_Electronico_Pa AS Correo, 
                Telefono_Pa AS Telefono,
                Id_Localidad_Pa, 
                Id_Provincia_L AS IdProvincia, 
                Nombre_L AS Localidad, 
                Nombre_P AS Provincia 
            FROM Pacientes 
            INNER JOIN Localidades ON Id_Localidad_Pa = Id_Localidad_L 
            INNER JOIN Provincias ON Id_Provincia_L = Id_Provincia_P 
            WHERE Activo_Pa = 1 AND Dni_Pa LIKE '%" + pac.getDni_Pa() + "%'";

            return ds.ObtenerTabla("Pacientes", consultaSQL);
        }

        /*getTablaPacientesxID
        Obtiene el detalle completo de un paciente activo (incluyendo localidad
        y provincia), buscado por su ID.*/
        public DataTable getTablaPacientesxID(Paciente pac)
        {
            string consultaSQL = @"SELECT 
                Id_Paciente_Pa AS ID, 
                Dni_Pa AS DNI, 
                Nombre_Pa AS Nombre, 
                Apellido_Pa AS Apellido, 
                CASE WHEN Sexo_Pa = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, 
                Nacionalidad_Pa AS Nacionalidad, 
                CONVERT(varchar(10), Fecha_Nacimiento_Pa, 103) AS FechaNacimiento, 
                Direccion_Pa AS Direccion, 
                Correo_Electronico_Pa AS Correo, 
                Telefono_Pa AS Telefono,
                Id_Localidad_Pa, 
                Id_Provincia_L AS IdProvincia, 
                Nombre_L AS Localidad, 
                Nombre_P AS Provincia,
                CASE WHEN Activo_Pa = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado
            FROM Pacientes 
            INNER JOIN Localidades ON Id_Localidad_Pa = Id_Localidad_L 
            INNER JOIN Provincias ON Id_Provincia_L = Id_Provincia_P 
            WHERE Activo_Pa = 1 AND Id_Paciente_Pa = " + pac.getId_Paciente_Pa();

            return ds.ObtenerTabla("Pacientes", consultaSQL);
        }

        /*getTablaPacientesxIDBaja
        Obtiene el detalle de un paciente activo por su ID, pensado para
        precargar el formulario de baja.*/
        public DataTable getTablaPacientesxIDBaja(int id)
        {
            string consultaSQL = @"SELECT 
        Id_Paciente_Pa AS ID, 
        Dni_Pa AS DNI, 
        Nombre_Pa AS Nombre, 
        Apellido_Pa AS Apellido, 
        CASE WHEN Sexo_Pa = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, 
        Nacionalidad_Pa AS Nacionalidad, 
        Fecha_Nacimiento_Pa AS FechaNacimiento, 
        Direccion_Pa AS Direccion, 
        Correo_Electronico_Pa AS Correo, 
        Telefono_Pa AS Telefono,
        Nombre_L AS Localidad, 
        Nombre_P AS Provincia,
        CASE WHEN Activo_Pa = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado
        FROM Pacientes 
        INNER JOIN Localidades ON Id_Localidad_Pa = Id_Localidad_L 
        INNER JOIN Provincias ON Id_Provincia_L = Id_Provincia_P 
        WHERE Activo_Pa = 1 AND Id_Paciente_Pa = " + id;

            return ds.ObtenerTabla("Pacientes", consultaSQL);
        }

        /*getTablaPacientesxIDMod
        Obtiene el detalle completo de un paciente activo por su ID, pensado
        para precargar el formulario de modificación.*/
        public DataTable getTablaPacientesxIDMod(int id)
        {
            string consultaSQL = @"SELECT 
                Id_Paciente_Pa AS ID, 
                Dni_Pa AS DNI, 
                Nombre_Pa AS Nombre, 
                Apellido_Pa AS Apellido, 
                CASE WHEN Sexo_Pa = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, 
                Nacionalidad_Pa AS Nacionalidad, 
                CONVERT(varchar(10), Fecha_Nacimiento_Pa, 103) AS FechaNacimiento, 
                Direccion_Pa AS Direccion, 
                Correo_Electronico_Pa AS Correo, 
                Telefono_Pa AS Telefono,
                Id_Localidad_Pa, 
                Id_Provincia_L AS IdProvincia, 
                Nombre_L AS Localidad, 
                Nombre_P AS Provincia,
                CASE WHEN Activo_Pa = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado
                FROM Pacientes 
                INNER JOIN Localidades ON Id_Localidad_Pa = Id_Localidad_L 
                INNER JOIN Provincias ON Id_Provincia_L = Id_Provincia_P 
                WHERE Activo_Pa = 1 AND Id_Paciente_Pa = " + id;

            return ds.ObtenerTabla("Pacientes", consultaSQL);
        }

        /*getTablaPacientesxProvincia
        Obtiene los pacientes activos que pertenezcan a la provincia
        del objeto Paciente recibido.*/
        public DataTable getTablaPacientesxProvincia(Paciente pac)
        {
            return ds.ObtenerTabla("Pacientes", "SELECT Id_Paciente_Pa AS ID, Dni_Pa AS DNI, Nombre_Pa AS Nombre, Apellido_Pa AS Apellido, CASE WHEN Sexo_Pa = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, Nacionalidad_Pa AS Nacionalidad, Fecha_Nacimiento_Pa AS FechaNacimiento, Direccion_Pa AS Direccion, Correo_Electronico_Pa AS Correo, Telefono_Pa AS Telefono, CASE WHEN Activo_Pa = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado FROM Pacientes INNER JOIN Localidades ON Pacientes.Id_Localidad_Pa = Localidades.Id_Localidad_L WHERE Activo_Pa = 1 AND Localidades.Id_Provincia_L = " + pac.getId_Localidad_Pa());
        }

        /*getTablaPacientesInactivosxLegajo
        Obtiene el detalle de un paciente inactivo por su ID, pensado
        para consulta de pacientes dados de baja.*/
        public DataTable getTablaPacientesInactivosxLegajo(Paciente pac)
        {
            return ds.ObtenerTabla("Pacientes", "SELECT Id_Paciente_Pa AS ID, Dni_Pa AS DNI, Nombre_Pa AS Nombre, Apellido_Pa AS Apellido,CASE WHEN Sexo_Pa = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, Nacionalidad_Pa AS Nacionalidad, Fecha_Nacimiento_Pa AS FechaNacimiento, Direccion_Pa AS Direccion, Correo_Electronico_Pa AS Correo, Telefono_Pa AS Telefono FROM Pacientes WHERE Activo_Pa = 0 AND Id_Paciente_Pa = " + pac.getId_Paciente_Pa());
        }

        /*ExistePacientexDNI
        Verifica si existe un paciente con el DNI del objeto Paciente recibido.
        Devuelve true si encuentra un registro.*/
        public bool ExistePacientexDNI(Paciente pac)
        {
            string consulta = "SELECT * FROM Pacientes WHERE Dni_Pa = '" + pac.getDni_Pa() + "'";
            return ds.existe(consulta);
        }

        /*ExistePacientexID
        Verifica si existe un paciente activo con el ID del objeto Paciente recibido.
        Devuelve true si encuentra un registro.*/
        public bool ExistePacientexID(Paciente pac)
        {
            string consulta = "SELECT * FROM Pacientes WHERE Id_Paciente_Pa = " + pac.getId_Paciente_Pa() + " AND Activo_Pa = 1";
            return ds.existe(consulta);
        }

        /*reactivarPaciente
        Reactiva un paciente previamente dado de baja, ejecutando el
        procedimiento almacenado correspondiente.*/
        public int reactivarPaciente(Paciente pac)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPacienteReactivar(ref comando, pac);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spReactivarPaciente");
        }

        /*ArmarParametrosPacienteReactivar
        Arma el parámetro necesario (Id_Paciente_Pa) para el procedimiento
        almacenado que reactiva a un paciente.*/
        private void ArmarParametrosPacienteReactivar(ref SqlCommand comando, Paciente pac)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Paciente_Pa", SqlDbType.Int);
            param.Value = pac.getId_Paciente_Pa();
        }

        /*ExistePacienteInactivo
        Verifica si existe un paciente inactivo con el ID del objeto
        Paciente recibido. Devuelve true si encuentra un registro.*/
        public bool ExistePacienteInactivo(Paciente pac)
        {
            string consulta = "SELECT * FROM Pacientes WHERE Id_Paciente_Pa = " + pac.getId_Paciente_Pa() + " AND Activo_Pa = 0";
            return ds.existe(consulta);
        }

        /*agregarPaciente
        Arma los parámetros a partir de un objeto Paciente y ejecuta el
        procedimiento almacenado que da de alta un nuevo paciente.*/
        public int agregarPaciente(Paciente pac)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPacienteAgregar(ref comando, pac);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarPaciente");
        }

        /*ArmarParametrosPacienteAgregar
        Arma todos los parámetros del paciente (datos personales, contacto
        y localidad) necesarios para el procedimiento almacenado que da
        de alta un paciente.*/
        private void ArmarParametrosPacienteAgregar(ref SqlCommand comando, Paciente pac)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Dni_Pa", SqlDbType.VarChar);
            param.Value = pac.getDni_Pa();
            param = comando.Parameters.Add("@Nombre_Pa", SqlDbType.VarChar);
            param.Value = pac.getNombre_Pa();
            param = comando.Parameters.Add("@Apellido_Pa", SqlDbType.VarChar);
            param.Value = pac.getApellido_Pa();
            param = comando.Parameters.Add("@Sexo_Pa", SqlDbType.Bit);
            param.Value = pac.getSexo_Pa();
            param = comando.Parameters.Add("@Nacionalidad_Pa", SqlDbType.VarChar);
            param.Value = pac.getNacionalidad_Pa();
            param = comando.Parameters.Add("@Fecha_Nacimiento_Pa", SqlDbType.Date);
            param.Value = pac.getFecha_Nacimiento_Pa();
            param = comando.Parameters.Add("@Direccion_Pa", SqlDbType.VarChar);
            param.Value = pac.getDireccion_Pa();
            param = comando.Parameters.Add("@Correo_Electronico_Pa", SqlDbType.VarChar);
            param.Value = pac.getCorreo_Electronico_Pa();
            param = comando.Parameters.Add("@Telefono_Pa", SqlDbType.VarChar);
            param.Value = pac.getTelefono_Pa();
            param = comando.Parameters.Add("@Id_Localidad_Pa", SqlDbType.Int);
            param.Value = pac.getId_Localidad_Pa();
        }

        /*eliminarPaciente
        Da de baja (lógica) a un paciente existente, ejecutando el
        procedimiento almacenado correspondiente.*/
        public int eliminarPaciente(Paciente pac)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPacienteEliminar(ref comando, pac);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarPaciente");
        }

        /*ArmarParametrosPacienteEliminar
        Arma el parámetro necesario (Id_Paciente_Pa) para el procedimiento
        almacenado que da de baja a un paciente.*/
        private void ArmarParametrosPacienteEliminar(ref SqlCommand comando, Paciente pac)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Paciente_Pa", SqlDbType.Int);
            param.Value = pac.getId_Paciente_Pa();
        }

        /*modificarPaciente
        Arma los parámetros a partir de un objeto Paciente y ejecuta el
        procedimiento almacenado que actualiza los datos de un paciente
        existente.*/
        public int modificarPaciente(Paciente pac)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosPacienteModificar(ref comando, pac);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spModificarPaciente");
        }

        /*ArmarParametrosPacienteModificar
        Arma todos los parámetros del paciente (datos personales, contacto
        y localidad) necesarios para el procedimiento almacenado que
        modifica un paciente existente.*/
        private void ArmarParametrosPacienteModificar(ref SqlCommand comando, Paciente pac)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Id_Paciente_Pa", SqlDbType.Int);
            param.Value = pac.getId_Paciente_Pa();
            param = comando.Parameters.Add("@Dni_Pa", SqlDbType.VarChar);
            param.Value = pac.getDni_Pa();
            param = comando.Parameters.Add("@Nombre_Pa", SqlDbType.VarChar);
            param.Value = pac.getNombre_Pa();
            param = comando.Parameters.Add("@Apellido_Pa", SqlDbType.VarChar);
            param.Value = pac.getApellido_Pa();
            param = comando.Parameters.Add("@Sexo_Pa", SqlDbType.Bit);
            param.Value = pac.getSexo_Pa();
            param = comando.Parameters.Add("@Nacionalidad_Pa", SqlDbType.VarChar);
            param.Value = pac.getNacionalidad_Pa();
            param = comando.Parameters.Add("@Fecha_Nacimiento_Pa", SqlDbType.Date);
            param.Value = pac.getFecha_Nacimiento_Pa();
            param = comando.Parameters.Add("@Direccion_Pa", SqlDbType.VarChar);
            param.Value = pac.getDireccion_Pa();
            param = comando.Parameters.Add("@Correo_Electronico_Pa", SqlDbType.VarChar);
            param.Value = pac.getCorreo_Electronico_Pa();
            param = comando.Parameters.Add("@Telefono_Pa", SqlDbType.VarChar);
            param.Value = pac.getTelefono_Pa();
            param = comando.Parameters.Add("@Id_Localidad_Pa", SqlDbType.Int);
            param.Value = pac.getId_Localidad_Pa();
        }

        /*getTablaPacientesActivos
        Obtiene el ID y nombre completo de todos los pacientes activos,
        útil para listados o combos.*/
        public DataTable getTablaPacientesActivos()
        {
            string sql = "SELECT Id_Paciente_Pa, (Nombre_Pa + ' ' + Apellido_Pa) AS NombreCompleto " +
                         "FROM Pacientes WHERE Activo_Pa = 1";

            return ds.ObtenerTabla("Pacientes", sql);
        }

        /*getTablaPacientesxNombreyID
        Busca pacientes activos filtrando simultáneamente por nombre/apellido
        (coincidencia parcial) y por ID exacto.*/
        public DataTable getTablaPacientesxNombreyID(Paciente pac)
        {
            return ds.ObtenerTabla("Pacientes",
                "SELECT Id_Paciente_Pa AS ID, Dni_Pa AS DNI, Nombre_Pa AS Nombre, " +
                "Apellido_Pa AS Apellido, " +
                "CASE WHEN Sexo_Pa = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, " +
                "Nacionalidad_Pa AS Nacionalidad, " +
                "Fecha_Nacimiento_Pa AS FechaNacimiento, " +
                "Direccion_Pa AS Direccion, " +
                "Correo_Electronico_Pa AS Correo, " +
                "Telefono_Pa AS Telefono " +
                "FROM Pacientes " +
                "WHERE Activo_Pa = 1 " +
                "AND (Nombre_Pa LIKE '%" + pac.getNombre_Pa() + "%' " +
                "OR Apellido_Pa LIKE '%" + pac.getNombre_Pa() + "%' " +
                "OR (Nombre_Pa + ' ' + Apellido_Pa) LIKE '%" + pac.getNombre_Pa() + "%') " +
                "AND Id_Paciente_Pa = " + pac.getId_Paciente_Pa());
        }

        /*getTablaPacientesxNombreProvincia
        Obtiene los pacientes activos que coincidan (parcialmente) con el nombre,
        apellido o nombre completo recibido, filtrando además por provincia.*/
        public DataTable getTablaPacientesxNombreProvincia(string nombre, int provincia)
        {
            string consulta = @"SELECT 
            Id_Paciente_Pa AS ID,
            Dni_Pa AS DNI,
            Nombre_Pa AS Nombre,
            Apellido_Pa AS Apellido,
            CASE WHEN Sexo_Pa = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo,
            Nacionalidad_Pa AS Nacionalidad,
            Fecha_Nacimiento_Pa AS FechaNacimiento,
            Direccion_Pa AS Direccion,
            Correo_Electronico_Pa AS Correo,
            Telefono_Pa AS Telefono,
            CASE WHEN Activo_Pa = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado
            FROM Pacientes
            INNER JOIN Localidades 
            ON Pacientes.Id_Localidad_Pa = Localidades.Id_Localidad_L
            WHERE Activo_Pa = 1
            AND (
                Nombre_Pa LIKE '%" + nombre + @"%'
                OR Apellido_Pa LIKE '%" + nombre + @"%'
                OR (Nombre_Pa + ' ' + Apellido_Pa) LIKE '%" + nombre + @"%'
            )
            AND Localidades.Id_Provincia_L = " + provincia;

            return ds.ObtenerTabla("Pacientes", consulta);
        }
    }
}