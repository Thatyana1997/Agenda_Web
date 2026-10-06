using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAgenda.Modelos;

namespace WebAgenda.Repositorios
{
    public class ContactoRepositorio
    {
        private readonly string _cadenaConexion;

        public ContactoRepositorio()
        {
            _cadenaConexion = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        }

        public ContactoRepositorio(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public int Crear(Contactos contacto)
        {
            using (SqlConnection conexion =
                   new SqlConnection(_cadenaConexion))
            {
                using (SqlCommand comando =
                       new SqlCommand("sp_CrearContacto", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 100).Value = contacto.NOMBRE;
                    comando.Parameters.Add("@APELLIDO", SqlDbType.VarChar, 100).Value = contacto.APELLIDO;
                    comando.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 30).Value =
                                               string.IsNullOrWhiteSpace(
                                               contacto.TELEFONO)
                                               ? (object)DBNull.Value
                                               : contacto.TELEFONO;
                    comando.Parameters.Add("@CORREO", SqlDbType.VarChar, 150).Value =
                                            string.IsNullOrWhiteSpace(
                                                contacto.CORREO)
                                                ? (object)DBNull.Value
                                                : contacto.CORREO;
                    comando.Parameters.Add("@ADICIONADO_POR", SqlDbType.VarChar, 50).Value = contacto.ADICIONADO_POR;
                    conexion.Open();
                    object resultado = comando.ExecuteScalar();
                    return Convert.ToInt32(resultado);
                }
            }
        }

        public List<Contactos> ConsultarTodos()
        {
            List<Contactos> lista = new List<Contactos>();
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("sp_ConsultarContactos", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(new Contactos
                            {
                                ID_CONTACTO = Convert.ToInt32(lector["ID_CONTACTO"]),
                                NOMBRE = Convert.ToString(lector["NOMBRE"]),
                                APELLIDO = Convert.ToString(lector["APELLIDO"]),
                                TELEFONO = lector["TELEFONO"] == DBNull.Value
                                                                ? null
                                                                : Convert.ToString(lector["TELEFONO"]),
                                CORREO = lector["CORREO"] == DBNull.Value
                                                            ? null
                                                            : Convert.ToString(lector["CORREO"]),
                                FECHA_ADICION = Convert.ToDateTime(lector["FECHA_ADICION"]),
                                ADICIONADO_POR = Convert.ToString(lector["ADICIONADO_POR"]),
                                FECHA_MODIFICACION = lector["FECHA_MODIFICACION"] == DBNull.Value
                                                                                    ? (DateTime?)null
                                                                                    : Convert.ToDateTime(lector["FECHA_MODIFICACION"]),
                                MODIFICADO_POR = lector["MODIFICADO_POR"] == DBNull.Value
                                                                            ? null
                                                                            : Convert.ToString(lector["MODIFICADO_POR"])
                            });
                        }
                    }
                }
            }
            return lista;
        }

        public List<Contactos> ConsultarPorTelefono(string telefono)
        {
            List<Contactos> lista = new List<Contactos>();
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("sp_ConsultarContactoPorTelefono", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 30).Value = telefono;
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(new Contactos
                            {
                                ID_CONTACTO = Convert.ToInt32(lector["ID_CONTACTO"]),
                                NOMBRE = Convert.ToString(lector["NOMBRE"]),
                                APELLIDO = Convert.ToString(lector["APELLIDO"]),
                                TELEFONO = lector["TELEFONO"] == DBNull.Value
                                                                ? null
                                                                : Convert.ToString(lector["TELEFONO"]),
                                CORREO = lector["CORREO"] == DBNull.Value
                                                            ? null
                                                            : Convert.ToString(lector["CORREO"]),
                                FECHA_ADICION = Convert.ToDateTime(lector["FECHA_ADICION"]),
                                ADICIONADO_POR = Convert.ToString(lector["ADICIONADO_POR"]),
                                FECHA_MODIFICACION = lector["FECHA_MODIFICACION"] == DBNull.Value
                                                                                    ? (DateTime?)null
                                                                                    : Convert.ToDateTime(lector["FECHA_MODIFICACION"]),
                                MODIFICADO_POR = lector["MODIFICADO_POR"] == DBNull.Value
                                                                            ? null
                                                                            : Convert.ToString(lector["MODIFICADO_POR"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public List<Contactos> ConsultarPorCorreo(string correo)
        {
            List<Contactos> lista = new List<Contactos>();
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("sp_ConsultarContactoPorCorreo", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@CORREO", SqlDbType.VarChar, 150).Value = correo;
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            lista.Add(new Contactos
                            {
                                ID_CONTACTO = Convert.ToInt32(lector["ID_CONTACTO"]),
                                NOMBRE = Convert.ToString(lector["NOMBRE"]),
                                APELLIDO = Convert.ToString(lector["APELLIDO"]),
                                TELEFONO = lector["TELEFONO"] == DBNull.Value
                                                                ? null
                                                                : Convert.ToString(lector["TELEFONO"]),
                                CORREO = lector["CORREO"] == DBNull.Value
                                                            ? null
                                                            : Convert.ToString(lector["CORREO"]),
                                FECHA_ADICION = Convert.ToDateTime(lector["FECHA_ADICION"]),
                                ADICIONADO_POR = Convert.ToString(lector["ADICIONADO_POR"]),
                                FECHA_MODIFICACION = lector["FECHA_MODIFICACION"] == DBNull.Value
                                                                                    ? (DateTime?)null
                                                                                    : Convert.ToDateTime(lector["FECHA_MODIFICACION"]),
                                MODIFICADO_POR = lector["MODIFICADO_POR"] == DBNull.Value
                                                                            ? null
                                                                            : Convert.ToString(lector["MODIFICADO_POR"])
                            });
                        }
                    }
                }
            }

            return lista;
        }

        public bool Actualizar(Contactos contacto)
        {
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("sp_ActualizarContacto",
                           conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@ID_CONTACTO", SqlDbType.Int).Value = contacto.ID_CONTACTO;
                    comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 100).Value = contacto.NOMBRE;
                    comando.Parameters.Add("@APELLIDO", SqlDbType.VarChar, 100).Value = contacto.APELLIDO;
                    comando.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 30).Value = string.IsNullOrWhiteSpace(
                                                                                        contacto.TELEFONO)
                                                                                        ? (object)DBNull.Value
                                                                                        : contacto.TELEFONO;
                    comando.Parameters.Add("@CORREO", SqlDbType.VarChar, 150).Value = string.IsNullOrWhiteSpace(
                                                                                        contacto.CORREO)
                                                                                        ? (object)DBNull.Value
                                                                                        : contacto.CORREO;
                    comando.Parameters.Add("@MODIFICADO_POR", SqlDbType.VarChar, 50).Value = contacto.MODIFICADO_POR;
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        public bool Eliminar(int idContacto)
        {
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                using (SqlCommand comando = new SqlCommand("sp_EliminarContacto", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@ID_CONTACTO", SqlDbType.Int).Value = idContacto;
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }
    }
}