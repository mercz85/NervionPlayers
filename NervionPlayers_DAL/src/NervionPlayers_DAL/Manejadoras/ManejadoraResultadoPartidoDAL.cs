﻿//TODO Actualizar
using DALClassLibrary;
using NervionPlayers_Ent.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NervionPlayers_DAL.Manejadoras
{
    public class ManejadoraResultadoPartidoDAL
    {
        private Connection con;

        public ManejadoraResultadoPartidoDAL()
        {
            con = new Connection("ProfesorNervion", "1iNu#L0par7€T0");
        }

        /// <summary>
        /// Busca en la base de datos y devuelve un ResultadoPartido con el id recibido
        /// </summary>
        /// <param name="id">Recibe la id del ResultadoPartido a buscar</param>
        /// <returns>retorna el ResultadoPartido</returns>
        public ResultadoPartido obtenerResultadoPartido(int id)
        {
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();
            ResultadoPartido oResultadoPartido = new ResultadoPartido();
            SqlDataReader lector;

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Select * From {0} Where {1} = {2}", ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_TABLE_NAME, ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_ID, id);
                miComando.Connection = conexion;
                lector = miComando.ExecuteReader();

                if (lector.HasRows)
                {
                    if (lector.Read())
                    {
                        oResultadoPartido.Id = Convert.ToInt32(lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_ID]);
                        oResultadoPartido.Id_Equipo = Convert.ToInt32(lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_ID_EQUIPO]);
                        oResultadoPartido.Ganados = Convert.ToInt32(lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_GANADOS]);
                        oResultadoPartido.Empatados = Convert.ToInt32(lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_EMPATADOS]);
                        oResultadoPartido.Perdidos = Convert.ToInt32(lector[ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_PERDIDOS]);
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

            return oResultadoPartido;
        }

        //TODO hacer

        /// <summary>
        /// Añade un nuevo resultadoPartido en la base de datos
        /// </summary>
        /// <param name="ResultadoPartido">Recibe un  tipo ResultadoPartido</param>
        /// <returns>retorna el numero de filas afectadas , int</returns>
        public int insertarResultadoPartido(ResultadoPartido resultadoPartido)
        {
            int filasAfectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("");
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
        /// Funcion que borra un ResultadoPartido de la base de datos 
        /// </summary>
        /// <param name="id">Recibe el id del ResultadoPartido a borrar</param>
        /// <returns>int , retorna el numero de filas afectadas</returns>
        public int borrarResultadoPartido(int id)
        {
            int filasafectadas = 0;
            SqlConnection conexion;
            SqlCommand miComando = new SqlCommand();

            try
            {
                conexion = con.openConnection();
                miComando.CommandText = String.Format("Delete from {0} where {1} = {2}", ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_TABLE_NAME, ContratoDB.ResultadosPartidos_DB.RESULTADOSPARTIDOS_DB_ID, id);
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
