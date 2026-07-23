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
    public class DaoMedico
    {

        AccesoDatos ds = new AccesoDatos();

        /*ExisteMedicoxDNI
        Verifica si existe un médico registrado con el mismo DNI que el
        objeto Medico recibido. Devuelve true si encuentra un registro.*/
        public bool ExisteMedicoxDNI(Medico med)
        {
            string consulta = "SELECT * FROM Medicos WHERE Dni_M = " + med.getDni_M();
            return ds.existe(consulta);
        }

        /*ExisteMedicoxLegajo
        Verifica si existe un médico registrado con el mismo legajo que el
        objeto Medico recibido. Devuelve true si encuentra un registro.*/
        public bool ExisteMedicoxLegajo(Medico med)
        {
            string consulta = "SELECT * FROM Medicos WHERE Legajo_M = " + med.getLegajo_M();
            return ds.existe(consulta);
        }

        /*agregarMedico
        Recibe el objeto Medico y el objeto Usuario asociado, arma los parámetros
        necesarios y ejecuta el procedimiento almacenado que da de alta un médico
        junto con su usuario en la base de datos.*/
        public int agregarMedico(Medico med, Usuario usu)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoAgregar(ref comando, med, usu);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarMedico");
        }

        /*ArmarParametrosMedicoAgregar
        Arma todos los parámetros del médico y del usuario (datos personales,
        contacto, especialidad, localidad y credenciales) necesarios para el
        procedimiento almacenado que da de alta un médico. Se pasa el comando
        por referencia porque se modifica dentro del método.*/
        private void ArmarParametrosMedicoAgregar(ref SqlCommand comando, Medico med, Usuario usu)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Dni_M", SqlDbType.VarChar);
            param.Value = med.getDni_M();
            param = comando.Parameters.Add("@Nombre_M", SqlDbType.VarChar);
            param.Value = med.getNombre_M();
            param = comando.Parameters.Add("@Apellido_M", SqlDbType.VarChar);
            param.Value = med.getApellido_M();
            param = comando.Parameters.Add("@Sexo_M", SqlDbType.Bit);
            param.Value = med.getSexo_M();
            param = comando.Parameters.Add("@Nacionalidad_M", SqlDbType.VarChar);
            param.Value = med.getNacionalidad_M();
            param = comando.Parameters.Add("@Fecha_Nacimiento_M", SqlDbType.Date);
            param.Value = med.getFecha_Nacimiento_M();
            param = comando.Parameters.Add("@Direccion_M", SqlDbType.VarChar);
            param.Value = med.getDireccion_M();
            param = comando.Parameters.Add("@Correo_Electronico_M", SqlDbType.VarChar);
            param.Value = med.getCorreo_Electronico_M();
            param = comando.Parameters.Add("@Telefono_M", SqlDbType.VarChar);
            param.Value = med.getTelefono_M();
            param = comando.Parameters.Add("@Id_Especialidad_M", SqlDbType.Int);
            param.Value = med.getId_Especialidad_M();
            param = comando.Parameters.Add("@Id_Localidad_M", SqlDbType.Int);
            param.Value = med.getId_Localidad_M();
            param = comando.Parameters.Add("@Nombre_U", SqlDbType.VarChar);
            param.Value = usu.getNombre_U();
            param = comando.Parameters.Add("@Contraseña_U", SqlDbType.VarChar);
            param.Value = usu.getContraseña_U();
        }

        /*ArmarParametrosMedicoModificar
        Arma todos los parámetros del médico (datos personales, contacto,
        especialidad, localidad y estado) necesarios para el procedimiento
        almacenado que modifica un médico existente.*/
        private void ArmarParametrosMedicoModificar(ref SqlCommand comando, Medico med)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Legajo_M", SqlDbType.Int);
            param.Value = med.getLegajo_M();
            param = comando.Parameters.Add("@Dni_M", SqlDbType.VarChar);
            param.Value = med.getDni_M();
            param = comando.Parameters.Add("@Nombre_M", SqlDbType.VarChar);
            param.Value = med.getNombre_M();
            param = comando.Parameters.Add("@Apellido_M", SqlDbType.VarChar);
            param.Value = med.getApellido_M();
            param = comando.Parameters.Add("@Sexo_M", SqlDbType.Bit);
            param.Value = med.getSexo_M();
            param = comando.Parameters.Add("@Nacionalidad_M", SqlDbType.VarChar);
            param.Value = med.getNacionalidad_M();
            param = comando.Parameters.Add("@Fecha_Nacimiento_M", SqlDbType.Date);
            param.Value = med.getFecha_Nacimiento_M();
            param = comando.Parameters.Add("@Direccion_M", SqlDbType.VarChar);
            param.Value = med.getDireccion_M();
            param = comando.Parameters.Add("@Correo_Electronico_M", SqlDbType.VarChar);
            param.Value = med.getCorreo_Electronico_M();
            param = comando.Parameters.Add("@Telefono_M", SqlDbType.VarChar);
            param.Value = med.getTelefono_M();
            param = comando.Parameters.Add("@Id_Especialidad_M", SqlDbType.Int);
            param.Value = med.getId_Especialidad_M();
            param = comando.Parameters.Add("@Id_Localidad_M", SqlDbType.Int);
            param.Value = med.getId_Localidad_M();
            param = comando.Parameters.Add("@Activo_M", SqlDbType.Bit);
            param.Value = med.getActivo_M();
        }

        /*ArmarParametrosMedicoEliminar
        Arma el parámetro necesario (Legajo_M) para el procedimiento almacenado
        que da de baja lógica a un médico.*/
        private void ArmarParametrosMedicoEliminar(ref SqlCommand comando, Medico med)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Legajo_M", SqlDbType.Int);
            param.Value = med.getLegajo_M();
        }

        /*eliminarMedico
        Da de baja (lógica) a un médico existente, ejecutando el procedimiento
        almacenado correspondiente.*/
        public int eliminarMedico(Medico med)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoEliminar(ref comando, med);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarMedico");
        }

        /*modificarMedico
        Arma los parámetros a partir de un objeto Medico y ejecuta el
        procedimiento almacenado que actualiza los datos de un médico existente.*/
        public int modificarMedico(Medico med)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoModificar(ref comando, med);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spModificarMedico");
        }

        /*getTablaMedicos
        Obtiene todos los médicos activos junto con su especialidad y provincia,
        mostrando el sexo y el estado en formato legible.*/
        public DataTable getTablaMedicos()
        {
            return ds.ObtenerTabla("Medicos",
                "SELECT m.Legajo_M AS Legajo, m.Dni_M AS DNI, m.Nombre_M AS Nombre, " +
                "m.Apellido_M AS Apellido, " +
                "CASE WHEN m.Sexo_M = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, " +
                "m.Nacionalidad_M AS Nacionalidad, " +
                "m.Fecha_Nacimiento_M AS FechaNacimiento, " +
                "m.Direccion_M AS Direccion, " +
                "m.Correo_Electronico_M AS Correo, " +
                "m.Telefono_M AS Telefono, " +
                "e.Nombre_E AS Especialidad, " +
                "CASE WHEN m.Activo_M = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado, " +
                "p.Nombre_P AS Provincia " +
                "FROM Medicos m " +
                "INNER JOIN Localidades l ON m.Id_Localidad_M = l.Id_Localidad_L " +
                "INNER JOIN Especialidades e ON m.Id_Especialidad_M = e.Id_Especialidad_E " +
                "INNER JOIN Provincias p ON l.Id_Provincia_L = p.Id_Provincia_P " +
                "WHERE m.Activo_M = 1");
        }

        /*getTablaMedicosxLegajo
        Obtiene el detalle completo de un médico activo (incluyendo localidad
        y provincia), buscado por su legajo.*/
        public DataTable getTablaMedicosxLegajo(Medico med)
        {
            return ds.ObtenerTabla("Medicos",
                "SELECT m.Legajo_M AS Legajo, m.Dni_M AS DNI, m.Nombre_M AS Nombre, " +
                "m.Apellido_M AS Apellido, " +
                "CASE WHEN m.Sexo_M = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, " +
                "CONVERT(varchar(10), m.Fecha_Nacimiento_M, 103) AS FechaNacimiento, " +
                "m.Nacionalidad_M AS Nacionalidad, " +
                "p.Nombre_P AS Provincia, " +
                "l.Nombre_L AS Localidad, " +
                "m.Direccion_M AS Direccion, " +
                "m.Correo_Electronico_M AS Correo, " +
                "m.Telefono_M AS Telefono, " +
                "e.Nombre_E AS Especialidad, " +
                "CASE WHEN m.Activo_M = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado, " +
                "m.Id_Especialidad_M AS IdEspecialidad, " +
                "m.Id_Localidad_M AS IdLocalidad, " +
                "l.Id_Provincia_L AS IdProvincia " +
                "FROM Medicos m " +
                "INNER JOIN Localidades l ON m.Id_Localidad_M = l.Id_Localidad_L " +
                "INNER JOIN Especialidades e ON m.Id_Especialidad_M = e.Id_Especialidad_E " +
                "INNER JOIN Provincias p ON l.Id_Provincia_L = p.Id_Provincia_P " +
                "WHERE m.Activo_M = 1 AND m.Legajo_M = " + med.getLegajo_M());
        }

        /*getTablaMedicosxLegajoMod
        Obtiene el detalle completo de un médico (activo o inactivo), buscado
        por su legajo, pensado para precargar el formulario de modificación.*/
        public DataTable getTablaMedicosxLegajoMod(Medico med)
        {
            return ds.ObtenerTabla("Medicos",
                "SELECT m.Legajo_M AS Legajo, m.Dni_M AS DNI, m.Nombre_M AS Nombre, " +
                "m.Apellido_M AS Apellido, " +
                "CASE WHEN m.Sexo_M = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, " +
                "CONVERT(varchar(10), m.Fecha_Nacimiento_M, 103) AS FechaNacimiento, " +
                "m.Nacionalidad_M AS Nacionalidad, " +
                "p.Nombre_P AS Provincia, " +
                "l.Nombre_L AS Localidad, " +
                "m.Direccion_M AS Direccion, " +
                "m.Correo_Electronico_M AS Correo, " +
                "m.Telefono_M AS Telefono, " +
                "e.Nombre_E AS Especialidad, " +
                "CASE WHEN m.Activo_M = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado, " +
                "m.Id_Especialidad_M AS IdEspecialidad, " +
                "m.Id_Localidad_M AS IdLocalidad, " +
                "l.Id_Provincia_L AS IdProvincia " +
                "FROM Medicos m " +
                "INNER JOIN Localidades l ON m.Id_Localidad_M = l.Id_Localidad_L " +
                "INNER JOIN Especialidades e ON m.Id_Especialidad_M = e.Id_Especialidad_E " +
                "INNER JOIN Provincias p ON l.Id_Provincia_L = p.Id_Provincia_P " +
                "WHERE m.Legajo_M = " + med.getLegajo_M());
        }

        /*getTablaMedicosxLegajoBaja
        Obtiene el detalle completo de un médico activo, buscado por su legajo,
        pensado para precargar el formulario de baja.*/
        public DataTable getTablaMedicosxLegajoBaja(Medico med)
        {
            return ds.ObtenerTabla("Medicos",
                "SELECT m.Legajo_M AS Legajo, m.Dni_M AS DNI, m.Nombre_M AS Nombre, " +
                "m.Apellido_M AS Apellido, " +
                "CASE WHEN m.Sexo_M = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, " +
                "CONVERT(varchar(10), m.Fecha_Nacimiento_M, 103) AS FechaNacimiento, " +
                "m.Nacionalidad_M AS Nacionalidad, " +
                "p.Nombre_P AS Provincia, " +
                "l.Nombre_L AS Localidad, " +
                "m.Direccion_M AS Direccion, " +
                "m.Correo_Electronico_M AS Correo, " +
                "m.Telefono_M AS Telefono, " +
                "e.Nombre_E AS Especialidad, " +
                "CASE WHEN m.Activo_M = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado " +
                "FROM Medicos m " +
                "INNER JOIN Localidades l ON m.Id_Localidad_M = l.Id_Localidad_L " +
                "INNER JOIN Especialidades e ON m.Id_Especialidad_M = e.Id_Especialidad_E " +
                "INNER JOIN Provincias p ON l.Id_Provincia_L = p.Id_Provincia_P " +
                "WHERE m.Activo_M = 1 AND m.Legajo_M = " + med.getLegajo_M());
        }

        /*getTablaMedicosxNombre
        Obtiene los médicos activos cuyo nombre y apellido combinados coincidan
        (parcialmente) con el nombre del objeto Medico recibido.*/
        public DataTable getTablaMedicosxNombre(Medico med)
        {
            return ds.ObtenerTabla("Medicos",
                "SELECT m.Legajo_M AS Legajo, m.Dni_M AS DNI, m.Nombre_M AS Nombre, " +
                "m.Apellido_M AS Apellido, " +
                "CASE WHEN m.Sexo_M = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, " +
                "m.Nacionalidad_M AS Nacionalidad, " +
                "m.Fecha_Nacimiento_M AS FechaNacimiento, " +
                "m.Direccion_M AS Direccion, " +
                "m.Correo_Electronico_M AS Correo, " +
                "m.Telefono_M AS Telefono, " +
                "e.Nombre_E AS Especialidad, " +
                "CASE WHEN m.Activo_M = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado, " +
                "p.Nombre_P AS Provincia " +
                "FROM Medicos m " +
                "INNER JOIN Localidades l ON m.Id_Localidad_M = l.Id_Localidad_L " +
                "INNER JOIN Especialidades e ON m.Id_Especialidad_M = e.Id_Especialidad_E " +
                "INNER JOIN Provincias p ON l.Id_Provincia_L = p.Id_Provincia_P " +
                "WHERE m.Activo_M = 1 AND (m.Nombre_M + ' ' + m.Apellido_M) LIKE '%" + med.getNombre_M() + "%'");
        }

        /*getTablaMedicosInactivos
        Obtiene todos los médicos inactivos (dados de baja) junto con su
        especialidad y provincia.*/
        public DataTable getTablaMedicosInactivos()
        {
            return ds.ObtenerTabla("Medicos",
                "SELECT m.Legajo_M AS Legajo, m.Dni_M AS DNI, m.Nombre_M AS Nombre, " +
                "m.Apellido_M AS Apellido, " +
                "CASE WHEN m.Sexo_M = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, " +
                "m.Nacionalidad_M AS Nacionalidad, " +
                "CONVERT(varchar(10), m.Fecha_Nacimiento_M, 103) AS FechaNacimiento, " +
                "m.Direccion_M AS Direccion, " +
                "m.Correo_Electronico_M AS Correo, " +
                "m.Telefono_M AS Telefono, " +
                "e.Nombre_E AS Especialidad, " +
                "CASE WHEN m.Activo_M = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado, " +
                "p.Nombre_P AS Provincia " +
                "FROM Medicos m " +
                "INNER JOIN Localidades l ON m.Id_Localidad_M = l.Id_Localidad_L " +
                "INNER JOIN Especialidades e ON m.Id_Especialidad_M = e.Id_Especialidad_E " +
                "INNER JOIN Provincias p ON l.Id_Provincia_L = p.Id_Provincia_P " +
                "WHERE m.Activo_M = 0");
        }

        /*getTablaMedicosInactivosxLegajo
        Obtiene el detalle de un médico inactivo en particular, buscado
        por su legajo.*/
        public DataTable getTablaMedicosInactivosxLegajo(Medico med)
        {
            return ds.ObtenerTabla("Medicos",
                "SELECT m.Legajo_M AS Legajo," +
                " m.Dni_M AS DNI," +
                " m.Nombre_M AS Nombre, " +
                "m.Apellido_M AS Apellido, " +
                "CASE WHEN m.Sexo_M = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, " +
                "m.Nacionalidad_M AS Nacionalidad, " +
                "CONVERT(varchar(10), m.Fecha_Nacimiento_M, 103) AS FechaNacimiento, " +
                "m.Direccion_M AS Direccion, " +
                "m.Correo_Electronico_M AS Correo, " +
                "m.Telefono_M AS Telefono, " +
                "e.Nombre_E AS Especialidad, " +
                "CASE WHEN m.Activo_M = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado, " +
                "p.Nombre_P AS Provincia " +
                "FROM Medicos m " +
                "INNER JOIN Localidades l ON m.Id_Localidad_M = l.Id_Localidad_L " +
                "INNER JOIN Especialidades e ON m.Id_Especialidad_M = e.Id_Especialidad_E " +
                "INNER JOIN Provincias p ON l.Id_Provincia_L = p.Id_Provincia_P " +
                "WHERE m.Activo_M = 0 AND m.Legajo_M = " + med.getLegajo_M());
        }

        /*getTablaMedicosxProvincia
        Obtiene los médicos activos que pertenezcan a la provincia
        recibida por Id.*/
        public DataTable getTablaMedicosxProvincia(int idProvincia)
        {
            return ds.ObtenerTabla("Medicos",
                "SELECT m.Legajo_M AS Legajo, m.Dni_M AS DNI, m.Nombre_M AS Nombre, " +
                "m.Apellido_M AS Apellido, " +
                "CASE WHEN m.Sexo_M = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, " +
                "m.Nacionalidad_M AS Nacionalidad, " +
                "m.Fecha_Nacimiento_M AS FechaNacimiento, " +
                "m.Direccion_M AS Direccion, " +
                "m.Correo_Electronico_M AS Correo, " +
                "m.Telefono_M AS Telefono, " +
                "e.Nombre_E AS Especialidad, " +
                "CASE WHEN m.Activo_M = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado, " +
                "p.Nombre_P AS Provincia " +
                "FROM Medicos m " +
                "INNER JOIN Localidades l ON m.Id_Localidad_M = l.Id_Localidad_L " +
                "INNER JOIN Especialidades e ON m.Id_Especialidad_M = e.Id_Especialidad_E " +
                "INNER JOIN Provincias p ON l.Id_Provincia_L = p.Id_Provincia_P " +
                "WHERE m.Activo_M = 1 AND l.Id_Provincia_L = " + idProvincia);
        }

        /*getTablaMedicosxEspecialidad
        Obtiene el legajo y nombre completo de los médicos activos que
        pertenezcan a la especialidad del objeto Medico recibido.*/
        public DataTable getTablaMedicosxEspecialidad(Medico med)
        {
            string sql = "SELECT Legajo_M, (Nombre_M + ' ' + Apellido_M) AS NombreCompleto " +
                         "FROM Medicos WHERE Id_Especialidad_M = " + med.getId_Especialidad_M() +
                         " AND Activo_M = 1";

            return ds.ObtenerTabla("Medicos", sql);
        }

        /*reactivarMedico
        Reactiva un médico previamente dado de baja, ejecutando el
        procedimiento almacenado correspondiente.*/
        public int reactivarMedico(Medico med)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosMedicoReactivar(ref comando, med);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spReactivarMedico");
        }

        /*ArmarParametrosMedicoReactivar
        Arma el parámetro necesario (Legajo_M) para el procedimiento
        almacenado que reactiva a un médico.*/
        private void ArmarParametrosMedicoReactivar(ref SqlCommand comando, Medico med)
        {
            SqlParameter param = new SqlParameter();
            param = comando.Parameters.Add("@Legajo_M", SqlDbType.Int);
            param.Value = med.getLegajo_M();

        }

        /*ExisteMedicoInactivo
        Verifica si existe un médico inactivo con el legajo del objeto
        Medico recibido. Devuelve true si encuentra un registro.*/
        public bool ExisteMedicoInactivo(Medico med)
        {
            string consulta = "SELECT * FROM Medicos WHERE Legajo_M = " + med.getLegajo_M() + " AND Activo_M = 0";
            return ds.existe(consulta);
        }

        /*getLegajoPorIdUsuario
        Obtiene el legajo del médico asociado a un Id de usuario.
        Devuelve 0 si no se encuentra ningún registro.*/
        public int getLegajoPorIdUsuario(int idUsuario)
        {
            DataTable tabla = ds.ObtenerTabla("Medicos",
                "SELECT Legajo_M FROM Medicos WHERE Id_Usuario_M = " + idUsuario);

            if (tabla.Rows.Count > 0)
                return Convert.ToInt32(tabla.Rows[0]["Legajo_M"]);
            else
                return 0;
        }

        /*getTablaMedicosxNombreyLegajo
        Obtiene los médicos activos filtrando simultáneamente por nombre/apellido
        (coincidencia parcial) y por legajo exacto.*/
        public DataTable getTablaMedicosxNombreyLegajo(Medico med)
        {
            return ds.ObtenerTabla("Medicos",
                "SELECT m.Legajo_M AS Legajo, m.Dni_M AS DNI, m.Nombre_M AS Nombre, " +
                "m.Apellido_M AS Apellido, " +
                "CASE WHEN m.Sexo_M = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo, " +
                "m.Nacionalidad_M AS Nacionalidad, " +
                "m.Fecha_Nacimiento_M AS FechaNacimiento, " +
                "m.Direccion_M AS Direccion, " +
                "m.Correo_Electronico_M AS Correo, " +
                "m.Telefono_M AS Telefono, " +
                "e.Nombre_E AS Especialidad, " +
                "CASE WHEN m.Activo_M = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado, " +
                "p.Nombre_P AS Provincia " +
                "FROM Medicos m " +
                "INNER JOIN Localidades l ON m.Id_Localidad_M = l.Id_Localidad_L " +
                "INNER JOIN Especialidades e ON m.Id_Especialidad_M = e.Id_Especialidad_E " +
                "INNER JOIN Provincias p ON l.Id_Provincia_L = p.Id_Provincia_P " +
                "WHERE m.Activo_M = 1 " +
                "AND (m.Nombre_M + ' ' + m.Apellido_M) LIKE '%" + med.getNombre_M() + "%' " +
                "AND m.Legajo_M = " + med.getLegajo_M());
        }

        /*getTablaMedicosxNombreProvincia
        Obtiene los médicos activos que coincidan (parcialmente) con el nombre,
        apellido o nombre completo recibido y filtrando además por provincia.*/
        public DataTable getTablaMedicosxNombreProvincia(string nombre, int provincia)
        {
            string consulta = @"
                SELECT 
                    m.Legajo_M AS Legajo,
                    m.Dni_M AS DNI,
                    m.Nombre_M AS Nombre,
                    m.Apellido_M AS Apellido,
                    CASE WHEN m.Sexo_M = 1 THEN 'Masculino' ELSE 'Femenino' END AS Sexo,
                    m.Nacionalidad_M AS Nacionalidad,
                    m.Fecha_Nacimiento_M AS FechaNacimiento,
                    m.Direccion_M AS Direccion,
                    m.Correo_Electronico_M AS Correo,
                    m.Telefono_M AS Telefono,
                    e.Nombre_E AS Especialidad,
                    CASE WHEN m.Activo_M = 1 THEN 'Activo' ELSE 'No Activo' END AS Estado, 
                    p.Nombre_P AS Provincia
                FROM Medicos m
                INNER JOIN Localidades l 
                    ON m.Id_Localidad_M = l.Id_Localidad_L
                INNER JOIN Especialidades e 
                    ON m.Id_Especialidad_M = e.Id_Especialidad_E
                INNER JOIN Provincias p
                    ON l.Id_Provincia_L = p.Id_Provincia_P
                WHERE m.Activo_M = 1
                AND (
                    m.Nombre_M LIKE '%" + nombre + @"%'
                    OR m.Apellido_M LIKE '%" + nombre + @"%'
                    OR (m.Nombre_M + ' ' + m.Apellido_M) LIKE '%" + nombre + @"%'
                )
                AND p.Id_Provincia_P = " + provincia;

            return ds.ObtenerTabla("Medicos", consulta);
        }
    }
}