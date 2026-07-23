using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    internal class AccesoDatos
    {
        String rutaBDSucursales = @"Data Source=LEONARDO-PC\SQLEXPRESS;Initial Catalog=BDClinica;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public AccesoDatos()
        {
            /*Constructor de la clase. Actualmente no requiere inicialización adicional.*/
        }

        /*ObtenerConexion
        Abre y devuelve una conexión activa (SqlConnection) hacia la base de datos.
        Si ocurre un error durante la apertura, se captura la excepción y se retorna null.*/
        private SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(rutaBDSucursales);
            try
            {
                cn.Open();
                return cn;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /*ObtenerAdaptador
        Crea un SqlDataAdapter a partir de una consulta SQL y una conexión ya abierta.
        El adaptador se encarga de traer los datos desde la base de datos y volcarlos
        en un DataSet, que es un conjunto de tablas manipulables en memoria sin necesidad
        de mantener la conexión activa mientras se trabaja con los datos.*/
        private SqlDataAdapter ObtenerAdaptador(String consultaSql, SqlConnection cn)
        {
            SqlDataAdapter adaptador;
            /*Se utiliza try/catch (y no un if) porque acá se busca capturar errores
             que pueden ocurrir en tiempo de ejecución (por ejemplo, que la base de
             datos no esté disponible), a diferencia de un if, que evalúa condiciones
             conocidas en tiempo de compilación.*/
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, cn);
                return adaptador;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /*ObtenerTabla
        Ejecuta una consulta SQL y devuelve el resultado como un DataTable.
        Internamente abre la conexión, llena un DataSet con la tabla solicitada
        y cierra la conexión antes de retornar el resultado.*/
        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet ds = new DataSet(); /*Contendrá la tabla traída desde la base de datos*/
            SqlConnection Conexion = ObtenerConexion(); /*Se obtiene la conexión a la base de datos*/
            SqlDataAdapter adp = ObtenerAdaptador(Sql, Conexion);
            adp.Fill(ds, NombreTabla);
            Conexion.Close();
            return ds.Tables[NombreTabla];
        }

        /*EjecutarProcedimientoAlmacenado
        Ejecuta un procedimiento almacenado (Stored Procedure) sobre la base de datos
        utilizando el SqlCommand recibido, y devuelve la cantidad de filas afectadas.*/
        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }

        /*existe
        Verifica si una consulta SQL devuelve al menos un registro.
        Retorna true si existe al menos una fila, false en caso contrario.*/
        public Boolean existe(String consulta)
        {
            Boolean estado = false;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand(consulta, Conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                estado = true;
            }
            return estado;
        }
    }
}