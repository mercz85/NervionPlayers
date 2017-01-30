﻿using DALClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraAlumnoDAL
    {

        private Connection con;

        public ManejadoraAlumnoDAL()
        {
            con = new Connection("AlumnoNervion", ".N3tApe$7aH");
        }

        /// <summary>
        /// Busca en la base de datos y devuelve un Alumno con el id recibido
        /// </summary>
        /// <param name="id">Recibe la id del alumno a buscar</param>
        /// <returns>retorna el Alumno</returns>
        public Alumno obtenerAlumno(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Alumno oAlumno = new Alumno();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Alumno_DB.ALUMNO_DB_TABLE_NAME, ContratoDB.Alumno_DB.ALUMNO_DB_ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        oAlumno.Id = (int)lector[ContratoDB.Alumno_DB.ALUMNO_DB_ID];
                        oAlumno.Nombre = (string)lector[ContratoDB.Alumno_DB.ALUMNO_DB_NOMBRE];
                        oAlumno.Apellidos = (string)lector[ContratoDB.Alumno_DB.ALUMNO_DB_APELLIDOS];
                        oAlumno.Alias = (string)lector[ContratoDB.Alumno_DB.ALUMNO_DB_ALIAS];
                        oAlumno.Correo = (string)lector[ContratoDB.Alumno_DB.ALUMNO_DB_CORREO];
                        oAlumno.Curso = (Byte)lector[ContratoDB.Alumno_DB.ALUMNO_DB_CURSO];
                        oAlumno.Contraseña = (String)lector[ContratoDB.Alumno_DB.ALUMNO_DB_CONTRASEÑA];
                        oAlumno.Foto = (Byte[])lector[ContratoDB.Alumno_DB.ALUMNO_DB_FOTO];
                        oAlumno.Confirmado = (bool)lector[ContratoDB.Alumno_DB.ALUMNO_DB_CONFIRMADO];
                        oAlumno.Letra = (String)lector[ContratoDB.Alumno_DB.ALUMNO_DB_LETRA];
                        oAlumno.Observaciones = (String)lector[ContratoDB.Alumno_DB.ALUMNO_DB_OBSERVACIONES];

                    }
                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return oAlumno;
        }

        /// <summary>
        /// Añade un nuevo Alumno en la base de datos
        /// </summary>
        /// <param name="alumno">Recibe un  tipo Alumno</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarAlumno(Alumno alumno)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("");//Preguntar a javi que se inserta y que no
                miComando.Connection = conexion;

                filasAfectadas = miComando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return filasAfectadas;
        }

        /// <summary>
        /// Funcion que borra un Alumno de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del Alumno a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarAlumno(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.Alumno_DB.ALUMNO_DB_TABLE_NAME, ContratoDB.Alumno_DB.ALUMNO_DB_ID, id);
                miComando.Connection = conexion;

                filasafectadas = miComando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }

            return filasafectadas;
        }
    }
}
