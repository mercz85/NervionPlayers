﻿using DALClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraDueloDAL
    {
        private Connection con;

        public ManejadoraDueloDAL()
        {
            con = new Connection("AlumnoNervion", ".N3tApe$7aH");
        }

        /// <summary>
        /// Busca en la base de datos y devuelve un Duelo con el id recibido
        /// </summary>
        /// <param name="id">Recibe la id del Duelo a buscar</param>
        /// <returns>retorna el Duelo</returns>
        public Duelo obtenerDuelo(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            Duelo oduelo = new Duelo();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.Duelos_DB.DUELOS_DB_TABLE_NAME, ContratoDB.Duelos_DB.DUELOS_DB_ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        oduelo.Id = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID];
                        oduelo.Id_Deporte = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_DEPORTE];
                        oduelo.Id_Local = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_LOCAL];
                        oduelo.Id_Visitante = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_ID_VISITANTE];
                        oduelo.Resultado_Local = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_RESULTADO_LOCAL];
                        oduelo.Resultado_Visitante = (int)lector[ContratoDB.Duelos_DB.DUELOS_DB_RESULTADO_VISITANTE];
                        oduelo.Lugar = (String)lector[ContratoDB.Duelos_DB.DUELOS_DB_LUGAR];
                        oduelo.Foto = (Byte[])lector[ContratoDB.Duelos_DB.DUELOS_DB_FOTO];
                        oduelo.Notas = (String)lector[ContratoDB.Duelos_DB.DUELOS_DB_NOTAS];
                        oduelo.Fecha_Duelo = (DateTime)lector[ContratoDB.Duelos_DB.DUELOS_DB_FECHA_DUELO];
                        oduelo.Fecha_Creacion = (DateTime)lector[ContratoDB.Duelos_DB.DUELOS_DB_FECHA_CREACION];

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

            return oduelo;
        }

        /// <summary>
        /// Añade un nuevo Duelo en la base de datos
        /// </summary>
        /// <param name="duelo">Recibe un  tipo Duelo</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarDuelo(Duelo duelo)
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
        /// Funcion que borra un Duelo de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del Duelo a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarDuelo(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.Duelos_DB.DUELOS_DB_TABLE_NAME, ContratoDB.Duelos_DB.DUELOS_DB_ID, id);
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
